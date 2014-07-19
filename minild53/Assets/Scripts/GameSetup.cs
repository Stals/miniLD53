using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	[SerializeField]
	BuildingContainer scienceContainer; 

	[SerializeField]
	GameObject taskPrefab;
	

	// Use this for initialization
	void Start () {
		Game.Instance.init ();

		setupBuilding (scienceContainer, Game.Instance.getBuildingByType (BuildingType.Science));
	}

	void setupBuilding(BuildingContainer container, Building building)
	{
		container.building = building;

		foreach (Task task in building.levels[building.currentLevel-1].tasks) {
		
			GameObject taskObject = createTask(container, task);



			// TODo - subscribe to add exp
		}

		container.tasksGrid.Reposition();
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
