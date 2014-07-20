using UnityEngine;
using System.Collections;

public class BankContainer : MonoBehaviour {

	[SerializeField]
	UISlider depositSlider;

	[SerializeField]
	UILabel currentMoneyLabel;

	[SerializeField]
	GameObject toStarsButton;
	

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{

		//if (Game.Instance.getPlayer ().money > 0) {
		//	Game.Instance.getBank ().addMoney(1);
		//	Game.Instance.getPlayer ().money -= 1;
		//}

		depositSlider.value = (float)Game.Instance.getPlayer().money / Game.Instance.getPlayer().maxMoney;

		currentMoneyLabel.text = Game.Instance.getPlayer().money + " $";

		if (Game.Instance.getPlayer ().money >= Game.Instance.getPlayer ().maxMoney) {
			toStarsButton.SetActive(true);
		}
	}
}
