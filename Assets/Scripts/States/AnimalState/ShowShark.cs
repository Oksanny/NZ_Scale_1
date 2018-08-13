using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowShark : BaseState
    {
        private Menus.ShowSharkGUI menuComponent;
        private GameObject feedHolder;
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
            feedHolder = (GameObject)Object.Instantiate(CommonData.prefabs.gameobjectLookup["PathMagicPathShark"],
                CommonData.prefabs.gameobjectLookup["SpawnPathFeedShark"].transform.position,
                CommonData.prefabs.gameobjectLookup["SpawnPathFeedShark"].transform.rotation);
            feedHolder.gameObject.transform.parent = CommonData.prefabs.gameobjectLookup["ARCamera"].transform;
            feedHolder.GetComponent<ControllerSharkFeed>().ShowShark = this;
            
        }

        public void ChangeAnimation()
        {
            CommonData.prefabs.gameobjectLookup["PA_Shark"].GetComponent<Animator>().SetTrigger("Feed");
            menuComponent.Label.SetActive(true);
            menuComponent.StartCoroutine(ShowLabel());
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
            Object.Destroy(feedHolder);
            
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
