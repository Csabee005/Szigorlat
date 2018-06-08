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

namespace SzigorlatWPF
{
    /// <summary>
    /// Interaction logic for Pseudo.xaml
    /// </summary>
    public partial class Code : Window
    {
        public Code()
        {
            InitializeComponent();
        }
        public new void AddText(string text)
        {
            CodeBox.Text = text;
        }
        public void ResetText()
        {
            CodeBox.Text = "";
        }
    }
}
