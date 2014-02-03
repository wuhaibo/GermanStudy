


using GermanVocabulary.Infrastructure;
using GermanLearningModule.Services;
using GermanVocabulary.DataAccess.Models;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;


namespace GermanLearningModule.ViewModels
{
    /// <summary>
    /// View Model of ScoreListView
    /// </summary>
    public class ScoreListViewModel : INavigationAware
    {
        #region Fileds
        private IScoreListService _scoreListService;
        private ObservableCollection<Score> _scores;
        private IRegionManager _regionManager;  
        #endregion Fileds

        #region Property

        /// <summary>
        /// Flag to judge if it is test view 
        /// </summary>
        public bool? IsTest { get; set; }

        /// <summary>
        /// Flag to judge if it will go to study view
        /// </summary>
        public bool? IsStudy { get; set; }

        /// <summary>
        /// Collection of Score 
        /// </summary>
        public ObservableCollection<Score> Scores 
        {
            get 
            {
                if (_scores == null)
                {
                  _scores = new ObservableCollection<Score>();
                }
                return _scores;
            }
            set
            {
                if (_scores == null)
                {
                    _scores = new ObservableCollection<Score>();
                }

                _scores.Clear();
                
                foreach (Score t in value)
                {
                    _scores.Add(t);
                }
            }
        }
        #endregion

        public ScoreListViewModel(IScoreListService scoreListService, IRegionManager regionManager)
        {
      
            //injection
            _scoreListService = scoreListService;            
            _regionManager = regionManager;

            //   
            Initial();            

            //command
            Navi2StudyTestCommand = new DelegateCommand<object>(Navi2StudyTest);
        }

        #region Command

        /// <summary>
        /// Command of Navi to StudyTestView
        /// </summary>
        public DelegateCommand<object> Navi2StudyTestCommand { get; private set; }
        
        /// <summary>
        /// Method to implement Navi2StudyTestCommand
        /// </summary>
        /// <param name="unit"></param>
        private void Navi2StudyTest(object unit)
        {
            Button btnUnit = unit as Button;

            if (btnUnit == null)
            {
                return;
            }

            int chosenUnit = Int32.Parse(btnUnit.Tag.ToString());
            if (IsStudy == true)
            {
                NavigateToStudyGermanListsView(chosenUnit);
                return;
            }

            if (IsTest == true)
            {
                NavigateToTestWordListView(chosenUnit);
                return;
            }

        }
        #endregion Command

        #region Navi
        /// <summary>
        /// method to Navigate To StudyGermanListsView
        /// </summary>
        /// <param name="unit"> the unit of the study items</param>
        public void NavigateToStudyGermanListsView(int unit)
        {
            UriQuery query = new UriQuery();
            query.Add("Unit", unit.ToString());

            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("StudyGermanView" + query.ToString(), UriKind.Relative));
        }

        /// <summary>
        /// method to Navigate To TestWordListView
        /// </summary>
        /// <param name="unit">the unit of the study items</param>
        public void NavigateToTestWordListView(int unit)
        {
            UriQuery query = new UriQuery();
            query.Add("Unit", unit.ToString());

            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                new Uri("TestWordListView" + query.ToString(), UriKind.Relative));
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
            InitialScore();
        }
        #endregion Navi

        #region PrivateFunction

        private void InitialScore()
        {

            Scores = new ObservableCollection<Score>(_scoreListService.GetAll());
        }

        private void Initial()
        {

            InitialScore();

            IsStudy = true;
            IsTest = false;
        }
        
        #endregion PrivateFunction
 }
}
