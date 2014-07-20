using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuildingType{
	Wackdonalds,
	Science,
	Criminal,
	Home,
	Unknown
};

// TODO get icon for building type

public class BuildingLevel{
	public delegate void OnLevelCompleted();
	public OnLevelCompleted onCompleted;

	public BuildingLevel(int _maxExp)
	{
		currentExp = 0;
		maxExp = _maxExp;
		addEnergy = 0;
	}

	public int currentExp;
	public int maxExp;

	// amount that is added to player energy on levelup
	public int addEnergy;

	public void addExp(int exp)
	{
		if (maxExp == -1) {
			return;
		}

		currentExp += exp;
		// TODO add leveluping
		// send event?

		if (currentExp >= maxExp) {
			Game.Instance.getPlayer().maxEnergy += addEnergy;

			if (onCompleted != null){
				onCompleted ();
			}
		}
	}

	public float getCurrentExpFactor()
	{	
		if (maxExp == -1) {
			return 1;
		}
		return (float)currentExp / maxExp;
	}

	public List<Task> tasks;
}

public class Building {
	public delegate void OnLevelCompleted();
	public OnLevelCompleted onCompleted;

	public Building(BuildingType _type)
	{
		currentLevel = 1;
		type = _type;

		levels = new List<BuildingLevel> ();

	}

	public int currentLevel { get; set; }
	
	public List<BuildingLevel> levels;
	public BuildingType type;

	public BuildingLevel getCurrentBuildingLevel()
	{
		return levels [currentLevel - 1];
	}

	public void addLevel(BuildingLevel level)
	{
		levels.Add (level);

		level.onCompleted += onCurrentLevelCompleted;
	}

	void onCurrentLevelCompleted()
	{
		currentLevel += 1;
		if(onCompleted != null) onCompleted();
	}

	public static BuildingType typeFromString(string str)
	{
		if (str == "Wackdonalds") {
			return BuildingType.Wackdonalds;
		}
		if (str == "Science") {
			return BuildingType.Science;
		}
		if (str == "Criminal"){
			return BuildingType.Criminal;
		}
		if (str == "Home"){
			return BuildingType.Home;
		}
		return BuildingType.Unknown;
	}
}
