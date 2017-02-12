using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DeathType
{
	Starvation,
	Thirst,
	Sleep,
	Madness,
	Electrocution,
	Burned,
	Explosion,
	Crushed
}

public class NeedBarsModel : MonoBehaviour
{

	public float hunger = 100f;
	public float thirst = 100f;
	public float sleep = 100f;
	public float fun = 100f;
	public float clean = 100f;

	public float hungerMax = 100f;
	public float thirstMax = 100f;
	public float sleepMax = 100f;
	public float funMax = 100f;
	public float cleanMax = 100f;

	public Vector2 hungerDecay = new Vector2(.1f, 1f);
	public Vector2 thirstDecay = new Vector2(.1f, 1f);
	public Vector2 sleepDecay = new Vector2(.1f, 1f);
	public Vector2 funDecay = new Vector2(.1f, 1f);
	public Vector2 cleanDecay = new Vector2(.1f, 1f);

	public float realHungerDecay;
	public float realThirstDecay;
	public float realSleepDecay;
	public float realFunDecay;
	public float realCleanDecay;

	public GameObject[] notifyOnDeath;
	public bool dead = false;

	private DeathType t;


	public void Start ()
	{
		
		this.realHungerDecay = Random.Range(this.hungerDecay.x, this.hungerDecay.y);
		this.realSleepDecay = Random.Range(this.sleepDecay.x, this.sleepDecay.y);
		this.realThirstDecay = Random.Range(this.thirstDecay.x, this.thirstDecay.y);
		this.realFunDecay = Random.Range(this.funDecay.x, this.funDecay.y);
		this.realCleanDecay = Random.Range(this.cleanDecay.x, this.cleanDecay.y);
		
	}

	public void FixedUpdate ()
	{
		//cleanliness fact, to lazy to rety, refactor later
		float f = 1 + ((1 - clean / cleanMax));

		this.hunger = this.hunger - (f * this.realHungerDecay * Time.fixedDeltaTime);
		this.thirst = this.thirst - (f * this.realThirstDecay * Time.fixedDeltaTime);
		this.fun = this.fun - f * (this.realFunDecay * Time.fixedDeltaTime);
		this.sleep = this.sleep - (f * this.realSleepDecay * Time.fixedDeltaTime);
		this.clean = this.clean - (f * this.realCleanDecay * Time.fixedDeltaTime);
		
		this.clean = Mathf.Clamp(this.clean, 0, this.cleanMax);
		this.hunger = Mathf.Clamp(this.hunger, 0, this.hungerMax);
		this.thirst = Mathf.Clamp(this.thirst, 0, this.thirstMax);
		this.fun = Mathf.Clamp(this.fun, 0, this.funMax);
		this.sleep = Mathf.Clamp(this.sleep, 0, this.sleepMax);

		this.notifyDeath();
	}

	private void notifyDeath ()
	{
		if (dead)
		{
			return;
		}

		if (this.hunger < 0)
		{
			t = DeathType.Starvation;
		}
		else
		if (this.thirst < 0)
		{
			t = DeathType.Thirst;
		}
		else
		if (this.fun < 0)
		{
			t = DeathType.Madness;
		}
		else
		if (this.sleep < 0)
		{
			t = DeathType.Sleep;
		}
		dead = true;

		foreach (GameObject g in notifyOnDeath)
			g.SendMessage("NotifyDeath", this);
	}

	public DeathType GetDeathReason ()
	{
		return this.t;
	}



}
