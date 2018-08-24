using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowServiceProv : BaseState
    {

        private Menus.ShowServiceProviderGUI menuComponent;
        public ShowServiceProv()
        { }
        private Vector3 pointSewrviceProviderVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;

        // Update is called once per frame
        public override void Update()
        {
            pointSewrviceProviderVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointSewrviceProviderVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new CheckServiceProvider());
                
            }
        }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].SetActive(false);
            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>()
                .ShowServiceProvider = this;
            
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowServiceProviderGUI>(StringConstants.PrefabShowServiceProviderGUI);
                menuComponent.LabelInfo.SetActive(true);
                menuComponent.LabelInfoPolacon.SetActive(false);
                menuComponent.LabelPointsConnectaPhone.SetActive(false);
            }
            ShowUI();

        }

        public void SelecPolacon()
        {
            menuComponent.LabelInfoPolacon.SetActive(true);
            CommonData.currentUser.data.Minus -= 360;
            complete = true;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>()
                 .ShowServiceProvider = null;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelecConnectaPhone()
        {
            menuComponent.LabelPointsConnectaPhone.SetActive(true);
            CommonData.currentUser.data.Minus -= 570;
            complete = true;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>()
                 .ShowServiceProvider = null;
            menuComponent.StartCoroutine(Exit());
        }
        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>()
                 .ShowServiceProvider = null;
            yield return new WaitForSeconds(3f);
            CommonData.mainManager.stateManager.SwapState(new CheckElephant());

        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>()
                 .ShowServiceProvider = null;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}
