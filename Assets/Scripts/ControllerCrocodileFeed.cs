using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Jacovone;
using States;
using UnityEngine;

public class ControllerCrocodileFeed : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
 
    public PathMagic PathExitCrocodile;
    public List<GameObject> MissFeeds = new List<GameObject>();
    private bool FeetHitten;
    public float Force;
    public GameObject Feed;
    public GameObject DirectionShoot;
    public AudioClip SmartiCall_2Alligator;
    public AudioClip Eating;
    public AudioClip Click_Button;
    public AudioSource AudioSource;
    public GameObject FeedInstant;
    public GameObject SpawnFeed;
    public ShowCrocodile ShowCrocodile;
    // Use this for initialization
    private void Start()
    {
        AudioSource.clip = Click_Button;
    }

    // Update is called once per frame
    private void Update()
    {

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
                    AudioSource.Play();
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

    }
    public void GetNewFeed()
    {
        if (Feed == null && ShowCrocodile != null)
        {
            Debug.Log("Instant");
            GameObject feedHolder = (GameObject)Instantiate(FeedInstant, SpawnFeed.transform.position, SpawnFeed.transform.rotation);
            feedHolder.gameObject.transform.parent = gameObject.transform;
            Feed = feedHolder;
        }


    }
    void ShootFeed()
    {
        if (ShowCrocodile != null)
        {
            Vector3 direction = DirectionShoot.transform.position - SpawnFeed.transform.position;

            Feed.GetComponent<BoxCollider>().isTrigger = false;
            Feed.GetComponent<Rigidbody>().AddForce(new Vector3(direction.normalized.x * Force, direction.normalized.y * Force, direction.normalized.z * Force));
            Feed.GetComponent<Rigidbody>().useGravity = true;
            Feed.GetComponent<FeedIceItem>().CrocodileController = this;
            Feed.GetComponent<FeedIceItem>().SelfDestruct();
        }

    }


    void StartFlight()
    {
        if (ShowCrocodile != null)
        {
            ShowCrocodile.SetAnimationFightEating();
            ShootFeed();
        }


        // PathFlight.Play();
    }

    public void MissCrocodile()
    {
        if (ShowCrocodile != null)
        {
            ShowCrocodile.SetAnimationEndShoot();
        }
        if (Feed != null)
        {
            Feed.gameObject.transform.parent = CommonData.prefabs.gameobjectLookup["Plane"].transform;
            MissFeeds.Add(Feed);
            Feed = null;
            if (MissFeeds.Count > 4)
            {
                GameObject tempItem = MissFeeds[0];
                MissFeeds.RemoveAt(0);
                Destroy(tempItem);
            }
        }


        StartCoroutine(SpawnFeedAfterMiss());
    }
    public void HitCrocodile()
    {
       
        CommonData.prefabs.gameobjectLookup["Jaw"].SetActive(true);
        if (Feed != null)
        {
            GameObject tempFeed = Feed;
            Feed = null;
            Destroy(tempFeed);
        }
        if (ShowCrocodile != null)
        {
            ShowCrocodile.SetAnimationEating();
        }

        
        //  StartCoroutine(SpawnFeedAfterHiT());
        AudioSource.clip = Eating;
        AudioSource.Play();
        StartCoroutine(HideIce());
    }

    IEnumerator HideIce()
    {
        yield return new WaitForSeconds(0.5f);
        CommonData.prefabs.gameobjectLookup["Jaw"].SetActive(false);
    }
    public void DeleteFeed()
    {
        if (Feed != null)
        {
            Destroy(Feed);
        }

    }
    IEnumerator SpawnFeedAfterHiT()
    {
        yield return new WaitForSeconds(3.5f);
        CommonData.prefabs.gameobjectLookup["Jaw"].SetActive(false);
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

    public void StartExitCrocodile()
    {
        PathExitCrocodile.Play();
    }
    public void HideCrocodile()
    {
        PathExitCrocodile.Target.gameObject.SetActive(false);
    }
}
