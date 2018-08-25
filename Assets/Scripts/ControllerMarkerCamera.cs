using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMarkerCamera : MonoBehaviour
{
    public GameObject CenterZona;
    public GameObject ArCameraGameObject;
    public RectTransform ImagePreview;
    public RectTransform ImageCursor;
    private float factorTransform;
    public float X;
    public float Y;
	// Use this for initialization
	void Start ()
	{
	    factorTransform = ImagePreview.rect.height/2/4.33f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 WordCoordinate=new Vector3(ArCameraGameObject.transform.position.x-CenterZona.transform.position.x,
            ArCameraGameObject.transform.position.y - CenterZona.transform.position.y,
            ArCameraGameObject.transform.position.z - CenterZona.transform.position.z);
       // Debug.Log(WordCoordinate.x+"   "+WordCoordinate.z);
        ImageCursor.anchoredPosition = new Vector2( WordCoordinate.z * factorTransform,-WordCoordinate.x * factorTransform);
	}
}
