using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipmentsData
{

    // Category ID
    public string categoryID = "<<ID>>";
    public string categoryName = "<<Name>>";
    public List<ShipmentEntry> shipments = new List<ShipmentEntry>();

    public ShipmentsData()
    {

    }

    public void DeleteShipment(string id)
    {
        List<ShipmentEntry> toDelete = shipments.FindAll(value =>
        {
            return value.a_shipmentId == id;
        });

        foreach (ShipmentEntry entry in toDelete)
        {
            shipments.Remove(entry);
        }
        foreach (ShipmentEntry shipmentEntry in shipments)
        {
            if (shipmentEntry.a_shipmentId == id)
            {
                throw new Exception("shipment already exists");
            }
        }
    }
    public void AddShipment(string id, string name, string description,string link)
    {
        AddShipmentHelper(id, name, description,link, shipments);
    }

    private void AddShipmentHelper(string id, string name, string description, string link,List<ShipmentEntry> shipmentList)
    {
        Debug.Log("Count shipmet 1="+shipmentList.Count);
        List<ShipmentEntry> toDelete = shipmentList.FindAll(value =>
        {
            return value.a_shipmentId == id;
        });

        foreach (ShipmentEntry entry in toDelete)
        {
            shipmentList.Remove(entry);
        }
        foreach (ShipmentEntry shipmentEntry in shipmentList)
        {
            if (shipmentEntry.a_shipmentId == id)
            {
                throw new Exception("shipment already exists");
            }
        }
        shipmentList.Add(new ShipmentEntry(id, name, description,link));
        Debug.Log("Count shipmet 2=" + shipmentList.Count);
    }
    [System.Serializable]
    public class ShipmentEntry
    {

        //  Constructor
        public ShipmentEntry(string id, string name, string descript,string link)
        {
          
           
            this.description = descript;
            this.b_name = name;
            this.a_shipmentId = id;
            this.linkAvatar = link;
        }

        // Unique shipment identifier.
        public string description;
        public string b_name;
        public string a_shipmentId;
        public string linkAvatar;
        // Plaintext string name.
       
       
    }
}
