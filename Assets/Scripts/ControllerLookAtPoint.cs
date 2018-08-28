using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Steps;

public class ControllerLookAtPoint : MonoBehaviour
{
    public GameObject Target;
    public GameObject Arrow;
    private Transform tempGameObject;
	// Use this for initialization
	void Start ()
	{
	    tempGameObject = new GameObject("temp").transform;
	}
	
	// Update is called once per frame
	void Update () {
        
	    if (Target!=null&&Target.activeSelf)
	    {
            foreach (var mesh in Arrow.GetComponentsInChildren<MeshRenderer>())
            {
                mesh.enabled = true;
            }
            tempGameObject.position = new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z);
            // Vector3 lookVector = Target.transform.position - transform.position;
            // lookVector.y = transform.position.y;
            // Debug.Log("lookVector="+lookVector);
            // Quaternion rot = Quaternion.LookRotation(lookVector);
            // Debug.Log("rot=" + rot);
            // rot=new Quaternion();
            // transform.rotation = Quaternion.Slerp(transform.rotation, rot, 100);
            transform.LookAt(tempGameObject);
            Arrow.transform.localEulerAngles = new Vector3(Arrow.transform.localEulerAngles.x, Arrow.transform.localEulerAngles.y, -transform.localEulerAngles.y);
            Debug.Log(transform.localEulerAngles.y);
          // if (Mathf.Abs(transform.localEulerAngles.y) < 15f || Mathf.Abs(transform.localEulerAngles.y) > 345f)
          // {
          //     foreach (var mesh in Arrow.GetComponentsInChildren<MeshRenderer>())
          //     {
          //         mesh.enabled = false;
          //     }
          // }
          // else
          // {
          //     foreach (var mesh in Arrow.GetComponentsInChildren<MeshRenderer>())
          //     {
          //         mesh.enabled = true;
          //     }
          // }
	    }
	    else
	    {
            foreach (var mesh in Arrow.GetComponentsInChildren<MeshRenderer>())
            {
                mesh.enabled = false;
            }
	    }
        
	}

}
