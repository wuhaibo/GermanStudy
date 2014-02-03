
using GermanLearningModule.Services;
using GermanVocabulary.DataAccess.Models;
using GermanVocabulary.Infrastructure;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;

namespace GermanLearningModule.ViewModels
{
    public class StudyGermanViewModel : NotificationObject, INavigationAware
    {
        #region Fields
        private List<StudyItem> _studyWordList;
        private int _currentStudyWordIndex;
        private StudyItem _studyWord;
        private bool _can2Test;
        private int _unit;
        private IRegionManager _regionManager;
        private IStudyWordsListService _studyWordListService;

      
        #endregion

        #region Property
        /// <summary>
        /// Property of current Word Index
        /// </summary>
        public int CurrentStudyWordIndex 
        {
            get 
            {
                return _currentStudyWordIndex;
            }
            set
            {
                _currentStudyWordIndex = value;
                if (_currentStudyWordIndex == 0)
                {
                    Information = "first";
                    return;
                }
                if (_currentStudyWordIndex == (_studyWordList.Count -1))
                {
                    Information = "last";
                    return;
                }
                Information = " ";
                
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string Information { get; private set; }
        
        /// <summary>
        /// Proptey of current study word
        /// </summary>
        public StudyItem StudyWord
        {
            get
            {
                return _studyWord;
            }
            set
            {
                _studyWord = value;
                RaisePropertyChanged("StudyWord");
            }
        }

        /// <summary>
        /// Flag to judge if it can go to test view
        /// </summary>
        public bool Can2Test
        {
            get
            {
                return _can2Test;
            }
            set
            {
                _can2Test = value;
            }
        }
       
        #endregion

 
        
        
        public StudyGermanViewModel(IStudyWordsListService studyWordListService, 
            IRegionManager regionManager)
        {
            //data
            _studyWordList = new List<StudyItem>();
            _studyWord = new StudyItem();

            //injection     
            _studyWordListService = studyWordListService;
            _regionManager = regionManager;


            //Commands 
            GoLastCommand = new DelegateCommand<object>(GoLast, CanGoLast);
            GoNextCommand = new DelegateCommand<object>(GoNext, CanGoNext);
            TestThisUnitCommand = new DelegateCommand<object>(TestThisUnit,CanTestThisUnit);
            
        }
    
        #region Command
        private void RaiseCommandCanExecute()
        {
            GoLastCommand.RaiseCanExecuteChanged();
            GoNextCommand.RaiseCanExecuteChanged();
            TestThisUnitCommand.RaiseCanExecuteChanged();
        }

      
        /// <summary>
        /// Go Last Command, move to last word item
        /// </summary>
        public DelegateCommand<object> GoLastCommand { get; private set; }

        /// <summary>
        /// method to implement GoLastCommand
        /// </summary>
        /// <param name="obj"></param>
        private void GoLast(object obj)
        {
            CurrentStudyWordIndex -= 1;
            StudyWord = _studyWordList[_currentStudyWordIndex];
            RaiseCommandCanExecute();
        }

        /// <summary>
        /// method to judge if GoLastCommand can be executed.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanGoLast(object obj)
        {
            if (_currentStudyWordIndex < 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Go Next Command, move to next word item
        /// </summary>
        public DelegateCommand<object> GoNextCommand { get; private set; }


        /// <summary>
        /// method to implement GoNextCommand
        /// </summary>
        /// <param name="obj"></param>
        private void GoNext(object obj)
        {
            CurrentStudyWordIndex += 1;
            StudyWord = _studyWordList[_currentStudyWordIndex];

            if(CurrentStudyWordIndex == (_studyWordList.Count - 1) )
            {
                Can2Test = true;
            }
            RaiseCommandCanExecute();
        }
       
        /// <summary>
        /// method to judge if GoNextCommand can be executed.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanGoNext(object obj)
        {
            int size = _studyWordList.Count - 1;
            if (_currentStudyWordIndex >= size)
            {
                return false;
            }
            return true;
        }
        
        /// <summary>
        /// TestThisUnitCommand, go to the testwordlistview to test the word in the study unit
        /// </summary>
        public DelegateCommand<object> TestThisUnitCommand { get; private set; }
        private void TestThisUnit(object obj)
        {
            int unit = _unit;
            UriQuery query = new UriQuery();
            query.Add("Unit", unit.ToString());

            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("TestWordListView" + query.ToString(), UriKind.Relative));
        }

        public bool CanTestThisUnit(object obj)
        {
            return Can2Test;
        }

        #endregion cmd

        #region Navigation    
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string unit = navigationContext.Parameters["Unit"];
            _unit = int.Parse(unit);

            Initial();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
        #endregion INavigationAware

        private void Initial()
        {
            //data initial           
            Can2Test = false;
            _studyWordList = _studyWordListService.GetStudyItemsWithUnit(_unit);
            CurrentStudyWordIndex = 0;
            StudyWord = _studyWordList[CurrentStudyWordIndex];

        }
    }
}
