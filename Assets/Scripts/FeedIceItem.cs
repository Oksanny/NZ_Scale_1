﻿using System.Collections;
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
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("jaw"))
        {
           
            CrocodileController.HitCrocodile();


        }
        if (other.gameObject.name.Contains("Plane"))
        {

           // CrocodileController.MissCrocodile();


        }
    }
    public void SelfDestruct()
    {
        StartCoroutine(Destruct());
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(1f);
        
       CrocodileController.MissCrocodile();
       yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
