using UnityEngine;
using System.Collections;

public class Age{
	public Age(int _years, int _months, int _weeks)
	{
		years = _years;
		months = _months;
		weeks = _weeks;
	}

	public int years{ get; set; }
	public int months{ get; set; }
	public int weeks{ get; set; }

	public void addWeek()
	{
		weeks += 1;

		if (weeks > 4) {
			weeks = 1;
			months += 1;
		}

		if (months > 12) {
			months = 1;
			years += 1;
		}
	}

	public string asString()
	{
		return string.Format ("{0}y {1}m {2}w", years, months, weeks);
	}
}

public class Player {
	public Player (int _energy, int _money)
	{
		energy = _energy;
		maxEnergy = energy;
		money = _money;

		age = new Age (20, 1, 1);
	}

	public int energy { get; set; }
	public int maxEnergy{ get; set; }
	public int money { get; set; }

	public Age age;
}
