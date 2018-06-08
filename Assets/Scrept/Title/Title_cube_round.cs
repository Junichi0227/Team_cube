using UnityEngine;
using System.Collections;

public class Title_cube_round : MonoBehaviour {

	public GameObject gameObject;

	// X軸、Y軸、Z軸を中心とした1秒あたりの回転速度
	// Time.deltaTimeをかけること！
	float speedX = 30.0f;
	float speedY = 40.0f;
	float speedZ = 50.0f;

	void Update () {
		// 前回のUpdate()の呼び出しからの経過時間を返す
		var d = Time.deltaTime * 1.5f;

		// このスクリプトを割り当てたオブジェクトを回転
		// 回転の軸はオブジェクトのローカル座標（Space.Self）に基づく
		gameObject.transform.Rotate(speedX * d, speedY * d, speedZ * d);
	}
}