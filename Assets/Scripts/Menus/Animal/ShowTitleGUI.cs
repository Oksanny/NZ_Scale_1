using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class ShowTitleGUI : BaseMenu
    {
        public AudioClip SmartiCall_2_Intro;
        public AudioClip SmartiCall_2_Intro_2;
        public GameObject Title_1;
        public GameObject Title_2;
        public AudioSource AudioSource;


        void Start()
        {
            StartCoroutine(PlayEngineSound());
        }
        IEnumerator PlayEngineSound()
        {
            Title_1.SetActive(true);
            Title_2.SetActive(false);
            AudioSource.clip = SmartiCall_2_Intro;
            AudioSource.Play();
            yield return new WaitForSeconds(AudioSource.clip.length+1f);
            Title_1.SetActive(false);
            Title_2.SetActive(true);
            AudioSource.clip = SmartiCall_2_Intro_2;
            AudioSource.Play();
           
        }
    }
}
