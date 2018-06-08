using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ステージ作るときに必要
/// 
/// </summary>
[System.Serializable]
public class StageData
{

    [SerializeField] private int userId, stageId;
    [SerializeField] private string authorName;
    [SerializeField] private List<DesployableData> desployeds;

    public int UserId{ get { return userId; }}
    public int StageId{ get { return stageId; }}
    public string AuthorName{ get { return authorName; }}
    public List<DesployableData> Desployeds{ get { return desployeds; }}
}
