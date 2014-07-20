using UnityEngine;
using System.Collections;

public class Bank {
	public Bank(int _maxMoney)
	{
		maxMoney = _maxMoney;
	}

	public int money { set; get; }
	public int maxMoney { set; get; }

	public void addMoney(int m)
	{
		money += m;
	}
}
