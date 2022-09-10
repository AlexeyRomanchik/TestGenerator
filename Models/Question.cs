using System.Xml.Serialization;

namespace Models
{
    public class Question
    {
        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlElement("answer")]
        public List<Answer> Answers { get; set; }
    }
}
