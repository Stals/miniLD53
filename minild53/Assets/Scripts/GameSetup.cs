using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	[SerializeField]
	BuildingContainer scienceContainer; 

	[SerializeField]
	BuildingContainer homeContainer;

	[SerializeField]
	BuildingContainer criminalContainer;

	[SerializeField]
	BuildingContainer wackdonaldsContainer;
	

	

	// Use this for initialization
	void Start () {
		Game.Instance.init ();

		setupBuilding (scienceContainer, Game.Instance.getBuildingByType (BuildingType.Science));
		setupBuilding (homeContainer, Game.Instance.getBuildingByType (BuildingType.Home));
		setupBuilding (criminalContainer, Game.Instance.getBuildingByType (BuildingType.Criminal));
		setupBuilding (wackdonaldsContainer, Game.Instance.getBuildingByType (BuildingType.Wackdonalds));
	}

	void setupBuilding(BuildingContainer container, Building building)
	{
		container.setBuilding (building);
		container.clearAndAddCurrentTasks ();
	}

}
