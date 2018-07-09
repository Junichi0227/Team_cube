using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonActive : MonoBehaviour {

    [SerializeField]
    private List<GameObject> buttons;

   


    private void Start()
    {
       // SetObjectActive(false);
    }
    public void SetObjectActive(bool active)
    {
        Debug.Log("Set");

        foreach(var b in buttons)
        {
            //b.SetActive(active);
        }
        
    }
}
