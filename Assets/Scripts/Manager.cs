using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager
{
    public bool IsUnderMouse(GameObject gameObject)
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Casts really small 2d ray, because 3d rays colides only with 3d colliders, so i need performance
        RaycastHit2D hit = Physics2D.Raycast(MousePosition, Vector2.up, 0.001f);

        if (hit)
        {
            if (hit.collider.gameObject.GetInstanceID() == gameObject.GetInstanceID())
            {
                //Debug.Log("Ray Colissions");
                return true;
            }
        }

        return false;
    }


}
