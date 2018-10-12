using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class ShowCrocodileGUI : BaseMenu
    {
        public GameObject LabelInfo;
        public GameObject LabelMissMessage;
        public GameObject LabelGreatMessage;
        public GameObject LabelBonusPoint;
        public GameObject LabelMissPoint;
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
