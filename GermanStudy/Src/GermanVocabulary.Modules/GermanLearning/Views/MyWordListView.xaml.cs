using GermanLearningModule.ViewModels;
using System.Windows.Controls;

namespace GermanLearningModule.Views
{
    /// <summary>
    /// Interaction logic for MyWordListView.xaml
    /// </summary>
    public partial class MyWordListView : UserControl
    {
        
        public MyWordListView(MyWordListViewModel myWordListViewModel)
        {
            InitializeComponent();

            this.dataGridMyWords.ItemsSource = myWordListViewModel.MyWordList;
            this.DataContext = myWordListViewModel;
        }

    }
}
