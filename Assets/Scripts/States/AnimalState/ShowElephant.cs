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
            ShowUI();
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelPoint.SetActive(false);
            Elephant = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabElephant];
            SetFightAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = this;
            Elephant.GetComponent<CapsuleCollider>().enabled = true;
            
        }
        public override void Update()
        {
            pointElephantVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointElephant].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete&&Vector3.Distance(pointElephantVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("Shark");
                CommonData.mainManager.stateManager.SwapState(new CheckElephant());

            }
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
            Elephant.GetComponent<CapsuleCollider>().enabled = false;
            SetTickleAnimation();
            menuComponent.LabelGreat.SetActive(true);
            menuComponent.LabelPoint.SetActive(true);
            CommonData.currentUser.data.Plus += 250;
            complete = true;
            Elephant.GetComponent<ControllerElephant>().ShowElephant = null;
            Elephant.GetComponent<CapsuleCollider>().enabled = false;
            Elephant.GetComponent<ControllerElephant>().AudioSource.Stop();
            menuComponent.StartCoroutine(ShowLabel());
        }
        IEnumerator ShowLabel()
        {
            yield return new WaitForSeconds(6f);
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelPoint.SetActive(false);

            CommonData.mainManager.stateManager.SwapState(new CheckServiceProvider());
        }
        public override StateExitValue Cleanup()
        {
            SetIdleAnimation();
            Elephant.GetComponent<ControllerElephant>().ShowElephant = null;
            Elephant.GetComponent<CapsuleCollider>().enabled = false;
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
