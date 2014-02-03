
using GermanLearningModule.ViewModels;
using System.Windows.Controls;

namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for StudyGermanView.xaml
    /// </summary>
    public partial class StudyGermanView : UserControl
    {
        
        public StudyGermanView(StudyGermanViewModel studyGermanViewModel)
        {
            InitializeComponent();
           
            DataContext = studyGermanViewModel;
        }

    }
}
