using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserMarker  {

	// Database ID
    public string id = "<<ID>>";
    // Plaintext name
    public string name = "<<USER NAME>>";
    public List<MarkerEntry> markers = new List<MarkerEntry>();
    public UserMarker() { }
    public void AddMarker(string markerName, string markerId, string link,double lot,double lonlat)
    {
        AddMarkerHelper(markerName, markerId, link, markers,lot,lonlat);
    }
    private void AddMarkerHelper(string markerName, string markerId, string link, List<MarkerEntry> markerList, double lot, double lonlat)
    {
        // Remove the map if we're saving over something that exists:
        List<MarkerEntry> toDelete = markerList.FindAll(value =>
        {
            return value.markerId == markerId;
        });

        foreach (MarkerEntry entry in toDelete)
        {
            markerList.Remove(entry);
        }

        foreach (MarkerEntry markerEntry in markerList)
        {
            if (markerEntry.markerId == markerId)
                throw new System.Exception("marker already exists");
        }

        markerList.Add(new MarkerEntry(markerName, markerId, link, lot,  lonlat));
    }
    [System.Serializable]
    public class MarkerEntry
    {

        //  Constructor
        public MarkerEntry(string name, string markerId, string link, double latit, double longit)
        {
            this.nameMarker = name;
            this.markerId = markerId;
            this.linkPhoto = link;
            this.latitude = latit;
            this.longitude = longit;
        }

        // Unique database identifier.
        public string markerId;
        // Plaintext string name.
        public string nameMarker = StringConstants.DefaultMarkerName;
        public string linkPhoto;
        public double latitude;
        public double longitude;

    }
}
