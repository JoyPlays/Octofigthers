using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAndParts : MonoBehaviour
{
    bool disabled;
    float PartsHealth = 20;
    float DamageWillTake = 5;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed left click.");
            Manager OctoManager = new Manager();
            if (OctoManager.IsUnderMouse(gameObject))
            {
                PartsHealth -= DamageWillTake;
                //Debug.Log("ATACKED");


            }

        }

        if (PartsHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
