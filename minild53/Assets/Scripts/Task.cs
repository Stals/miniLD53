using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Requirement {
	BuildingType type;
	int level;
}


public enum TaskEffectType{
	EnergyChange,
	MoneyChange,
	BuildingExpChange
};

public class TaskEffect{
	TaskEffectType type;
	int amount;
};

public class Task {
	string name;

	List<Requirement> requirements;
	List<TaskEffect> complitionEffects;
}
