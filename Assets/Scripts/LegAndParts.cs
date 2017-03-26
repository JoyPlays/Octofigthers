using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegAndParts : MonoBehaviour
{
    bool disabled;
    public float PartsHealth = 15;
    float DamageWillTake = 5;
    bool ActiveCour;
	public bool Active;
	public float StunTimeOut = 1;

	bool tempCheck = false;

	void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Pressed left click.");
            Manager OctoManager = new Manager();
            if (OctoManager.IsUnderMouse(gameObject) && gameObject.name != "head" && Octupus.stuned)
            {
				Debug.Log("Doing damage to octopus leg");
               PartsHealth -= DamageWillTake;

				if (!Global.PlayerAttackStarted)
				{
					Global.PlayerAttackStarted = true;
					StartCoroutine("ResetOctupuStun");
				}
            }

            //if (OctoManager.IsUnderMouse(gameObject) && !Global.OctoStunned && Global.OctoAttacking)
            //{
            //Global.OctoStunned = true;
            //call gesture

            //}

            //ja uzspiez
            if (OctoManager.IsUnderMouse(gameObject) && !ActiveCour && Active && !Octupus.stuned)
            {
				//animacija

				//cancels health loss and stuns if gesture ok
				//StunTimeOut = 2;
				//StartCoroutine("GestureTimeOut");

				Debug.Log("Click has WORKED");
                StartCoroutine("GestureTimeOut");
				StartCoroutine("ResetStunned");
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
		ActiveCour = true;
		Debug.Log("Starting Gesture Timeout");
		Global.OctoAttacking = false;
        Global.OctoStunned = true;
		while (Global.OctoStunned)
		{
			Debug.Log("Waiting for input gesture");
			if (Global.Gesture)
			{
				Debug.Log("-------------- GESTURE INPUTED --------------");
				Global.OctoStunned = false;
				Global.OctoAttacking = true;
				ActiveCour = false;
			}
			yield return null;
		}
		yield return null;
    }
	IEnumerator ResetStunned()
	{
		ActiveCour = true;
		Debug.Log("-------------- RESETING OCTO STUN TO FALSE BECAUSE OF NO GESTURE INPUT --------------");
		yield return new WaitForSeconds(3f);
		if (!Global.Gesture)
		{
			Global.OctoStunned = false;
			Global.OctoAttacking = true;
		}
		else
		{
			Debug.Log("Gesture was INPUTED --------------------- HORRAYYYY NO DAMAGE RECEIVED AND ENEMY STUNNED");
			Global.OctoAttacking = true;
			Octupus.stuned = true;
		}
		Debug.Log("-------------- RESET STUN TO FALSE BECAUSE OF NO GESTURE INPUT --------------");
		ActiveCour = false;
	}

	IEnumerator ResetOctupuStun()
	{
		Debug.Log("Resetting Octopus Stun");
		yield return new WaitForSeconds(2f);
		Octupus.stuned = false;
		Global.PlayerAttackStarted = false;
	}

}
