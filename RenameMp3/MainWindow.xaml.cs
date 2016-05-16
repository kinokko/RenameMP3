using Microsoft.Win32;
using RenameMp3.Model;
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
        private RenameUtil _renameUtil;
        public MainWindow()
        {
            initialization();
        }

        private void fileDialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool result = _fileUtil.ChooseFiles(fileDialog);
            if (result == true)
            {
                _songListViewUtil.AddSongsToListView(_fileUtil.FilePaths);
            }
        }

        private void initialization()
        {
            InitializeComponent();
            _fileUtil = new FileUtil();
            _songListViewUtil = new SongListViewUtil(songListView);
            _renameUtil = new RenameUtil();
        }

        private void defaultRuleButton_Click(object sender, RoutedEventArgs e)
        {
            _renameUtil.SetDefaultRenameRule(ruleTextBox);
        }

        private void actionButton_Click(object sender, RoutedEventArgs e)
        {
            List<SongDetail> succeedSongDetailList = _renameUtil.RenameAction(_songListViewUtil.SongListView.Items, ruleTextBox.Text);
            _songListViewUtil.RemoveDetailFromList(succeedSongDetailList);
        }
    }
}
