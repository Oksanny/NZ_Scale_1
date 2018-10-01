using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace States
{
    public class CheckSmartphone : BaseState
    {

        private Menus.CheckSmartphoneGUI menuComponent;
        public CheckSmartphone() { }
        private Vector3 pointSmartphoneVector3;
        private Vector3 pointARCamerVector3;
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone];

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCage].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<bl_MiniMapItem>().Size = 40;
            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckSmartphoneGUI>(StringConstants.PrefabCheckSmartphone);
            }
            
            ShowUI();

        }
        public override void Update()
        {
            pointSmartphoneVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointSmartphoneVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                CommonData.mainManager.stateManager.SwapState(new ShowSmartphone());

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
