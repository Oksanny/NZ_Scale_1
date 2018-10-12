using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class ShowBancomatGUI : BaseMenu
    {
        public GameObject LabelInfo;
        public GameObject LabelPoints;
        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}
