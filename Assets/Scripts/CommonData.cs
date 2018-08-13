using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData 
{

	 public static PrefabList prefabs;
   
    
    public static MainManager mainManager;
    public static GameObject canvasHolder;
    public static DBStruct<UserData> currentUser;
    public static DBStruct<UserMarker> currentUserMarker;
    public static DBStruct<ShipmentsData> currentCategory;
   
   
    // Paths to various database tables:
    // Trailing slashes required, because in some cases
    // we append further paths onto these.
    public const string DBCategoryTablePath = "CategoryList/";
    public const string DBBonusMapTablePath = "BonusMaps/";
    public const string DBUserTablePath = "DB_Users/";
    public const string DBCategoryNEWTablePath = "NEWCategoryList/";
   

    // Whether we're signed in or not.
    public static bool isNotSignedIn = false;

    // Utility function to see if we should be showing menu options that
    // require internet access and a user profile.
    public static bool ShowInternetMenus() {
      return !(isNotSignedIn || currentUser == null);
    }
  
}
