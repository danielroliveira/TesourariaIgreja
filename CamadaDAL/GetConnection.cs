using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CamadaDAL
{
	public class GetConnection
	{

        public string LoadConnectionString(string SourceXMLFile, string stringName)
        {
            XmlDocument doc = new XmlDocument();

            //--- Try open XML Document
            try
            {
                doc.LoadXml(SourceXMLFile);
            }
            catch (Exception ex)
            {
                throw new Exception("Uma exceção ocorreu ao Ler o arquivo XML... \n" +
                                    ex.Message);
            }


            foreach (XmlNode node in doc.GetElementsByTagName("setting"))
            {
                if (node.Attributes["name"].Value == stringName)
                {
                    return node.SelectSingleNode("value").InnerText;
                }
            }

            return null;

        }

        public bool SaveConnectionStringLocation(string SourceXMLFile, string stringName)
        {
            try
            {
                ConfigurationManager.AppSettings["ConexaoStringFile"] = SourceXMLFile;
                ConfigurationManager.AppSettings["ConexaoStringName"] = stringName;
                // My.MySettings.Default.Save()
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
