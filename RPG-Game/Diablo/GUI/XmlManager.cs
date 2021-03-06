﻿using System;
using System.Xml.Serialization;
using System.IO;

namespace Diablo.GUI
{
    public class XmlManager<T>
    {
        public XmlManager()
        {
            this.Type = typeof(T);
        }

        public Type Type { get; set; }
        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }
        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
