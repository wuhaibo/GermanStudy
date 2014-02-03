
using GermanLearningModule.Services;
using GermanVocabulary.DataAccess.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace GermanLearningModule.ViewModels
{
    /// <summary>
    /// The view model class for MyWordListView.
    /// </summary>
    public class MyWordListViewModel : INavigationAware
    {
        #region Fileds
        private IMyWordListService _myWordListService;
        private IRegionManager _regionManager;
    
        #endregion

        #region Property
        
        /// <summary>
        /// Collection of MyWord.
        /// </summary>
        public ObservableCollection<MyWord> MyWordList { get; set; }

        #endregion Property

        public MyWordListViewModel(IMyWordListService myWordListService, IRegionManager regionManager)
        {
            //injection
            _myWordListService = myWordListService;
            _regionManager = regionManager;


            //
            Initial();
           
            //command
            RemoveMyWordByMyWordIdCommand = new DelegateCommand<object>(RemoveMyWordByMyWordId);
        }

        #region Command
        /// <summary>
        /// Command to remove one word item in MyWord List.
        /// </summary>
        public DelegateCommand<object> RemoveMyWordByMyWordIdCommand { get; private set; }
       
        /// <summary>
        /// Method to implement the RemoveMyWordByMyWordIdCommand
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveMyWordByMyWordId(object obj)
        {
            var myWordId = (int)obj;

            _myWordListService.RemoveByMyWordId(myWordId);
           
            GetMyWordListUpdate();
        }
        #endregion Command




        #region Navi
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
                //make sure MyWordList is the same as in database 
                GetMyWordListUpdate();            
        }
        #endregion Navi

        #region PrivateFunction

        private void Initial()
        {
            MyWordList = new ObservableCollection<MyWord>();
        }

        /// <summary>
        /// Method to get MyWordList in database
        /// </summary>
        private void GetMyWordListUpdate()
        {
            MyWordList.Clear();
            List<MyWord> lst = new List<MyWord>();

            lst = _myWordListService.GetAll();

            foreach (var word in lst)
            {
                MyWordList.Add(word);
            }
        }
        #endregion
    }
}
