using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMarkerCamera : MonoBehaviour
{
    public Text angelCamera;
    public Text angelGround;
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
        angelCamera.text = ArCameraGameObject.transform.eulerAngles.y.ToString();
        
       
        factorTransform = ImagePreview.rect.height / 2/Vector3.Distance(new Vector3(CenterZona.transform.position.x, CenterZona.transform.position.y, CenterZona.transform.position.z),
            new Vector3(ReperPoint.transform.position.x, ReperPoint.transform.position.y, ReperPoint.transform.position.z));
      

        float X = CenterZona.transform.position.x - ArCameraGameObject.transform.position.x;
        float z = CenterZona.transform.position.z - ArCameraGameObject.transform.position.z;
        
        Vector3 WordCoordinate = new Vector3(ArCameraGameObject.transform.position.x - CenterZona.transform.position.x,
            ArCameraGameObject.transform.position.y - CenterZona.transform.position.y,
            ArCameraGameObject.transform.position.z - CenterZona.transform.position.z);
         Debug.Log("word= "+WordCoordinate.x+"   "+WordCoordinate.z);
         if (X >= 0 && z >= 0)
         {
             ImageCursor.anchoredPosition = new Vector2(-WordCoordinate.z * factorTransform, WordCoordinate.x * factorTransform);
         }
         if (X <= 0 && z <= 0)
         {
             ImageCursor.anchoredPosition = new Vector2(WordCoordinate.z * factorTransform, -WordCoordinate.x * factorTransform);
         }
        ImageCursor.localEulerAngles=new Vector3(0,0,270-ArCameraGameObject.transform.eulerAngles.y);
        Debug.Log("Image= " + ImageCursor.localEulerAngles.z);
        angelGround.text = ImageCursor.localEulerAngles.z.ToString();
    }
}
