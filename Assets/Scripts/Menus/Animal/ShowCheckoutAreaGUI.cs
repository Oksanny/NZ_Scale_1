using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class ShowCheckoutAreaGUI : BaseMenu
    {

        public GameObject LabelInfo;
        public Text PlusLabel;
        public Text MinusLabel;
        public Text Total;
        public Text Message;

         void Start()
         {
             
             PlusLabel.text = "+" + CommonData.currentUser.data.Plus.ToString() + " points";
             MinusLabel.text =  CommonData.currentUser.data.Minus.ToString() + " points";
             int total = CommonData.currentUser.data.Plus + CommonData.currentUser.data.Minus;
             Debug.Log(total);
             if (total > 0)
             {
                 total = CommonData.currentUser.data.Plus + CommonData.currentUser.data.Minus;
                 Total.text = "+" + total.ToString() + " Total Points!";
                 Message.text = "Congratulations! You have scored +"+total.ToString()+" points! Hope you enjoyed your Augmented Reality experience!";
             }
             if (total < 0)
             {
                 total = CommonData.currentUser.data.Plus + CommonData.currentUser.data.Minus;
                 Total.text = total.ToString() + " Total Points!";
                 Message.text = "Congratulations! You have scored " + total.ToString() + " points! Hope you enjoyed your Augmented Reality experience!";
             }
             if (total == 0)
             {
                 Total.text = "0  Total Points!";
                 Message.text = "Congratulations! You have scored 0 points! Hope you enjoyed your Augmented Reality experience!";
             }
         }
    }
}
