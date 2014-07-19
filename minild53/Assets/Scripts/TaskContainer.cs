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
		slider.value = slider.value + 0.1f;
		if(slider.value >= 1){
			slider.value -= 1;
		}
		Game.Instance.getPlayer ().money += 50;
		Game.Instance.getPlayer ().age.addWeek ();
		Game.Instance.getPlayer ().changeEnergy (-5);

	}
}
