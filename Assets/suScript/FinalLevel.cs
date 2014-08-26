using UnityEngine;
using System.Collections;

public class FinalLevel : MonoBehaviour {
	//몇단계에서 죽었는지 표시해주는 변수.
	string finalLevel ;
	// Use this for initialization
	void Start () {
		//PlayerPrefs를 이용하여 저장된 값을 불러온다.
		finalLevel = PlayerPrefs.GetString ("final level");
		Debug.Log (finalLevel + " : final");
	}
	
	// Update is called once per frame
	void Update () {
		//UILabel의 텍스트를 변경해준다. 
		transform.gameObject.GetComponent<UILabel> ().text = finalLevel;
	}
}
