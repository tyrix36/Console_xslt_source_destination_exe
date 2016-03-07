using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Console_xslt_source_destination
{
    class Program
    {


        #region fonction

        //private static void write_dataFile_from_xslt(FileInfo xslInput, FileInfo xmlInput, DirectoryInfo folder_result, string s_extention_out)
        //{

        //    FileInfo path_result = new FileInfo(
        //        folder_result.FullName + "\\"
        //        + xmlInput.Name + "_"
        //        + xslInput.Name + "." + s_extention_out);

        //    Console.WriteLine(" ecriture du fichier : " + path_result.FullName + " en cour ... ");

        //    XPathDocument myXPathDoc = new XPathDocument(xmlInput.FullName);
        //    XslCompiledTransform myXslTrans = new XslCompiledTransform();
        //    myXslTrans.Load(xslInput.FullName);

        //    using (XmlTextWriter myWriter = new XmlTextWriter(path_result.FullName, null))
        //    {
        //        myXslTrans.Transform(myXPathDoc, null, myWriter);
        //    }


        //    Console.WriteLine(" ecriture du fichier : " + path_result.FullName + " terminé. ");

        //}



        private static void write_dataFile_from_xslt(FileInfo xslInput, DirectoryInfo folder_xmlInput, DirectoryInfo folder_result, string s_extention_out)
        {

            XslCompiledTransform myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(xslInput.FullName);

            FileInfo[] fi_in = folder_xmlInput.GetFiles("*.xml");

            foreach (FileInfo xmlInput in fi_in)
            {
                
                try
                {

                    FileInfo path_result = new FileInfo(
                        folder_result.FullName + "\\"
                        + xmlInput.Name + "_"
                        + xslInput.Name + "." + s_extention_out);

                    Console.WriteLine(" ecriture du fichier : " + path_result.FullName + " en cour ... ");

                    XPathDocument myXPathDoc = new XPathDocument(xmlInput.FullName);
                    
                    using (XmlTextWriter myWriter = new XmlTextWriter(path_result.FullName, null))
                    {
                        myXslTrans.Transform(myXPathDoc, null, myWriter);
                    }


                    Console.WriteLine(" ecriture du fichier : " + path_result.FullName + " terminé. ");
                    
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

            }


        }


        #endregion fonction


        #region main

        static void Main(string[] args)
        {

            Console.WriteLine(" debut de Console_xslt_source_destination. ");

            try
            {

                FileInfo xslt = new FileInfo(args[0]);
                DirectoryInfo folder_xml_source = new DirectoryInfo(args[1]);
                DirectoryInfo folder_destination = new DirectoryInfo(args[2]);

                write_dataFile_from_xslt(xslt, folder_xml_source, folder_destination, "xml");

            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.WriteLine(" fin de Console_xslt_source_destination. ");


#if (DEBUG)
            Console.ReadKey();
#endif

            Console.WriteLine(" le programme est en cour d'arret ... ");

        }


        #endregion main

    }
}
