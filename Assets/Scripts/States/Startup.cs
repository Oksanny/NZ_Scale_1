using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace States
{
    class Startup : BaseState
    {
       // Firebase.Auth.FirebaseAuth auth;
        public const string DefaultDesktopID = "YZZY";

        // Initialization method.  Called after the state
        // is added to the stack.
        public override void Initialize()
        {
           
            // When the game starts up, it needs to either download the user data
            // or create a new profile.
        //    auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

            // On desktop, we just use the default user id.
            manager.PushState(new States.FetchUserData(DefaultDesktopID));

        }
        public override void Resume(StateExitValue results)
        {
            Debug.Log("resume StartUp");
            if (results.sourceState == typeof(FetchUserData))
            {
                Debug.Log("resume5 StartUp");
             //   manager.SwapState(new States.MainMenuMap());

                if (CommonData.currentUserMarker == null)
                {
                    Debug.Log("resume4 StartUp");
                    //  If we can't fetch data, tell the user.
                    manager.PushState(new BasicDialog(StringConstants.CouldNotFetchUserData));
                }
                
            }
            else
            {
                throw new System.Exception("Returned from unknown state: " + results.sourceState);
            }
        }
    }
}
