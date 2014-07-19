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
			List<TaskEffect> changedEffects = effects.GetRange (0, effects.Count);
			foreach (TaskEffect effect in changedEffects) {
				// TODO round?
				effect.amount *= (int)(buildingLevel * E_CONST);
			}

			return changedEffects;

		} else {
			return effects;
		}
	}

}
