
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class CheckLionGUI : BaseMenu
    {

        public GUIButton Previous_Button;
        public GUIButton Next_Button;
        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
    }
}