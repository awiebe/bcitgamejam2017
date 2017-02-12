using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedSliderController : MonoBehaviour
{

	public NeedBarsModel model;
	public Slider foodSlider;
	public Slider thirstSlider;
	public Slider sleepSlider;
	public Slider funSlider;
	public Slider cleanSlider;

	void Start ()
	{
		this.foodSlider.maxValue = model.hungerMax;
		this.thirstSlider.maxValue = model.thirstMax;
		this.sleepSlider.maxValue = model.sleepMax;
		this.funSlider.maxValue = model.funMax;
		this.cleanSlider.maxValue = model.cleanMax;
	}

	// Update is called once per frame
	void Update ()
	{
		this.foodSlider.value = model.hunger;
		this.thirstSlider.value = model.thirst;
		this.sleepSlider.value = model.sleep;
		this.funSlider.value = model.fun;
		this.cleanSlider.value = model.clean;
	}
}
