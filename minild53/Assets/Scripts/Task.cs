using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Requirement {
	public Requirement()
	{
	}

	public BuildingType type;
	public int level;

	static public string getIconPath(BuildingType bType)
	{
		switch (bType) {
			case BuildingType.Wackdonalds:
				return "icon_wacdonalds";
			case BuildingType.Science:
				return "icon_science";
			case BuildingType.Criminal:
				return "icon_criminal";
			case BuildingType.Home:
				return "icon_home";

		}
		return "";
	}

	public bool isEnough()
	{
		return level >= Game.Instance.getBuildingByType (type).currentLevel;
	}

}

public enum TaskEffectType{
	EnergyChange,
	MoneyChange,
	BuildingExpChange,
	UnknownChange
};

public class TaskEffect{
	public TaskEffect(TaskEffect other)
	{
		type = other.type;
		amount = other.amount;
	}

	public TaskEffect()
	{
	}

	public TaskEffectType type;
	public int amount;

	static public TaskEffectType stringToType(string str)
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

	public string getAmountString()
	{
		string sign = amount > 0 ? "+" : "";
		return sign + amount;
	}
};

// TODO при парсе сразу раскрываем сложности - но не преобразовываем по уровню?
// мы у эффекта спрашиваем отдавая ему уровнь наверное
public class Task {
	public Task(Building _building)
	{
		building = _building;
	}

	public string name { get; set; }

	public List<Requirement> requirements;
	public List<TaskEffect> complitionEffects;

	public Building building;

	public TaskEffect getEffectByType(TaskEffectType type)
	{
		foreach (TaskEffect effect in complitionEffects) {
			if(effect.type == type){
				return  effect;
			}
		}

		return null;
	}
}
