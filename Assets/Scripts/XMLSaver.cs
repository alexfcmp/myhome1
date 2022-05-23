using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public sealed class XMLSaver : ILoadSave<Vector3>
    {
        public void SaveBonus(Vector3 bonus, string path = null)
        {
            XmlDocument document = new XmlDocument();

            XmlNode rootNode = document.CreateElement("Bonus");
            document.AppendChild(rootNode);

            var element = document.CreateElement("Position X");
            element.SetAttribute("value", bonus.x.ToString());
            rootNode.AppendChild(element);

            element = document.CreateElement("Position Y");
            element.SetAttribute("value", bonus.y.ToString());
            rootNode.AppendChild(element);

            element = document.CreateElement("Position Z");
            element.SetAttribute("value", bonus.z.ToString());
            rootNode.AppendChild(element);

            document.Save(path);
        }
        public Vector3 LoadBonus(string path = null)
        {
            var result = new Vector3();
            if (!File.Exists(path)) return result;
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Position X";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.x = forResult;
                    }
                    key = "Position Y";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.y = forResult;
                    }
                    key = "Position Z";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.z = forResult;
                    }
                }
            }
            return result;
        }
    }
}
