using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menus
{
    public class ShowCheckoutAreaGUI : BaseMenu
    {
        public AudioClip SmartiCall_2OutroatSummary;
        public AudioSource AudioSource;
        public GameObject LabelInfo;
        public GameObject LabelAnswer;
        public Text PlusLabel;
        public Text TimeBonusLabel;
        public Text MinusLabel;
        public Text Total;
        public Text Message;

         void Start()
         {
             LabelInfo.SetActive(true);
             LabelAnswer.SetActive(false);
             PlusLabel.text = "Cash Collected: " + "+" + CommonData.currentUser.data.Plus.ToString() + " points";
             
             if (CommonData.currentUser.data.TimeBonus>=0)
             {

                 TimeBonusLabel.text = "Time Bonus: " + "+" + CommonData.currentUser.data.TimeBonus.ToString() + " points";
             }
             else
             {
                 TimeBonusLabel.text = "Penalty: " +  CommonData.currentUser.data.TimeBonus.ToString() + " points";
             }
             
             MinusLabel.text ="Purchases: "+  CommonData.currentUser.data.Minus.ToString() + " points";
             int total = CommonData.currentUser.data.Plus + CommonData.currentUser.data.Minus + CommonData.currentUser.data.TimeBonus;
             Debug.Log(total);
             if (total > 0)
             {
                
                 Total.text = "+" + total.ToString() + " Total Points!";
                 Message.text = "Congratulations! You have scored +"+total.ToString()+" points! Hope you enjoyed your Augmented Reality experience!";
             }
             if (total < 0)
             {
                 
                 Total.text = total.ToString() + " Total Points!";
                 Message.text = "Congratulations! You have scored " + total.ToString() + " points! Hope you enjoyed your Augmented Reality experience!";
             }
             if (total == 0)
             {
                 Total.text = "0  Total Points!";
                 Message.text = "Congratulations! You have scored 0 points! Hope you enjoyed your Augmented Reality experience!";
             }
             StartCoroutine(StartPlaySound());
         }

        IEnumerator StartPlaySound()
        {
            yield return new WaitForSeconds(2f);
            AudioSource.clip = SmartiCall_2OutroatSummary;
            AudioSource.Play();
            yield return new WaitForSeconds(AudioSource.clip.length - 1f);
            LabelInfo.SetActive(false);
            LabelAnswer.SetActive(true);
        }
    }
}
