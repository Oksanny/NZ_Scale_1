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
    public Text LabelTotalToken;
    public GameObject TotalPoints;
    public RectTransform MaskTotalPonts;
	// Use this for initialization
	void Start ()
	{
	    currentTime = StringConstants.TimeGame;
        TotalPoints.SetActive(true);
        CommonData.prefabs.gameobjectLookup[StringConstants.PrefaArrowPivot].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
	    if (StartTime&&!StopTime)
	    {
	        currentTime -= Time.deltaTime;
            if (currentTime<=180f)
            {
                AddBonuse();
                
            }
	        if (currentTime<=0)
	        {
	            currentTime = 0;
	            StopTime = true;
                CommonData.mainManager.stateManager.SwapState(new ShowMissionFailed());
	        }
            SetToken();
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

    void SetToken()
    {
        int total = CommonData.currentUser.data.Plus + CommonData.currentUser.data.Minus + CommonData.currentUser.data.TimeBonus;
        int GameTotal = (int)StringConstants.BancomatReward + (int)StringConstants.ElephantReward + (int)StringConstants.LionReward +
                        (int)StringConstants.CrocodiletReward + (int)StringConstants.SpecialBonusReward+(int)StringConstants.TimeGame;
        MaskTotalPonts.localScale = new Vector3((float)total/GameTotal, 1, 1);
        Debug.Log("total="+total+"   GameTotal="+GameTotal+"   scale="+(float)total/GameTotal);
        if (total > 0)
        {
            
            LabelTotalToken.text = "+" + total.ToString() ;
            
        }
        if (total < 0)
        {

            LabelTotalToken.text = total.ToString();
        }
        if (total == 0)
        {
            LabelTotalToken.text = "0";
        }
    }
    void AddBonuse()
    {
        int bonuse = 0;
        int current = (int)StringConstants.TimeGame - (int)CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].GetComponent<ControllerTime>().currentTime;
        Debug.Log(current);
        if (current <= StringConstants.TimePoint_1)
        {
            Debug.Log("1");
            bonuse = ((int)StringConstants.TimePoint_1 - current) * 20 +
                     ((int)StringConstants.TimePoint_2 - (int)StringConstants.TimePoint_1) * 10;
        }
        else
        {
            if (current <= StringConstants.TimePoint_2)
            {
                Debug.Log("2");
                bonuse = ((int)StringConstants.TimePoint_2 - current) * 10;
            }
            else
            {
                if (current <= StringConstants.TimePoint_3)
                {
                    Debug.Log("3");
                    bonuse = (current - (int)StringConstants.TimePoint_2) * (-5);
                }
                else
                {
                    if (current <= StringConstants.TimeGame)
                    {
                        Debug.Log("4");
                        bonuse = (current - (int)StringConstants.TimePoint_3) * (-10) + ((int)StringConstants.TimePoint_3 - (int)StringConstants.TimePoint_2) * (-5);
                    }
                }
            }
        }
        CommonData.currentUser.data.TimeBonus = bonuse;
      // if (bonuse >= 0)
      // {
      //     CommonData.currentUser.data.Plus += bonuse;
      // }
      // else
      // {
      //     CommonData.currentUser.data.Minus += bonuse;
      // }
        Debug.Log(bonuse);
    }
}
