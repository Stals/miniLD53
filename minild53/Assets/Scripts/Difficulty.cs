﻿using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Difficulty {
	public Difficulty(){}

	public string name { get; set; }
	public List<TaskEffect> effects;

	// 
	public List<TaskEffect> getEffectsForLevel(int buildingLevel)
	{
		return effects;
	}

}
