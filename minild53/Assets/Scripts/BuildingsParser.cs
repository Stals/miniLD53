using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
			effect.amount = 85;
			
			effects.Add(effect);
		}

		return effects;
	}

	public static List<Difficulty> getDifficultiesFromXML(/* difficulties node */)
	{
		List<Difficulty> difficulties = new List<Difficulty>();

		Difficulty difficulty = new Difficulty ();
		difficulty.name = "Easy";
		difficulty.effects = getFakeEffects ();

		difficulties.Add (difficulty);

		return difficulties;
	}


	public static List<Task> getFakeTasks()
	{
		List<Task> tasks = new List<Task> ();

		{
			Task task = new Task ();
			task.name = "research";
			//task.requirements
			task.complitionEffects = getDifficultyByName ("Easy").getEffectsForLevel (1);
		}

		return tasks;
	}

	public static List<Building> getBuildingsFromXML()
	{
		difficulties = getDifficultiesFromXML (/* difficulties node */);

		List<Building> buildings = new List<Building>();

		Building building = new Building (BuildingType.Science);
		building.levels = new List<BuildingLevel> ();

		{
			BuildingLevel level = new BuildingLevel (100);
			level.tasks = getFakeTasks ();
			building.levels.Add (level);
		}
		{
			BuildingLevel level = new BuildingLevel (200);
			level.tasks = getFakeTasks ();
			building.levels.Add (level);
		}

		return buildings;
	}
}
