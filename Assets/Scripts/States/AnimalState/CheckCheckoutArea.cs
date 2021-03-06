﻿using System.Collections;
using System.Collections.Generic;
using I2.Loc;
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
            LocalizationManager.CurrentLanguage = CommonData.Language;
            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckCheckoutAreaGUI>(StringConstants.PrefabCheckCheckoutAre);
            }
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckoutArea];

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckoutArea].GetComponent<bl_MiniMapItem>().Size = 40; 
            ShowUI();

        }
        public override void Update()
        {
            pointCheckoutAreaVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointCheckoutAreaVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("ServiceProvider");
                menuComponent.AudioSrc.Play();
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
