using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleAppReadXMLFiltering
{
    public class Translations
    {
        public List<string> generateTranslationFiles()
        {
            XmlDataDocument xml = new XmlDataDocument();
            XmlNodeList xmlnode;
            //string language = "ru";
            //string filename = "Bilingual_ru_2022-06-28 0546.xlf";
            string language = "es";
            string filename = "Bilingual_es_2022-06-28 0516.xlf";
            //string language = "fr";
            //string filename = "Bilingual_fr_2022-06-28 0522.xlf";

            FileStream fs = new FileStream(@"C:\Users\SalcedJ\source\repos\ConsoleAppReadXMLFiltering\ConsoleAppReadXMLFiltering\xmlFiles\" + filename, FileMode.Open, FileAccess.Read);
            xml.Load(fs);

            XmlNode innerNodes = xml.DocumentElement.SelectSingleNode("/xliff/file/body");

            StringBuilder sb = new StringBuilder();
            List<string> fileContent = new List<string>();
            List<string> flowNames = new List<string>();
            flowNames.Add("Flow.Flow.Add_All_Security_Risks.1");
            flowNames.Add("Flow.Flow.X1st_Notification_Location_Security_Risk_Assessment.8");
            flowNames.Add("Flow.Flow.X1st_Notification_National_Security_Context.5");
            flowNames.Add("Flow.Flow.Risk_Register_Approved.31");
            flowNames.Add("Flow.Flow.Risk_Register_Submitted.22");
            flowNames.Add("Flow.Flow.Last_Day_Notification_National_Security_Context.3");
            flowNames.Add("Flow.Flow.Last_Day_Notification_Location_Security_Risk_Assessment.3");
            flowNames.Add("Flow.Flow.Risk_Review_Submitted.31");
            flowNames.Add("Flow.Flow.Risk_Review_Approved.28");
            flowNames.Add("Flow.Flow.Bulk_Adding_Risk_into_Risk_Review.12");
            flowNames.Add("Flow.Flow.NA_Risk_Review_Flow_French_V2.5");
            flowNames.Add("Flow.Flow.NA_Risk_Review_Flow_Russian_V2.5");
            flowNames.Add("Flow.Flow.NA_Risk_Review_Flow_Spanish_V2.6");
            flowNames.Add("Flow.Flow.NA_Risk_Review_Flow_English_V2.3");
            flowNames.Add("Flow.Flow.NA_Risk_Review_Flow.14");
            flowNames.Add("Flow.Flow.Bulk_Update_Risk_Values_on_Risk_Review.1");

            fileContent.Add(@"<?xml version=""1.0"" encoding=""UTF-8""?>
   <xliff version=""1.2"">   
       <file original=""Salesforce"" source-language=""en_US"" target-language=""" + language + @""" translation-type=""metadata"" datatype=""xml"">
                  <body>");

            foreach (XmlNode node in innerNodes.ChildNodes)
            {
                String name = node.Attributes["id"].Value;
                String newName = "";
                String oldName = "";
                if (flowNames.Any(s => name.Contains(s)))
                {
                    oldName = flowNames.FirstOrDefault(s => name.Contains(s));
                    newName = oldName.Substring(0, oldName.LastIndexOf(".") + 1) + "1";
                    fileContent.Add(node.OuterXml.Replace(oldName, newName));
                }
            }

            fileContent.Add(@"</body>
    </file>
</xliff>");

            File.WriteAllLines("newfile_" + language + ".xlf", fileContent);
            return fileContent;
        }
    }
}
