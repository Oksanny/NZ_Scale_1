﻿using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerShelf : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowAcssesorShop ShowAcssesorShop;
    public shaderGlow ShaderGlowPhone;
    public shaderGlow ShaderGlowPowerBAnk_1;
    public shaderGlow ShaderGlowPowerBAnk_2;
    public shaderGlow ShaderGlowCase;
    public shaderGlow ShaderGlowChenge;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)
        if (Input.touchCount == 1)
        {

            Touch touch = Input.touches[0];

            ray = CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<Camera>().ScreenPointToRay(Input.touches[0].position);
            if (touch.phase == TouchPhase.Stationary && Physics.Raycast(ray.origin, ray.direction, out hit))
            {

                switch (hit.collider.gameObject.name)
                {
                    case "deer_head_case":
                        FeetHitten = true;
                        ShaderGlowCase.lightOn();
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectCase();
                           // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "charger":
                        FeetHitten = true;
                        ShaderGlowChenge.lightOn();
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectCharge();
                           // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Powerbank":
                        FeetHitten = true;
                        ShaderGlowPowerBAnk_1.lightOn();
                        ShaderGlowPowerBAnk_2.lightOn();

                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectPowerBank();
                          //  hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Headphones_b_prefab":
                        ShaderGlowPhone.lightOn();
                        FeetHitten = true;
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectPhone();
                           // hit.collider.gameObject.SetActive(false);
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
                    case "deer_head_case":
                        FeetHitten = true;
                        ShaderGlowCase.lightOn();
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectCase();
                           // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "charger":
                        FeetHitten = true;
                        ShaderGlowChenge.lightOn();
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectCharge();
                           // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Powerbank":
                        FeetHitten = true;
                        ShaderGlowPowerBAnk_1.lightOn();
                        ShaderGlowPowerBAnk_2.lightOn();

                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectPowerBank();
                          //  hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Headphones_b_prefab":
                        ShaderGlowPhone.lightOn();
                        FeetHitten = true;
                        if (ShowAcssesorShop != null)
                        {
                            ShowAcssesorShop.SelectPhone();
                           // hit.collider.gameObject.SetActive(false);
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
        ShaderGlowCase.lightOff();
        ShaderGlowChenge.lightOff();
        ShaderGlowPowerBAnk_1.lightOff();
        ShaderGlowPowerBAnk_2.lightOff();
        ShaderGlowPhone.lightOff();
    }
    public void SelectPhone()
    {
        if (ShowAcssesorShop != null)
        {
            ShowAcssesorShop.SelectPhone();
        }
    }
    public void SelectCase()
    {
        if (ShowAcssesorShop != null)
        {
            ShowAcssesorShop.SelectCase();
        }
    }
    public void SelectChange()
    {
        if (ShowAcssesorShop != null)
        {
            ShowAcssesorShop.SelectCharge();
        }
    }
    public void SelectPowerBank()
    {
        if (ShowAcssesorShop != null)
        {
            ShowAcssesorShop.SelectPowerBank();
        }
    }

}
