﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BuildingType{
	Wackdonalds,
	Science,
	Criminal,
	Home
};

public class BuildingLevel{
	List<Task> tasks;
}

public class Building {
	public int currentLevel { get; set; }

	public List<BuildingLevel> levels;
	public BuildingType type;
}
