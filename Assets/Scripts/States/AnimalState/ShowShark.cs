using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowShark : BaseState
    {
        private Menus.ShowSharkGUI menuComponent;
        
        public ShowShark() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowSharkGUI>(StringConstants.PrefabShowShark);
            }
            menuComponent.Label.SetActive(false);
            ShowUI();
            
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerSharkFeed>().ShowShark = this;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerSharkFeed>().GetNewFeed();
        }

        public void SetAnimationFightEating()
        {
            CommonData.prefabs.gameobjectLookup["PA_Shark"].GetComponent<Animator>().SetTrigger("Shoot");
        }

        public void SetAnimationEating()
        {
            CommonData.prefabs.gameobjectLookup["PA_Shark"].GetComponent<Animator>().SetTrigger("Eating");
            menuComponent.Label.SetActive(true);
            menuComponent.StartCoroutine(ShowLabel());
        }
        public void SetAnimationEndShoot()
        {
            CommonData.prefabs.gameobjectLookup["PA_Shark"].GetComponent<Animator>().SetTrigger("EndShoot");
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
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerSharkFeed>().ShowShark = null;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerSharkFeed>().DeleteFeed();
            
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

          // if (source == menuComponent.Previous_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckShark());
          //
          // }
          // else if (source == menuComponent.Next_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckElephant());
          // }

        }
    }
}
