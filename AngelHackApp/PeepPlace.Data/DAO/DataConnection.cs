using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CPS;
using System.Xml;

namespace PeepPlace.Data.DAO
{
    public class DataConnection
    {
        private static CPS_Connection InstantiateConn()
        {
            List<string> connectionStrings = new List<string>();
            connectionStrings.Add("tcp://cloud-eu-0.clusterpoint.com:9007");
            connectionStrings.Add("tcp://cloud-eu-1.clusterpoint.com:9007");
            connectionStrings.Add("tcp://cloud-eu-2.clusterpoint.com:9007");
            connectionStrings.Add("tcp://cloud-eu-3.clusterpoint.com:9007");

            Dictionary<string, string> additionalParams = new Dictionary<string, string>();
            additionalParams["account"] = "1554";

            CPS_Connection cpsConn = new CPS_Connection(new CPS_LoadBalancer(connectionStrings), "Angelhack2015", "reyc21908@gmail.com", "pwHack2015", "document", "//document/id", additionalParams);
            return cpsConn;
        }

        public static void InsertData(XmlDocument xmlDoc)
        {
            CPS_Connection cpsConn = InstantiateConn();
            CPS_Simple cpsSimple = new CPS_Simple(cpsConn);

            // Insert
            cpsSimple.insertSingle("id1", xmlDoc.DocumentElement);
        }

        public Dictionary<string, CPS_SimpleXML> Search(string searchKeyword)
        {
            CPS_Connection cpsConn = InstantiateConn();
            CPS_Simple cpsSimple = new CPS_Simple(cpsConn);
            // search for items with Building == 'searchKeyword' 
            string query = Utils.CPS_Term(searchKeyword);//, "Location/Address/Building");

            // return documents starting with the first one - offset 0
            int offset = 0;

            // return not more than 5 documents
            int docs = 5;

            // return these fields from the documents
            Dictionary<string, string> list = new Dictionary<string, string>();
           
            // order by name
            string ordering = Utils.CPS_StringOrdering("Name", "English", "descending");
            Dictionary<string, CPS_SimpleXML> documents = (Dictionary<string, CPS_SimpleXML>)cpsSimple.search(
                query, offset, docs, list, ordering, CPS_Response.DOC_TYPE.DOC_TYPE_SIMPLEXML);
           
            return documents;
        }
    }
}
