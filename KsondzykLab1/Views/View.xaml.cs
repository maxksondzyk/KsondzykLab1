using System.Windows.Controls;
using KsondzykLab1.ViewModels;

namespace KsondzykLab1.Views
{
    /// <summary>
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : UserControl
    {
        public View()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }
    }
}
