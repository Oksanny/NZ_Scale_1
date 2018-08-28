using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowShark : BaseState
    {
        private Menus.ShowSharkGUI menuComponent;
        private Vector3 pointSharktVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        public ShowShark() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark];

            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowSharkGUI>(StringConstants.PrefabShowShark);
            }
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelMiss.SetActive(false);
            menuComponent.LabelPoint.SetActive(false);
            ShowUI();
            
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().ShowShark = this;
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().GetNewFeed();
        }
        public override void Update()
        {
            pointSharktVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointShark].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointSharktVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("Shark");
                CommonData.mainManager.stateManager.SwapState(new CheckShark());

            }
        }
        public void SetAnimationFightEating()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<Animator>().SetTrigger("Shoot");
        }

        public void SetAnimationEating()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<Animator>().SetTrigger("Eating");
            
            menuComponent.StartCoroutine(ShowLabelGreat());
        }

        
        public void SetAnimationEndShoot()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<Animator>().SetTrigger("EndShoot");
            menuComponent.StartCoroutine(ShowLAbelMiss());
        }
        
        IEnumerator ShowLAbelMiss()
        {
            menuComponent.LabelMiss.SetActive(true);
            yield return new WaitForSeconds(1f);
            menuComponent.LabelMiss.SetActive(false);
        }
        IEnumerator ShowLabelGreat()
        {
            menuComponent.LabelGreat.SetActive(true);
            menuComponent.LabelPoint.SetActive(true);
            CommonData.currentUser.data.Plus += 250;
            complete = true;
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().DeleteFeed();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().ShowShark = null;
            yield return new WaitForSeconds(2f);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<Animator>().SetTrigger("EndShoot");
            CommonData.mainManager.stateManager.SwapState(new CheckServiceProvider());
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            DestroyUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabShark].GetComponent<Animator>().SetTrigger("EndShoot");
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().DeleteFeed();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerSharkFeed>().ShowShark = null;
            
            
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
