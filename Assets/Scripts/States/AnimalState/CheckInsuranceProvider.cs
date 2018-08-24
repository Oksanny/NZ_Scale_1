using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CheckInsuranceProvider : BaseState
    {
        private Menus.CheckInsuranceProviderGUI menuComponent;
        public CheckInsuranceProvider() { }
        private Vector3 pointInsuranceProviderVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckInsuranceProviderGUI>(StringConstants.PrefabCheckInsurance);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].SetActive(true);
            ShowUI();

        }
        public override void Update()
        {
            pointInsuranceProviderVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointInsuranceProviderVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                CommonData.mainManager.stateManager.SwapState(new ShowInsuranceeProvider());

            }
        }
        public override void Suspend()
        {

            HideUI();
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
