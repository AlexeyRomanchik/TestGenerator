using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    [XmlRoot("test")]
    public class Test
    {
        [XmlElement("question")]
        public List<Question> Questions { get; set; }

        public Test(List<Question> questions)
        {
            Questions = questions;
        }
    }
}
