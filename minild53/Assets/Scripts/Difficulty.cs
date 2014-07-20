using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class Difficulty {
	public Difficulty(){}

	public string name { get; set; }
	public List<TaskEffect> effects;

	private const float E_CONST = 2.7182f;

	// 
	public List<TaskEffect> getEffectsForLevel(int buildingLevel)
	{
		if (buildingLevel > 1) {


			List<TaskEffect> changedEffects = new List<TaskEffect>();

			foreach(TaskEffect effect in effects)
			{
				TaskEffect newEffect = new TaskEffect(effect);
				newEffect.amount = (int)getAmountForLevel(newEffect.amount, buildingLevel);
				changedEffects.Add(newEffect);
			}

			return changedEffects;

		} else {
			return effects;
		}
	}

	private float getAmountForLevel(int amount, int level)
	{
		return amount * level;
		//return amount * (level * E_CONST);
	}

}
