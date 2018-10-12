using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace States
{
    public class SpecialBonus : BaseState
    {
        private Vector3 pointSpecialBonuseVector3;
        private Vector3 pointARCamerVector3;
        private Menus.SpecialBonusGUI menuComponent;
        public SpecialBonus() { }
        private float time = 10f;
        private bool stopTime;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSpecialBonuse].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSpecialBonuse];
            LocalizationManager.CurrentLanguage = CommonData.Language;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSpecialBonuse].GetComponent<bl_MiniMapItem>().Size = 40; 
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.SpecialBonusGUI>(StringConstants.PrefabSpecialBonus);
            }
            menuComponent.LabelInfo.SetActive(true);
            menuComponent.LabeTimer.SetActive(true);
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelMiss.SetActive(false);
            menuComponent.LabelPoint.SetActive(false);
            ShowUI();
            

        }
        public override void Update()
        {
            if (!stopTime)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    stopTime = true;
                    time = 0;
                    ExitMiss();
                }
                int showTime = (int) time;
                menuComponent.Timer.text = showTime.ToString()+"  sec";
                
            }

            pointSpecialBonuseVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSpecialBonuse].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSpecialBonuse].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!stopTime&&Vector3.Distance(pointSpecialBonuseVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                stopTime = true;
                ExitGreat();
                // CommonData.mainManager.stateManager.SwapState(new CheckServiceProvider());

            }

        }

        void ExitGreat()
        {
            Debug.Log("ExitGreat");
            menuComponent.AudioSrc.clip = menuComponent.Buttonsound;
            menuComponent.AudioSrc.Play();
            menuComponent.LabeTimer.SetActive(false);
            menuComponent.LabelGreat.SetActive(true);
            menuComponent.LabelPoint.SetActive(true);
            CommonData.currentUser.data.Plus += (int)StringConstants.SpecialBonusReward;
            menuComponent.StartCoroutine(Exit());
        }

        void ExitMiss()
        {
            Debug.Log("ExitMiss");
            menuComponent.AudioSrc.clip = menuComponent.OOps;
            menuComponent.AudioSrc.Play();
            menuComponent.LabelMiss.SetActive(true);
            menuComponent.StartCoroutine(Exit());
        }
        public override void Suspend()
        {

            HideUI();
        }

        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSpecialBonuse].SetActive(false);
            
            
            yield return new WaitForSeconds(3f);
           
            
            CommonData.mainManager.stateManager.SwapState(new CheckCrocodile());

        }
        public override StateExitValue Cleanup()
        {

            
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}
