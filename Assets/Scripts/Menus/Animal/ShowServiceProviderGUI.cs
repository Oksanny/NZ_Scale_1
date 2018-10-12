﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class ShowServiceProviderGUI : BaseMenu
    {

        public GameObject LabelInfo;
       
        public GameObject LabelSelectPhone_Big;
        public GameObject LabelSelectPhone_Small;
        public GameObject LabelGreat;
        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}
