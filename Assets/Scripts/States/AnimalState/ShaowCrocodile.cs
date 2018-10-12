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
            menuComponent.LabelInfo.SetActive(true);
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);

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
            menuComponent.LabelGreatMessage.SetActive(true);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(true);
            menuComponent.LabelMissPoint.SetActive(false);
            CommonData.currentUser.data.Plus +=(int) StringConstants.CrocodiletReward;
            complete = true;
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().DeleteFeed();
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().ShowCrocodile = null;
            menuComponent.StartCoroutine(SetAnimationTaskCompleet());
        }

        IEnumerator SetAnimationTaskCompleet()
        {
            yield return new WaitForSeconds(3f);
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Hit");
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().AudioSource.clip =CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().SmartiCall_2Alligator;
            CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().AudioSource.Play();
            menuComponent.StartCoroutine(SetAnimationRun());
        }
        IEnumerator SetAnimationRun()
        {
            yield return new WaitForSeconds(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].GetComponent<ControllerCrocodileFeed>().AudioSource.clip.length-1f);
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("Run");
            CommonData.prefabs.gameobjectLookup["ARCamera"].GetComponent<ControllerCrocodileFeed>().StartExitCrocodile();
              menuComponent.StartCoroutine(Exit());
        }
        public void SetAnimationEndShoot()
        {
            CommonData.prefabs.gameobjectLookup["crocodile_01"].GetComponent<Animator>().SetTrigger("EndShoot");
            CommonData.currentUser.data.Minus -= (int)StringConstants.CrocodiletMiss;
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(true);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(true);
            menuComponent.StartCoroutine(HideLabel());
        }
        IEnumerator HideLabel()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);
            
        }
        IEnumerator Exit()
        {
            yield return new WaitForSeconds(4f);
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);
            CommonData.mainManager.stateManager.SwapState(new CheckInsuranceProvider());
          // if (true||CommonData.currentUser.data.SmarticallBuy && CommonData.currentUser.data.contAcssesur==3)
          // {
          //     CommonData.mainManager.stateManager.SwapState(new SpecialBonus());
          // }
          // else
          // {
          //     CommonData.mainManager.stateManager.SwapState(new CheckInsuranceProvider());
          // }
            
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

