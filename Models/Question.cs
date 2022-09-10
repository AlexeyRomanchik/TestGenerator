using System.Xml.Serialization;

namespace Models
{
    public class Question
    {
        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlElement("answer")]
        public List<Answer> Answers { get; set; }

        public Question(string text, List<Answer> answers)
        {
            Text = text;
            Answers = answers;
        }
    }
}
