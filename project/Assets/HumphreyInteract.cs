using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumphreyInteract : MonoBehaviour {
    public Interactable closest;
    public float minimumDistance = 2;
    public Interactable selected = null;
    public bool isPlayerOne = true;
    public GameObject attentionIcon;

    public GameObject deadCrushed;

    public bool keyDown = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        closest = Interactable.GetClosest(this.transform.position);
        //Vector2.distance
        if (this.minimumDistance > Vector2.Distance(this.transform.position,closest.transform.position))
        {
            this.selected = this.closest;
        }
        else
        {
            this.selected = null;
        }

        if(this.selected)
        {
            this.attentionIcon.SetActive(true);
        }else
        {
            this.attentionIcon.SetActive(false);
        }

        if (this.isPlayerOne)
        {
            if (Input.GetAxis("Fire1") > 0 )
            {
                if (keyDown)
                {
                    return;
                }
                this.keyDown = true;
                if (this.selected)
                {
                    this.selected.SendMessage("OnInteract",this);
                }
            }else
            {
                this.keyDown = false;
            }
        }
        else
        {
            if (Input.GetAxis("Fire1P2") > 0)
            {
               if(keyDown)
                {
                    return;
                }
                this.keyDown = true;

                if (this.selected)
                {
                    this.selected.SendMessage("OnInteract", this);

                }

            }
            else
            {
                this.keyDown = false;
            }

        }

	}

    private void OnDrawGizmos()
    {
        if(selected != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, closest.transform.position);
        }
    }
    void NotifyDeath(DangerZone dangerZone)
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<HumphreyMove>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
       switch(dangerZone.deathtype)
        {
            case DeathType.Crushed:
                this.deadCrushed.SetActive(true);
                break;

        }
    }
}
