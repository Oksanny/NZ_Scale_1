﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class CheckServiceProviderGUI : BaseMenu
    {

        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}
