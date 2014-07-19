using UnityEngine;
using System.Collections;

// TODO этот же класс добавляет prefab что дается для отображения
public class TaskContainer : MonoBehaviour {

	[SerializeField]
	GameObject EffectPrefab;
	
	[SerializeField]
	UILabel taskNameLabel;

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
	}

	public void increaseValue()
	{
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
		//if (full && (effect.type == TaskEffectType.BuildingExpChange)) {
			// то увеличиваем опыт
			// и обновляем его бар
			//return;
		//}

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
