using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
//http://unitynoobs.blogspot.ru/2011/02/xml-loading-data-from-xml-file.html

public class BuildingsParser {
	static List<Difficulty> difficulties;

	static public Difficulty getDifficultyByName(string difficultyName)
	{
		foreach (Difficulty difficulty in difficulties) {
			if(difficulty.name == difficultyName){
				return difficulty;
			}
		}
		return null;
	}

	private static List<TaskEffect> getEffects(XmlNodeList effectsNode)
	{
		List<TaskEffect> effects = new List<TaskEffect>();
		foreach (XmlNode effectNode in effectsNode) {
			TaskEffect effect = new TaskEffect ();
			effect.type = TaskEffect.stringToType(effectNode.Attributes["Type"].Value);
			effect.amount = int.Parse(effectNode.Attributes["Amount"].Value);
			
			effects.Add(effect);
		
		}

		return effects;
	}
	

	private static List<Difficulty> getDifficultiesFromXML(XmlNode node)
	{
		List<Difficulty> difficulties = new List<Difficulty>();

		XmlNodeList list = node.ChildNodes;
		foreach (XmlNode diffNode in list) {
			Difficulty difficulty = new Difficulty ();
			difficulty.name = diffNode.Attributes["Name"].Value;
			difficulty.effects = getEffects (diffNode.ChildNodes);

			difficulties.Add (difficulty);
		}
		return difficulties;
	}


	private static List<Task> getFakeTasks(Building building)
	{
		List<Task> tasks = new List<Task> ();

		{
			Task task = new Task (building);
			task.name = "research";
			//task.requirements
			task.complitionEffects = getDifficultyByName ("Easy").getEffectsForLevel (1);
			tasks.Add(task);
		}

		{
			Task task = new Task (building);
			task.name = "discover";
			//task.requirements
			task.complitionEffects = getDifficultyByName ("Easy").getEffectsForLevel (1);
			tasks.Add(task);
		}

		return tasks;
	}

	private static List<Building> getBuildingsFromXML(XmlNode buildingsNode)
	{
		List<Building> buildings = new List<Building> ();

		XmlNodeList list = buildingsNode.ChildNodes;
		foreach (XmlNode buildingNode in list) {

			Building building = new Building (Building.typeFromString(buildingNode.Attributes["Type"].Value));
			building.levels = new List<BuildingLevel> ();

			int levelCount = 1;
			foreach(XmlNode buildingLevelNode in buildingNode.ChildNodes){
				BuildingLevel level = parseLevel(buildingLevelNode, building, levelCount);
				building.addLevel(level);
				++levelCount;
			}
			buildings.Add(building);
		}
		return buildings;
	}

	private static BuildingLevel parseLevel(XmlNode node, Building building, int levelNum)
	{
		BuildingLevel level = new BuildingLevel (int.Parse (node.Attributes ["ExpToLevel"].Value));

		level.tasks = new List<Task> ();

		XmlNodeList tasksList = node.ChildNodes [0].ChildNodes;
		foreach (XmlNode taskNode in tasksList) {
			Task task = parseTask (taskNode, building, levelNum);
			level.tasks.Add (task);
		}
		return level;
	}

	private static Task parseTask(XmlNode node, Building building, int levelNum)
	{
		Task task = new Task (building);
		task.name = node.Attributes ["Name"].Value;
		//task.requirements

		// TODO parse requirenments
		// TODO pass different levels

		string diffuculty = node.LastChild.Attributes ["difficulty"].Value;
		task.complitionEffects = getDifficultyByName (diffuculty).getEffectsForLevel (levelNum);

		return task;
	}

		/*

			<Task Name="do research" >
				<Requirements>
				<Requirement Type="Science" Level="2" />
				<Requirement Type="Criminal" Level="2" />
				</Requirements>
				<Effects difficulty="Easy" />
				
				return null;
				*/

	
	public static List<Building> getBuildings()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.Load("Assets/data/buildings.xml"); // load the file.
		XmlNode diffNode = xmlDoc.GetElementsByTagName("Difficulties")[0];
		difficulties = getDifficultiesFromXML (xmlDoc.GetElementsByTagName("Difficulties")[0]);

		List<Building> buildings = getBuildingsFromXML (xmlDoc.GetElementsByTagName ("Buildings") [0]);
		
			/*{
			Building building = new Building (BuildingType.Science);
			building.levels = new List<BuildingLevel> ();

			{
				BuildingLevel level = new BuildingLevel (100);
				level.tasks = getFakeTasks (building);
				building.addLevel(level);
			}
			{
				BuildingLevel level = new BuildingLevel (200);
				level.tasks = getFakeTasks (building);
				building.addLevel(level);
			}

			buildings.Add(building);
		}

		{
			Building building = new Building (BuildingType.Wackdonalds);
			building.levels = new List<BuildingLevel> ();
			
			{
				BuildingLevel level = new BuildingLevel (100);
				level.tasks = getFakeTasks (building);
				building.levels.Add (level);
			}
			{
				BuildingLevel level = new BuildingLevel (200);
				level.tasks = getFakeTasks (building);
				building.levels.Add (level);
			}

			buildings.Add(building);
		}*/

		return buildings;
	}
}
