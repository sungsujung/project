using UnityEngine;
using System.Collections;

public class StartClick : MonoBehaviour {
	GameObject ch;

	[System.NonSerialized] UIButton m;

	UIButtonColor bc;



	// Use this for initialization
	void Start () {
//		ch = gameObject.GetComponent<UIButton> ().onClick;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.name == "leftHand") {
			Debug.Log("trigger");
			//bc.SetState(UIButtonColor.State.Hover,false);
		//	m.SetState(UIButtonColor.State.Hover,true);



		}

	}

}
