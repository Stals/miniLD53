using UnityEngine;
using System.Collections;

public class GuiUpdater : MonoBehaviour {

	[SerializeField]
	UILabel moneyLabel;

	[SerializeField]
	UILabel ageLabel;

	[SerializeField]
	UISlider energyBar;

	Player player;

	void Start()
	{
		player = Game.Instance.getPlayer ();
	}

	void OnGUI()
	{
		moneyLabel.text = moneyToString (Game.Instance.getPlayer ().money);

		ageLabel.text = "Age: " + Game.Instance.getPlayer().age.asString ();
	}

	string moneyToString(int money)
	{
		return string.Format("Money: {0}$", money);
	}
}
