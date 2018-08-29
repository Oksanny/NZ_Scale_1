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
        FrameInsuramore.SetActive(false);
        FramePlanetsure.SetActive(false);
    }

}
