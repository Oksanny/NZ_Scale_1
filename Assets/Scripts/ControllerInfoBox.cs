﻿using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerInfoBox : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowServiceProv ShowServiceProvider;
    public GameObject FrameConnectaPhone;
    public GameObject FramePolacone;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)
        if (Input.touchCount == 1)
        {

            Touch touch = Input.touches[0];

            ray = CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<Camera>().ScreenPointToRay(Input.touches[0].position);
            if (touch.phase == TouchPhase.Stationary && Physics.Raycast(ray.origin, ray.direction, out hit))
            {

                switch (hit.collider.gameObject.name)
                {
                    case "ConnectaPhone":
                        FeetHitten = true;
                        FrameConnectaPhone.SetActive(true);
                        if (ShowServiceProvider != null)
                        {
                            ShowServiceProvider.SelecConnectaPhone();
                        }
                        break;
                    case "Polacon":
                        FeetHitten = true;
                        FramePolacone.SetActive(true);
                        if (ShowServiceProvider != null)
                        {
                            ShowServiceProvider.SelecPolacon();
                        }
                        break;
                }

                // Debug.Log(hit.collider.gameObject.name);

            }
            else
                if ((touch.phase == TouchPhase.Ended && FeetHitten))
                {


                    FeetHitten = false;
                    
                }


        }
#else
                       //Mouse
        if (Input.GetMouseButtonDown(0))
        {

            ray = CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("It's working!");

                switch (hit.collider.gameObject.name)
                {
                    case "ConnectaPhone":
                        FeetHitten = true;
                        FrameConnectaPhone.SetActive(true);
                        if (ShowServiceProvider != null)
                        {
                            ShowServiceProvider.SelecConnectaPhone();
                        }
                        break;
                    case "Polacon":
                        FeetHitten = true;
                        FramePolacone.SetActive(true);
                        if (ShowServiceProvider != null)
                        {
                            ShowServiceProvider.SelecPolacon();
                        }
                        break;

                }

            }
            else
            {
                // Debug.Log("No hit");
            }

        }
        if (Input.GetMouseButtonUp(0) && FeetHitten)
        {
            FeetHitten = false;
            //  StartCoroutine(GetNewFeed());
            //Debug.Log("Mouse is UP");
        }
#endif
	}

    public void Rewind()
    {
        FrameConnectaPhone.SetActive(false);
        FramePolacone.SetActive(false);
    }

}
