using GermanLearningModule.Services;
using GermanLearningModule.Views;
using GermanVocabulary.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;

namespace GermanLearningModule
{
    public class GermanLearningModule : IModule
    {

        private IUnityContainer _container;
        private IRegionManager _manager;

        public GermanLearningModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }


        public void Initialize()
        {
            //view reg
            _container.RegisterType<NaviMyWordListView>();
            _container.RegisterType<NaviScoreListView>();
            
            _container.RegisterType<Object, StudyGermanView>("StudyGermanView");
            _container.RegisterType<Object, MyWordListView>("MyWordListView");
            _container.RegisterType<Object, ScoreListView>("ScoreListView");
            _container.RegisterType<Object, TestWordListView>("TestWordListView");


            //service reg
            _container.RegisterType<IStudyWordsListService, StudyWordListService>();
            _container.RegisterType<IMyWordListService, MyWordListService>();
            _container.RegisterType<IScoreListService, ScoreListService>();
            _container.RegisterType<ITestWordListService, TestWordListService>();

            //navi button reg
            _manager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(NaviScoreListView));
            _manager.RegisterViewWithRegion(RegionNames.ToolbarRegion, typeof(NaviMyWordListView));
            _manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ScoreListView));        

        }
    }
}
