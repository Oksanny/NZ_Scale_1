using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckLion : BaseState
    {
        private Menus.CheckLionGUI menuComponent;
        public CheckLion() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckLionGUI>(StringConstants.PrefabCheckLion);
            }
            ShowUI();
            CommonData.StateAnimal = true;
        }
        public override void Suspend()
        {

            HideUI();
        }

        public override StateExitValue Cleanup()
        {
            CommonData.StateAnimal = false;
            DestroyUI();
            return null;
        }

        public override void HandleUIEvent(GameObject source, object eventData)
        {

            if (source == menuComponent.Previous_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowCrocodile());

            }
            else if (source == menuComponent.Next_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowLion());
            }

        }
    }
}

