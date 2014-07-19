using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	[SerializeField]
	BuildingContainer scienceContainer; 


	

	// Use this for initialization
	void Start () {
		Game.Instance.init ();

		setupBuilding (scienceContainer, Game.Instance.getBuildingByType (BuildingType.Science));
	}

	void setupBuilding(BuildingContainer container, Building building)
	{
		container.setBuilding (building);
		container.clearAndAddCurrentTasks ();
	
	}

}
