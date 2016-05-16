using Microsoft.Win32;
using RenameMp3.Util;
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

namespace RenameMp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileUtil _fileUtil;
        private SongListViewUtil _songListViewUtil;
        public MainWindow()
        {
            initialization();
        }

        private void fileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            List<string> songPaths = _fileUtil.ChooseFiles(fileDialog);
            _songListViewUtil.AddSongsToListView(songPaths);
        }

        private void initialization()
        {
            InitializeComponent();
            _fileUtil = new FileUtil();
            _songListViewUtil = new SongListViewUtil(songListView);
        }
    }
}
