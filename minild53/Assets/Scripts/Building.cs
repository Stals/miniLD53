using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuildingType{
	Wackdonalds,
	Science,
	Criminal,
	Home
};

public class BuildingLevel{
	public BuildingLevel(int _maxExp)
	{
		currentExp = 0;
		maxExp = _maxExp;
	}

	public int currentExp;
	public int maxExp;

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
}
