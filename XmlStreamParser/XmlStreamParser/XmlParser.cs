using System.Xml;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;
using System.Linq.Expressions;

namespace XmlStreamParser
{
    public enum Gender
    {
        Male,
        Female
    }

    public class XmlParser
    {
        #region Fields

        private readonly Dictionary<Gender, int> XmlSum = new Dictionary<Gender, int>();
        private readonly Dictionary<Gender, int> XmlQuantity = new Dictionary<Gender, int>();
        private bool isFemale = true;

        #endregion

        #region Constructor

        public XmlParser(string fileName)
        {
            XmlSum.Add(
                key: Gender.Female,
                value: 0
            );
            XmlSum.Add(
                key: Gender.Male,
                value: 0
            );
            XmlQuantity.Add(
                key: Gender.Female,
                value: 0
            );
            XmlQuantity.Add(
                key: Gender.Male,
                value: 0
            );
            GetInformationFromXml(fileName);
        }

        #endregion

        #region Public Methods

        public int AvgAge(Gender gender)
        {
            return XmlSum[gender] / XmlQuantity[gender];
        }

        #endregion

        #region Private Methods

        private void GetInformationFromXml(string fileName)
        {
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "plec":
                                if (reader.Read())
                                {
                                    if (reader.Value.Trim() == "K" || reader.Value.Trim() == "k")
                                    {
                                        isFemale = true;
                                    }
                                    else
                                    {
                                        isFemale = false;
                                    }
                                }
                                break;
                            case "wiek":
                                if (reader.Read())
                                {
                                    var gender = isFemale ? Gender.Female : Gender.Male;
                                    XmlSum[gender] += Int32.Parse(reader.Value.Trim());
                                    XmlQuantity[gender] += 1;
                                }
                                break;
                        }
                    }
                }
            }
        }

        #endregion
    }
}