namespace TianWen.Framework.Common
{
    using System;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    public class CDATA : IXmlSerializable
    {
        private string _value;

        public CDATA()
        {
        }

        public CDATA(string value)
        {
            this._value = value;
        }

        public static implicit operator CDATA(string text)
        {
            return new CDATA(text);
        }

        public static implicit operator string(CDATA element)
        {
            return ((element == null) ? null : element._value);
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            this._value = reader.ReadElementContentAsString();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteCData(this._value);
        }

        public override string ToString()
        {
            return this._value;
        }

        public string Value
        {
            get
            {
                return this._value;
            }
        }
    }
}

