using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CPS;
using PeepPlace.Data.DAO;
using PeepPlace.Common.Entities;

namespace PeepPlace.Core.Businesses
{
    public class Business
    {
        public void InsertXML(string name, string floor, string building, string street, string barangay, string town, string province)
        {
            XmlDocument xmlDoc = new XmlDocument();
            Guid siteId = Guid.NewGuid();
            Guid locId = Guid.NewGuid();
            xmlDoc.LoadXml(string.Format("<document><id>{0}</id><Name>{1}</Name><Floor>{2}</Floor><Building>{3}</Building><Street>{4}</Street><Barangay>{5}</Barangay><Town>{6}</Town>"+
                 "<Province>{7}</Province></document>",siteId, name,
                 floor,building, street,barangay,town, province));
            DataConnection.InsertData(xmlDoc);
            
        }

        public List<Location> Search(string keyword)
        {
            DataConnection data = new DataConnection();
            var locations = new List<Location>();
             foreach (KeyValuePair<string, CPS_SimpleXML> pair in data.Search(keyword))
             {
                 //var test = pair.Value["Location"]["Address"].GetChild("Floor");
                 locations.Add(new Location
                 {
                     Name = pair.Value.GetChild("Name"),
                     Floor = string.IsNullOrEmpty(pair.Value.GetChild("Floor")) ? string.Empty : pair.Value.GetChild("Floor") + "F",
                     Building = pair.Value.GetChild("Building"),
                     City = pair.Value.GetChild("Town"),
                     Province = pair.Value.GetChild("Province")
                 });
             }
             return locations;                    
        }
    }
}
