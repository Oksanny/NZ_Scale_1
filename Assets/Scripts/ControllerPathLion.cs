using System.Collections;
using System.Collections.Generic;
using Jacovone;
using UnityEngine;

public class ControllerPathLion : MonoBehaviour
{
    public Transform TargetLion;
    public PathMagic PathExitFromCage;
    public PathMagic PathRoundLion;
    public Animation animationCage;
    public Animator AnimatorLion;
    public AudioClip LonRoar;
    public AudioClip SmartiCall_2Lion;
    public AudioSource AudioSource;
	// Use this for initialization
	void Start ()
	{
	    //StartCoroutine(StartLion());
	    AudioSource.loop = true;
	    AudioSource.clip = LonRoar;
	}

    public void TaskCompleet()
    {
        AudioSource.Stop();
        AudioSource.loop = false;
        AudioSource.clip = SmartiCall_2Lion;
        AudioSource.Play();
        animationCage.Play("open_door");
        AnimatorLion.SetTrigger("Eating");

        StartCoroutine(StopPlaySound());
    }

    IEnumerator StopPlaySound()
    {
        yield return new WaitForSeconds(AudioSource.clip.length-1f);
        StartExit();
    }
    public void StartExit()
    {
        OpenCage();
    }
    IEnumerator StartLion()
    {
        yield return new WaitForSeconds(5f);
        OpenCage();
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenCage()
    {
       // animationCage.Play("open_door");
        StartCoroutine(ExitLion());
    }

    IEnumerator ExitLion()
    {
        yield return new WaitForSeconds(0.5f);
        StartExitFromCage();
    }
    public void StartExitFromCage()
    {
        PathExitFromCage.Target = TargetLion;
        AnimatorLion.SetTrigger("Walk");
        PathExitFromCage.Play();
    }

    public void GoToRoundPath()
    {
        PathExitFromCage.Pause();
        PathExitFromCage.Target = null;
        PathRoundLion.Target = TargetLion;
       // PathExitFromCage.Stop();
        PathRoundLion.Play();
    }

    public void HideTarget()
    {
        TargetLion.GetComponent<AudioSource>().Stop();
        
       PathExitFromCage.Target.gameObject.SetActive(false); 
    }
    public void Rewind()
    {
        PathRoundLion.Stop();
        PathRoundLion.Rewind();
        PathExitFromCage.Target = PathRoundLion.Target;
        PathRoundLion.Target = null;
        PathExitFromCage.Rewind();
        AnimatorLion.SetTrigger("Idle");
        animationCage.Play("close_door");
    }
}
