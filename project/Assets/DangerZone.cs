using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour {
    public ArrayList occupants = new ArrayList();
    public DeathType deathtype = DeathType.Crushed;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.occupants.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.occupants.Remove(collision.gameObject);
    }

    public void KillOccupants()
    {
        foreach(GameObject g in occupants)
        {
            g.BroadcastMessage("NotifyDeath",this);
        }
    }
}
