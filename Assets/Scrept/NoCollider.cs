using UnityEngine;
using System.Collections;

public class NoCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int layer1 = LayerMask.NameToLayer("player_1"); 
		int layer2 = LayerMask.NameToLayer("player_2"); 

		int layer3 = LayerMask.NameToLayer("Stage");
		int layer4 = LayerMask.NameToLayer("FallFloor");

		// 衝突判定を無視するLayerの設定 
		Physics.IgnoreLayerCollision( layer1, layer2 ); 
		Physics.IgnoreLayerCollision( layer3, layer4 );
	}


}
