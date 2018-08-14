using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class ControllerLetter : MonoBehaviour
{
    public WritingHandler WrHandler;
    public ShowLion ShowLion;
    private float timeN = 10f;
    private float timeZ = 10;
    private float time;
    private float currentTime;
	// Use this for initialization
	void Start ()
	{
	    time = timeN;
	}
	
	// Update is called once per frame
	void Update ()
	{
	  // if (WritingHandler.currentLetterIndex==0)
	  // {
      //     time = timeN;
	  // }
      // if (WritingHandler.currentLetterIndex == 1)
      // {
      //     time = timeZ;
      // }
      // currentTime += Time.deltaTime;
      // if (currentTime >= time && !WrHandler.clickStarted)
      // {
      //     currentTime = 0;
      //     ShowLion.CheckTime();
      //     WrHandler.RefreshProcess();
      // }
	}
}
