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

    bool stuned;
    float StunPeriod;

    float AttackInterval;
    float TimeAfterLatAttack;
    
    void Start()
    {
        AttackInterval = PrepareForAttack(AttackTimeMin, AttackTimeMax);//max exclusive9
    }

	
	void Update ()
    {
        if ((Time.time - TimeAfterLatAttack) > AttackInterval)

        {
            //attack sequence starts 
            TimeAfterLatAttack = Time.time;
            AttackInterval = PrepareForAttack(AttackTimeMin, AttackTimeMax);//max exclusive9

            //activate some animation

            //execute attack
            attack();

        }
    }

    public float PrepareForAttack(float AttackTimeMin, float AttackTimeMax)
    {
        return Random.Range(AttackTimeMin, AttackTimeMax);
    }

    public void attack()
    {
        Player.GetComponent<Player>().Health -= Damage;
        Debug.Log("Attack jhealth left: " + Player.GetComponent<Player>().Health);
    }



}
