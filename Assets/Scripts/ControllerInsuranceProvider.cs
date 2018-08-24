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
                    case "Insuramore":
                        FeetHitten = true;
                        if (ShowInsuranceeProvider != null)
                        {
                            ShowInsuranceeProvider.SelecInsuramore();
                        }
                        break;
                    case "Planetsure":
                        FeetHitten = true;
                        if (ShowInsuranceeProvider != null)
                        {
                            ShowInsuranceeProvider.SelecPlanetsure();
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
                    case "Insuramore":
                        FeetHitten = true;
                        if (ShowInsuranceeProvider != null)
                        {
                            ShowInsuranceeProvider.SelecInsuramore();
                        }
                        break;
                    case "Planetsure":
                        FeetHitten = true;
                        if (ShowInsuranceeProvider != null)
                        {
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
        if (Input.GetMouseButtonUp(0) && FeetHitten)
        {
            FeetHitten = false;
            //  StartCoroutine(GetNewFeed());
            //Debug.Log("Mouse is UP");
        }
#endif
    }

    

}
