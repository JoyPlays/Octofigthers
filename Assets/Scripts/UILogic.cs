using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

	public Image fadeToBlack;

	[SerializeField]
	private float fillAmount;

	[SerializeField]
	private Image content;
	
	private float Map(float value, float inMin, float inMax, float outMin, float outMax)
	{
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}

	public void HandleBar()
	{
		content.fillAmount = Map(53,0,100,0,1);
	}

	public void FadeToBlack()
	{
		Color tempColor = fadeToBlack.color;
		float t = 5f;
		while (t > 0)
		{
			tempColor.a += 0.2f;
			t -= Time.deltaTime;
		}


	}
}
