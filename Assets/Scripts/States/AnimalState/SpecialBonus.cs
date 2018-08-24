using System.Collections;
using System.Collections.Generic;
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
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.SpecialBonusGUI>(StringConstants.PrefabSpecialBonus);
            }
            menuComponent.LabelInfo.SetActive(true);
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
            menuComponent.LabelGreat.SetActive(true);
            menuComponent.LabelPoint.SetActive(true);
            CommonData.currentUser.data.Plus += 500;
            menuComponent.StartCoroutine(Exit());
        }

        void ExitMiss()
        {
            Debug.Log("ExitMiss");
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
           
            
            CommonData.mainManager.stateManager.SwapState(new CheckInsuranceProvider());

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
