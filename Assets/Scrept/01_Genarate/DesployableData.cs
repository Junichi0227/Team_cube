using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DesployableData {

    [SerializeField] private int id;
    [SerializeField] private Vector3 position,rotation;
    [SerializeField] private Const.DesployObjectType type;

    public int Id{ get { return id; }}
    public Vector3 Position{ get { return position; }}
    public Vector3 Rotarion{ get { return rotation; }}
    public Const.DesployObjectType Type{ get { return type; }}


}
