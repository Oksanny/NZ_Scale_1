using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckShark : BaseState
    {
        private Menus.CheckSharkGUI menuComponent;
        public CheckShark() { }
        private Vector3 pointSharkVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckSharkGUI>(StringConstants.PrefabCheckShark);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark];
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<bl_MiniMapItem>().Size = 40;
            ShowUI();

        }
        public override void Update()
        {
            pointSharkVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointSharkVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new ShowShark());

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

            if (source == menuComponent.Previous_Button.gameObject)
            {
                Debug.Log(source.name);
               // manager.SwapState(new CheckShark());

            }
            else if (source == menuComponent.Next_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowShark());
            }

        }
    }
}

