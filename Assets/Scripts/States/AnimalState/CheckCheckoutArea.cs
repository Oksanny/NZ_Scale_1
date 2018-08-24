using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CheckCheckoutArear : BaseState
    {
        private Menus.CheckCheckoutAreaGUI menuComponent;
        public CheckCheckoutArear() { }
        private Vector3 pointCheckoutAreaVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckCheckoutAreaGUI>(StringConstants.PrefabCheckCheckoutAre);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].SetActive(true);
            ShowUI();

        }
        public override void Update()
        {
            pointCheckoutAreaVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointCheckoutAreaVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                CommonData.mainManager.stateManager.SwapState(new ShowCheckoutArea());

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
