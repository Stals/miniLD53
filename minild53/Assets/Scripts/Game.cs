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
	//Bank bank;

	List<Building> buildings;

	public void init()
	{
		player = new Player(100, 0, 100000);
		//bank = new Bank (100000);

		buildings = BuildingsParser.getBuildings ();
	}
	
	public Player getPlayer(){
		return player;
	}

	//public Bank getBank()
	///{
	//	return bank;
	//}

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
