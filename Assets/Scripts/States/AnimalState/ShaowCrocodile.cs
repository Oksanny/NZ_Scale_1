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
        private Vector3 pointCrocodileVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCrocodile];

            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowCrocodileGUI>(StringConstants.PrefabShowCrocodile);
            }
            ShowUI();
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelMiss.SetActive(false);
            menuComponent.LabelPoint.SetActive(false);

            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = this;
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().GetNewFeed();
           
        }
        public override void Update()
        {
            pointCrocodileVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCrocodile].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointCrocodileVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("Shark");
                CommonData.mainManager.stateManager.SwapState(new CheckCrocodile());

            }
        }
        public void SetAnimationFightEating()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Shoot");
        }

        public void SetAnimationEating()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Eating");
            menuComponent.LabelGreat.SetActive(true);
            menuComponent.LabelPoint.SetActive(true);
            CommonData.currentUser.data.Plus += 250;
            complete = true;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().DeleteFeed();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = null;
            menuComponent.StartCoroutine(Exit());
        }
        public void SetAnimationEndShoot()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("EndShoot");
            menuComponent.LabelMiss.SetActive(true);
            menuComponent.StartCoroutine(HideLabel());
        }
        IEnumerator HideLabel()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.LabelMiss.SetActive(false);
            
        }
        IEnumerator Exit()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.LabelGreat.SetActive(false);
            if (CommonData.currentUser.data.SmarticallBuy && CommonData.currentUser.data.contAcssesur==3)
            {
                CommonData.mainManager.stateManager.SwapState(new SpecialBonus());
            }
            else
            {
                CommonData.mainManager.stateManager.SwapState(new CheckInsuranceProvider());
            }
            
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            DestroyUI();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = null;
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().DeleteFeed();
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

