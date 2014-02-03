using GermanVocabulary.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;


namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for NaviScoreListView.xaml
    /// </summary>
    public partial class NaviScoreListView : UserControl
    {
        private IRegionManager _regionManager ;
        public NaviScoreListView(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;

        }

        private void NavigateToScoreListViewRadioButton_Click(object sender, RoutedEventArgs e)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                               new Uri("ScoreListView", UriKind.Relative));
        }
    }
}
