using UnityEngine;
using System.Collections;

public class FallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){
		Debug.Log ("In");
		Invoke ("Fall", 2);
	}
	void Fall(){
		GetComponent<Rigidbody> ().isKinematic = false;
	}
}
