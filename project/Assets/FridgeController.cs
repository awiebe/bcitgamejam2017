using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeController : MonoBehaviour {
    public GameObject fridgeUp;
    public GameObject fridgeDown;
    public bool isUp;

    public DangerZone dangerZone;

    void OnInteract(MonoBehaviour sender)
    {

        Debug.Log("Pressed fridge." + this.isUp);

        if (isUp)
        {
            //Drop the fridge
            dangerZone.KillOccupants();
            fridgeDown.SetActive(true);
            fridgeUp.SetActive(false);
          
        }
        else
        {
            fridgeDown.SetActive(false);
            fridgeUp.SetActive(true);
            
        }
        isUp = !isUp;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
