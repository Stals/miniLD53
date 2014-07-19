using UnityEngine;
using System.Collections;

// TODO этот же класс добавляет prefab что дается для отображения
public class TaskContainer : MonoBehaviour {

	[SerializeField]
	GameObject EffectPrefab;
	
	[SerializeField]
	UILabel taskNameLabel;

	[SerializeField]
	GameObject energyEffect;
	[SerializeField]
	GameObject moneyEffect;

	[SerializeField]
	Color aboveZeroColor;
	[SerializeField]
	Color belowZeroColor;

	// TODO use and give stuff from here


	public Task task;

	UISlider slider;
	// Use this for initialization
	void Start () {
		slider = GetComponent<UISlider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updateData()
	{
		taskNameLabel.text = task.name;

		updateEffect (energyEffect, task.getEffectByType (TaskEffectType.EnergyChange));
		updateEffect (moneyEffect, task.getEffectByType (TaskEffectType.MoneyChange));
	}

     public void updateEffect(GameObject effect, TaskEffect taskEffect)
     {
		if(taskEffect == null){
			effect.SetActive(false);
			return;
		}
		UILabel label = effect.GetComponentInChildren<UILabel> ();
		label.text = taskEffect.getAmountString ();
		if (taskEffect.amount < 0) {
			label.color = belowZeroColor;
		} else {
			label.color = aboveZeroColor;
		}
	}

	private bool enoughEnergy()
	{
		TaskEffect effect = task.getEffectByType (TaskEffectType.EnergyChange);

		if(effect != null){
			if(effect.amount < 0){
				return Game.Instance.getPlayer().energy >= effect.amount;
			}
		}

		return true;
	}

	private bool enoughMoney()
	{
		TaskEffect effect = task.getEffectByType (TaskEffectType.MoneyChange);
		
		if(effect != null){
			if(effect.amount < 0){
				return Game.Instance.getPlayer().money >= effect.amount;
			}

		}
		return true;
	}

	public void increaseValue()
	{
		if (!enoughEnergy ()) {
			return;		
		}
		if (!enoughMoney ()) {
			return;
		}

		Game.Instance.getPlayer ().age.addWeek ();


		bool fullyCompleted = false;
		slider.value = slider.value + 0.1f;
		if(slider.value >= 1){
			slider.value -= 1;

			fullyCompleted = true;
		}
		applyTaskEffects (task, fullyCompleted);
	}

	public void applyTaskEffects(Task task, bool full)
	{
		foreach (TaskEffect effect in task.complitionEffects) {
			applyEffect(effect, full);
		}
	}

	public void applyEffect(TaskEffect effect, bool full)
	{
		if (full && (effect.type == TaskEffectType.BuildingExpChange)) {
			task.building.getCurrentBuildingLevel().addExp(effect.amount);
			// TODO и обновляем его бар?
			return;
		}

		switch (effect.type) {
		case TaskEffectType.MoneyChange:
			Game.Instance.getPlayer ().money += effect.amount;
			break;

		case TaskEffectType.EnergyChange:
			Game.Instance.getPlayer ().changeEnergy (effect.amount);
			break;
		}
	}
}
