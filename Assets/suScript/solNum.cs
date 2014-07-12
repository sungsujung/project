using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class solNum : MonoBehaviour {

	private UILabel l_count;
	// Use this for initialization
	void Start () {
		l_count = (GameObject.Find("level_num") as GameObject).GetComponent(typeof (UILabel))as UILabel;

	}
	
	// Update is called once per frame
	void Update () {
		l_count.text = Application.loadedLevel + "";

	}
}
