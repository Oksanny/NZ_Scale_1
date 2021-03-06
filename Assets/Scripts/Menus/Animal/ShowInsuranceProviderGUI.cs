﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class ShowInsuranceProviderGUI : BaseMenu
    {

        public GameObject LabelInfo;
        public GameObject LabelStandart;
        public GameObject LabelLuxury;
        public GameObject LabelSelectPhone_1;
        public GameObject LabelSelectPhone_2;
        public GameObject LabelSelectPhone_3;
        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}
