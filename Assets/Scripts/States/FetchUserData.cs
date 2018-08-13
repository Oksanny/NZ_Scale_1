using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States
{
    // Утилита состояния для получения пользовательских данных. (Или создать новый профиль пользователя, если данные не могут быть получены.)
    // В основном просто выполняет выборку, а затем возвращает результат в любое вызванное им состояние.
    class FetchUserData : BaseState
    {
        private string userID;

        public FetchUserData(string userID)
        {
            this.userID = userID;
        }
        // Это состояние предназначено для простого и удобного способа использования состояния WaitingForDBLoad 
        // для получения пользовательских данных, а затем обработки полученных результатов.
        public override void Initialize()
        {
            Debug.Log("Init FetchUserData");
            
            manager.PushState(
              new WaitingForDBLoad<UserMarker>(CommonData.DBUserTablePath + userID));
        }
        public override StateExitValue Cleanup()
        {
            return new StateExitValue(typeof(FetchUserData), null);
        }
        public override void Resume(StateExitValue results)
        {
            Debug.Log("Resume FetchUserData");
            if (results != null)
            {
                if (results.sourceState == typeof(WaitingForDBLoad<UserMarker>))
                {
                    var resultData = results.data as WaitingForDBLoad<UserMarker>.Results;
                    if (resultData.wasSuccessful)
                    {
                        if (resultData.results != null)
                        {
                            // Got some results back!  Use this data.
                         //  CommonData.currentUserMarker = new DBStruct<UserMarker>(
                         //      CommonData.DBUserTablePath + userID, CommonData.app);
                         //  CommonData.currentUserMarker.Initialize(resultData.results);
                         //  Debug.Log("Fetched user " + CommonData.currentUserMarker.data.name);
                        }
                        else
                        {
                            // Make a new user, using default credentials.
                         //  Debug.Log("Could not find user " + userID + " - Creating new profile.");
                         //  UserMarker temp = new UserMarker();
                         //  temp.name = StringConstants.DefaultUserName;
                         //  temp.id = userID;
                         //  CommonData.currentUserMarker = new DBStruct<UserMarker>(
                         //    CommonData.DBUserTablePath + userID, CommonData.app);
                         //  CommonData.currentUserMarker.Initialize(temp);
                         //  CommonData.currentUserMarker.PushData();
                        }
                    }
                    else
                    {
                        // Can't fetch data.  Assume internet problems, stay offline.
                        CommonData.currentUser = null;
                    }
                }
            }
            // Whether we successfully fetched, or had to make a new user,
            // return control to the calling state.
            manager.PopState();
        }
    }
}
