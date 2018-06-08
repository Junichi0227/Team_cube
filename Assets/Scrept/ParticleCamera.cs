using UnityEngine;
using System.Collections;

public class ParticleCamera : MonoBehaviour {

	public GameObject gameobject;
	public GameObject particle;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 clickPosition;
			clickPosition = Input.mousePosition;
			clickPosition.z = 5f;
			gameobject = Instantiate (particle, Camera.main.ScreenToWorldPoint (clickPosition), Quaternion.identity) as GameObject;
			//Invoke ("EffectDelete", 2);
		}
		//格納して格納したものを削除していく
		//再生が終われば徐々に削除させる
	}

	public void Particle(){

		Destroy (gameobject);

	}
}