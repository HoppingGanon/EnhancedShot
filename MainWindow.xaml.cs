using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
using Microsoft.VisualBasic;

namespace EnhancedShot
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel Model { get { return (MainViewModel)(this.DataContext); } }

        private bool updating = false;

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


            if (this.Model.Preset < 0 || this.Model.Preset >= this.Model.settings.presets.Count)
            {
                this.Model.Preset = 0;
            }

            this.updatePreset();

            this.saveButton.Click += this.saveButton_Click;

            this.delButton.Click += this.delButton_Click;

            this.presetList.SelectionChanged += this.changePresetList;
            this.preset2List.SelectionChanged += this.changePresetList;

        }

        public void close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Model.settings.presets.Where((p) => p.equals(this.Model.preset)).Count() == 0)
            {
                var r = MessageBox.Show("保存していないプリセットがあります\n保存して終了しますか？", "", MessageBoxButton.YesNoCancel);
                if (r == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                } else if(r == MessageBoxResult.Yes)
                {
                    this.Model.savePreset(this.Model.preset.name);
                }
            } 
            
            if (!this.Model.close())
            {
                e.Cancel = true;
            }
        }
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var presetName = Interaction.InputBox("プリセット名を入力してください", "", this.Model.preset.name);
            if (presetName != "")
            {
                var index = this.Model.savePreset(presetName);
                this.updatePreset();
                this.presetList.SelectedIndex = index;
                this.preset2List.SelectedIndex = index;
            }
        }
        private void delButton_Click(object sender, RoutedEventArgs e)
        {
            var index = this.Model.deletePreset(this.presetList.Text);
            this.updatePreset();
            this.presetList.SelectedIndex = index;
            this.preset2List.SelectedIndex = index;
        }

        private void changePresetList(object sender, RoutedEventArgs e)
        {
            if (this.Model.listening)
            {
                if (0 <= this.Model.Preset && this.Model.Preset < this.Model.settings.presets.Count)
                {
                    this.Model.preset = this.Model.settings.presets[this.Model.Preset].clone();
                } else
                {
                    this.Model.preset =new viewmodels.PresetSettings();
                }
                this.updatePreset();
            }
        }

        private void updatePreset()
        {
            if (!this.updating)
            {
                this.updating = true;
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
                    this.presetList,
                    this.preset2List
                })
                {
                    var bindingExpression = BindingOperations.GetBindingExpression(obj, ComboBox.ItemsSourceProperty);
                    bindingExpression.UpdateTarget();
                }

                foreach (var obj in new System.Windows.DependencyObject[]{
                    this.shotPositionList,
                    this.extensionList,
                    this.subFolderRuleList,
                    this.nameRuleList,
                    this.preset2List,
                    this.presetList
                })
                {
                    var bindingExpression = BindingOperations.GetBindingExpression(obj, ComboBox.SelectedIndexProperty);
                    bindingExpression.UpdateTarget();
                }

                this.updating = false;
            }
        }
    }
}
