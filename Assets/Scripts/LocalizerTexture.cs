using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizerTexture : MonoBehaviour
{
    public Material ServProv_1;
    public Material ServProv_2;

    public Material SmartPhone_1;
    public Material SmartPhone_2;

    public Material Insurance_1;
    public Material Insurance_2;

    public Texture ServProv_1_ENG;         
    public Texture ServProv_2_ENG;

    public Texture SmartPhone_1_ENG;
    public Texture SmartPhone_2_ENG;

    public Texture Insurance_1_ENG;
    public Texture Insurance_2_ENG;

    public Texture ServProv_1_GM;
    public Texture ServProv_2_GM;

    public Texture SmartPhone_1_GM;
    public Texture SmartPhone_2_GM;

    public Texture Insurance_1_GM;
    public Texture Insurance_2_GM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEG()
    {
        ServProv_1.mainTexture = ServProv_1_ENG;
        ServProv_2.mainTexture = ServProv_2_ENG;

        SmartPhone_1.mainTexture = SmartPhone_1_ENG;
        SmartPhone_2.mainTexture = SmartPhone_2_ENG;

        Insurance_1.mainTexture = Insurance_1_ENG; ;
        Insurance_2.mainTexture = Insurance_2_ENG; ;
    }
    public void SetGM()
    {
        ServProv_1.mainTexture = ServProv_1_GM;
        ServProv_2.mainTexture = ServProv_2_GM;

        SmartPhone_1.mainTexture = SmartPhone_1_GM;
        SmartPhone_2.mainTexture = SmartPhone_2_GM;

        Insurance_1.mainTexture = Insurance_1_GM; ;
        Insurance_2.mainTexture = Insurance_2_GM; ;
    }
}
