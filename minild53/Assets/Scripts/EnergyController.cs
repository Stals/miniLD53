using UnityEngine;
using System.Collections;

public class EnergyController : MonoBehaviour {
	UISlider progressBar;

	// Use this for initialization
	void Start () {
		progressBar = GetComponent<UISlider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		float targetValue = Game.Instance.getPlayer ().getCurrentEnergyFactor ();
		progressBar.value = Mathf.Lerp(progressBar.value, targetValue, Time.deltaTime * 5f);
	}
}
