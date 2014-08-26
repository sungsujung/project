using UnityEngine;
using System.Collections;

public class LevelNum : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//UILabel text 변경.
		transform.gameObject.GetComponent<UILabel> ().text = Application.loadedLevel + 1 + "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
