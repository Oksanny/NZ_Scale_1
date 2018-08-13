using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtMagicPath : MonoBehaviour
{
    public  bool Align;
    public Transform target;
    public Toggle check;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (check.isOn)
	    {
            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = rotation;
	        Align = true;
	    }
	    else
	    {
	        Align = false;
	    }
	}
}
