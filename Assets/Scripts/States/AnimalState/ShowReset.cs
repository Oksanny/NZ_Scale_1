using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowReset : BaseState
    {

        private Menus.ShowResetGUI menuComponent;
        public ShowReset()
        { }
        

        // Update is called once per frame
        
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabResetButton].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].SetActive(false);
             CommonData.prefabs.gameobjectLookup[StringConstants.PrefabBancomat].GetComponent<ControllerBancomat>().Rewind();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().Rewind();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabInfoBox].GetComponent<ControllerInfoBox>().Rewind();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabSmartphone].GetComponent<ControllerSmartphone>().Rewind();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShelf].GetComponent<ControllerShelf>().Rewind();
            CommonData.prefabs.gameobjectLookup["lion_sv_ip"].GetComponent<ControllerPathLion>().Rewind();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabKioskInsurance].GetComponent<ControllerInsuranceProvider>().Rewind();
            InitializeUI();
       
            
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowResetGUI>(StringConstants.PrefabShowReset);
                menuComponent.LabelInfo.SetActive(true);
              
            }
            ShowUI();
          //  menuComponent.StartCoroutine(Exit());
        }

      
        IEnumerator Exit()
        {
           
            yield return new WaitForSeconds(5f);

          //  CommonData.mainManager.stateManager.SwapState(new CheckBancomat());
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
