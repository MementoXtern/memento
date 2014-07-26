using System.IO;
using System.Xml;
using System.Xml.Xsl;

namespace Lib.Utilities
{
    public static class ProcessXml
    {
        #region Public Methods

        public static string TransformXml(string xml, string xsl)
        {
            //create an object to perform the XSLT transformation
            XslCompiledTransform xct = new XslCompiledTransform();

            //create an object to recieve the results of the transformation
            StringWriter outStream = null;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xslDoc = new XmlDocument();

            xmlDoc.LoadXml(xml);
            xslDoc.Load(xsl);

            try
            {
                outStream = new StringWriter();

                // load the xslt
                xct.Load(xsl);

                // transform the xml document and pass the results to the Stream object
                xct.Transform(xmlDoc, null, outStream);

                // send the result back to the calling function
                return outStream.ToString();
            }
            finally
            {
                if (outStream != null)
                {
                    //close the stream
                    outStream.Close();
                    outStream.Dispose();
                }
            }
        }

        public static string TransformXml(string xml, string xsl, XsltArgumentList xsltArgs)
        {
            //create an object to perform the XSLT transformation
            XslCompiledTransform xct = new XslCompiledTransform();

            //create an object to recieve the results of the transformation
            StringWriter outStream = null;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xslDoc = new XmlDocument();

            xmlDoc.LoadXml(xml);
            xslDoc.Load(xsl);

            try
            {
                outStream = new StringWriter();

                // load the xslt
                xct.Load(xsl);

                // transform the xml document and pass the results to the Stream object
                xct.Transform(xmlDoc, xsltArgs, outStream);

                // send the result back to the calling function
                return outStream.ToString();
            }
            finally
            {
                if (outStream != null)
                {
                    //close the stream
                    outStream.Close();
                    outStream.Dispose();
                }
            }
        }

        #endregion
    }
}
