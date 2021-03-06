﻿using System.Collections;
using System.Collections.Generic;
using I2.Loc;
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
           if (!CommonData.prefabs.gameobjectLookup[StringConstants.PrefabLion].GetComponent<AudioSource>().isPlaying)
           {
               CommonData.prefabs.gameobjectLookup[StringConstants.PrefabLion].GetComponent<AudioSource>().Play();
           }
            LocalizationManager.CurrentLanguage = CommonData.Language;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion];
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<bl_MiniMapItem>().Size = 0;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCage].GetComponent<bl_MiniMapItem>().Size = 40;
            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckLionGUI>(StringConstants.PrefabCheckLion);
            }
            ShowUI();
           
        }
        public override void Update()
        {
            pointLionVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (Vector3.Distance(pointLionVector3, pointARCamerVector3) <= 0.5f)
            {
                Debug.Log("BAncomat");
                menuComponent.AudioSrc.Play();
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

