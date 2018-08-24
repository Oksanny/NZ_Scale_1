using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowMissionFailed : BaseState
    {

        private Menus.ShowMissinFailedGUI menuComponent;
        public ShowMissionFailed()
        { }
        

        // Update is called once per frame
        
        public override void Initialize()
        {
           
            InitializeUI();
       
            
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowMissinFailedGUI>(StringConstants.PrefabShowMissionFailed);
                menuComponent.LabelInfo.SetActive(true);
              
            }
            ShowUI();
            menuComponent.StartCoroutine(Exit());
        }

      
        IEnumerator Exit()
        {
           
            yield return new WaitForSeconds(10f);

            CommonData.mainManager.stateManager.SwapState(new ShowCheckoutArea());
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
