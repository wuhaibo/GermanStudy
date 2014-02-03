
using GermanLearningModule.Util;
using GermanVocabulary.Infrastructure;
using GermanLearningModule.Services;
using GermanVocabulary.DataAccess.Models;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GermanLearningModule.ViewModels
{

    public class TestWordListViewModel:  NotificationObject,INavigationAware
    {

        #region Fields      
        private IMyWordListService _myWordListService;
        private ITestWordListService _testWordListService;
        private IScoreListService _scoreListService;
        private IRegionManager _regionManager;

        private List<QnAModel> _lstQnAModels;
        private ObservableCollection<AnswerState> _answerStates;
        private int _currentIndex;
        private QnAModel _testItem;
        private ObservableCollection<string> _choices;
        private float _score ;
        private int _unit = 1;
        private string _showGoNextBtn; 
        private string _showGoNextUnitBtn;

        #endregion

        #region Property  
        /// <summary>
        /// property to show score
        /// </summary>
        public float Score 
        {
            get 
            {
                return _score;
            }
            set
            {
                _score = value;
                RaisePropertyChanged("Score");
            }
        }
        
        /// <summary>
        /// property of one test item
        /// </summary>
        public QnAModel TestItem 
        {
            get
            {
                return _testItem;
            }
            set
            {
                _testItem = value;
                RaisePropertyChanged("TestItem");
            }
        }
        
        /// <summary>
        /// collection of answer choices
        /// </summary>
        public ObservableCollection<string> Choices
        {
            get
            {
                    return _choices;
            }
            set
            {
                _choices.Clear();
               
                for (int i = 0; i < value.Count; i++)
                {
                    _choices.Add(value[i]);
                }
            }
        }
       
        /// <summary>
        /// collection of answer states (right or wrong)
        /// </summary>
        public ObservableCollection<AnswerState> AnswerStates
        {
            get 
            {
                return _answerStates;
            }
            set
            {
                _answerStates.Clear();
                for (int i = 0; i < value.Count; i++)
                {
                    _answerStates.Add(value[i]);
                }

            }
        }
       
        /// <summary>
        /// property to judge if show the go next button
        /// </summary>
        public string ShowGoNextBtn 
        {
            get
            {
                return _showGoNextBtn;
            }

            set
            {
                _showGoNextBtn = value;
                RaisePropertyChanged("ShowGoNextBtn");
            }
        }
        
        /// <summary>
        /// property to judge if show the go next unit button
        /// </summary>
        public string ShowGoNextUnitBtn
        {
            get
            {
                return _showGoNextUnitBtn;
            }
            set
            {
                _showGoNextUnitBtn = value;
                RaisePropertyChanged("ShowGoNextUnitBtn");
            }
        }
        
        /// <summary>
        /// property show the total number of questions
        /// </summary>
        public int NumOfQuestions { get { return _lstQnAModels.Count; } }
        
        /// <summary>
        /// property show current test item index
        /// </summary>
        public int CurrentIndex 
        {
            get { return _currentIndex; }
            private set { _currentIndex = value; RaisePropertyChanged("CurrentIndex"); }               
        }
       
        /// <summary>
        /// property to judege if GoNextQuestionCommand can be executed.
        /// </summary>
        public bool CanGoNext { get; set; }
        
        #endregion Property

        public TestWordListViewModel(IMyWordListService myWordListService, ITestWordListService testWordListService,
            IScoreListService scoreListService,
            IRegionManager regionManager)
        {
            InitialData();

            //injection
            _regionManager = regionManager;            
            _testWordListService = testWordListService;
            _myWordListService = myWordListService;
            _scoreListService = scoreListService;

            //command initial
            GoNextQuestionCommand = new DelegateCommand<object>(GoNextQuestion, CanGoNextQuestion);
            Add2MyWordListCommand = new DelegateCommand<StudyItem>(Add2MyWordList);
            GoNextQuestionNoAnswerCheckCommand = new DelegateCommand<object>(GoNextQuestionNoAnswerCheck);
            Navi2NextUnitCommand = new DelegateCommand<object>(Navi2NextUnit);

        }

        #region Command

        /// <summary>
        /// Command of Navi2NextUnit
        /// </summary>
        public DelegateCommand<object> Navi2NextUnitCommand { get; private set; }

        /// <summary>
        /// method to impelent Navi2NextUnitCommand
        /// </summary>
        /// <param name="obj"></param>
        private void Navi2NextUnit(object obj)
        {
            NavigateToNextTestWordListView();
        }

        /// <summary>
        /// update the state of if command can be executed
        /// </summary>
        private void RaiseCommandCanExecute()
        {
            GoNextQuestionCommand.RaiseCanExecuteChanged();          
        }

        /// <summary>
        /// GoNextQuestionNoAnswerCheckCommand command
        /// Go to next question without check the answer is right or wrong
        /// </summary>
        public DelegateCommand<object> GoNextQuestionNoAnswerCheckCommand { get; private set; }

        /// <summary>
        /// method to implement GoNextQuestionNoAnswerCheckCommand
        /// it goes to next question without check the answer from user 
        /// </summary>
        /// <param name="obj"></param>
        private void GoNextQuestionNoAnswerCheck(Object obj)
        {
            //enable GoNextQuestionCommand
            CanGoNext = true;
            RaiseCommandCanExecute();

            //set answer judge list 
            for (int i = 0; i < 3; i++)
            {
                AnswerStates[i] = AnswerState.NoShow;
            }

            //set btn visible
            ShowGoNextBtn = Visibility.Hidden.ToString();
            ShowGoNextUnitBtn = Visibility.Hidden.ToString();

            //move to next
            ++CurrentIndex;

            //already end ? calculate and show score 
            if (CurrentIndex > (_lstQnAModels.Count - 1))
            {
                CurrentIndex = _lstQnAModels.Count - 1;
                ShowScore();

                //show go next unit button
                ShowGoNextUnitBtn = Visibility.Visible.ToString(); 

            }
            else
            {
                //set choice content
                TestItem = _lstQnAModels[CurrentIndex];
                for (int i = 0; i < 3; i++)
                {
                    Choices[i] = TestItem.lstChioces[i];
                }    
 
            }


        }

        /// <summary>
        /// GoNextQuestionCommand command 
        /// It goes to next question and check the answer
        /// </summary>
        public DelegateCommand<object> GoNextQuestionCommand { get; private set; }
        
        /// <summary>
        /// method to implement GoNextQuestionCommand
        /// if the answer is right, it goes to next question
        /// if not, it shows the right answer
        /// </summary>
        /// <param name="obj"></param>
        private void GoNextQuestion(object obj)
        {
           
            RadioButton rBtn = obj as RadioButton;

            //set answer judge list 
            for (int i = 0; i < 3; i++)
            {
               AnswerStates[i] = AnswerState.NoShow;
            }

            //set btn visible
            ShowGoNextBtn = Visibility.Hidden.ToString();
            ShowGoNextUnitBtn = Visibility.Hidden.ToString();

            //check answer
            string answer;
            if (rBtn != null)
            {
                answer = rBtn.Content.ToString();
                rBtn.IsChecked = false;
            }
            else
            {
                answer = "";
            }

            bool isRight = CheckAnswer(answer);

            //if the answer is wrong
            if (!isRight)
            {
                //add the wrong one 2 my word list
                Add2MyWordList(TestItem);

                //show right answer                 
                ShowRightAnswer();

                if (CurrentIndex == _lstQnAModels.Count - 1)
                {
                    //show go next unit button
                    _showGoNextUnitBtn = Visibility.Visible.ToString();
                }
                else
                {
                    //show go next button
                    ShowGoNextBtn = Visibility.Visible.ToString();

                }
                
                //disable GoNextQuestionCommand
                CanGoNext = false;
                RaiseCommandCanExecute();
            }
            else
            {
                // answer is right, get one point
                Score += 1;
                
                //move to next
                ++CurrentIndex;

                //already end ? calculate and show score 
                if (CurrentIndex > (_lstQnAModels.Count - 1))
                {
                    CurrentIndex = _lstQnAModels.Count - 1;

                    ShowScore();

                    //disable GoNextCommand
                    CanGoNext = false;
                    RaiseCommandCanExecute();

                    //show go next unit button
                    ShowGoNextUnitBtn = Visibility.Visible.ToString(); 

                }
                else
                {
                    //set choice content
                    TestItem = _lstQnAModels[CurrentIndex];
                    for (int i = 0; i < 3; i++)
                    {
                      Choices[i] = TestItem.lstChioces[i];
                    }
                }

            }
     
        }

        /// <summary>
        /// method to judge if the GoNextQuestionCommand can be executed.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanGoNextQuestion(object obj)
        {
            return CanGoNext;           
        }

        /// <summary>
        /// Command of Add2MyWordListCommand
        /// add the test word into my word list.
        /// </summary>
        public DelegateCommand<StudyItem> Add2MyWordListCommand { get; private set; }

        /// <summary>
        /// method to implement the Add2MyWordListCommand
        /// add the test word into my word list
        /// </summary>
        /// <param name="studyItem"></param>
        private void Add2MyWordList(StudyItem studyItem)
        {
            MyWord myword = new MyWord(); 
            myword.German = studyItem.German;
            myword.Chinese = studyItem.Chinese;

            _myWordListService.Add(myword);
        }

        #endregion Command


        #region Navi
        /// <summary>
        /// method to navi 2 TestWordListView
        /// </summary>
        /// <param name="unit">the unit of test words</param>
        public void NavigateToTestWordListView(int unit)
        {

            //navi            
            UriQuery query = new UriQuery();
            query.Add("Unit", unit.ToString());
            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("TestWordListView" + query.ToString(), UriKind.Relative));
        }

        public void NavigateToNextTestWordListView()
        {
            NavigateToTestWordListView(_unit + 1);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //enable GoNextQuestionCommand
            CanGoNext = true;
            RaiseCommandCanExecute();

            //hidden the buttons
            ShowGoNextBtn = Visibility.Hidden.ToString();
            ShowGoNextUnitBtn = Visibility.Hidden.ToString(); 

            //data 
            string unit = navigationContext.Parameters["Unit"];
            _unit = int.Parse(unit);
            _lstQnAModels = _testWordListService.GetTestSequence(_unit);

            CurrentIndex = 0;
            Score = 0;
            TestItem = _lstQnAModels[0];
            Choices = new ObservableCollection<string>(TestItem.lstChioces);
            
            AnswerStates.Clear();
            for (int i = 0; i < 3; i++)
            {
                AnswerStates.Add(AnswerState.NoShow);                
            }
        }
        #endregion Navi

        #region PrivateFunction

        private void InitialData()
        {
            _lstQnAModels = new List<QnAModel>();
            _answerStates = new ObservableCollection<AnswerState>();
            _testItem = new QnAModel();
            _choices = new ObservableCollection<string>();
            _unit = 1;

            CanGoNext = true;         
            CurrentIndex = 0;
            ShowGoNextBtn = Visibility.Hidden.ToString(); 
            ShowGoNextUnitBtn = Visibility.Hidden.ToString();
        }

        /// <summary>
        /// finally gives the score
        /// </summary>
        private void ShowScore()
        {
            //calculate score
            Score = (Score) / _lstQnAModels.Count * 100.0f;

            //1 show score in textblock 
            //2 update the database               
            //3 go next
            //4 remove all answer
            QnAModel tmp = new QnAModel {Question = "Score:" + Score.ToString("F0")};
            TestItem = tmp;

            _scoreListService.Update(_unit, Score);

            
            Choices.Clear();

        }

        /// <summary>
        /// method to check if the answer is right
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        private bool CheckAnswer(string answer)
        {
            if (answer == TestItem.Answer)
            {

                return true;
            }

            return false;
        }

        /// <summary>
        /// method to show the right answer
        /// </summary>
        private void ShowRightAnswer()
        {
            for (int i = 0; i < 3; i++)
            {
                if (TestItem.Answer == Choices[i])
                {
                    AnswerStates[i] = AnswerState.Right;
                }
                else
                {
                    AnswerStates[i] = AnswerState.Wrong;
                }
            }

        }

        /// <summary>
        /// method add the current test word to my word list 
        /// </summary>
        /// <param name="item"></param>
        private void Add2MyWordList(QnAModel item)
        {
            MyWord myword = new MyWord();
            if (item.QuestionType == "German")
            {
                myword.German = item.Question;
                myword.Chinese = item.Answer;
            }

            if (item.QuestionType == "Chinese")
            {
                myword.German = item.Answer;
                myword.Chinese = item.Question;
            }
            _myWordListService.Add(myword);
        }
        #endregion PrivateFunction

    }
}
