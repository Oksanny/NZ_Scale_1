using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;
using UnityEngine.UI;

public class ControllerTime : MonoBehaviour
{
    public  float currentTime;
    public  bool StartTime;
    public  bool StopTime;
    private bool AddedBonuse;
    public Text LabelTime;
	// Use this for initialization
	void Start ()
	{
	    currentTime = StringConstants.TimeGame;
	}
	
	// Update is called once per frame
	void Update () {
	    if (StartTime&&!StopTime)
	    {
	        currentTime -= Time.deltaTime;
	        if (currentTime<=0)
	        {
	            currentTime = 0;
	            StopTime = true;
                CommonData.mainManager.stateManager.SwapState(new ShowMissionFailed());
	        }
	        SetTime();
	    }
	    
	}

    void SetTime()
    {
        int current = (int) currentTime;
        int min = current / 60;
        int sec = current%60;
        if (sec<10)
        {
            LabelTime.text = "0" + min.ToString() + " : 0" + sec.ToString();
        }
        else
        {
            LabelTime.text = "0" + min.ToString() + " : " + sec.ToString();
        }
        
    }

    void AddBonuse()
    {
        int bonuse=0;
        int current = (int)StringConstants.TimeGame - (int)currentTime;
        Debug.Log(current);
        if (current<=StringConstants.TimePoint_1)
        {
            Debug.Log("1");
            bonuse = ((int)StringConstants.TimePoint_1 - current)*20 +
                     ((int)StringConstants.TimePoint_2 - (int)StringConstants.TimePoint_1) * 10;
        }
        else
        {
            if (current <= StringConstants.TimePoint_2)
            {
                Debug.Log("2");
                bonuse = ((int)StringConstants.TimePoint_2 - current) * 10 ;
            }
            else
            {
                if (current <= StringConstants.TimePoint_3)
                {
                    Debug.Log("3");
                    bonuse = (current-(int)StringConstants.TimePoint_2) * (-5);
                }
                else
                {
                    if (current <= StringConstants.TimeGame)
                    {
                        Debug.Log("4");
                        bonuse = (current - (int)StringConstants.TimePoint_3) * (-10) + ((int)StringConstants.TimePoint_3 - (int)StringConstants.TimePoint_2)*(-5);
                    }
                }
            }
        }
        if (bonuse>=0)
        {
           
        }
        Debug.Log(bonuse);
    }
}
