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
	public UIWidget tintableWidget;

	[SerializeField]
	public UILabel levelLabel;

	[SerializeField]
	public Color buildingColor;
	
    [SerializeField]
    UILabel levelExpLabel;

	// Use this for initialization
	void Start () {
		// TODO update here

        levelExpLabel.gameObject.SetActive(Game.Instance.isDebug());
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

		levelLabel.text = string.Format("{0}", building.currentLevel);

        // TODO comment in prod, or research defines in c#
        if (Game.Instance.isDebug())
        {
            BuildingLevel buildingLevel = building.getCurrentBuildingLevel();
            levelExpLabel.text = buildingLevel.currentExp.ToString() + " / " + buildingLevel.maxExp.ToString();
        }
	}

	void onBuildingLevelup()
	{
		clearAndAddCurrentTasks ();
		//audio.pitch = Random.Range(0.9f, 1.1f);
		audio.Play();
	}

	public void clearAndAddCurrentTasks()
	{
		while (tasksGrid.transform.childCount > 0) {
			NGUITools.Destroy (tasksGrid.transform.GetChild (0).gameObject);
		}

		foreach (Task task in building.getCurrentBuildingLevel().tasks) {
			/*GameObject taskObject = */createTask(this, task);

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

		tintableWidget.color = buildingColor;
		//taskContainer.tintableWidget.color = buildingColor;

        UIButton button = taskContainer.GetComponentInChildren<UIButton>();
        button.pressed = Lighten(buildingColor, 0.15f);
        button.hover = Lighten(buildingColor, -0.1f);
        button.defaultColor = buildingColor;

		return taskObject;
	}

    public static Color Lighten(Color inColor, float inAmount)
    {
        return new Color(
            Mathf.Min(1f, inColor.r + 1f * inAmount),
            Mathf.Min(1f, inColor.g + 1f * inAmount),
            Mathf.Min(1f, inColor.b + 1f * inAmount),
            inColor.a);
    }
    

}
