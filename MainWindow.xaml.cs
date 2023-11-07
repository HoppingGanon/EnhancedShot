using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace EnhancedShot
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.shotPositionList.Items.Add("指定した領域");
            this.shotPositionList.Items.Add("条件に一致したウィンドウ");

            this.extensionList.Items.Add("無圧縮(bmp)");
            this.extensionList.Items.Add("中画質(jpg)");
            this.extensionList.Items.Add("高画質(jpg)");
            this.extensionList.Items.Add("無劣化(png)");

            this.nameRuleList.Items.Add("ウィンドウタイトルで保存");
            this.nameRuleList.Items.Add("ウィンドウタイトルから正規表現で指定して保存");
            this.nameRuleList.Items.Add("固定名称で保存");

            this.subFolderRuleList.Items.Add("サブフォルダを使用しない");
            this.subFolderRuleList.Items.Add("ウィンドウタイトルで保存");
            this.subFolderRuleList.Items.Add("ウィンドウタイトルから正規表現で指定して保存");
            this.subFolderRuleList.Items.Add("固定名称で保存");

        }

        public void close(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void onSettingPresetChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.Print("");

        }
    }
}
