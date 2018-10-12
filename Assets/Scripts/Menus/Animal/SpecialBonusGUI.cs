using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Menus
{
    public class SpecialBonusGUI : BaseMenu
    {
        public Text Timer;
        public GameObject LabelInfo;
        public GameObject LabelMiss;
        public GameObject LabelGreat;
        public GameObject LabelPoint;
        public GameObject LabeTimer;
        public AudioClip Buttonsound;
        public AudioClip OOps;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}
