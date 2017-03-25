using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        if (Health <= 0)
        {
            //lose    
            Debug.Log("GameOver");

            
        }
	}
}
