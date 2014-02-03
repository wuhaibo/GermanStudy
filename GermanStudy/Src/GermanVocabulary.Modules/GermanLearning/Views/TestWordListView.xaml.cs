using GermanLearningModule.ViewModels;
using System.Windows.Controls;

namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for TestWordListView.xaml
    /// </summary>
    public partial class TestWordListView : UserControl
    {
        TestWordListViewModel testWordListViewModel;
        public TestWordListView(TestWordListViewModel testWordListViewModel)
        {
            InitializeComponent();
            this.testWordListViewModel = testWordListViewModel;
                    
            lstBoxAnswers.ItemsSource = testWordListViewModel.Choices;
            lstBoxAnswersJudge.ItemsSource = testWordListViewModel.AnswerStates;
            DataContext = this.testWordListViewModel;  
        }


    }
}
