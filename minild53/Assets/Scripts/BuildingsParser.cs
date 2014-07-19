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

	public static List<TaskEffect> getFakeEffects()
	{
		List<TaskEffect> effects = new List<TaskEffect>();
		{
			TaskEffect effect = new TaskEffect ();
			effect.type = TaskEffectType.BuildingExpChange;
			effect.amount = 50;

			effects.Add(effect);
		}

		{
			TaskEffect effect = new TaskEffect ();
			effect.type = TaskEffectType.EnergyChange;
			effect.amount = -5;
			
			effects.Add(effect);
		}

		{
			TaskEffect effect = new TaskEffect ();
			effect.type = TaskEffectType.MoneyChange;
			effect.amount = 10;
			
			effects.Add(effect);
		}

		return effects;
	}

	public static List<Difficulty> getDifficultiesFromXML(XmlNode node)
	{
		List<Difficulty> difficulties = new List<Difficulty>();

		XmlNodeList list = node.ChildNodes;
		foreach (XmlNode diffNode in list) {
			Difficulty difficulty = new Difficulty ();
			difficulty.name = diffNode.Attributes["Name"].Value;
			difficulty.effects = getFakeEffects ();

			difficulties.Add (difficulty);
		}
		return difficulties;
	}


	public static List<Task> getFakeTasks(Building building)
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

	public static List<Building> getBuildingsFromXML()
	{
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.Load("Assets/data/buildings.xml"); // load the file.
		XmlNode diffNode = xmlDoc.GetElementsByTagName("Difficulties")[0];

		//XmlNodeList levelsList = xmlDoc.GetElementsByTagName("Difficulties")[0];


		difficulties = getDifficultiesFromXML (diffNode);

		List<Building> buildings = new List<Building>();

		{
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
		}

		return buildings;
	}
}
