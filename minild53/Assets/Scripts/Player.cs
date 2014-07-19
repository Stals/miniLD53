using UnityEngine;
using System.Collections;

public class Player {
	public Player (int _energy, int _money)
	{
		energy = _energy;
		money = _money;
	}

	public int energy { get; set; }
	public int money { get; set; }

}
