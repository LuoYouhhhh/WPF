using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataGridView.ViewModel;

namespace DataGridView.View
{
    /// <summary>
    /// WinMain.xaml 的交互逻辑
    /// </summary>
    public partial class WinMain : Window
    {
        public WinMain()
        {
            InitializeComponent();
        }

        //未用到
        private void FilterTexBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.DataContext is WinMainViewModel vm)
            {
                vm.OnFilterTextChanged();
            }
        }
    }
}
