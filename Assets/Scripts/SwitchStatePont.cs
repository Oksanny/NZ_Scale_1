using System;
using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class SwitchStatePont : MonoBehaviour
{
    private bool enter;
    private bool exit;
    private Vector3 PointShark;
    private Vector3 PointElaphant;
    private Vector3 PointLion;
    private Vector3 PointCrocodile;
    private bool sharkAl;
    private bool elephantAl;
    private bool lionAl;
    private bool crocodileAl;
    // Use this for initialization
    void Start()
    {
        enter = true;
        exit = false;
        sharkAl = false;
        elephantAl = false;
        lionAl = false;
        crocodileAl = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonData.StateAnimal)
        {
            PointShark = new Vector3(CommonData.prefabs.gameobjectLookup["Point_Shark"].transform.position.x, 0, CommonData.prefabs.gameobjectLookup["Point_Shark"].transform.position.z);
            PointElaphant = new Vector3(CommonData.prefabs.gameobjectLookup["Point_Elephant"].transform.position.x, 0, CommonData.prefabs.gameobjectLookup["Point_Elephant"].transform.position.z);
            PointLion = new Vector3(CommonData.prefabs.gameobjectLookup["Point_Lion"].transform.position.x, 0, CommonData.prefabs.gameobjectLookup["Point_Lion"].transform.position.z);
            PointCrocodile = new Vector3(CommonData.prefabs.gameobjectLookup["Point_Crocodile"].transform.position.x, 0, CommonData.prefabs.gameobjectLookup["Point_Crocodile"].transform.position.z);
            Vector3 camerPosition = new Vector3(transform.position.x, 0, transform.position.z);

            if (enter)
            {
                if (Vector3.Distance(camerPosition, PointShark) < 0.25f)
                {
                    enter = false;
                    exit = true;

                    sharkAl = true;
                    elephantAl = false;
                    lionAl = false;
                    crocodileAl = false;
                    CommonData.mainManager.stateManager.PushState(new ShowShark());
                }
                if (Vector3.Distance(camerPosition, PointElaphant) < 0.25f)
                {
                    enter = false;
                    exit = true;

                    sharkAl = false;
                    elephantAl = true;
                    lionAl = false;
                    crocodileAl = false;
                    CommonData.mainManager.stateManager.PushState(new ShowElephant());
                }
                if (Vector3.Distance(camerPosition, PointLion) < 0.25f)
                {
                    enter = false;
                    exit = true;

                    sharkAl = false;
                    elephantAl = false;
                    lionAl = true;
                    crocodileAl = false;
                    CommonData.mainManager.stateManager.PushState(new ShowLion());
                }
                if (Vector3.Distance(camerPosition, PointCrocodile) < 0.25f)
                {
                    enter = false;
                    exit = true;

                    sharkAl = false;
                    elephantAl = false;
                    lionAl = false;
                    crocodileAl = true;
                    CommonData.mainManager.stateManager.PushState(new ShowCrocodile());
                }
            }
            if (exit)
            {
                if (sharkAl && Vector3.Distance(camerPosition, PointShark) > 0.25f)
                {
                    enter = true;
                    exit = false;
                    sharkAl = false;
                    Debug.Log("EXIT Point");

                    CommonData.mainManager.stateManager.PopState();
                }
                if (elephantAl && Vector3.Distance(camerPosition, PointElaphant) > 0.25f)
                {
                    enter = true;
                    exit = false;
                    elephantAl = false;
                    Debug.Log("EXIT Point");

                    CommonData.mainManager.stateManager.PopState();
                }
                if (lionAl && Vector3.Distance(camerPosition, PointLion) > 0.25f)
                {
                    enter = true;
                    exit = false;
                    lionAl = false;
                    Debug.Log("EXIT Point");

                    CommonData.mainManager.stateManager.PopState();
                }
                if (crocodileAl && Vector3.Distance(camerPosition, PointCrocodile) > 0.25f)
                {
                    enter = true;
                    exit = false;
                    crocodileAl = false;
                    Debug.Log("EXIT Point");

                    CommonData.mainManager.stateManager.PopState();
                }
            } 
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Point_Shark"))
        {
            Debug.Log("Point");
            //   CommonData.mainManager.stateManager.PushState(new ShowShark());


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
