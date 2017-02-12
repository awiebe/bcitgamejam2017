using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumphreyInteract : MonoBehaviour {
    public Interactable closest;
    public float minimumDistance = 2;
    public Interactable selected = null;
    public bool isPlayerOne = true;

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
}
