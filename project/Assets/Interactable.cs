using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
    public static ArrayList interactables = new ArrayList();
    public GameObject target;

	// Use this for initialization
	void Start () {

        interactables.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDestroy()
    {
        interactables.Remove(this);
    }

    public void OnInteract()
    {
        this.target.SendMessage("onInteract", this);
    }

    public Interactable GetClosest(Vector2 p)
    {
        if(Interactable.interactables.Count == 0)
        {
            return null;
        }

        Interactable closest = null;
        closest = (Interactable)Interactable.interactables[0];
        float closestDistance = Vector2.Distance(closest.transform.position, p);

        foreach (Interactable i in Interactable.interactables) 
        {
            //If objects distance > distance, make it the new distance
            Transform t = i.transform;

            float currentDistance = Vector2.Distance(p, t.position);


            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closest = i;
            }
        }

        return closest;
    }
}
