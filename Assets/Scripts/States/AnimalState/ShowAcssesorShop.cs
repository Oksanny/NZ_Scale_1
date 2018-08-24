using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowAcssesorShop : BaseState
    {
         private Menus.ShowAcssesorShopGUI menuComponent;
         public ShowAcssesorShop()
        { }
         private Vector3 pointAcssesorShopVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        private bool all_complete;
        private int countItem;
        public override void Update()
        {
            pointAcssesorShopVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointAcssesorShopVector3, pointARCamerVector3) > 0.5f)
            {
                if (!all_complete)
                {
                    if (complete)
                    {
                        CommonData.mainManager.stateManager.SwapState(new CheckCrocodile());
                    }
                    else
                    {
                        CommonData.mainManager.stateManager.SwapState(new CheckAcssesorShop());
                    }
                }
               

            }
        }
        public override void Initialize()
        {
            countItem = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointAcssesorShop].SetActive(false);
            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShelf].GetComponent<ControllerShelf>()
                .ShowAcssesorShop = this;

        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowAcssesorShopGUI>(StringConstants.PrefabShowAcssesorShop);
                menuComponent.InfoLabel.SetActive(true);
                menuComponent.PhonePointsLabel.SetActive(false);
                menuComponent.CasePointsLabel.SetActive(false);
                menuComponent.PowerBankPointsLabel.SetActive(false);
                menuComponent.ChargePointsLabel.SetActive(false);
            }
            ShowUI();

        }

        public void SelectPhone()
        {
            countItem++;
            menuComponent.PhonePointsLabel.SetActive(true);
            CommonData.currentUser.data.Minus -= 80;
            if (countItem==3)
            {
                all_complete = true;
                menuComponent.StartCoroutine(Exit(menuComponent.PhonePointsLabel));
            }
            else
            {
                complete = true;
                menuComponent.StartCoroutine(HideLabel(menuComponent.PhonePointsLabel));
            }
        }
        public void SelectPowerBank()
        {
            countItem++;
            menuComponent.PowerBankPointsLabel.SetActive(true);
            CommonData.currentUser.data.Minus -= 50;
            if (countItem == 3)
            {
                all_complete = true;
                menuComponent.StartCoroutine(Exit(menuComponent.PowerBankPointsLabel));
            }
            else
            {
                complete = true;
                menuComponent.StartCoroutine(HideLabel(menuComponent.PowerBankPointsLabel));
            }
        }
        public void SelectCase()
        {
            countItem++;
            menuComponent.CasePointsLabel.SetActive(true);
            CommonData.currentUser.data.Minus -= 35;
            if (countItem == 3)
            {
                all_complete = true;
                menuComponent.StartCoroutine(Exit(menuComponent.CasePointsLabel));
            }
            else
            {
                complete = true;
                menuComponent.StartCoroutine(HideLabel(menuComponent.CasePointsLabel));
            }
        }
        public void SelectCharge()
        {
            countItem++;
            menuComponent.ChargePointsLabel.SetActive(true);
            CommonData.currentUser.data.Minus -= 45;
            if (countItem == 3)
            {
                all_complete = true;
                menuComponent.StartCoroutine(Exit(menuComponent.ChargePointsLabel));
            }
            else
            {
                complete = true;
                menuComponent.StartCoroutine(HideLabel(menuComponent.ChargePointsLabel));
            }
        }

        IEnumerator HideLabel(GameObject label)
        {
            yield return new WaitForSeconds(2f);
            label.SetActive(false);
        }

        IEnumerator Exit(GameObject label)
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShelf].GetComponent<ControllerShelf>()
                .ShowAcssesorShop = null;
            yield return new WaitForSeconds(2f);
            label.SetActive(false);
            CommonData.mainManager.stateManager.SwapState(new CheckCrocodile());

        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShelf].GetComponent<ControllerShelf>()
                .ShowAcssesorShop = null;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}

