using ServiceRestExample.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace ServiceRestExample.Controllers
{
    public class PowerBiController : ApiController
    {

        PowerBiReportMethod powerBiReportMethod = new PowerBiReportMethod();

        // GET: api/PowerBiReport
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PowerBiReport/1
        //http://localhost:50325/api/PowerBi/1
        //public string Get(int id)
        //{

        //    string stringxml = null;

        //    if (id == 1)
        //    {
        //        //method to convert xml to a string
        //        XmlDocument powerBiReport = new XmlDocument();
        //        powerBiReport.Load("\\users\\MINI PC JEANNORY 64\\source\\repos\\ServiceRestExample" +
        //                            "\\ServiceRestExample\\Files\\powerBiReport.xml");
        //        stringxml = powerBiReportMethod.GetStringFromXml(powerBiReport);

        //        return stringxml;
        //    }

        //    return "error";
        //}

        // GET: api/PowerBiReport/1
        //public Records Get(int id)
        //{

        //    string stringxml = null;

        //    if (id == 1)
        //    {


        //        //method to convert xml to a string
        //        XmlDocument powerBiReport = new XmlDocument();
        //        powerBiReport.Load("\\users\\MINI PC JEANNORY 64\\source\\repos\\ServiceRestExample" +
        //                            "\\ServiceRestExample\\Files\\powerBiReport.xml");
        //        stringxml = powerBiReportMethod.GetStringFromXml(powerBiReport);


        //        //Deserialize the string
        //        Records records = powerBiReportMethod.Deserialize<Records>(stringxml);

        //        //Manipulate the RSA object to create a new object NewPowerBiReport
        //        powerBiReportMethod.getNewPowerBiReport(records);

        //        return records;
        //    }

        //    return null;
        //}

        // GET: api/PowerBiReport/1
        public List<NewPowerBiReport> Get(int id)
        {

            string stringxml = null;

            if (id == 1)
            {

                //method to convert xml to a string
                XmlDocument powerBiReport = new XmlDocument();
                powerBiReport.Load("C:\\PowerBi\\InitialePowerBiReport.xml");
                stringxml = powerBiReportMethod.GetStringFromXml(powerBiReport);


                //Deserialize the string
                Records records = powerBiReportMethod.Deserialize<Records>(stringxml);

                //Manipulate the RSA object to create a new object NewPowerBiReport + Serialize object to a xml file
                List<NewPowerBiReport> newPowerBiReports = powerBiReportMethod.getNewPowerBiReport(records);

                return newPowerBiReports;


            }

            return null;
        }


        // POST: api/PowerBiReport
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PowerBiReport/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PowerBiReport/5
        public void Delete(int id)
        {
        }
    }
}
