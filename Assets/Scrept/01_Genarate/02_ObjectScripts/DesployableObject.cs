using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesployableObject : MonoBehaviour {

    [SerializeField] private DesployableData _data;

    public void Init(DesployableData data){
        _data = data;
        transform.position = data.Position;
        transform.eulerAngles = data.Rotarion;
    }
}
