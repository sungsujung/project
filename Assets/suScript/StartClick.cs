using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StartClick : MonoBehaviour {
		

	//컬러값 변경.
	Color ch;
	// 시간 가져오기.
	string time;
	// 시간변경 오브젝트 
	UILabel ob_Timer;
	//왼손손가락 개수.
	private UnityHand u_hand;
	//손가락 갯수 저장.
	int sum;
	//현재시간.
	float delTime ;
	//라벨의 시간을 정수로 바꾼걸 저장하기위한것.
	int par_text;

	//현재시간 + 라벨의시간.
	float par_sum;


	// Use this for initTialization
	void Start () {		
	//초기화작업.
		u_hand = (GameObject.Find ("left") as GameObject).GetComponent (typeof(UnityHand)) as UnityHand;
		time = (GameObject.Find ("Time") as GameObject).GetComponent<UILabel> ().text ;
		ob_Timer = (GameObject.Find ("Time") as GameObject).GetComponent<UILabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		//핸드를 찾으면.
		if(u_hand.handFound) {
			//왼쪽손의 합계를 저장한다.
			sum = u_hand.hand.Fingers.Count;
			Debug.Log("sum  : "+sum);

		}
	}

	//립모션손이 버튼에서 벗어나면.
	void OnTriggerExit(Collider collider)
	{
		//UISprite의 컬러를 바꾼다.
		ch = gameObject.GetComponent<UISprite> ().color = Color.white;

	}
	//립모션손이 버튼에 머무르면.
	void OnTriggerStay(Collider collider)
	{
				//충돌체의 오브젝트 이름이 왼쪽손이면.
				if (collider.gameObject.name == "leftHand") 
				{
						//UISprite의 컬러를 변경한다.
						ch = gameObject.GetComponent<UISprite> ().color = Color.blue;
						//시간을 줄이기위한 코루틴을 시작한다.
						StartCoroutine(T_Count(0));
				} 
	
		}
	//시간을 계산하고 0초되면 새로운 코루틴을 시작한다. 
	IEnumerator T_Count(float delay)
	{
		//현재시간.
		delTime -=Time.deltaTime ;
		//처음설정한 시간을 정수로 가져오기.
		par_text =  int.Parse (time);
		//현재시간과 정수로가저온시간을 더해준다. 
		par_sum = par_text + delTime;
		//시간라벨에 적용.
		ob_Timer.text = par_sum.ToString() ;

		//더해준것이 0보다 작으면 다음신으로 넘기기위한 코루틴시작.
		if(par_sum < 0.0f)
		{
			StartCoroutine(NextLevel());
			yield break;

		}

		yield return new WaitForSeconds (delay);
	}
	//다음레벨로 넘어가는 코루틴.
	IEnumerator NextLevel()
	{
		Application.LoadLevel ("scene1");
		yield return new WaitForSeconds (1);
	}

}
