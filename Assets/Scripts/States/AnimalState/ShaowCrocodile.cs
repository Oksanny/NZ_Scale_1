using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowCrocodile : BaseState
    {
        private Menus.ShowCrocodileGUI menuComponent;
        private GameObject feedHolder;
        public ShowCrocodile() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowCrocodileGUI>(StringConstants.PrefabShowCrocodile);
            }
            ShowUI();
            menuComponent.Label.SetActive(false);
            
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = this;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().GetNewFeed();
           
        }

        public void SetAnimationFightEating()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Shoot");
        }

        public void SetAnimationEating()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Eating");
            menuComponent.Label.SetActive(true);
            menuComponent.StartCoroutine(ShowLabel());
        }
        public void SetAnimationEndShoot()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("EndShoot");
        }
        
        IEnumerator ShowLabel()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.Label.SetActive(false);
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            DestroyUI();
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = null;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().DeleteFeed();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

          // if (source == menuComponent.Previous_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckCrocodile());
          //
          // }
          // else if (source == menuComponent.Next_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckLion());
          // }

        }
    }
}

