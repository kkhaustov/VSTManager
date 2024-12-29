using vstmanagertest.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace vstmanagertest.Views.Pages
{
    public partial class DashboardPage : INavigableView<DashboardViewModel>
    {
        public DashboardViewModel ViewModel { get; }

        public DashboardPage(DashboardViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
