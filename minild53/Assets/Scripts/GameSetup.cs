﻿using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Game.Instance.init ();
	}
}