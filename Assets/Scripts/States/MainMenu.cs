using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    public class MainMenu : BaseState
    {
        private Menus.MainMenuGUI menuComponent;
        public MainMenu() { }
        public override void Initialize()
        {

            InitializeUI();
        }
        private void InitializeUI()
        {
            if (menuComponent == null)
            {
                menuComponent = SpawnUI<Menus.MainMenuGUI>(StringConstants.PrefabMainMenu);
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
            if (source == menuComponent.CreaterCategoryButton.gameObject)
            {
                Debug.Log(source.name);
                // manager.SwapState(new LoadCategory());
               //manager.SwapState(new LoadCategoryList());
            }
            else if (source == menuComponent.CreaterBrendButton.gameObject)
            {
                Debug.Log(source.name);
                //manager.SwapState(new Editor());
            }
            else if (source == menuComponent.CreaterItemButton.gameObject)
            {
                Debug.Log(source.name);
                // manager.SwapState(new CategoryList());
            }

        }
    }
}
