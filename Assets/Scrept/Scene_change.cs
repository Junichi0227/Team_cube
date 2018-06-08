using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour {

	public void Title (){
		SceneManager.LoadScene ("TItle");
		//Application.LoadLevel (0);
	}

	public void Stage_Select(){
		SceneManager.LoadScene ("Stage_select");
		//Application.LoadLevel (10);
	}

	public void Stage_1(){
		SceneManager.LoadScene ("Stage1-1");
		//Application.LoadLevel (3);
	}

	public void Stage_2(){
		SceneManager.LoadScene ("Stage1-2");
		//Application.LoadLevel (4);
	}

	public void Stage_3(){
		SceneManager.LoadScene ("Stage2-1");
		//Application.LoadLevel (5);
	}

	public void Stage_4(){
		SceneManager.LoadScene ("Stage2-2");
		//Application.LoadLevel (6);
	}

	public void Stage_5(){
		SceneManager.LoadScene ("Stage2-3");
		//Application.LoadLevel (7);
	}

	public void Stage_6(){
		SceneManager.LoadScene ("Stage3-2");
		//Application.LoadLevel (8);
	}

	public void Stage_7(){
		SceneManager.LoadScene ("Stage7-7");
		//Application.LoadLevel (9);
	}
}
