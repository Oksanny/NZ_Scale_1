﻿using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace States
{
    public class ShowInsuranceeProvider : BaseState
    {

        private Menus.ShowInsuranceProviderGUI menuComponent;
        public ShowInsuranceeProvider()
        { }
        private Vector3 pointInsuranceProviderVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        // Update is called once per frame
        public override void Update()
        {
            pointInsuranceProviderVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointInsuranceProviderVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("BAncomat");
               // CommonData.mainManager.stateManager.SwapState(new CheckInsuranceProvider());
                
            }
        }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointInsurance].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance];
            LocalizationManager.CurrentLanguage = CommonData.Language;
            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<ControllerInsuranceProvider>()
                .ShowInsuranceeProvider = this;
             CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<ControllerInsuranceProvider>().StartPlaySound();
            
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowInsuranceProviderGUI>(StringConstants.PrefabInsuranceProvider);
                menuComponent.LabelInfo.SetActive(true);
                menuComponent.LabelLuxury.SetActive(false);
                menuComponent.LabelStandart.SetActive(false);
            }
            ShowUI();

        }

        public void SelecInsuramore()
        {
           // menuComponent.LabelInsuramoree.SetActive(true);
            
            CommonData.currentUser.data.Minus -= 120;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelecPlanetsure()
        {
          //  menuComponent.LabelPlanetsure.SetActive(true);
            
            CommonData.currentUser.data.Minus -= 180;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_1()
        {
            menuComponent.LabelSelectPhone_1.SetActive(true);
            menuComponent.LabelStandart.SetActive(true);
          //  CommonData.currentUser.data.Minus -= 180;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_2()
        {
            menuComponent.LabelSelectPhone_2.SetActive(true);
            menuComponent.LabelLuxury.SetActive(true);
            CommonData.currentUser.data.Minus -= 200;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_3()
        {
            menuComponent.LabelSelectPhone_3.SetActive(true);
            menuComponent.LabelLuxury.SetActive(true);
            CommonData.currentUser.data.Minus -= 300;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<ControllerInsuranceProvider>()
               .ShowInsuranceeProvider = null;
            yield return new WaitForSeconds(6f);
           // CommonData.mainManager.stateManager.SwapState(new CheckElephant());
            CommonData.mainManager.stateManager.SwapState(new CheckCheckoutArear());
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<ControllerInsuranceProvider>()
               .ShowInsuranceeProvider = null;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}
