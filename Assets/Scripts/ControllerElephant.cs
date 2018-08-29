using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerElephant : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public ShowElephant ShowElephant;
    public int countHit;
    public AudioSource AudioSource;
	// Use this for initialization
	void Start () {
		countHit=0;
	}
	
	// Update is called once per frame
	void Update () {

                       //Mouse
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("It's working!");


                if (hit.collider.gameObject.name.Contains("Baby_Elephant_FV_IP_MX_BRM"))
                {
                    countHit++;
                    if (countHit==3)
                    {
                        countHit = 0;
                        ShowElephant.ShowResult();
                        AudioSource.Play();
                        
                    }
                    // Debug.Log("It's working!");
                  
                    
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
        
	}
}
