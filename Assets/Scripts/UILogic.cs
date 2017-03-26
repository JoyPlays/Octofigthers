using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

	public GameObject fadeToBlack;
	public GameObject hitRed;
	public GameObject loseScreen;
	public GameObject winScreen;
	public Animator uiAnimator;
	public Animator Hero;

	public GameObject explosion;


	public GameObject[] LegsAndHead;

	private float tempMaxHP;

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;

	public void Start()
	{
		tempMaxHP = Player.Health;
	}

	public void Update()
	{
		HandleBar();
		FadeToBlack();
	} 

	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	public void HandleBar()
	{
		content.fillAmount = Map(Player.Health,0,tempMaxHP,0,1);
	}

	public void FadeToBlack()
	{
		if (Global.OctoStunned)
		{
			fadeToBlack.SetActive(true);
		}
		else
		{
			fadeToBlack.SetActive(false);
		}
	}

	public void BoosterRum()
	{
		Player.Health += 10;
	}

	public void BoosterBomb()
	{
		explosion.SetActive(true);
		int i = Random.Range(0, 8);
		LegsAndHead[i].SetActive(false);
		Hero.SetTrigger("Explosion");
	}

	public void BoosterShield()
	{
		Player.Shield = true;
	}

	public void GameOverUI()
	{
		loseScreen.gameObject.SetActive(true);
		uiAnimator.SetTrigger("Lose");
	}

	public void GameWon()
	{
		winScreen.gameObject.SetActive(true);
		uiAnimator.SetTrigger("Win");
	}


	public void PlayerHit()
	{
		StartCoroutine("PlayerHitCouroutine");
	}
	IEnumerator PlayerHitCouroutine()
	{
		hitRed.gameObject.SetActive(true);
		yield return new WaitForSeconds(1);
		hitRed.gameObject.SetActive(false);
	}
}
