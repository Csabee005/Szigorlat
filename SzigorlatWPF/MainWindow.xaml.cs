using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SzigorlatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Algorithm> algorithms = new List<Algorithm>();
        List<string> headers = new List<string>();
        List<string> pseudos = new List<string>();
        List<string> codes = new List<string>();
        Pseudo pseudo;
        Code code;
        AlgorithmCodes ac = new AlgorithmCodes();
        
        public MainWindow()
        {
            InitializeComponent();
            pseudo = new Pseudo();
            pseudo.Show();
            code = new Code();
            code.Show();
            LoadBasicAlgos();
            FillBasicAlgos();
        }
        public void WriteOutput(string text)
        {
            Output.Text += text + "\n";
        }


        public void LoadBasicAlgos()
        {
            LoadBasicHeaders();
            LoadBasicCodes();
            LoadBasicPseudo();

            for (int i = 0; i < headers.Count; i++)
            {
                algorithms.Add(new Algorithm(headers[i], codes[i], pseudos[i], Algorithm.GetAlgo(headers[i])));
            }
            WriteOutput("Done");
        }
        private void LoadBasicHeaders()
        {
            StreamReader sr = new StreamReader("BasicAlgorithmsHeader.txt");
            while (!sr.EndOfStream)
            {
                headers.Add(sr.ReadLine());
            }
            sr.Close();
        }
        private void LoadBasicPseudo()
        {
            StreamReader sr = new StreamReader("BasicAlgorithmsPseudo.txt");
            while (!sr.EndOfStream)
            {
                StringBuilder sb = new StringBuilder();
                string beolvasott = sr.ReadLine();
                while (beolvasott != "END.")
                {
                    sb.Append(beolvasott);
                    sb.AppendLine();
                    beolvasott = sr.ReadLine();
                }
                pseudos.Add(sb.ToString());
            }
            sr.Close();
        }
        private void LoadBasicCodes()
        {
            StreamReader sr = new StreamReader("BasicAlgorithmsCSharp.txt");
            while (!sr.EndOfStream)
            {
                StringBuilder sb = new StringBuilder();
                string beolvasott = sr.ReadLine();
                while (beolvasott !=  "END.")
                {
                    sb.Append(beolvasott);
                    sb.AppendLine();
                    beolvasott = sr.ReadLine();
                }
                codes.Add(sb.ToString());
            }
            sr.Close();
        }

        private void FillBasicAlgos()
        {
            for (int i = 0; i < headers.Count; i++)
            {
                BasicAlgos.Items.Add(headers[i]);

            }

        }

        private void RunAlgo_Click(object sender, RoutedEventArgs e)
        {
            if (BasicAlgos.SelectedIndex < 0) return;
            string header = BasicAlgos.Items[BasicAlgos.SelectedIndex].ToString();
            Algorithm a = algorithms.Find(i => i.Title == header);
            a.Run();
        }
    }
}
