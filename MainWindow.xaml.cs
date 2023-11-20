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
        MainViewModel Model { get { return (MainViewModel)(this.DataContext); } }

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

            var presets = this.Model.settings.presets;
            foreach (var preset in presets)
            {
                this.presetList.Items.Add(preset.name);
                this.preset2List.Items.Add(preset.name);
            }

            if (this.Model.Preset < 0 || this.Model.Preset >= this.Model.settings.presets.Count)
            {
                this.Model.Preset = 0;
            }

            if (this.Model.settings.presets.Count != 0)
            {
                this.presetList.Text = this.Model.settings.presets[this.Model.Preset].name;
                this.Model.preset = this.Model.settings.presets[this.Model.Preset].clone();
            }

            this.updatePreset();

            this.saveButton.Click += this.saveButton_Click;
        }

        public void close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Model.close();
        }

        private void onSettingPresetChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Model.Preset = ((ComboBox)sender).SelectedIndex;
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Model.setPreset(this.presetList.Text);
        }

        private void updatePreset()
        {
            foreach (var obj in new System.Windows.DependencyObject[]{
                this.x,
                this.y,
                this.width,
                this.height,
                this.target,
                this.savePath,
                this.subFolderName,
                this.filename
            })
            {
                var bindingExpression = BindingOperations.GetBindingExpression(obj, TextBox.TextProperty);
                bindingExpression.UpdateTarget();
            }

            foreach (var obj in new System.Windows.DependencyObject[]{
                this.shotPositionList,
                this.extensionList,
                this.subFolderRuleList,
                this.nameRuleList,
                this.preset2List,
            })
            {
                var bindingExpression = BindingOperations.GetBindingExpression(obj, ComboBox.SelectedIndexProperty);
                bindingExpression.UpdateTarget();
            }
        }
    }
}
