using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartClick : MonoBehaviour {
	Color ch;

	[System.NonSerialized] UIButton m;

	UIButtonColor bc;
	TweenColor tw;

	//왼손손가락 개수.
	private UnityHand u_hand;
	int sum;


	// Use this for initialization
	void Start () {		
	
		u_hand = (GameObject.Find ("left") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;

	}
	
	// Update is called once per frame
	void Update () {
		if (u_hand.handFound) {

			sum = u_hand.hand.Fingers.Count;
			Debug.Log("sum  : "+sum);

		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (sum == 1)
			Application.LoadLevel ("Scene1");
	}

	void OnTriggerExit(Collider collider)
	{
		ch = gameObject.GetComponent<UISprite> ().color = Color.white;

	}

	void OnTriggerStay(Collider collider)
	{
		
		if (collider.gameObject.name == "leftHand") 
		{
			Debug.Log ("trigger");
			ch = gameObject.GetComponent<UISprite> ().color = Color.blue;
		} 
	}


}
