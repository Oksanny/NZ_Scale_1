using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckCrocodile : BaseState
    {
        private Menus.CheckCrocodileGUI menuComponent;
        public CheckCrocodile() { }
        private Vector3 pointCrocodileVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckCrocodileGUI>(StringConstants.PrefabCheckCrocodile);
            }
            ShowUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].SetActive(true);

        }
        public override void Update()
        {
            pointCrocodileVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointCrocodileVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                CommonData.mainManager.stateManager.SwapState(new ShowCrocodile());

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
                manager.SwapState(new ShowElephant());

            }
            else if (source == menuComponent.Next_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowCrocodile());
            }

        }
    }
}

