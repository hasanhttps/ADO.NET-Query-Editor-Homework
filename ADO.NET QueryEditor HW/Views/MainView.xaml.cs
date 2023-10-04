using System;
using System.Linq;
using System.Text;
using System.Windows;
using ADO.NET_QueryEditor_HW.ViewModels;

namespace ADO.NET_QueryEditor_HW.Views {
    public partial class MainView : Window {
        public MainView()  {
            InitializeComponent();
            DataContext = new MainViewModel(ProviderNamesCB, BaseTabControl);
        }
    }
}
