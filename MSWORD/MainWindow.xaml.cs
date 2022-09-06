using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MSWORD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(FilePathTxtb.Text, new TextRange(contentTxtb.Document.ContentStart,contentTxtb.Document.ContentEnd).Text);
        }

        private void FilePathBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;
            if (choofdlog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                FilePathTxtb.Text = sFileName;
                contentTxtb.SelectAll();
                contentTxtb.Cut();
                contentTxtb.AppendText(File.ReadAllText(sFileName));
            }


        }

        private void CutBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Cut();
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Copy();
        }

        private void PasteBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.Paste();
        }

        private void SelectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            contentTxtb.SelectAll();
        }
    }
}
