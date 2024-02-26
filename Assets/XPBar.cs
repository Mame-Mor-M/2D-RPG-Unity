using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void SetMaxEXP(float playerXP)
	{
		slider.maxValue = playerXP;
		slider.value = playerXP;
			
		fill.color = gradient.Evaluate(1f);
	}

	public void SetEXP(float playerXP)
	{
		slider.value = playerXP;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
