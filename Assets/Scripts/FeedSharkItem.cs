using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedSharkItem : MonoBehaviour
{
    public ControllerSharkFeed SharkController;
    private bool checkCollider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("LowerJaw"))
        {
            Debug.Log("HIT");
            if (SharkController != null)
            {
                checkCollider = true;
                SharkController.HitShark();
            }
            


        }
        if (other.gameObject.name.Contains("Floor"))
        {
            if (SharkController!=null)
            {
                checkCollider = true;
                SharkController.MissShark();
            }

           


        }
    }

}
