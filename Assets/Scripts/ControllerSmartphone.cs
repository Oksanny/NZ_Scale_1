﻿using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerSmartphone : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public AudioClip SmartiCall_2_salesrep_Station_2a;
    public AudioClip SmartiCall_2_salesrep_Station_2b;
    public AudioClip Click_Button;
    public AudioSource AudioSource;
    public ShowSmartphone ShowSmartphone;
    public GameObject FrameSmarticall_9;
    public GameObject FrameCommunata_8;
    public shaderGlow PhoneSmarticall_9;
    public shaderGlow PhoneCommunata_8;

    public shaderGlow PhoneGlow_1;
    public shaderGlow PhoneGlow_2;
    public shaderGlow PhoneGlow_3;
    public shaderGlow PhoneGlow_4;
    private bool animationCompleet;
    public Animator Nathan_Animator;
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
                    case "Smarticall_9":
                        FeetHitten = true;

                        if (ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            FrameSmarticall_9.SetActive(true);
                            PhoneSmarticall_9.lightOn();
                            ShowSmartphone.SelectSmartical();
                            CommonData.currentUser.data.SmarticallBuy = true;
                        }
                        break;
                    case "Smartphone_Smart":
                        FeetHitten = true;

                        if (ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            FrameSmarticall_9.SetActive(true);
                            PhoneSmarticall_9.lightOn();
                            ShowSmartphone.SelectSmartical();
                            CommonData.currentUser.data.SmarticallBuy = true;
                        }
                        break;
                    case "Communata_8":
                        FeetHitten = true;

                        if (ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneCommunata_8.lightOn();
                            FrameCommunata_8.SetActive(true);
                            ShowSmartphone.SelectCommunata();
                        }
                        break;
                    case "Smartphone_Communata":
                        FeetHitten = true;

                        if (ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneCommunata_8.lightOn();
                            FrameCommunata_8.SetActive(true);
                            ShowSmartphone.SelectCommunata();
                        }
                        break;
                    case "Phone_1_Black":
                        FeetHitten = true;

                        if (animationCompleet && ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_1.lightOn();

                            ShowSmartphone.SelectPhone_1();
                        }
                        break;
                    case "Phone_2_White":
                        FeetHitten = true;

                        if (animationCompleet && ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_2.lightOn();

                            ShowSmartphone.SelectPhone_2();
                        }
                        break;
                    case "Phone_3_Metalic":
                        FeetHitten = true;

                        if (animationCompleet && ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_3.lightOn();

                            ShowSmartphone.SelectPhone_3();
                        }
                        break;
                    case "Phone_4_Gold":
                        FeetHitten = true;

                        if (animationCompleet && ShowSmartphone != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_4.lightOn();

                            ShowSmartphone.SelectPhone_4();
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
    public void StartPlaySound()
    {

        StartCoroutine(PlayEngineSound());
        Nathan_Animator.SetTrigger("Laughing");
    }
    IEnumerator PlayEngineSound()
    {

        AudioSource.clip = SmartiCall_2_salesrep_Station_2a;

        AudioSource.Play();


        yield return new WaitForSeconds(AudioSource.clip.length);

        AudioSource.clip = SmartiCall_2_salesrep_Station_2b;
        AudioSource.Play();


        yield return new WaitForSeconds(AudioSource.clip.length-1.7f);

        Nathan_Animator.SetTrigger("Idle");
        animationCompleet = true;
        AudioSource.clip = Click_Button;


    }
    public void Rewind()
    {
        FrameSmarticall_9.SetActive(false);
        PhoneSmarticall_9.lightOff();
        PhoneCommunata_8.lightOff();
        FrameCommunata_8.SetActive(false);
    }

}
