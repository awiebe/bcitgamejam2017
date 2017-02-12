using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateUV : MonoBehaviour {

    public Vector2 velocity;
    public MeshRenderer render;
	// Use this for initialization
	void Start () {
        render = this.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        this.render.material.mainTextureOffset += this.velocity*Time.deltaTime;
	}
}
