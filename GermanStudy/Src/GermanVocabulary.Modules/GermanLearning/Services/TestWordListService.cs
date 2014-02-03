using GermanLearningModule.Util;
using GermanVocabulary.DataAccess.Models;
using GermanVocabulary.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GermanLearningModule.Services
{
    public class TestWordListService : ServiceBase<StudyItem, VocabularyContext>, ITestWordListService
    {

        public List<StudyItem> GetStudyItemsWithUnit(int unit)
        {
            using (var context = new VocabularyContext())
            {
                 return context.StudyItems.Where(studyItem => studyItem.Unit == unit).ToList();                      
            }
        }


        public List<QnAModel> GetTestSequence(int unit)
        {
            var lstQnAModel = new List<QnAModel>();            
            var lstWords = GetStudyItemsWithUnit(unit);           
            var rnd = new Random();
            
            //German 2 Chinese test
            for(int i =0; i<lstWords.Count;i++ )
            {
                lstQnAModel.Add(getTestItem(i, lstWords, false, rnd));
            }
                        
            //Chinese 2 German test
            for (int i = 0; i < lstWords.Count; i++)
            {
                lstQnAModel.Add(getTestItem(i, lstWords, true, rnd));
            }

            return lstQnAModel;
        }


        private QnAModel getTestItem(int curIndex, List<StudyItem> lstWords, bool isInverseTest, Random rnd)
        {
            var testItem = new QnAModel();

            if (isInverseTest)
            {
               //Chinese 2 German test
                testItem.Question = lstWords[curIndex].Chinese;
                testItem.Answer = lstWords[curIndex].German;
                testItem.QuestionType = "Chinese";
            }
            else
            {
                //German 2 Chinese test 
                testItem.Question = lstWords[curIndex].German;
                testItem.Answer = lstWords[curIndex].Chinese;
                testItem.QuestionType = "German";
            }

            int len = lstWords.Count;
            const int numOfChoices = 3;
            var indexs = new int[numOfChoices];

            var radomGenerators = new RadomGenerators();
            
            radomGenerators.GetRadoms(indexs, numOfChoices, curIndex, 0, len, rnd);

            for (int i = 0; i < numOfChoices; i++)
            {
                string content;
                if (isInverseTest)
                {
                    //Chinese 2 German test
                    content = lstWords[indexs[i]].German;
                }
                else
                {
                    //German 2 Chinese test 
                    content = lstWords[indexs[i]].Chinese;
                }

                testItem.lstChioces.Add(content);
            }
                 
            int rightIndex = rnd.Next(0, 3);
            testItem.lstChioces[rightIndex] = testItem.Answer;      


            return testItem;

        }



    }
}
