using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceMonitor
{
    public static class Helper
    {
        /// <summary>
        /// Serializes as string.
        /// </summary>
        /// <param name="T">The Type of object</param>
        /// <param name="o">The object.</param>
        /// <returns>Object as XML</returns>
        public static string SerializeAsString(this object o,Type T)
        {
            var xmlSerializer = new XmlSerializer(T);
            var writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;

            var stringWriter = new StringWriter();

            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            using (XmlWriter xmlWriter = new XmlTextWriterFormattedNoDeclaration(stringWriter))
            {
                xmlSerializer.Serialize(xmlWriter, o, ns);
            }
            return stringWriter.ToString();
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="T">The Type.</param>
        /// <returns>Deserialized Object</returns>
        public static dynamic Deserialize(this string xml,Type T)
        {
            var xmlDeserializer = new XmlSerializer(T);
            var o = Convert.ChangeType(xmlDeserializer.Deserialize(new XmlTextReader(new StringReader(xml))),T);
            return o;
        }

        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="o">Dynamic Object</param>
        /// <returns>
        /// Validation results
        /// </returns>
        public static List<ValidationResult> ValidateObject(this object o)
        {
            var ctx = new ValidationContext(o, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(o, ctx, results, true);
            return results;
        }

        /// <summary>
        /// XmlTextWriterFormattedNoDeclaration
        /// </summary>
        class XmlTextWriterFormattedNoDeclaration : System.Xml.XmlTextWriter
        {
            public XmlTextWriterFormattedNoDeclaration(System.IO.TextWriter w)
                : base(w)
            {
                Formatting = System.Xml.Formatting.Indented;       //todo:remove before deployment
            }
            public override void WriteStartDocument()
            {
                //removes the namespace
            }
        }
    }


}