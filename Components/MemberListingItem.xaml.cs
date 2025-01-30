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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemberManager.Components
{
    /// <summary>
    /// Interaction logic for MemberListingItem.xaml
    /// </summary>
    public partial class MemberListingItem : UserControl
    {
        public MemberListingItem()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            dropdown.IsOpen = false;
        }
    }
}
