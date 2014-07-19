using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuildingType{
	Wackdonalds,
	Science,
	Criminal,
	Home
};

// TODO get icon for building type

public class BuildingLevel{
	public BuildingLevel(int _maxExp)
	{
		currentExp = 0;
		maxExp = _maxExp;
	}

	public int currentExp;
	public int maxExp;

	public void addExp(int exp)
	{
		currentExp += exp;
		// TODO add leveluping
		// send event?
	}

	public float getCurrentExpFactor()
	{	
		return (float)currentExp / maxExp;
	}

	public List<Task> tasks;
}

public class Building {
	public Building(BuildingType _type)
	{
		currentLevel = 1;
		type = _type;

	}

	public int currentLevel { get; set; }
	
	public List<BuildingLevel> levels;
	public BuildingType type;

	public BuildingLevel getCurrentBuildingLevel()
	{
		return levels [currentLevel - 1];
	}
}
