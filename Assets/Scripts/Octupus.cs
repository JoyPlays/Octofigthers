using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octupus : MonoBehaviour 
{
    public float AttackTimeMin;
    public float AttackTimeMax;
    public float Damage;
    public int LegCount;
    public Player Player;
    public List<LegAndParts> LegsAndHead;

    bool stuned;
    public float StunPeriod;

    float AttackInterval;
    float TimeAfterLatAttack;
    int AttackingLeg;
    
    void Start()
    {
        //AttackInterval = PrepareForAttack();// (AttackTimeMin, AttackTimeMax);//max exclusive9
        //AttackingLeg = PrepareForAttack();
        PrepareForNextAttack();
    }

	
	void Update ()
    {
        if (!stuned)
        {
            if ((Time.time - TimeAfterLatAttack) > AttackInterval)
            {
                //reset scale
                foreach (LegAndParts Leg in LegsAndHead)
                {
                    Leg.transform.localScale = new Vector3(1, 1, 1);
                }

                //attack sequence starts 
                TimeAfterLatAttack = Time.time;

                //activate some animation
                LegsAndHead[AttackingLeg].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

                //execute attack
                attack();

                //after
                PrepareForNextAttack();
            }
        }
        else
        {
            //TimeAfterLatAttack = Time.time + StunPeriod;//just ads wait time
            //stuned = false;

        }
    }

    //public float PrepareForAttack(float AttackTimeMin, float AttackTimeMax)
    public void PrepareForNextAttack()
    {
        AttackInterval = Random.Range(AttackTimeMin, AttackTimeMax);
        AttackingLeg = Random.Range(0, LegCount + 1);//+1 because of head;

        while (!LegsAndHead[AttackingLeg].isActiveAndEnabled)
        {
            AttackingLeg = Random.Range(0, LegCount + 1);//+1 because of head;
        }
    }

    public void attack()
    {
        Player.GetComponent<Player>().Health -= Damage;
        Debug.Log("Attack jhealth left: " + Player.GetComponent<Player>().Health);
    }



}
