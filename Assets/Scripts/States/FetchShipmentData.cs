using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace States
{
    class FetchShipmentData : BaseState
    {
        private string categoryID;
        private string categoryName;

        public FetchShipmentData(string id,string name)
        {
            categoryID = id;
            categoryName = name;
        }

        public override void Initialize()
        {
          
            manager.PushState(
              new WaitingForDBLoad<ShipmentsData>(CommonData.DBCategoryTablePath + categoryID));
        }
        public override StateExitValue Cleanup()
        {
            return new StateExitValue(typeof(FetchShipmentData), null);
        }
        public override void Resume(StateExitValue results)
        {
            Debug.Log("Resume FetchUserData");
            if (results != null)
            {
                if (results.sourceState == typeof(WaitingForDBLoad<ShipmentsData>))
                {
                    var resultData = results.data as WaitingForDBLoad<ShipmentsData>.Results;
                    if (resultData.wasSuccessful)
                    {
                        if (resultData.results != null)
                        {
                            // Got some results back!  Use this data.
                         //  CommonData.currentCategory = new DBStruct<ShipmentsData>(
                         //      CommonData.DBCategoryTablePath + categoryID, CommonData.app);
                         //  CommonData.currentCategory.Initialize(resultData.results);
                         //  Debug.Log("Fetched user " + CommonData.currentUser.data.name);
                        }
                        else
                        {
                            // Make a new user, using default credentials.
                         //  Debug.Log("Could not find category " + categoryName + " - Creating new profile.");
                         //  ShipmentsData temp = new ShipmentsData(){categoryID = this.categoryID, categoryName = this.categoryName};
                         //
                         //  CommonData.currentCategory = new DBStruct<ShipmentsData>(
                         //    CommonData.DBCategoryTablePath + categoryID, CommonData.app);
                         //  CommonData.currentCategory.Initialize(temp);
                         //  CommonData.currentCategory.PushData();
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

