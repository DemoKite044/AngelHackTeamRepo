using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CPS;

namespace DAO
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

        public Dictionary<string, CPS_SimpleXML> Search(string keyword)
        {
            DataConnection class1 = new DataConnection();
             Dictionary<string, CPS_SimpleXML> docs = class1.Search(keyword);
             return docs;                    
        }
    }
}
