using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Like : MonoBehaviour {

    //検索用にuserIdとstageIdを生成する
    [SerializeField] private int userId, stageId;
    public int UserId{ get { return userId; }}
    public int StageId{ get { return stageId; }}
}
