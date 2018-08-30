using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowTitle : BaseState
    {

        private Menus.ShowTitleGUI menuComponent;
        public ShowTitle()
        { }
        

        // Update is called once per frame
        
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefaMiniMap].GetComponent<Canvas>().enabled=true;
            CommonData.prefabs.gameobjectLookup[StringConstants.Prefa_EN_Button].SetActive(true);
            CommonData.prefabs.gameobjectLookup[StringConstants.Prefa_GM_Button].SetActive(true);
            InitializeUI();
       
            
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowTitleGUI>(StringConstants.PrefabShowTitle);
                menuComponent.LabelInfo.SetActive(true);
              
            }
            ShowUI();
            menuComponent.StartCoroutine(Exit());
        }

      
        IEnumerator Exit()
        {
           
            yield return new WaitForSeconds(5f);

            CommonData.mainManager.stateManager.SwapState(new CheckBancomat());
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
