using System.Collections;
using System.Collections.Generic;
using Jacovone;
using States;
using UnityEngine;

public class ControllerSharkFeed : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public PathMagic PathFlight;
    public GameObject FeedInstant;
    public GameObject SpawnFeed;
    public ShowShark ShowShark;
    // Use this for initialization
    private void Start()
    {
        Instant();
    }

    // Update is called once per frame
    private void Update()
    {
#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)
        if (Input.touchCount == 1)
        {

            Touch touch = Input.touches[0];

            ray = CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<Camera>().ScreenPointToRay(Input.touches[0].position);
            if (touch.phase == TouchPhase.Stationary && Physics.Raycast(ray.origin, ray.direction, out hit))
            {

                if (hit.collider.gameObject.name.Contains("Feed") )
                {
                    FeetHitten = true;
                    StartFlight();
                }

                // Debug.Log(hit.collider.gameObject.name);

            }
            else
                if ((touch.phase == TouchPhase.Ended && FeetHitten))
                {


                    FeetHitten = false;
                    
                }


        }
#else
        //Mouse
        if (Input.GetMouseButtonDown(0))
        {
             Debug.Log("Mouse is down");
             ray = CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                 Debug.Log("It's working!");


                if (hit.collider.gameObject.name.Contains("Feed"))
                {
                    // Debug.Log("It's working!");
                    FeetHitten = true;
                    StartFlight();
                }
                else
                {
                    //Debug.Log("nopz");
                }
            }
            else
            {
                // Debug.Log("No hit");
            }

        }
        if (Input.GetMouseButtonUp(0) && FeetHitten)
        {
            FeetHitten = false;
          //  StartCoroutine(GetNewFeed());
            //Debug.Log("Mouse is UP");
        }
#endif
    }

    public void Instant()
    {
        GameObject feedHolder = (GameObject)Instantiate(FeedInstant, SpawnFeed.transform.position, SpawnFeed.transform.rotation);
        feedHolder.gameObject.transform.parent = gameObject.transform;
        feedHolder.GetComponent<FeedSharkItem>().SharkController = this;
        PathFlight.Target = feedHolder.transform;
        PathFlight.Stop();
    }

    public void StartFlight()
    {
        PathFlight.Play();
    }

    public void ChangeAnimation()
    {
        ShowShark.ChangeAnimation();
    }
    public void StopPath()
    {
        GameObject destroyFeed = PathFlight.Target.gameObject;
        PathFlight.Target = null;
        PathFlight.Pause();
        Destroy(destroyFeed);
        PathFlight.Stop();
        Instant();
    }
    public void Point_1()
    {
        Debug.Log("Point_1");
        
    }

    public void Point_2()
    {
       Debug.Log("Point_2");
        StopPath();

    }
}
