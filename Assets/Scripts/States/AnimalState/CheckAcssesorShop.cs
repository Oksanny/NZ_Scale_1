using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class CheckAcssesorShop : BaseState
    {
        private Menus.CheckAcssesorShopGUI menuComponent;
        public CheckAcssesorShop() { }
        private Vector3 pointAcssesorShopVector3;
        private Vector3 pointARCamerVector3;

        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop];

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCage].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShelf].GetComponent<bl_MiniMapItem>().Size = 40;
            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckAcssesorShopGUI>(StringConstants.PrefabCheckAcssesorShop);
            }
           
            ShowUI();

        }
        public override void Update()
        {
            pointAcssesorShopVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointAcssesorShopVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                CommonData.mainManager.stateManager.SwapState(new ShowAcssesorShop());

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