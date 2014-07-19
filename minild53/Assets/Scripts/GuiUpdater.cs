using UnityEngine;
using System.Collections;

public class GuiUpdater : MonoBehaviour {

	[SerializeField]
	UILabel moneyLabel;

	[SerializeField]
	UISlider energyBar;

	Player player;

	void onStart()
	{
		player = Game.Instance.getPlayer ();
	}

	void OnGUI()
	{
		moneyLabel.text = moneyToString (Game.Instance.getPlayer ().money);
	}

	string moneyToString(int money)
	{
		return string.Format("Money: {0}$", money);
	}
}
