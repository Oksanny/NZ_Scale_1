using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowElephant : BaseState
    {
        private Menus.ShowElephantGUI menuComponent;
        private GameObject Elephant;
        private Vector3 pointElephantVector3;
        private Vector3 pointARCamerVector3;
        private bool complete;
        public ShowElephant() { }
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabElephant];

            InitializeUI();
        }
        private void InitializeUI()
        {
            
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowElephantGUI>(StringConstants.PrefabShowElephant);
            }
           // menuComponent.BonusPointStr.text = StringConstants.ElephantReward.ToString();
           // menuComponent.MissPointStr.text = StringConstants.ElephantMiss.ToString();
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);
            menuComponent.LabelInfo.SetActive(true);
            Elephant = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabElephant];
            SetFightAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = this;
            Elephant.GetComponent<ControllerElephant>().ColliderCheck.enabled = true;

          //  Elephant.GetComponent<CapsuleCollider>().enabled = true;
            ShowUI();
        }
        public override void Update()
        {
            pointElephantVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointElephantVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("Shark");
              //  CommonData.mainManager.stateManager.SwapState(new CheckElephant());

            }
        }
        public override void Suspend()
        {
            Elephant.GetComponent<ControllerElephant>().ColliderCheck.enabled = false;
           // Elephant.GetComponent<CapsuleCollider>().enabled = false;
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

        public void ShowMiss()
        {
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(true);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(true);
            CommonData.currentUser.data.Minus -=(int) StringConstants.ElephantMiss;
            menuComponent.StartCoroutine(HideElement());
        }
        public void ShowResult()
        {
            complete = true;
            Elephant.GetComponent<ControllerElephant>().ColliderCheck.enabled = false;
          //  Elephant.GetComponent<CapsuleCollider>().enabled = false;
            Elephant.GetComponent<ControllerElephant>().AudioSource.Play();
            SetTickleAnimation();
            menuComponent.LabelGreatMessage.SetActive(true);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(true);
            menuComponent.LabelMissPoint.SetActive(false);
            CommonData.currentUser.data.Plus +=(int) StringConstants.ElephantReward;
            
            Elephant.GetComponent<ControllerElephant>().ShowElephant = null;
            Elephant.GetComponent<ControllerElephant>().ColliderCheck.enabled = false;
          //  Elephant.GetComponent<CapsuleCollider>().enabled = false;
          //  Elephant.GetComponent<ControllerElephant>().AudioSource.Stop();
            menuComponent.StartCoroutine(ShowLabel());
        }
        IEnumerator ShowLabel()
        {
            yield return new WaitForSeconds(Elephant.GetComponent<ControllerElephant>().AudioSource.clip.length-1f);
            SetIdleAnimation();
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);

            CommonData.mainManager.stateManager.SwapState(new CheckServiceProvider());
        }

        IEnumerator HideElement()
        {
            yield return new WaitForSeconds(1.5f);
            menuComponent.LabelGreatMessage.SetActive(false);
            menuComponent.LabelMissMessage.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);
        }
        public override StateExitValue Cleanup()
        {
            SetIdleAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = null;
            Elephant.GetComponent<ControllerElephant>().ColliderCheck.enabled = false;
           // Elephant.GetComponent<CapsuleCollider>().enabled = false;
            Elephant.GetComponent<ControllerElephant>().AudioSource.Stop();
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
