using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class CheckCrocodile : BaseState
    {
        private Menus.CheckCrocodileGUI menuComponent;
        public CheckCrocodile() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.CheckCrocodileGUI>(StringConstants.PrefabCheckCrocodile);
            }
            ShowUI();

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

            if (source == menuComponent.Previous_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowElephant());

            }
            else if (source == menuComponent.Next_Button.gameObject)
            {
                Debug.Log(source.name);
                manager.SwapState(new ShowCrocodile());
            }

        }
    }
}

