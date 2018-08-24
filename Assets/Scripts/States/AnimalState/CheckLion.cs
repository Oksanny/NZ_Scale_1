using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckLion : BaseState
    {
        private Menus.CheckLionGUI menuComponent;
        public CheckLion() { }
        private Vector3 pointLionVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckLionGUI>(StringConstants.PrefabCheckLion);
            }
            ShowUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].SetActive(true);
        }
        public override void Update()
        {
            pointLionVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointLionVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new ShowLion());

            }
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {
            CommonData.StateAnimal = false;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

            

        }
    }
}

