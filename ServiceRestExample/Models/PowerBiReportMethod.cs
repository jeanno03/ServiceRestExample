using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceRestExample.Models
{
    public class PowerBiReportMethod
    {

        //To get a string from a xml
        public string GetStringFromXml(XmlDocument powerBiReport)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            powerBiReport.WriteTo(tx);

            string str = sw.ToString();
            return str;
        }

        //https://www.codeproject.com/Articles/1163664/Convert-XML-to-Csharp-Object
        //Deserialize a string to an object
        public T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        //en paramatre l'object Record RSA
        //en sortie l'object NewPowerBiReport
        public List<NewPowerBiReport> getNewPowerBiReport(Records records)
        {

            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(tr1);

            TextWriterTraceListener tr2 = new TextWriterTraceListener(System.IO.File.CreateText("C:\\PowerBi\\Output.txt"));
            Debug.Listeners.Add(tr2);

            Debug.Indent();
            Debug.WriteLine("Debug Information-Product Starting");
            Debug.WriteLine("The product name is PowerBiReport");
            Debug.WriteLine("**********************************");

            Record[] record = records.Record;

            List<NewPowerBiReport> newPowerBiReports = new List<NewPowerBiReport>();


            for (int a = 0; a < record.Length; a++)
            {
                Debug.WriteLine("record[a].contentId :" + record[a].contentId);

                //On créé le nouvel object
                NewPowerBiReport newPowerBiReport = new NewPowerBiReport() { };
                List<Ville> villes = new List<Ville>();
                List<Couleure> couleures = new List<Couleure>();

                //On ajoute ContentId
                newPowerBiReport.ContentId = record[a].contentId;

                RecordField[] field = record[a].Field;


                for (int b=0; b< field.Length; b++)
                {
                    Debug.WriteLine("field[b].id : " + field[b].id);

                    try
                    {
                        Debug.WriteLine("field[b].Value : " + field[b].Value);

                        //On ajoute Control_Name
                        if (field[b].id == "22682")
                        {
                            newPowerBiReport.Control_Name = field[b].Value;
                        }

                        //On ajoute Antivirus_Installes
                        if (field[b].id == "22679")
                        {
                            newPowerBiReport.Antivirus_Installes = field[b].Value;
                        }

                        //On ajoute Nb_Postes_Travail
                        if (field[b].id == "22678")
                        {
                            newPowerBiReport.Nb_Postes_Travail = field[b].Value;
                        }

                        //On ajoute Exploitation_Vuln
                        if (field[b].id == "22681")
                        {
                            newPowerBiReport.Exploitation_Vuln = field[b].Value;
                        }

                        //On ajoute FormuleToApply
                        if (field[b].id == "22677")
                        {
                            newPowerBiReport.FormuleToApply = field[b].Value;
                        }

                        //On ajoute Pourcentage_Conformite
                        if (field[b].id == "22680")
                        {
                            newPowerBiReport.Pourcentage_Conformite = field[b].Value;
                        }

                        RecordFieldListValuesListValue[] recordFieldListValues = field[b].ListValues;

                        try
                        {
                            for (int c = 0; c < recordFieldListValues.Length; c++)
                            {
                                Debug.WriteLine("recordFieldListValues[c].Value : " + recordFieldListValues[c].Value);

                                //On ajoute Ville 
                                if (field[b].id == "2233")
                                {
                                    Ville ville = new Ville() { Nom = recordFieldListValues[c].Value };
                                    villes.Add(ville);
                                }

                                //On ajoute Prenom 
                                if (field[b].id == "2244")
                                {
                                    newPowerBiReport.Prenom = recordFieldListValues[c].Value;
                                }

                            }
                        }
                        catch (NullReferenceException ex)
                        {
                            Debug.WriteLine("recordFieldListValues[c].Value : empty ");
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        Debug.WriteLine("field[b].Value : empty ");
                    }



                }

                try
                {
                    Record[] record1 = record[a].Record1;

                    for(int a1=0;a1< record1.Length; a1++)
                    {
                        Debug.WriteLine("record1[a1].contentId : " + record1[a1].contentId);

                        RecordField[] field1 = record1[a1].Field;

                        for (int b1 = 0; b1 < field1.Length; b1++)
                        {
                            Debug.WriteLine("field1[b1].id : " + field1[b1].id);
                            try
                            {
                                Debug.WriteLine("field1[b1].Value : " + field1[b1].Value);

                                RecordFieldListValuesListValue[] recordFieldListValues1 = field1[b1].ListValues;

                                try
                                {
                                    for (int c1 = 0; c1 < recordFieldListValues1.Length; c1++)
                                    {
                                        Debug.WriteLine("recordFieldListValues1[c1].Value : " + recordFieldListValues1[c1].Value);

                                        //On ajoute Couleure  
                                        if (field1[b1].id == "2255")
                                        {
                                            Couleure couleure = new Couleure() { Nom = recordFieldListValues1[c1].Value };
                                            couleures.Add(couleure);
                                        }

                                    }
                                }
                                catch (NullReferenceException ex)
                                {
                                    Debug.WriteLine("recordFieldListValues1[c1].Value : empty ");
                                }
                            }
                            catch (NullReferenceException ex)
                            {
                                Debug.WriteLine("field1[b1].Value : empty ");
                            }
                        }

                    }

                }
                catch (NullReferenceException ex)
                {
                    Debug.WriteLine("record1[a].contentId : empty ");
                }

                newPowerBiReport.Villes = villes;
                newPowerBiReport.Couleures = couleures;

                newPowerBiReports.Add(newPowerBiReport);

            }

            //Serialize object to a xml file
            EditNewPowerBiReports(newPowerBiReports);
            Debug.WriteLine("Get your doc in C:\\PowerBi\\ResultNewPowerBi.xml");

            Debug.Unindent();
            Debug.WriteLine("**********************************");
            Debug.WriteLine("Debug Information-Product Ending");

            Debug.Flush();
            return newPowerBiReports;

        }


        //Serialize object to a xml file
        private void EditNewPowerBiReports(List<NewPowerBiReport> getNewPowerBiReport)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<NewPowerBiReport>));
            using (StreamWriter wr = new StreamWriter("C:\\PowerBi\\ResultNewPowerBi.xml"))
            {
                xs.Serialize(wr, getNewPowerBiReport);
            }

            
        }


    }
}