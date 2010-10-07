using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Listicus.Core.Utilities
{
    /// <summary>
    /// Summary description for XmlSerializerHelper.
    /// </summary>
    public sealed class XmlSerializerHelper
    {
        private static readonly Dictionary<Type, XmlSerializer> serializers = new Dictionary<Type, XmlSerializer>();

        public static T DeserializeXmlElement<T>(XmlElement element)
        {
            return DeserializeString<T>(element.OuterXml);
        }

        public static object DeserializeString(XmlSerializer ser, string xml)
        {
            if (xml == null) return null;

            xml.Trim();
            StreamWriter sw = new StreamWriter(new MemoryStream());
            sw.Write(xml);
            sw.Flush();
            sw.BaseStream.Position = 0;
            XmlTextReader xtr = new XmlTextReader(sw.BaseStream);
            return ser.Deserialize(xtr);
        }

        /// <summary>
        /// Deserializes a string into a DTO object.
        /// </summary>
        /// <param name="xml">string representation of XML DTO object</param>
        /// <returns>DTO object</returns>
        public static T DeserializeString<T>(string xml)
        {
            return DeserializeString<T>(GetSerializer<T>(), xml);
        }

        /// <summary>
        /// Deserializes a string into a DTO object.
        /// </summary>
        /// <param name="serializer">the serializer to use</param>
        /// <param name="xml">string representation of XML DTO object</param>
        /// <returns>DTO object</returns>
        public static T DeserializeString<T>(XmlSerializer serializer, string xml)
        {
            if (xml == null) return default(T);

            XmlSerializer ser;

            return (T)DeserializeString(serializer, xml);
        }

        public static XmlElement GetXmlElement(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }

        /// <summary>
        /// Serializes a DTO object to a string using the specified type.
        /// </summary>
        /// <param name="obj">DTO object</param>
        /// <returns>string representation of XML DTO object</returns>
        public static string SerializeToString<T>(T obj)
        {
            return SerializeToString(GetSerializer<T>(), obj);
        }

        /// <summary>
        /// Serializes a DTO object to a string using the runtime type.
        /// </summary>
        /// <param name="obj">DTO object</param>
        /// <returns>string representation of XML DTO object</returns>
        public static string SerializeToString(object obj)
        {
            XmlSerializer serializer = GetSerializer(obj.GetType());
            return SerializeToString(serializer, obj);
        }

        public static XmlElement SerializeToXmlElement<T>(T obj)
        {
            return GetXmlElement(SerializeToString<T>(obj));
        }

        public static XmlElement SerializeToXmlElement(object obj, XmlSerializer serializer)
        {
            return GetXmlElement(SerializeToString(serializer, obj));
        }

        public static XmlElement SerializeToXmlElement(object obj)
        {
            return GetXmlElement(SerializeToString(GetSerializer(obj), obj));
        }

        public static XmlSerializer GetSerializer(object obj)
        {
            return GetSerializer(obj.GetType());
        }
        /// <summary>
        /// Gets the XML representation of the object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>The objects XML representation.</returns>
        public static XmlDocument GetXmlDocument(object obj)
        {
            XmlDocument document = new XmlDocument();

            if (obj != null)
            {
                XmlSerializer serializer = GetSerializer(obj.GetType());
                document.LoadXml(SerializeToString(serializer, obj));
            }

            return document;
        }

        /// <summary>
        /// Serializes a DTO object to a string.
        /// </summary>
        /// <param name="ser">Serializer to use</param>
        /// <param name="obj">DTO object</param>
        /// <returns>string representation of XML DTO object</returns>
        public static string SerializeToString(XmlSerializer ser, object obj)
        {
            if (obj == null) return null;
            XmlTextWriter xtr = new XmlTextWriter(new MemoryStream(), Encoding.UTF8);
            ser.Serialize(xtr, obj);
            xtr.Flush();
            xtr.BaseStream.Position = 0;
            StreamReader sr = new StreamReader(xtr.BaseStream);
            return sr.ReadToEnd();
        }

        public static XmlSerializer GetSerializer<T>()
        {
            XmlSerializer serializer = GetSerializer(typeof(T));
            return serializer;
        }

        public static XmlSerializer GetSerializer(Type t)
        {
            lock (serializers)
            {
                if (serializers.ContainsKey(t))
                {
                    return serializers[t];
                }
                else
                {
                    XmlSerializer serializer = CreateSerializer(t);
                    serializers.Add(t, serializer);
                    return serializer;
                }
            }
        }

        private static XmlSerializer CreateSerializer(Type t)
        {
            //Logger.Debug("Creating new serializer for " + t.Name);
            XmlSerializer serializer = new XmlSerializer(t);
            return serializer;
        }

        public static T DeserializeFromFile<T>(string url)
        {
            XmlSerializer deserializer = GetSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(url);
            return (T)deserializer.Deserialize(reader);
        }

        public static void SerializeToFile<T>(string url, T output)
        {
            SerializeToFile(url, output, Encoding.Default);
        }

        public static void SerializeToFile<T>(string url, T output, Encoding encoding)
        {
            XmlSerializer serializer = GetSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(url, encoding);
            serializer.Serialize(writer, output);
        }
    }
}
