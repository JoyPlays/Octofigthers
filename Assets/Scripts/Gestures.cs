using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestures : MonoBehaviour
{
    Vector2 LastMousePosition;
    Vector2 CurrentMousePosition;
    Vector2 MiddlePoint = new Vector2(360,640);

    float TotalAngle;
    
	void Start ()
    {

    }

    void FixedUpdate()
    {
        if (Global.MyPause == true)
        {
            //for first point
            if (Input.GetMouseButtonDown(0))
            {
                LastMousePosition = Input.mousePosition;
                //Debug.Log("LastMousePosition: " + LastMousePosition);
            }

            //
            if (Input.GetMouseButton(0))
            {
                CurrentMousePosition = Input.mousePosition;
                //Debug.Log("CurrentMousePosition: " + CurrentMousePosition);
                VectorStuff();

                LastMousePosition = CurrentMousePosition;

            }

            if (Input.GetMouseButtonUp(0))
            {
                //clear all
                TotalAngle = 0;

            }
        }
    }

    public void VectorStuff()
    {
        float MyAngle = Vector2.Angle((LastMousePosition- MiddlePoint), (CurrentMousePosition- MiddlePoint));
        //Debug.Log("Angle: "+MyAngle);
        TotalAngle += MyAngle;
        //Debug.Log("TotalAngle: " + TotalAngle);
        if (TotalAngle > 360)
        {
            CircleGesture();
        }
    }

    public void CircleGesture()
    {
        //reset if gesture is done
        TotalAngle = 0;
        Debug.Log("Circle");
    }
}
