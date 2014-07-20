using UnityEngine;
using System.Collections;

public class BankContainer : MonoBehaviour {

	[SerializeField]
	UISlider depositSlider;

	[SerializeField]
	UILabel currentMoneyLabel;


	bool isDepositing = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (!isDepositing)
			return;

		if (Game.Instance.getPlayer ().money > 0) {
			Game.Instance.getBank ().addMoney(1);
			Game.Instance.getPlayer ().money -= 1;
		}

		depositSlider.value = (float)Game.Instance.getBank ().money / Game.Instance.getBank ().maxMoney;


		currentMoneyLabel.text = Game.Instance.getBank ().money + " $";
	}

	public void startDeposit()
	{
		isDepositing = true;
	}

	public void endDeposit()
	{
		isDepositing = false;
	}
}
