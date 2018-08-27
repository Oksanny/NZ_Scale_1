using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class ControllerArrow : MonoBehaviour
{
    public PathMagic PathArrow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rewind()
    {
        PathArrow.Stop();
        PathArrow.Play();

    }
}
