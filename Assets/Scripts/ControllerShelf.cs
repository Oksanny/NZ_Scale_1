using System.Collections;
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
    public AudioSource AudioSource;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
                       
                        if (ShowAcssesorShop != null)
                        {
                            AudioSource.Play();
                            ShaderGlowCase.lightOn();
                            ShowAcssesorShop.SelectCase();
                            CommonData.currentUser.data.contAcssesur++;
                            // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "charger":
                        FeetHitten = true;
                       
                        if (ShowAcssesorShop != null)
                        {
                            AudioSource.Play();
                            ShaderGlowChenge.lightOn();
                            ShowAcssesorShop.SelectCharge();
                            CommonData.currentUser.data.contAcssesur++;
                           // hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Powerbank":
                        FeetHitten = true;
                       

                        if (ShowAcssesorShop != null)
                        {
                            AudioSource.Play();
                            ShaderGlowPowerBAnk_1.lightOn();
                            ShaderGlowPowerBAnk_2.lightOn();
                            ShowAcssesorShop.SelectPowerBank();
                            CommonData.currentUser.data.contAcssesur++;
                          //  hit.collider.gameObject.SetActive(false);
                        }
                        break;
                    case "Headphones_b_prefab":
                        
                        FeetHitten = true;
                        if (ShowAcssesorShop != null)
                        {
                            AudioSource.Play();
                            ShaderGlowPhone.lightOn();
                            ShowAcssesorShop.SelectPhone();
                            CommonData.currentUser.data.contAcssesur++;
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
