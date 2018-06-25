using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour {

    [SerializeField]
    private int id;

    /// <summary>
    /// アイテムの種類
    /// </summary>
    [SerializeField]
    private ItemType itemType;

    /// <summary>
    /// アイテムの分野
    /// </summary>
    [SerializeField]
    private ItemField itemField;

    public int ID
    {
        get { return id; }
    }

    public ItemField ItemField
    {
        get{ return itemField; }
    }

    public ItemType ItemType
    {
        get { return itemType; }
    }




}
