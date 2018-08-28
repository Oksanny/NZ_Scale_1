using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    public class ShowCheckoutArea : BaseState
    {

        private Menus.ShowCheckoutAreaGUI menuComponent;
        public ShowCheckoutArea()
        { }
        

        // Update is called once per frame
        
        public override void Initialize()
        {
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckoutArea].GetComponent<bl_MiniMapItem>().Size = 0; 
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabCheckPointCheckoutArea].SetActive(false);
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabArrowController].GetComponent<ControllerLookAtPoint>().Target = null;
            CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].GetComponent<ControllerTime>().StopTime = true;
            AddBonuse();
            InitializeUI();
       
            
        }
        private void InitializeUI()
        {
           
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.ShowCheckoutAreaGUI>(StringConstants.PrefabShowCheckoutAre);
                menuComponent.LabelInfo.SetActive(true);
              
            }
            ShowUI();

            menuComponent.StartCoroutine(Exit());
        }

        void AddBonuse()
        {
            int bonuse = 0;
            int current = (int)StringConstants.TimeGame - (int)CommonData.prefabs.gameobjectLookup[StringConstants.PrefabTimer].GetComponent<ControllerTime>().currentTime;
            Debug.Log(current);
            if (current <= StringConstants.TimePoint_1)
            {
                Debug.Log("1");
                bonuse = ((int)StringConstants.TimePoint_1 - current) * 20 +
                         ((int)StringConstants.TimePoint_2 - (int)StringConstants.TimePoint_1) * 10;
            }
            else
            {
                if (current <= StringConstants.TimePoint_2)
                {
                    Debug.Log("2");
                    bonuse = ((int)StringConstants.TimePoint_2 - current) * 10;
                }
                else
                {
                    if (current <= StringConstants.TimePoint_3)
                    {
                        Debug.Log("3");
                        bonuse = (current - (int)StringConstants.TimePoint_2) * (-5);
                    }
                    else
                    {
                        if (current <= StringConstants.TimeGame)
                        {
                            Debug.Log("4");
                            bonuse = (current - (int)StringConstants.TimePoint_3) * (-10) + ((int)StringConstants.TimePoint_3 - (int)StringConstants.TimePoint_2) * (-5);
                        }
                    }
                }
            }
            if (bonuse >= 0)
            {
                CommonData.currentUser.data.Plus += bonuse;
            }
            else
            {
                CommonData.currentUser.data.Minus += bonuse;
            }
            Debug.Log(bonuse);
        }
        IEnumerator Exit()
        {
           
            yield return new WaitForSeconds(10f);
          
            CommonData.mainManager.stateManager.SwapState(new ShowReset());

        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {

            
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {



        }
    }
}
