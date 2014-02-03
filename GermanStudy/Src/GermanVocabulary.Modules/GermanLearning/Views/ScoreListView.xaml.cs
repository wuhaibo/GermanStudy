using GermanLearningModule.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for ScoreListView.xaml
    /// </summary>
    public partial class ScoreListView : UserControl
    {
        
        public ScoreListView(ScoreListViewModel scoreListViewModel)
        {
            InitializeComponent();    
            lstBoxScores.ItemsSource = scoreListViewModel.Scores;
            DataContext = scoreListViewModel;
        }

    }
}
