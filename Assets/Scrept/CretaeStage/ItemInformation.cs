using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour {

    [SerializeField]
    private int id;

    [SerializeField]
    private ItemType type;

    public int ID
    {
        get { return id; }
    }

    public ItemType Type
    {
        get{ return type; }
    }



}
