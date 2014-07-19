using UnityEngine;
using System.Collections;

public class TaskContainer : MonoBehaviour {

	UISlider slider;
	// Use this for initialization
	void Start () {
		slider = GetComponent<UISlider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void increaseValue()
	{
		slider.value = slider.value + 0.1f;
		if(slider.value >= 1){
			slider.value -= 1;
		}
		Game.Instance.getPlayer ().money += 50;
		Game.Instance.getPlayer ().age.addWeek ();

	}
}
