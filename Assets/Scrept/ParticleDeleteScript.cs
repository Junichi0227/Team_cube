using UnityEngine;
using System.Collections;

public class ParticleDeleteScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("EffectDelete", 1);
	}

	void EffectDelete(){
		Destroy (this.gameObject); 
	}
}
