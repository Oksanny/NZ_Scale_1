using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckElephant : BaseState
    {
        private Menus.CheckElephantGUI menuComponent;
        public CheckElephant() { }
        private Vector3 pointElephantkVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckElephantGUI>(StringConstants.PrefabCheckElephant);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant];


            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabElephant].GetComponent<bl_MiniMapItem>().Size = 40;
            ShowUI();

        }
        public override void Update()
        {
            pointElephantkVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointElephantkVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new ShowElephant());

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


          // if (source == menuComponent.Previous_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new ShowShark());
          //
          // }
          // else if (source == menuComponent.Next_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new ShowElephant());
          // }
        }
    }
}

