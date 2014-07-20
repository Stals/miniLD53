using UnityEngine;
using System.Collections;

public class BankContainer : MonoBehaviour {

	[SerializeField]
	UISlider depositSlider;

	bool isDepositing;

	// Use this for initialization
	void Start () {
		isDepositing = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (isDepositing) {
			depositSlider.value = depositSlider.value + 0.001f;
		}
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
