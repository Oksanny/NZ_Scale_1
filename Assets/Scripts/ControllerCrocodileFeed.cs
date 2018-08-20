using System.Collections;
using System.Collections.Generic;
using Jacovone;
using States;
using UnityEngine;

public class ControllerCrocodileFeed : MonoBehaviour {
    Ray ray;
    RaycastHit hit;
    private bool FeetHitten;
    public float Force;
    public GameObject Feed;
    public GameObject DirectionShoot;

   
    public GameObject FeedInstant;
    public GameObject SpawnFeed;
    public ShowCrocodile ShowCrocodile;
    // Use this for initialization
    private void Start()
    {
       
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

                if (hit.collider.gameObject.name.Contains("icePop") )
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
           // Debug.Log("Mouse is down");
            ray = CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
               // Debug.Log("It's working!");


                if (hit.collider.gameObject.name.Contains("icePop"))
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
  public    void GetNewFeed()
    {
        
        GameObject feedHolder = (GameObject)Instantiate(FeedInstant, SpawnFeed.transform.position, SpawnFeed.transform.rotation);
        feedHolder.gameObject.transform.parent = gameObject.transform;

        Feed = feedHolder;

    }
    void ShootFeed()
    {
        Vector3 direction = DirectionShoot.transform.position - SpawnFeed.transform.position;

        // Feed.GetComponent<CapsuleCollider>().enabled = true;
        Feed.GetComponent<Rigidbody>().AddForce(new Vector3(direction.normalized.x * Force, direction.normalized.y * Force, direction.normalized.z * Force));
        Feed.GetComponent<Rigidbody>().useGravity = true;
        Feed.GetComponent<FeedIceItem>().CrocodileController = this;
        Feed.GetComponent<FeedIceItem>().SelfDestruct();
    }
    

     void StartFlight()
    {
        if (ShowCrocodile != null)
        {
            ShowCrocodile.SetAnimationFightEating();
        }
        
        ShootFeed();
        // PathFlight.Play();
    }

    public void MissCrocodile()
    {
        if (ShowCrocodile!=null)
        {
            ShowCrocodile.SetAnimationEndShoot();
        }
        
        
        StartCoroutine(SpawnFeedAfterMiss());
    }
    public void HitCrocodile()
    {
        if (ShowCrocodile != null)
        {
            ShowCrocodile.SetAnimationEating();
        }
        
        if (Feed != null)
        {
            Destroy(Feed);
        }
        StartCoroutine(SpawnFeedAfterHiT());
    }

    public void DeleteFeed()
    {
        if (Feed!=null)
        {
            Destroy(Feed);
        }
        
    }
    IEnumerator SpawnFeedAfterHiT()
    {
        yield return new WaitForSeconds(2.5f);
        GetNewFeed();
    }
    IEnumerator SpawnFeedAfterMiss()
    {
        yield return null;
        GetNewFeed();
      // yield return new WaitForSeconds(5f);
      // if (Feed != null)
      // {
      //     Destroy(Feed);
      // }
    }
}
