using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class SwitchStatePont : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Point_Shark"))
        {
            Debug.Log("Point");
            CommonData.mainManager.stateManager.PushState(new ShowShark());


        }
        if (other.gameObject.name.Contains("Point_Crocodile"))
        {
            Debug.Log("Point");
            CommonData.mainManager.stateManager.PushState(new ShowCrocodile());


        }
        if (other.gameObject.name.Contains("Point_Elephant"))
        {
            Debug.Log("Point");
            CommonData.mainManager.stateManager.PushState(new ShowElephant());


        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Point_Shark"))
        {
            Debug.Log("EXIT Point");

            CommonData.mainManager.stateManager.PopState();

        }
        if (other.gameObject.name.Contains("Point_Crocodile"))
        {
            Debug.Log("EXIT Point");

            CommonData.mainManager.stateManager.PopState();

        }
        if (other.gameObject.name.Contains("Point_Elephant"))
        {
            Debug.Log("EXIT Point");

            CommonData.mainManager.stateManager.PopState();

        }
    }
}
