using UnityEngine;
using System.Collections;

public class Cameratest : MonoBehaviour {

	public GameObject camera;
	public float speed = 0.1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update (){
		if (Input.GetMouseButtonDown (1)) {
			//Camera.main.transform.TransformDirection (Vector3.forward) = 前向きに動く
			Vector3 camerapos = Camera.main.transform.TransformDirection (Vector3.forward);
			//normalize = 単位ベクトルにしてくれる
			camerapos.Normalize ();
			camera.transform.position += -camerapos * speed * Time.deltaTime;


			//camera.transform.position += Camera.main.transform.TransformDirection (Vector3.forward);
		}
	}
}
