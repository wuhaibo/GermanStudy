using System.Collections.Generic;

namespace GermanLearningModule.Util
{
    public class QnAModel
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public List<string> lstChioces { get; set; }
        public string QuestionType { get; set; }

        public QnAModel()
        {
            this.Question = "";
            this.Answer = "";
            this.lstChioces = new List<string>();
        }
    }
}
