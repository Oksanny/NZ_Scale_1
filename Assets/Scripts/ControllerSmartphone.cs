using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerSmartphone : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowSmartphone ShowSmartphone;
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
                    case "Smarticall_9":
                        FeetHitten = true;
                        if (ShowSmartphone != null)
                        {
                            ShowSmartphone.SelectSmartical();
                        }
                        break;
                    case "Communata_8":
                        FeetHitten = true;
                        if (ShowSmartphone != null)
                        {
                            ShowSmartphone.SelectCommunata();
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
                    case "Smarticall_9":
                        FeetHitten = true;
                        if (ShowSmartphone != null)
                        {
                            ShowSmartphone.SelectSmartical();
                        }
                        break;
                    case "Communata_8":
                        FeetHitten = true;
                        if (ShowSmartphone != null)
                        {
                            ShowSmartphone.SelectCommunata();
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
