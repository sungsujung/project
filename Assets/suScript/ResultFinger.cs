using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResultFinger : MonoBehaviour {
	//왼손손가락 개수.
	private UnityHand u_hand;
	//오른손손가락 개수.
	private UnityHand r_hand;
	//LeapManager
	private LeapManager _leapManager;
	// 왼손과 오른손의 합계.
	private int sum;
	//Grate Object.
	public GameObject grate;
	//맴버의 자식오브젝트담는 배열.
	public Transform[] ch_label;

	public GameObject[] Hp_s;
	
	private int count;

	List<GameObject> hp = new List<GameObject>();

	bool five= false;
	bool four = false;
	bool three = false;
	bool two = false;
	bool one = false;
		
	// Use this for initialization
	void Start () {
		//텍스쳐매쉬,립매니져,왼손,오른손,초기화.
		_leapManager = (GameObject.Find ("LeapManager") as GameObject).GetComponent (typeof(LeapManager)) as LeapManager;
		u_hand = (GameObject.Find ("left") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;
		r_hand = (GameObject.Find ("right") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;
		ch_label = (GameObject.Find ("Member")as GameObject).GetComponentsInChildren<Transform>();
		Hp_s = GameObject.FindGameObjectsWithTag ("hps");

	}
	
	// Update is called once per frame
	void Update () {
		HandsCheck ();
	}

	void HandsCheck()
	{
				if (five == false || four == false || three == false || two == false || one == false) {
						//왼쪽 손을 찾으면.
						if (u_hand.handFound) {
								//합계변수에 왼쪽손 카운트를 계산하여 넣어준다.
								sum = u_hand.hand.Fingers.Count;
								Debug.Log ("sum : " + sum);
								// 왼손 + 오른손일때.
								if (r_hand.handFound) {
										Debug.Log ("u_f : ");
										//양쪽손 합계를 계산하여 합계 변수에 넣어준다.
										sum = r_hand.hand.Fingers.Count + u_hand.hand.Fingers.Count;
				
								}
								if (sum == 5) {
										five = true;
								} else if (sum == 4) {
										four = true;
								} else if (sum == 3) {
										three = true;
								} else if (sum == 2) {
										two = true;
								} else if (sum == 1) {
										one = true;
								}
								//1단계의 문제의 답이 2이므로 2라면.
								if (sum == 2) {
										//자식오브젝트 검사.
										foreach (Transform c  in ch_label) {
												//NGUI SETACTIVE 시키는것.
												NGUITools.SetActive (c.gameObject, false);
										}
										//참잘햇어요 보이도록.
										grate.SetActive (true);
										// 시간 계속 진행. 1일때 진행 0일때 정지.
										Time.timeScale = 0;
								} else {

										//몇단계에서 죽었는지 저장을한다.
										PlayerPrefs.SetString ("final level", Application.loadedLevelName);

										foreach (GameObject h in Hp_s) {
												hp.Add (h.gameObject);

										}

										//끝나는 화면으로 이동한다.
										//Application.LoadLevel("end");
								}
						}
				}
		}
}
