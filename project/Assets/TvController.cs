using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour {
    public Animator animator;
    public SpriteRenderer renderer;
    public Sprite offSprite;
    public bool isOn;
    void OnInteract(MonoBehaviour sender)
    {
        isOn = !isOn;
        if (isOn)
        {
            animator.enabled = true;
        }
        else
        {
            animator.enabled = false;
            renderer.sprite = offSprite;
        }
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
