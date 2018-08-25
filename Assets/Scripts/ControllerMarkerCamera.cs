using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMarkerCamera : MonoBehaviour
{
    public GameObject CenterZona;
    public GameObject ArCameraGameObject;
    public GameObject ReperPoint;
    public RectTransform ImagePreview;
    public RectTransform ImageCursor;
    private float factorTransform;
    public float X;
    public float Y;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("CZ="+CenterZona.transform.position);
        Debug.Log("AR="+ArCameraGameObject.transform.position);
        factorTransform = ImagePreview.rect.height / 2/Vector3.Distance(new Vector3(CenterZona.transform.position.x, CenterZona.transform.position.y, CenterZona.transform.position.z),
            new Vector3(ReperPoint.transform.position.x, ReperPoint.transform.position.y, ReperPoint.transform.position.z));
        Debug.Log("K="+factorTransform);
        Debug.Log(Vector3.Distance(new Vector3(CenterZona.transform.position.x, CenterZona.transform.position.y, CenterZona.transform.position.z),
            new Vector3(ReperPoint.transform.position.x, ReperPoint.transform.position.y, ReperPoint.transform.position.z)));
        Vector3 WordCoordinate = new Vector3(ArCameraGameObject.transform.position.x - CenterZona.transform.position.x,
            ArCameraGameObject.transform.position.y - CenterZona.transform.position.y,
            ArCameraGameObject.transform.position.z - CenterZona.transform.position.z);
         Debug.Log("word= "+WordCoordinate.x+"   "+WordCoordinate.z);

        ImageCursor.anchoredPosition = new Vector2(WordCoordinate.z * factorTransform, -WordCoordinate.x * factorTransform);
        Debug.Log("Image= " + new Vector2(WordCoordinate.z * factorTransform, -WordCoordinate.x * factorTransform));
    }
}
