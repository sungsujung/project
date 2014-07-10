using UnityEngine;
using System.Collections;

public class Scene : MonoBehaviour {
	// 텍스쳐매쉬 변수.
	private TextMesh text;
	// Use this for initialization
	void Start () {
		//텍스쳐매쉬,립매니져,왼손,오른손,초기화.
		text = gameObject.GetComponent(typeof(TextMesh)) as TextMesh;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = Application.loadedLevelName;
	}
}
