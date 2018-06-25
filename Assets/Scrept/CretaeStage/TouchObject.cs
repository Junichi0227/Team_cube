using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TouchObject
{

    public static bool IsTouchObject(GameObject gameObject, Camera camera)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Rayを飛ばす
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) return true;
            }
        }

        return false;
    }


    public static bool IsTouchObject(string tag, Camera camera)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Rayを飛ばす
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == tag) return true;
            }
        }

        return false;
    }


}
