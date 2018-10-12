using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerInfoBox : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public AudioClip SmartiCall_2_salesrep_Station_1a;
    public AudioClip SmartiCall_2_salesrep_Station_1b;
    public AudioClip Click_Button;
    public ShowServiceProv ShowServiceProvider;
    public GameObject FrameConnectaPhone;
    public GameObject FramePolacone;
    public AudioSource AudioSource;
    public shaderGlow Smartphone_Big_Glow;
    public shaderGlow Smartphone_Small_Glow;
    public Animator Nathan_Animator;
    private bool animationCompleet;
    private bool checkPlay;
	// Use this for initialization
	void Start ()
	{
	    
	}
	
	// Update is called once per frame
	void Update () {
//#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)
//        if (Input.touchCount == 1)
//        {
//
//            Touch touch = Input.touches[0];
//
//            ray = CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<Camera>().ScreenPointToRay(Input.touches[0].position);
//            if (touch.phase == TouchPhase.Stationary && Physics.Raycast(ray.origin, ray.direction, out hit))
//            {
//
//                switch (hit.collider.gameObject.name)
//                {
//                    case "ConnectaPhone":
//
//                        FeetHitten = true;
//                        if (ShowServiceProvider != null)
//                        {
//                            
//                            FrameConnectaPhone.SetActive(true);
//                            ShowServiceProvider.SelecConnectaPhone();
//                        }
//                        break;
//                    case "Polacon":
//                        FeetHitten = true;
//                        
//                        if (ShowServiceProvider != null)
//                        {
//                            FramePolacone.SetActive(true);
//                            ShowServiceProvider.SelecPolacon();
//                        }
//                        break;
//                }
//
//                // Debug.Log(hit.collider.gameObject.name);
//
//            }
//            else
//                if ((touch.phase == TouchPhase.Ended && FeetHitten))
//                {
//
//
//                    FeetHitten = false;
//                    
//                }
//
//
//        }
//#else
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
                        if (animationCompleet&&ShowServiceProvider != null)
                        {
                            AudioSource.Play();
                            FrameConnectaPhone.SetActive(true);
                            ShowServiceProvider.SelecConnectaPhone();
                        }
                        break;
                    case "Polacon":
                        FeetHitten = true;

                        if (animationCompleet && ShowServiceProvider != null)
                        {
                            AudioSource.Play();
                            FramePolacone.SetActive(true);
                            ShowServiceProvider.SelecPolacon();
                        }
                        break;
                    case "Smartphone_Big":
                        FeetHitten = true;

                        if (animationCompleet && ShowServiceProvider != null)
                        {
                            AudioSource.Play();
                            Smartphone_Big_Glow.lightOn();
                            ShowServiceProvider.SelecPhone_Big();
                            animationCompleet = false;
                        }
                        break;
                    case "Smartphone_Small":
                        FeetHitten = true;

                        if (animationCompleet && ShowServiceProvider != null)
                        {
                            AudioSource.Play();
                            Smartphone_Small_Glow.lightOn();
                            ShowServiceProvider.SelecPhone_Small();
                            animationCompleet = false;
                        }
                        break;

                }

            }
            else
            {
                // Debug.Log("No hit");
            }

        }
        
//#endif
	}

    public void Rewind()
    {
        StopCoroutine(PlayEngineSound());
        AudioSource.Stop();
        Nathan_Animator.SetTrigger("Idle");
        animationCompleet = false;
        checkPlay = false;
        // FrameConnectaPhone.SetActive(false);
        // FramePolacone.SetActive(false);
    }

    public void StartPlaySound()
    {
        checkPlay = true;
        StartCoroutine(PlayEngineSound());
        Nathan_Animator.SetTrigger("Laughing");
    }
    IEnumerator PlayEngineSound()
    {
        if (checkPlay)
        {
            AudioSource.clip = SmartiCall_2_salesrep_Station_1a;

            AudioSource.Play();
        }
       
        yield return new WaitForSeconds(AudioSource.clip.length);
        if (checkPlay)
        {
            AudioSource.clip = SmartiCall_2_salesrep_Station_1b;
            AudioSource.Play();
        }
        
        yield return new WaitForSeconds(AudioSource.clip.length);
        if (checkPlay)
        {
            Nathan_Animator.SetTrigger("Idle");
            animationCompleet = true;
            AudioSource.clip = Click_Button;
        }
        
    }
}
