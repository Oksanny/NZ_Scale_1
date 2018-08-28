using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CheckBancomat : BaseState
    {
        private Menus.CheckBancomatGUI menuComponent;
        public CheckBancomat()
        { }
        private Vector3 pointBancomatVector3;
        private Vector3 pointARCamerVector3;

        // Update is called once per frame
        public override void Update()
        {
            pointBancomatVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointBancomatVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new ShowBancomat());
                
            }
        }
        public override void Initialize()
        {
            
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabResetButton].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].SetActive(true);
            
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].GetComponent<ControllerTime>().StartTime = true;

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat];

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<bl_MiniMapItem>().Size = 40;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabMarkerCamera].SetActive(true);
            InitializeUI();
        }
        private void InitializeUI()
        {
            CommonData.currentUser = new DBStruct<UserData>("Player");
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckBancomatGUI>(StringConstants.PrefabCheckBancomatGUI);
            }
            ShowUI();
           
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
