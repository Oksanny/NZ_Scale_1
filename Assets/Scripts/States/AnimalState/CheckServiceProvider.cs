using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CheckServiceProvider : BaseState
    {
        private Menus.CheckServiceProviderGUI menuComponent;
        public CheckServiceProvider() { }
        private Vector3 pointServiceProviderVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckServiceProviderGUI>(StringConstants.PrefabCheckServiceProvider);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].SetActive(true);
            ShowUI();

        }
        public override void Update()
        {
            pointServiceProviderVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointServiceProvider].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointServiceProviderVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                CommonData.mainManager.stateManager.SwapState(new ShowServiceProv());

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
