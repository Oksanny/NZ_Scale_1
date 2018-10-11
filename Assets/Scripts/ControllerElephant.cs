using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerElephant : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public shaderGlow ShaderGlow;
    public ShowElephant ShowElephant;
    public int countHit;
    public AudioSource AudioSource;
    public BoxCollider ColliderCheck;
    // Use this for initialization
    void Start()
    {
        countHit = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Mouse
        if (Input.GetMouseButtonDown(0))
        {

            ray = CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("It's working!");


                if (hit.collider.gameObject.name.Contains("spine1_hiResSpine1"))
                {
                    if (ShowElephant != null)
                    {
                        countHit++;
                        ShaderGlow.lightOn();
                       
                        if (countHit == 3)
                        {
                            countHit = 0;


                            ShowElephant.ShowResult();
                            AudioSource.Play();
                            StartCoroutine(HideShaderGlow_End());


                        }
                        else
                        {
                            StartCoroutine(HideShaderGlowHit());
                        }
                    }

                     Debug.Log("It's Baby");


                }
                else
                {
                    if (ShowElephant != null)
                    {
                        Debug.Log("No Baby_2");
                        ShowElephant.ShowMiss();
                    }
                    Debug.Log("No Baby");
                }
            }
            else
            {
                if (ShowElephant != null)
                {
                    Debug.Log("No hit_2");
                    ShowElephant.ShowMiss();
                }
                 Debug.Log("No hit");
            }

        }

    }

    IEnumerator HideShaderGlowHit()
    {
        yield return new WaitForSeconds(0.5f);
        ShaderGlow.lightOff(); 
        
    }
    IEnumerator HideShaderGlow_End()
    {
        yield return new WaitForSeconds(6f);
        
            ShaderGlow.lightOff();
       
       
    }
}
