using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Requirement {
	public Requirement()
	{
	}

	public BuildingType type;
	public int level;
}

public enum TaskEffectType{
	EnergyChange,
	MoneyChange,
	BuildingExpChange,
	UnknownChange
};

public class TaskEffect{
	public TaskEffect()
	{
	}

	public TaskEffectType type;
	public int amount;

	public TaskEffectType stringToType(string str)
	{
		if(str == "Energy"){
			return TaskEffectType.EnergyChange;
		}
		if(str == "Money"){
			return TaskEffectType.MoneyChange;
		}
		if(str == "Exp"){
			return TaskEffectType.BuildingExpChange;
		}

		return TaskEffectType.UnknownChange;
	}
};

// TODO при парсе сразу раскрываем сложности - но не преобразовываем по уровню?
// мы у эффекта спрашиваем отдавая ему уровнь наверное
public class Task {
	public Task()
	{
	}

	public string name { get; set; }

	public List<Requirement> requirements;
	public List<TaskEffect> complitionEffects;
}
