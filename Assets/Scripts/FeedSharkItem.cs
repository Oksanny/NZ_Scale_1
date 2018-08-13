using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSharkItem : MonoBehaviour
{
    public ControllerSharkFeed SharkController;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("PA_Shark"))
        {
            Debug.Log("HIT");
            SharkController.StopPath();
            SharkController.ChangeAnimation();


        }
    }

}
