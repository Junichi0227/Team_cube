using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour {

    //これをJsonに書き出す。
    [SerializeField]private StageData stageData;

	// Use this for initialization
	private void SetUp () {
        foreach(var d in stageData.Desployeds){
            var obj = Instantiate(Resources.Load(Const.DesployObjectPath(d.Type))) as GameObject;
            var component = obj.GetComponent<DesployableObject>();
            component.Init(d);
            obj.transform.SetParent(transform);
        }
	}

    private void Start()
    {
        SetUp();
    }

    // Update is called once per frame
    void Update () {
		
	}


    //JsonSaveをする
}
