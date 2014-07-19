using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Singleton
{
	private static Singleton instance;
	
	private Singleton() {}
	
	public static Singleton Instance
	{
		get 
		{
			if (instance == null)
			{
				instance = new Singleton();
			}
			return instance;
		}
	}
}

// TODO static
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


	List<Difficulty> difficulties;
	Player player;
	List<Building> buildings;

	public void init()
	{
		player = new Player(100, 0);
		parseBuildings();
	}

	public Difficulty getDifficultyByName(string difficultyName)
	{
		foreach (Difficulty difficulty in difficulties) {
			if(difficulty.name == difficultyName){
				return difficulty;
			}
		}
		return null;
	}
	
	public Player getPlayer(){
		return player;
	}

	private void parseBuildings()
	{
		// fake
	}
}
