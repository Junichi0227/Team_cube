using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation : MonoBehaviour {

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

    /// <summary>
    /// マス目
    /// </summary>
    private Squares squares;

    /// <summary>
    /// 階層
    /// </summary>
    private int fault;

    public ItemField ItemField
    {
        get{ return itemField; }
    }

    public ItemType ItemType
    {
        get { return itemType; }
    }

    public Squares Squares
    {
        get { return squares; }
        set { this.squares = value; }
    }

    public int Fault
    {
        get { return fault; }
        set { this.fault = value; }
    }





}
