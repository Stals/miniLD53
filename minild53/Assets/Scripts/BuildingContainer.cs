using UnityEngine;
using System.Collections;

public class BuildingContainer : MonoBehaviour {

	public Building building;

	[SerializeField]
	public UIGrid tasksGrid;

	[SerializeField]
	public UISlider progressSlider;

	// Use this for initialization
	void Start () {
		// TODO update here
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		progressSlider.value = building.getCurrentBuildingLevel ().getCurrentExpFactor ();
	}
}
