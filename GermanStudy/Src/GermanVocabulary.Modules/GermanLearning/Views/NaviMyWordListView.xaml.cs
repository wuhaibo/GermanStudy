
using GermanVocabulary.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for NaviMyWordListView.xaml
    /// </summary>
    public partial class NaviMyWordListView : UserControl
    {
        private IRegionManager _regionManager;
        public NaviMyWordListView(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void NavigateToMyWordListViewRadioButton_Click(object sender, RoutedEventArgs e)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion,
                            new Uri("MyWordListView", UriKind.Relative));
        }
    }
}
