using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

namespace States
{
    public class ShowSmartphone : BaseState
    {

         private Menus.ShowSmartphoneGUI menuComponent;
         public ShowSmartphone()
        { }
        private Vector3 pointSmartphoneVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        // Update is called once per frame
        public override void Update()
        {
            pointSmartphoneVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointSmartphoneVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("BAncomat");
               // CommonData.mainManager.stateManager.SwapState(new CheckSmartphone());
                
            }

        }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone];
            LocalizationManager.CurrentLanguage = CommonData.Language;
            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
                .ShowSmartphone = this;
             CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>().StartPlaySound();

        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowSmartphoneGUI>(StringConstants.PrefabShowSmartphone);
               
                menuComponent.LabelStandart.SetActive(false);
                menuComponent.LabelLuxury.SetActive(false);
                menuComponent.LabelSelectPhone_1.SetActive(false);
                menuComponent.LabelSelectPhone_2.SetActive(false);
                menuComponent.LabelSelectPhone_3.SetActive(false);
                menuComponent.LabelSelectPhone_4.SetActive(false);
                menuComponent.LabelInfo.SetActive(true);
            }
            ShowUI();

        }
        public void SelectCommunata()
        {
            Debug.Log("Sc");
           // menuComponent.LabelPointCommunata.SetActive(true);
            CommonData.currentUser.data.Minus -= 600;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectSmartical()
        {
            Debug.Log("SS");
            complete = true;
           // menuComponent.LabelPointsSmartical.SetActive(true);
            CommonData.currentUser.data.Minus -= 1000;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_1()
        {
            menuComponent.LabelSelectPhone_1.SetActive(true);
            menuComponent.LabelStandart.SetActive(true);
           // CommonData.currentUser.data.Minus -= 600;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_2()
        {
            menuComponent.LabelSelectPhone_2.SetActive(true);
            menuComponent.LabelStandart.SetActive(true);
           // CommonData.currentUser.data.Minus -= 600;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_3()
        {
            menuComponent.LabelSelectPhone_3.SetActive(true);
            menuComponent.LabelLuxury.SetActive(true);
            CommonData.currentUser.data.Minus -= 100;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectPhone_4()
        {
            menuComponent.LabelSelectPhone_4.SetActive(true);
            menuComponent.LabelLuxury.SetActive(true);
            CommonData.currentUser.data.Minus -= 100;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
               .ShowSmartphone = null;
            yield return new WaitForSeconds(6f);
            if (CommonData.currentUser.data.SmarticallBuy )
            {
                CommonData.mainManager.stateManager.SwapState(new SpecialBonus());
            }
            else
            {
                CommonData.mainManager.stateManager.SwapState(new CheckCrocodile());
            }
           // CommonData.mainManager.stateManager.SwapState(new SpecialBonus());

        }
        public override void Suspend()
        {
            
            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
               .ShowSmartphone = null;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}
