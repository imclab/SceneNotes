using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

public class SceneNote : IXmlSerializable {

	public Vector3 position;
	public string text = "";

	public System.Xml.Schema.XmlSchema GetSchema ()
	{
		return null;
	}

	public void ReadXml (System.Xml.XmlReader reader)
	{
//		reader.ReadElementString ("Text", text);
//		reader.ReadStartElement ("Position");
//		Vector3 pos = new Vector3 ();
//		pos.x = float.Parse (reader.ReadAttributeValue ("x"));
//		pos.y = float.Parse (reader.ReadAttributeValue ("y"));
//		pos.z = float.Parse (reader.ReadAttributeValue ("z"));
//		position = pos;
//		reader.ReadEndElement ();
	}

	public void WriteXml (System.Xml.XmlWriter writer)
	{
//		writer.WriteElementString ("Text", text);
//		writer.WriteStartElement ("Position");
//		writer.WriteAttributeString ("x", position.x);
//		writer.WriteAttributeString ("y", position.y);
//		writer.WriteAttributeString ("x", position.z);
//		writer.WriteEndElement ();
	}
}
