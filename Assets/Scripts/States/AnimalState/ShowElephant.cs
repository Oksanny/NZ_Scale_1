using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowElephant : BaseState
    {
        private Menus.ShowElephantGUI menuComponent;
        private GameObject Elephant;
        public ShowElephant() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowElephantGUI>(StringConstants.PrefabShowElephant);
            }
            ShowUI();
            menuComponent.Label.SetActive(false);
            Elephant = CommonData.prefabs.gameobjectLookup["Baby_Elephant"];
            SetFightAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = this;
            Elephant.GetComponent<CapsuleCollider>().enabled = true;
            
        }
        public override void Suspend()
        {
            Elephant.GetComponent<CapsuleCollider>().enabled = false;
            HideUI();
        }

        public void SetIdleAnimation()
        {
            Elephant.GetComponent<Animator>().SetTrigger("Idle");
        }
        public void SetFightAnimation()
        {
            Elephant.GetComponent<Animator>().SetTrigger("Fight");
        }
        public void SetTickleAnimation()
        {
            Elephant.GetComponent<Animator>().SetTrigger("Fight_2");
        }
        public void ShowResult()
        {
            menuComponent.Label.SetActive(true);
            menuComponent.StartCoroutine(ShowLabel());
        }
        IEnumerator ShowLabel()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.Label.SetActive(false);
        }
        public override StateExitValue Cleanup()
        {
            SetIdleAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = null;
            
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

          // if (source == menuComponent.Previous_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckElephant());
          //
          // }
          // else if (source == menuComponent.Next_Button.gameObject)
          // {
          //     Debug.Log(source.name);
          //     manager.SwapState(new CheckCrocodile());
          // }

        }
    }
}
