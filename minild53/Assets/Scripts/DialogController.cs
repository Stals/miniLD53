using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onCloseButtonPress()
	{
		this.gameObject.SetActive (false);
	}

	public void show()
	{
		this.gameObject.SetActive (true);
	}
}
