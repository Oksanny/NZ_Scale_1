using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowLion : BaseState
    {
        private Vector3 pointLionVector3;
        private Vector3 pointARCamerVector3;
        private ControllerPathLion controllerPathLion;
        private WritingHandler WrHandler;
        private float timeN = 10f;
        private float timeZ = 10;
        private float time;
        private float currentTime;
        private Menus.ShowLionGUI menuComponent;
        public ShowLion() { }
        private GameObject letterHolder;
        private bool complete;
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCage];

            InitializeUI();
        }
        private void InitializeUI()
        {

            if (!CommonData.StateLion)
            {
                if (menuComponent == null)
                {
                    menuComponent = SpawnUI<Menus.ShowLionGUI>(StringConstants.PrefabShowLion);
                }
                ShowUI();
                time = timeN;
                //  letterHolder =CommonData.prefabs.gameobjectLookup["Letter"];
                //  letterHolder.SetActive(true);
                Debug.Log("Init");
                letterHolder = (GameObject)Object.Instantiate(CommonData.prefabs.gameobjectLookup["Letter"],
                    CommonData.prefabs.gameobjectLookup["SpawnLetter"].transform.position,
                    CommonData.prefabs.gameobjectLookup["SpawnLetter"].transform.rotation);


                letterHolder.gameObject.transform.parent = CommonData.prefabs.gameobjectLookup["CameraLetter"].transform;
                letterHolder.GetComponent<WritingHandler>().ShowLion = this;
                controllerPathLion = CommonData.prefabs.gameobjectLookup["lion_sv_ip"].GetComponent<ControllerPathLion>();
                WrHandler = letterHolder.GetComponent<WritingHandler>();
               // menuComponent.BonusPointStr.text = StringConstants.LionReward.ToString();
               // menuComponent.MissPointsStr.text = StringConstants.LionMiss.ToString();
                menuComponent.LabelInfo.SetActive(true);
                menuComponent.LabelInstruction.SetActive(true);
                menuComponent.LabelTimeOut.SetActive(false);
                menuComponent.LabelGreat.SetActive(false);
                menuComponent.LabelBonusPoint.SetActive(false);
                menuComponent.LabelMissPoint.SetActive(false);

                menuComponent.StartCoroutine(HideInstruction());
            }

        }
        public override void Update()
        {
            pointLionVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointLion].transform.position.z);
            pointARCamerVector3 = new Vector3(CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.x, 0, CommonData.prefabs.gameobjectLookup[StringConstants.ARCamera].transform.position.z);
            if (!complete && Vector3.Distance(pointLionVector3, pointARCamerVector3) > 0.5f)
            {
                Debug.Log("Shark");
                CommonData.mainManager.stateManager.SwapState(new CheckLion());

            }
            if (!CommonData.StateLion)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= time && !WrHandler.clickStarted)
                {
                    currentTime = 0;
                    CheckTime();
                    if (WrHandler != null)
                    {
                        WrHandler.RefreshProcess();
                    }
                }
            }

        }
        public void CheckTime()
        {
            menuComponent.LabelTimeOut.SetActive(true);
            menuComponent.LabelInfo.SetActive(false);
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(true);
            CommonData.currentUser.data.Minus -= (int)StringConstants.LionMiss;
            if (WrHandler != null)
            {
                WrHandler.RefreshProcess();
            }
            menuComponent.StartCoroutine(ShowCheckTime());
        }

        IEnumerator ShowCheckTime()
        {
            yield return new WaitForSeconds(2f);
            //
            menuComponent.LabelInfo.SetActive(false);
            menuComponent.LabelTimeOut.SetActive(false);
            menuComponent.LabelGreat.SetActive(false);
            menuComponent.LabelBonusPoint.SetActive(false);
            menuComponent.LabelMissPoint.SetActive(false);
        }

        IEnumerator HideInstruction()
        {
            yield return new WaitForSeconds(5f);
            menuComponent.LabelInfo.SetActive(false);
        }
        public void FinishLetter()
        {
            if (WritingHandler.currentLetterIndex == 0)
            {
                currentTime = 0;
                if (WrHandler != null)
                {
                    //WrHandler.RefreshProcess();
                }
            }
            if (WritingHandler.currentLetterIndex == 1)
            {
                CommonData.StateLion = true;
                currentTime = 0;
                complete = true;
                menuComponent.LabelGreat.SetActive(true);
                menuComponent.LabelBonusPoint.SetActive(true);
                menuComponent.LabelTimeOut.SetActive(false);
                menuComponent.LabelInfo.SetActive(false);
                menuComponent.LabelMissPoint.SetActive(false);
                CommonData.currentUser.data.Plus += (int)StringConstants.LionReward;
                letterHolder.SetActive(false);
                menuComponent.StartCoroutine(DeleteLetter());
            }


        }

        IEnumerator DeleteLetter()
        {
            yield return new WaitForSeconds(2f);
            if (WrHandler != null)
            {
                WrHandler.RefreshProcess();
            }
            controllerPathLion.StartExit();
            if (CommonData.prefabs.gameobjectLookup[StringConstants.PrefabLion].GetComponent<AudioSource>().isPlaying)
            {
                CommonData.prefabs.gameobjectLookup[StringConstants.PrefabLion].GetComponent<AudioSource>().Stop();
            }
            yield return new WaitForSeconds(4f);
            CommonData.mainManager.stateManager.SwapState(new CheckSmartphone());
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {
            if (WrHandler != null)
            {
                WrHandler.RefreshProcess();
            }

            WritingHandler.currentLetterIndex = 0;
            Object.Destroy(letterHolder);
            DestroyUI();


            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {


            //  if (source == menuComponent.Previous_Button.gameObject)
            //  {
            //      Debug.Log(source.name);
            //      manager.SwapState(new ShowLion());
            //
            //  }
            //  else if (source == menuComponent.Next_Button.gameObject)
            //  {
            //      Debug.Log(source.name);
            //      manager.SwapState(new CheckShark());
            //  }
        }
    }
}
