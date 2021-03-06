﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabList : MonoBehaviour {
    
    // Lookup dictionaries, for quickly finding the prefab, given a name.

    // List of all the prefabs that contain menu screens for UI.  Populated
    // via the Unity inspector.  Similar to the prefab list, these get
    // processed into a dictionary at runtime to make lookups easier.
    public MenuEntry[] menuScreens;
    public GameObjectEntry[] GameobjectEntries;
    [HideInInspector]
    public Dictionary<string, GameObject> menuLookup;
    [HideInInspector]
    public Dictionary<string, GameObject> gameobjectLookup;
    void Awake()
    {
        menuLookup = new Dictionary<string, GameObject>();
        foreach (MenuEntry entry in menuScreens)
        {
            menuLookup[entry.name] = entry.prefab;
        }
        gameobjectLookup = new Dictionary<string, GameObject>();
        foreach (GameObjectEntry entry in GameobjectEntries)
        {
            gameobjectLookup[entry.name] = entry.prefab;
        }
        Debug.Log("menuLookUp Count=" + menuLookup.Count);
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[System.Serializable]
public struct MenuEntry
{
    public MenuEntry(string name, GameObject prefab)
    {
        this.name = name;
        this.prefab = prefab;
    }
    public string name;
    public GameObject prefab;
}
[System.Serializable]
public struct GameObjectEntry
{
    public GameObjectEntry(string name, GameObject prefab)
    {
        this.name = name;
        this.prefab = prefab;
    }
    public string name;
    public GameObject prefab;
}
