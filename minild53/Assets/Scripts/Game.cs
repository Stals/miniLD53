using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game  {
	private static Game instance;
	private Game() {}
	public static Game Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new Game();
			}
			return instance;
		}
	}

	Player player;


	List<Building> buildings;

	public void init()
	{
		player = new Player(100, 0);
		buildings = BuildingsParser.getBuildingsFromXML ();
	}
	
	public Player getPlayer(){
		return player;
	}

	private void parseBuildings()
	{
		// fake
	}

	public Building getBuildingByType(BuildingType type)
	{
		foreach (Building building in buildings) {
			if(building.type == type){
				return building;
			}
		}
		return null;
	}
}
