using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class User {


    [SerializeField] private int id;
    [SerializeField] private string nickname;
    [SerializeField] private List<StageData> stageData;


    public int Id{ get { return id; }}
    public string NickName{ get { return nickname; }}
    public List<StageData> Stages{ get { return stageData; }}


    public StageData GetStageData(int id){
        return stageData.Find(s => s.StageId == id);
    }
}