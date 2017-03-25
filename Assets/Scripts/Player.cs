using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float Health = 50f;
	public UILogic uiLogic;
	public static bool Shield;
	public MenuLogic menuLogic;
	private bool gameLost;

	void Update ()
    {
		if (Health <= 0 && !gameLost)
		{
			gameLost = true;
			if (gameLost)
			{
				//lose    
				Debug.Log("GameOver");
				uiLogic.GameOverUI();
				StartCoroutine("LoseGame");
			}  
        }
	}

	IEnumerator LoseGame()
	{
		Health = 50f;
		yield return new WaitForSeconds(2f);
		menuLogic.ReturnToMainMenu();

	}
}
