using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerBancomat : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowBancomat ShowBancomat;
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

                if (hit.collider.gameObject.name.Contains("Geldautomat_1") )
                {
                    
                    // Debug.Log("It's working!");
                    FeetHitten = true;
                   if (ShowBancomat!=null)
                    {
                        ShowBancomat.SelectBancomat();
                    }
                   
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


                if (hit.collider.gameObject.name.Contains("Geldautomat_1"))
                {

                    // Debug.Log("It's working!");
                    FeetHitten = true;
                    if (ShowBancomat != null)
                    {
                        ShowBancomat.SelectBancomat();
                    }

                }
                else
                {
                    //Debug.Log("nopz");
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
