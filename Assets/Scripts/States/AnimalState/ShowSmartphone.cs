using System.Collections;
using System.Collections.Generic;
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
                CommonData.mainManager.stateManager.SwapState(new CheckSmartphone());
                
            }

        }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointSmartphone].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone];

            InitializeUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
                .ShowSmartphone = this;

        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowSmartphoneGUI>(StringConstants.PrefabShowSmartphone);
               
                menuComponent.LabelPointCommunata.SetActive(false);
                menuComponent.LabelPointsSmartical.SetActive(false);
            }
            ShowUI();

        }
        public void SelectCommunata()
        {
            Debug.Log("Sc");
            menuComponent.LabelPointCommunata.SetActive(true);
            CommonData.currentUser.data.Minus -= 600;
            complete = true;
            menuComponent.StartCoroutine(Exit());
        }
        public void SelectSmartical()
        {
            Debug.Log("SS");
            complete = true;
            menuComponent.LabelPointsSmartical.SetActive(true);
            CommonData.currentUser.data.Minus -= 1000;
            menuComponent.StartCoroutine(Exit());
        }
        IEnumerator Exit()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
               .ShowSmartphone = null;
            yield return new WaitForSeconds(6f);
           CommonData.mainManager.stateManager.SwapState(new CheckLion());

        }
        public override void Suspend()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>()
               .ShowSmartphone = null;
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
