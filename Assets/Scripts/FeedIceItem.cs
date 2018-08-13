using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedIceItem : MonoBehaviour {

    public ControllerCrocodileFeed CrocodileController;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("spine1_loResSpine1"))
        {
            Debug.Log("HIT Croc");
            CrocodileController.StopPath();
            CrocodileController.ChangeAnimation();


        }
    }
}
