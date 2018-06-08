using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FlagManeger : MonoBehaviour {

	public bool flag_gool1 = false;
	public bool flag_gool2 = false;
	float timeover = 1f;
	float time = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (flag_gool1 == true && flag_gool2 == true) {
			SceneManager.LoadScene ("Goal");
		}
		if (flag_gool1 == true || flag_gool2 == true) {
			time = Time.deltaTime;
			timeover = timeover - time;

			if (timeover <= 0) {
				SceneManager.LoadScene ("Failed");
			}
		}
	}
}

