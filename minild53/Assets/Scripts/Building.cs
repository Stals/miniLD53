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
	List<Task> tasks;
}

public class Building {
	List<BuildingLevel> levels;
	BuildingType type;

	// Use this for initialization
	void Start () {
	
	}
}
