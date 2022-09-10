using System.Xml.Serialization;

namespace Models
{
    public class Answer
    {
        [XmlText]
        public string Text { get; set; }

        [XmlAttribute("correct")]
        public bool Correct { get; set; }

        public Answer(string text)
        {
            Text = text;
        }
    }
}
