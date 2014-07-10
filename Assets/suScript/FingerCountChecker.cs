using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FingerCountChecker : MonoBehaviour
{
		//LeapManager
		private LeapManager _leapManager;
		// 텍스쳐매쉬 변수.
		private TextMesh text;
		// 왼손과 오른손의 합계.
		private int sum;
		//왼손손가락 개수.
		private UnityHand u_hand;
		//오른손손가락 개수.
		private UnityHand r_hand;

		private UILabel sn_text;

		


		// Use this for initialization
		void Start ()
		{
				//텍스쳐매쉬,립매니져,왼손,오른손,초기화.
				text = gameObject.GetComponent (typeof(TextMesh)) as TextMesh;
				_leapManager = (GameObject.Find ("LeapManager") as GameObject).GetComponent (typeof(LeapManager)) as LeapManager;
				u_hand = (GameObject.Find ("left") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;
				r_hand = (GameObject.Find ("right") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;
				sn_text = (GameObject.Find ("sol_num")as GameObject).GetComponent(typeof(UILabel)) as UILabel;

		}
	
		// Update is called once per frame
		void Update ()
		{
	
				//손가락 체크하는 함수.
				FingerCountCheck ();


		}

		void FingerCountCheck ()
		{


				if (u_hand.handFound) {
						Debug.Log ("u : ");
						sum = u_hand.hand.Fingers.Count;

						if (r_hand.handFound) {
								Debug.Log ("u_f : ");		
								sum = r_hand.hand.Fingers.Count + u_hand.hand.Fingers.Count;

						}

				} else if (r_hand.handFound) {
						Debug.Log ("f : ");
						//왼손과 오른손 카운트를 세어 저장한다. 
						sum = r_hand.hand.Fingers.Count;

				}
				string name = Application.loadedLevelName;
				if (sum == 1 && name.Equals ("scene1")) {
						
						NextLevel (2);

				} else if (sum == 2 && name.Equals ("scene2")) {
						
						NextLevel (3);	

				} else if (sum == 3 && name.Equals ("scene3")) {
						
						NextLevel (4);	

				} else if (sum == 4 && name.Equals ("scene4")) {

						NextLevel (5);	

				} else if (sum == 5 && name.Equals ("scene5")) {

						NextLevel (6);	

				} else if (sum == 6 && name.Equals ("scene6")) {

						NextLevel (7);	

				} else if (sum == 7 && name.Equals ("scene7")) {

						NextLevel (8);	

				} else if (sum == 8 && name.Equals ("scene8")) {

						NextLevel (9);		

				} else if (sum == 9 && name.Equals ("scene9")) {

						NextLevel (10);	
				} 

				//Texture에 표시한다. 
				//text.text = "Finger Count : " + sum +" : "+ Application.loadedLevelName;
				sn_text.text = sum + "";

	
		}

		void NextLevel (int lev)
		{
				Application.LoadLevel ("scene" + lev);


		}

}
