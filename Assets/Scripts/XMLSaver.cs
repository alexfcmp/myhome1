using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public sealed class XMLSaver : ILoadSave<Vector3>
    {
        public void Save(Vector3 bonus, string path = null)
        {
            XmlDocument document = new XmlDocument();

            XmlNode rootNode = document.CreateElement("Bonus");
            document.AppendChild(rootNode);

            //шифрование с помощью алгоритма {x + 100 / 3}

            var element = document.CreateElement("Position_X");
            element.SetAttribute("value", $"{(bonus.x + 100) / 3}");
            rootNode.AppendChild(element);

            element = document.CreateElement("Position_Y");
            element.SetAttribute("value", $"{(bonus.y + 100) / 3}");
            rootNode.AppendChild(element);

            element = document.CreateElement("Position_Z");
            element.SetAttribute("value", $"{(bonus.z + 100) / 3}");
            rootNode.AppendChild(element);

            document.Save(path);
        }
        public Vector3 Load(string path = null)
        {
            var result = new Vector3();
            if (!File.Exists(path)) return result;
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Position_X";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.x = forResult * 3 - 100;
                    }
                    key = "Position_Y";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.y = forResult * 3 - 100;
                    }
                    key = "Position_Z";
                    if (reader.IsStartElement(key))
                    {
                        var parse = reader.GetAttribute("value");
                        float.TryParse(parse, out var forResult);
                        result.z = forResult * 3 - 100;
                    }
                }
            }
            return result;
        }
    }
}