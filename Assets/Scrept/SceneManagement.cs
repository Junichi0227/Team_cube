using UnityEngine;
using System.Collections;

public class SceneManagement : MonoBehaviour {

	private static bool created = false;



	void Awake(){
		if(!created){
			// シーンを切り替えても指定のオブジェクトを破棄せずに残す
			DontDestroyOnLoad(this.gameObject);
			// 生成した
			created = true;
		} else {
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if()
	}
}
