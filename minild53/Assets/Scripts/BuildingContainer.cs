﻿using UnityEngine;
using System.Collections;

public class BuildingContainer : MonoBehaviour {

	public Building building;

	[SerializeField]
	public UIGrid tasksGrid;

	[SerializeField]
	GameObject taskPrefab;

	[SerializeField]
	public UISlider progressSlider;

	[SerializeField]
	public UILabel levelLabel;
	

	// Use this for initialization
	void Start () {
		// TODO update here
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setBuilding(Building _building)
	{
		building = _building;
		building.onCompleted += onBuildingLevelup;
	}

	void OnGUI()
	{
		float targetValue = building.getCurrentBuildingLevel ().getCurrentExpFactor ();
		progressSlider.value = Mathf.Lerp(progressSlider.value, targetValue, Time.deltaTime * 5f);

		levelLabel.text = "level " + building.currentLevel;
	}

	void onBuildingLevelup()
	{
		clearAndAddCurrentTasks ();
	}

	public void clearAndAddCurrentTasks()
	{
		while (tasksGrid.transform.childCount > 0) {
			NGUITools.Destroy (tasksGrid.transform.GetChild (0).gameObject);
		}

		foreach (Task task in building.getCurrentBuildingLevel().tasks) {
			GameObject taskObject = createTask(this, task);

			// TODo - subscribe to add exp
		}
		
		tasksGrid.Reposition();
	}

	
	GameObject createTask(BuildingContainer container,Task task)
	{
		// create task from prefab
		GameObject taskObject;
		taskObject = NGUITools.AddChild(container.tasksGrid.gameObject, taskPrefab);
		taskObject.GetComponent<UISprite>().name = "task";
		//UIEventListener.Get(bulbObject).onClick += onBulbClick;
		
		TaskContainer taskContainer = taskObject.GetComponent<TaskContainer> ();
		taskContainer.task = task;
		taskContainer.updateData ();
		
		return taskObject;
	}
}
