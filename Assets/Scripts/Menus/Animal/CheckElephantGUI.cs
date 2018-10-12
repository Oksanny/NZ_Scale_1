
using System.Collections.Generic;
using UnityEngine;

namespace Menus
{
    public class CheckElephantGUI : BaseMenu
    {

       // public GUIButton Previous_Button;
       // public GUIButton Next_Button;
        public AudioClip Buttonsound;
        public AudioSource AudioSrc;

        void Start()
        {
            AudioSrc.clip = Buttonsound;
            AudioSrc.Play();
        }
        
    }
}