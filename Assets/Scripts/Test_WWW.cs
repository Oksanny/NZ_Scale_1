using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_WWW : MonoBehaviour
{
    public RawImage img;
	// Use this for initialization
	void Start ()
	{
        StartCoroutine(Load("https://firebasestorage.googleapis.com/v0/b/inernetcomercia.appspot.com/o/Categorys_Image%2F-KvX-nXDtWHzMmBdOkwj.jpg?alt=media&token=70eb541c-48e6-462f-bc60-c987028258b6"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Load(string url)
    {
        WWW www=new WWW(url);
        yield return www;
        if (www.isDone)
        {
            Debug.Log("Sucs");
        }
        if (www.error!=null)
        {
            Debug.Log(www.error);
        }
        else
        {
            img.texture = www.texture;
        }
    }
}
