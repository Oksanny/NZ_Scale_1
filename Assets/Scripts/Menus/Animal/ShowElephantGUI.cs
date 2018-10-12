using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class ShowElephantGUI : BaseMenu
    {
        public GameObject LabelInfo;
        public GameObject LabelGreatMessage;
        public GameObject LabelMissMessage;
        public GameObject LabelBonusPoint;
        public GameObject LabelMissPoint;

       // public Text BonusPointStr;
       // public Text MissPointStr;
        // public GUIButton Previous_Button;
        // public GUIButton Next_Button;
        public AudioClip OOps;
        public AudioClip ButtonClick;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = ButtonClick;
            AudioSrc.Play();
        }
    }
}

