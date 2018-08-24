using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowBancomat : BaseState
    {

        private Menus.ShowBancomatGUI menuComponent;
        public ShowBancomat()
        { }
        private Vector3 pointBancomatVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        // Update is called once per frame
        public override void Update()
        {
            pointBancomatVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointBancomatVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new CheckBancomat());
                
            }
        }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointBancomat].SetActive(false);
            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<ControllerBancomat>()
                .ShowBancomat = this;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<BoxCollider>().enabled =
                true;
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowBancomatGUI>(StringConstants.PrefabShowBancomatGUI);
                menuComponent.LabelInfo.SetActive(true);
                menuComponent.LabelPoints.SetActive(false);
            }
            ShowUI();
           
        }

        public void SelectBancomat()
        {
            menuComponent.LabelPoints.SetActive(true);
            CommonData.currentUser.data.Plus += 2000;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }

        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<ControllerBancomat>()
                 .ShowBancomat = null;
            yield return new WaitForSeconds(3f);
            CommonData.mainManager.stateManager.SwapState(new CheckShark());

        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<ControllerBancomat>()
                 .ShowBancomat = null;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<BoxCollider>().enabled =
               false;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

            

        }
    }
}

