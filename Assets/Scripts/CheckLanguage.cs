using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLanguage : MonoBehaviour
{
    public string Language;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLanguage()
    {
        CommonData.Language = Language;
    }
}
