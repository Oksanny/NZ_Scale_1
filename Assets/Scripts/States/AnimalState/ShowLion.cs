using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class ShowLion : BaseState
    {
        private ControllerPathLion controllerPathLion;
        private WritingHandler WrHandler;
        private float timeN = 10f;
        private float timeZ = 10;
        private float time;
        private float currentTime;
        private Menus.ShowLionGUI menuComponent;
        public ShowLion() { }
        private GameObject letterHolder;
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if ( !CommonData.StateLion)
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
                menuComponent.LabelInfo.SetActive(true);
                menuComponent.LabelTimeOut.SetActive(false);
                menuComponent.LabelGreat.SetActive(false);
            }
            
        }
        public override void Update()
        {
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
            if (WrHandler != null)
            {
                WrHandler.RefreshProcess();
            }
            menuComponent.StartCoroutine(ShowCheckTime());
        }

        IEnumerator ShowCheckTime()
        {
            yield return new WaitForSeconds(2f);
            menuComponent.LabelTimeOut.SetActive(false);

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
                menuComponent.LabelGreat.SetActive(true);
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
            Object.Destroy(letterHolder);
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            DestroyUI();
            if (WrHandler != null)
            {
                WrHandler.RefreshProcess();
            }
            
            WritingHandler.currentLetterIndex = 0;
            Object.Destroy(letterHolder);
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
