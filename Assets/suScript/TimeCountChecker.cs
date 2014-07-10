using UnityEngine;
using System.Collections;

public class TimeCountChecker : MonoBehaviour {

	//시간제한 5초.
	public float timeLimit = 5.0f;
	//립모션 매니져.
	private LeapManager _leapManager;
	//타이머 동작.
	public bool begin = true;
	

	// Use this for initialization
	void Start () {
		_leapManager = (GameObject.Find("LeapManager") as GameObject).GetComponent(typeof(LeapManager)) as LeapManager;

	}
	
	// Update is called once per frame
	void Update () {
		//타이머 동작. 
		if (begin == true) {
			// 총 5초의 시간을 줌 0이 될때까지 실행.
			if (timeLimit > 0) 
			{
				//시간을 감소 시킴. 
				timeLimit -= Time.deltaTime;
				//시간을 출력.
//				text.text = "Time Count: " + timeLimit.ToString ();
				// 시간 계속 진행. 1일때 진행 0일때 정지.
				Time.timeScale = 1;
			}
			
			
		}
		else 
		{
			//만약 동작하다가 손가락이 1개로 상태가 변경되면 시간을 멈춘다. 
			Time.timeScale = 0;
			

		} 
		//0초가 되면 두번째로 넘어간다. 
		if(timeLimit <=  0)
			Application.LoadLevel("scene" + Application.loadedLevel);
		
	}
}
