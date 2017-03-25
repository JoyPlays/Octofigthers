using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAndParts : MonoBehaviour
{
    bool disabled;
    public float PartsHealth = 15;
    float DamageWillTake = 5;
    public bool Active;
    public float StunTimeOut = 1;

	void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed left click.");
            Manager OctoManager = new Manager();
            //if (OctoManager.IsUnderMouse(gameObject) && gameObject.name != "head" && Global.OctoStunned)
            //{
            //    PartsHealth -= DamageWillTake;

            //}

            //if (OctoManager.IsUnderMouse(gameObject) && !Global.OctoStunned && Global.OctoAttacking)
            //{
            //Global.OctoStunned = true;
            //call gesture

            //}

            //ja uzspiez
            if (Active && OctoManager.IsUnderMouse(gameObject))
            {
                //animacija

                //cancels health loss and stuns if gesture ok
                //StunTimeOut = 2;
                //StartCoroutine("GestureTimeOut");

                StartCoroutine("GestureTimeOut");
            }

        }

        if (PartsHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    //IEnumerator GestureTimeOut()
    //{
    //    yield return new WaitForSeconds(2f);

    //}

    IEnumerator GestureTimeOut()
    {
        Octupus.stuned = true;

        yield return new WaitForSeconds(2f);//pause or interuption

        Octupus.stuned = false;
    }

}
