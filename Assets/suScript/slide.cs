using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class slide : MonoBehaviour {
	//끝나는 시점 포지션.
	public GameObject targetPosition;

	//이동스피드.
	public float speed = 1.0F;
	//시작 시간.
	private float startTime;
	//시작과 끝의 거리.
	private float journeyLength;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		//거리 측정.
		journeyLength = Vector3.Distance (transform.position,targetPosition.transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		//두점사이의 거리가 10일때  속력 v=m/s 1초에  한프레임당 1움직인다고하면
		// 속력/길이 = m/s 
		// m =1/s 시간 fracJourney =0.1f
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (transform.position , targetPosition.transform.position,fracJourney);

	}
}
