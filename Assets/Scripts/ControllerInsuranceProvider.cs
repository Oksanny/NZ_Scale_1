using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerInsuranceProvider : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowInsuranceeProvider ShowInsuranceeProvider;
    public GameObject FrameInsuramore;
    public GameObject FramePlanetsure;
    public AudioClip SmartiCall_2salesrep_Station3;
    public AudioClip Click_Button;
    public AudioSource AudioSource;
    public shaderGlow PhoneGlow_1;
    public shaderGlow PhoneGlow_2;
    public shaderGlow PhoneGlow_3;
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
                    case "Insuramore":
                       
                        FeetHitten = true;
                       
                        if (ShowInsuranceeProvider != null)
                        {
                            AudioSource.Play();
                            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowInsuranceBox].SetActive(false);
                            FrameInsuramore.SetActive(true);
                            ShowInsuranceeProvider.SelecInsuramore();
                        }
                        break;
                    case "Planetsure":
                        
                        FeetHitten = true;
                        
                        if (ShowInsuranceeProvider != null)
                        {
                            AudioSource.Play();
                            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowInsuranceBox].SetActive(false);
                            FramePlanetsure.SetActive(true);
                            ShowInsuranceeProvider.SelecPlanetsure();
                        }
                        break;
                    case "Phone_1_64":
                        FeetHitten = true;

                        if (animationCompleet && ShowInsuranceeProvider != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_1.lightOn();

                            ShowInsuranceeProvider.SelectPhone_1();
                        }
                        break;
                    case "Phone_2_128":
                        FeetHitten = true;

                        if (animationCompleet && ShowInsuranceeProvider != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_2.lightOn();

                            ShowInsuranceeProvider.SelectPhone_2();
                        }
                        break;
                    case "Phone_3_256":
                        FeetHitten = true;

                        if (animationCompleet && ShowInsuranceeProvider != null)
                        {
                            AudioSource.Play();
                            PhoneGlow_3.lightOn();

                            ShowInsuranceeProvider.SelectPhone_3();
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
        Nathan_Animator.SetTrigger("Pointing");
    }
    IEnumerator PlayEngineSound()
    {

        AudioSource.clip = SmartiCall_2salesrep_Station3;

        AudioSource.Play();


        yield return new WaitForSeconds(AudioSource.clip.length-1f);


        Nathan_Animator.SetTrigger("Idle");
        animationCompleet = true;
        AudioSource.clip = Click_Button;


    }
    public void Rewind()
    {
        FrameInsuramore.SetActive(false);
        FramePlanetsure.SetActive(false);
    }

}
