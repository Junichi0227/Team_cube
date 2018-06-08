using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//このスクリプトはCubeにはる
public class RotateCube41_Blue : MonoBehaviour {

	GameObject Parent; //親オブジェクト
	Vector3 current; //現在の回転値
	Vector3 destination; //目的となる回転値
	public float speed = 1; //回転のスピード
	bool move = false; //今動いているかどうか
	bool isFall = false;
	bool isFly = false;
	bool isWarp = false;
	GameObject warpTarget = null;

	bool push_up = false;
	bool push_down = false;
	bool push_right = false;
	bool push_left = false;

	float time = 0; //タイマー　1になったら回転終了
	public FlagManeger flagManeger;

	void Start () {
		
		Parent = new GameObject ("Parent"); //Parentという空のオブジェクトを生成する。
		this.transform.parent = Parent.transform; //Cubeの親をParentオブジェクトにする
	}

	// Update is called once per frame
	void Update () {

		//もし動いていない状態で
		if (!move & !isFall) {
			RaycastHit hit;

			Vector3 posfallY = new Vector3 (0, -1, 0);
			Ray rayfallY = new Ray (transform.position, posfallY);
			Debug.DrawRay (rayfallY.origin, rayfallY.direction, Color.red, 5, false);
			if (Physics.Raycast (rayfallY, out hit, 1)) {
				//GetComponent<Rigidbody> ().isKinematic = false;
			}

			//上キーを押したら
			if (push_up) {
				//Rayを生成する
				//前を判定するためのray
				Vector3 pos = new Vector3 (0, 0, 1);
				Ray rayZ = new Ray (transform.position, pos);
				//下を判定するためのray
				Vector3 posY = new Vector3 (0, -1, 0);
				Ray rayY = new Ray (transform.position + new Vector3 (0, 0, 1), posY);

				if (Physics.Raycast (rayZ, out hit, 1)) {
					//壁に当たると止まる
					if (hit.collider.tag == "Wall") {
					} 
					//階段処理
					else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, size / 2, size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (180, 0, 0); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					}
				} 
				//次のブロックのタグが床か階段だったら進む
				//ゴールだったら進んでから飛ぶ
				else if (Physics.Raycast (rayY, out hit, 1)) {
					if (hit.collider.tag == "Floar") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (90, 0, 0); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					} else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (90, 0, 0); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					} else if (hit.collider.tag == "Goal") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (90, 0, 0); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						isFly = true;
					} else if(hit.collider.tag == "Warp"){


						//2016/05/24書き足したところ
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (90, 0, 0); //目標の回転値
						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						warpTarget = hit.collider.gameObject.GetComponent<WarpScrept>().gettarget();
						isWarp = true;

						Debug.Log ("in");
					}

				}

				//何にもなければそのまま進み落ちる
				else {
					this.transform.parent = null;
					float size = transform.localScale.x;
					Parent.transform.position = transform.position + new Vector3 (0, -size / 2, size / 2);
					transform.parent = Parent.transform;
					//ここまで、親の位置を回転軸まで移動させる
					current = Parent.transform.rotation.eulerAngles; //現在の回転値
					destination = current + new Vector3 (90, 0, 0); //目標の回転値

					move = true; //動いている状態にする
					time = 0; //タイマーリセット

					isFall = true;

				}
			}



			//下キーを押したら
			if (push_down) {
			//if (Input.GetKeyDown (KeyCode.DownArrow)) {
				Vector3 pos = new Vector3 (0, 0, -1);
				Ray rayZ1 = new Ray (transform.position, pos);

				//下を判定するためのray
				Vector3 posY = new Vector3 (0, -1, 0);
				Ray rayY = new Ray (transform.position + new Vector3 (0, 0, -1), posY);


				if (Physics.Raycast (rayZ1, out hit, 1)) {
					//壁に当たると止まる
					if (hit.collider.tag == "Wall") {
					} 
					//階段処理
					else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, size / 2, -size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (-180, 0, 0); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					}
				} 
				//次のブロックのタグが床か階段だったら進む
				//ゴールだったら進んでから飛ぶ
				else if (Physics.Raycast (rayY, out hit, 1)) {
					Debug.DrawRay (rayY.origin, rayY.direction, Color.red, 5, false);
					if (hit.collider.tag == "Floar") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, -size / 2);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (-90, 0, 0);

						move = true;
						time = 0;
					} else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, -size / 2);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (-90, 0, 0);

						move = true;
						time = 0;

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					} else if (hit.collider.tag == "Goal") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, -size / 2);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (-90, 0, 0);

						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						isFly = true;
					} else if(hit.collider.tag == "Warp"){


						//2016/05/24書き足したところ
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (0, -size / 2, -size / 2);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (-90, 0, 0); //目標の回転値
						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						warpTarget = hit.collider.gameObject.GetComponent<WarpScrept>().gettarget();
						isWarp = true;

						Debug.Log ("in");
					}

				}

				//何にもなければそのまま進み落ちる
				else {
					this.transform.parent = null;
					float size = transform.localScale.x;
					Parent.transform.position = transform.position + new Vector3 (0, -size / 2, -size / 2);
					transform.parent = Parent.transform;
					current = Parent.transform.rotation.eulerAngles;
					destination = current + new Vector3 (-90, 0, 0);

					move = true;
					time = 0;

					isFall = true;

				}
			}



			// 左キーを押したら
			if (push_left) {
			//if (Input.GetKeyDown (KeyCode.LeftArrow)) {

				Vector3 pos = new Vector3 (-1, 0, 0);
				Ray rayZ = new Ray (transform.position, pos);

				Vector3 posY = new Vector3 (0, -1, 0);
				Ray rayY = new Ray (transform.position + new Vector3 (-1, 0, 0), posY);


				if (Physics.Raycast (rayZ, out hit, 1)) {
					//壁に当たると止まる
					if (hit.collider.tag == "Wall") {
					} 
					//階段処理
					else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (-size / 2, size / 2, 0);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (0, 0, 180); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					}
				} 
				//次のブロックのタグが床か階段だったら進む
				//ゴールだったら進んでから飛ぶ
				else if (Physics.Raycast (rayY, out hit, 1)) {
					
					if (hit.collider.tag == "Floar") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (-size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, 90);

						move = true;
						time = 0;
					} else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (-size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, 90);

						move = true;
						time = 0;
					} else if (hit.collider.tag == "Goal") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (-size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, 90);

						move = true;
						time = 0;

						isFly = true;
					} else if(hit.collider.tag == "Warp"){


						//2016/05/24書き足したところ
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 ( -size / 2, -size / 2,0);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (0, 0, 90); //目標の回転値
						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						warpTarget = hit.collider.gameObject.GetComponent<WarpScrept>().gettarget();
						isWarp = true;

						Debug.Log ("in");
					}

				}

				//何にもなければそのまま進み落ちる
				else {
					this.transform.parent = null;
					float size = transform.localScale.x;
					Parent.transform.position = transform.position + new Vector3 (-size / 2, -size / 2, 0);
					transform.parent = Parent.transform;
					current = Parent.transform.rotation.eulerAngles;
					destination = current + new Vector3 (0, 0, 90);

					move = true;

					time = 0;
					isFall = true;

				}

			}



			// 右キーを押したら

			if(push_right){
			//if (Input.GetKeyDown (KeyCode.RightArrow)) {
				Vector3 pos = new Vector3 (1, 0, 0);
				Ray rayZ = new Ray (transform.position, pos);


				Vector3 posY = new Vector3 (0, -1, 0);
				Ray rayY = new Ray (transform.position + new Vector3 (1, 0, 0), posY);


				if (Physics.Raycast (rayZ, out hit, 1)) {
					//壁に当たると止まる
					if (hit.collider.tag == "Wall") {
					} 
					//階段処理
					else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (size / 2, size / 2, 0);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (0, 0, -180); //目標の回転値

						move = true; //動いている状態にする
						time = 0; //タイマーリセット
					}
				} 
				//次のブロックのタグが床か階段だったら進む
				//ゴールだったら進んでから飛ぶ
				else if (Physics.Raycast (rayY, out hit, 1)) {
					if (hit.collider.tag == "Floar") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, -90);

						move = true;

						time = 0;
					} else if (hit.collider.tag == "Stairs") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, -90);

						move = true;

						time = 0;
					} else if (hit.collider.tag == "Goal") {
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 (size / 2, -size / 2, 0);
						transform.parent = Parent.transform;
						current = Parent.transform.rotation.eulerAngles;
						destination = current + new Vector3 (0, 0, -90);

						move = true;

						time = 0;

						isFly = true;
					} else if(hit.collider.tag == "Warp"){


						//2016/05/24書き足したところ
						this.transform.parent = null;
						float size = transform.localScale.x;
						Parent.transform.position = transform.position + new Vector3 ( size / 2, -size / 2,0);
						transform.parent = Parent.transform;
						//ここまで、親の位置を回転軸まで移動させる
						current = Parent.transform.rotation.eulerAngles; //現在の回転値
						destination = current + new Vector3 (0, 0, -90); //目標の回転値
						move = true; //動いている状態にする
						time = 0; //タイマーリセット

						warpTarget = hit.collider.gameObject.GetComponent<WarpScrept>().gettarget();

						isWarp = true;

						Debug.Log ("in");
					}

				}

				//何にもなければそのまま進み落ちる
				else {
					this.transform.parent = null;
					float size = transform.localScale.x;
					Parent.transform.position = transform.position + new Vector3 (size / 2, -size / 2, 0);
					transform.parent = Parent.transform;
					current = Parent.transform.rotation.eulerAngles;
					destination = current + new Vector3 (0, 0, -90);

					move = true;

					time = 0;
					isFall = true;

					//ここで下にRAYを床があるか確認
				}
			}
		}



		// 動いている状態なら
		if (move) {
			
			Moving ();
		}

		if (isFall) {
			RaycastHit hit;
			Vector3 posY_Fall = new Vector3 (0, -1, 0);
			Ray rayY = new Ray (transform.position, posY_Fall);



			if (time == 0) {

				float fallSpeed = -1.0f;
				//この辺りは先に床を取れなかったら落っことす
				if (Physics.Raycast (rayY, out hit, 0.5f)) {
					if (hit.collider.tag == "Floar" || hit.collider.tag == "Stairs") {
						isFall = false;
					} else if (hit.collider.tag == "Goal") {
						isFall = false;
						isFly = true;
					}
				}
				transform.position += new Vector3 (0, fallSpeed * Time.deltaTime * 10.0f, 0);
			}

			if (transform.position.y <= -10) {
				Destroy (this.gameObject);
			}
		}

		if (isFly) {
			if (time == 0) {
				float time2 = 3.0f;
				transform.position += new Vector3 (0, time2 * Time.deltaTime * 10.0f, 0);
				transform.Rotate(0, time2 * 20.0f, 0);
				if (transform.position.y >= 10.0f) {
					flagManeger.flag_gool1 = true;
					time = 0;
				}
			}
		}

		if (transform.position.y <= -10) {
			Destroy (this.gameObject);
		}
	}

	/// <summary>
	/// キューブを回転させる処理
	/// </summary>
	private void Moving()
	{
		if (move) {

			GetComponent<Rigidbody> ().useGravity = false;

			// タイマーを足していく
			time += Time.deltaTime * speed * 2.0f;
			// 回転させる Leapを使用
			Parent.transform.eulerAngles = Vector3.Lerp (current, destination, time);

			// 回転し終わったら
			if (time >= 1) {
				if (isWarp) 
				{
					Warp (warpTarget);
					isWarp = false;
				}
				move = false;
				time = 0;
				transform.parent = null;
				Parent.transform.eulerAngles = Vector3.zero;
				transform.parent = Parent.transform;
				push_up = false;
				push_down = false;
				push_right = false;
				push_left = false;
				GetComponent<Rigidbody> ().useGravity = true;
			}
		}
	}
	public void PushDown_Up()
	{
		push_up = true;

	}
	public void PushDown_Down()
	{
		push_down = true;
	}
	public void PushDown_Right()
	{
		push_right = true;
	}
	public void PushDown_Left()
	{
		push_left = true;
	}
	public void Warp(GameObject warp1){
		this.gameObject.transform.position = warp1.transform.position;
	}
}