using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnhancedShot.viewmodels
{
    internal class Settings
    {
        public MenuSettings menu;
        public CommonSettings common;
        public List<PresetSettings> presets;
        public Settings()
        {
            this.menu = new MenuSettings();
            this.common = new CommonSettings();
            this.presets = new List<PresetSettings>();
        }
    }

    internal class MenuSettings
    {
        public int preset;
        public string sub_folder;
        public string filename;

        public MenuSettings()
        {
            this.preset = -1;
            this.sub_folder = "";
            this.filename = "";
        }
    }

    internal class CommonSettings
    {
        public bool top_most;
        public bool shortcut_rec;
        public bool shortcut_shot;
        public bool shortcut_play;
        public int previewBuffSize;
        public int maxFramerate;

        public CommonSettings()
        {
            this.top_most = false;
            this.shortcut_rec = false;
            this.shortcut_shot = false;
            this.shortcut_play = false;
            this.previewBuffSize = 30;
            this.maxFramerate = 8;
        }
    }

    internal class PresetSettings
    {
        public string name;
        public int shot_position;
        public int x;
        public int y;
        public int width;
        public int height;
        public string target;
        public int extension;
        public string save_path;
        public int sub_folder_name_rule;
        public string sub_folder_name;
        public int filename_rule;
        public string filename;

        public PresetSettings()
        {
            this.name = "";
            this.shot_position = 0;
            this.x = 0;
            this.y = 0;
            this.width = 1280;
            this.height = 720;
            this.target = "";
            this.extension = 0;
            this.save_path = "";
            this.sub_folder_name_rule = 0;
            this.sub_folder_name = "";
            this.filename_rule = 0;
            this.filename = "";
        }

        public PresetSettings clone()
        {
            var o = new PresetSettings();
            o.name =  this.name;
            o.shot_position = this.shot_position;
            o.x = this.x;
            o.y = this.y;
            o.width = this.width;
            o.height = this.height;
            o.target = this.target;
            o.extension = this.extension;
            o.save_path = this.save_path;
            o.sub_folder_name_rule = this.sub_folder_name_rule;
            o.sub_folder_name = this.sub_folder_name;
            o.filename_rule = this.filename_rule;
            o.filename = this.filename;

            return o;
        }
    }

    internal class FlatSettings
    {
        public PresetSettings preset;

        public Settings settings;

        public FlatSettings() {
            this.preset = new PresetSettings();
            this.settings = new Settings();
        }

        public void loadJson(string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    // JSONファイルを読み出す
                    using (var sr = new StreamReader(stream))
                    {
                        this.settings = JsonConvert.DeserializeObject<Settings>(sr.ReadToEnd());
                    }
                }
            }catch(Exception e)
            {
                MessageBox.Show("settings.jsonが読み込めませんでした\n" + e.Message);
            }
        }

        public void saveJson(string path)
        {
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    // JSONファイルを読み出す
                    using (var sr = new StreamWriter(stream))
                    {
                        sr.WriteAsync(JsonConvert.SerializeObject(this.settings));
                        
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("settings.json保存できませんでした\n" + e.Message);
            }
        }

        public void setPreset(string name)
        {
            var hits = this.settings.presets.Where(p => p.name == name);
            if (hits.Count() > 0)
            {
                this.settings.presets.Remove(hits.ToArray()[0]);
                MessageBox.Show($"プリセット'{name}'を更新しました");
            } else
            {
                MessageBox.Show($"プリセット'{name}'を追加しました");
            }
            this.preset.name = name;
            this.settings.presets = (new List<PresetSettings> {this.preset}).Concat(this.settings.presets).ToList();
            this.Preset = 0;
            this.saveJson("settings.json");
        }

        public int Preset
        {
            get { return this.settings.menu.preset; }
            set { this.settings.menu.preset = value; }
        }
        public string SubFolder
        {
            get { return this.settings.menu.sub_folder; }
            set { this.settings.menu.sub_folder = value; }
        }
        public string Filename
        {
            get { return this.settings.menu.filename; }
            set { this.settings.menu.filename = value; }
        }

        public bool TopMost
        {
            get { return this.settings.common.top_most; }
            set { this.settings.common.top_most = value; }
        }
        public bool ShortcutRec
        {
            get { return this.settings.common.shortcut_rec; }
            set { this.settings.common.shortcut_rec = value; }
        }
        public bool ShortcutShot
        {
            get { return this.settings.common.shortcut_shot; }
            set { this.settings.common.shortcut_shot = value; }
        }
        public bool ShortcutPlay
        {
            get { return this.settings.common.shortcut_play; }
            set { this.settings.common.shortcut_play = value; }
        }
        public int PreviewBuffSize
        {
            get { return this.settings.common.previewBuffSize; }
            set { this.settings.common.previewBuffSize = value; }
        }
        public int MaxFramerate
        {
            get { return this.settings.common.maxFramerate; }
            set { this.settings.common.maxFramerate = value; }
        }

        public int ShotPosition
        {
            get { return this.preset.shot_position; }
            set {
                this.preset.shot_position = value;
            }
        }
        public string X
        {
            get { return ""+ this.preset.x; }
            set {
                try
                {
                    this.preset.x = int.Parse(value);
                } catch
                { /* ignore */ }
            }
        }
        public string Y
        {
            get { return "" + this.preset.y; }
            set
            {
                try
                {
                    this.preset.y = int.Parse(value);
                }
                catch
                { /* ignore */ }
            }
        }
        public string Width
        {
            get { return "" + this.preset.width; }
            set
            {
                try
                {
                    this.preset.width = int.Parse(value);
                }
                catch
                { /* ignore */ }
            }
        }
        public string Height
        {
            get { return "" + this.preset.height; }
            set
            {
                try
                {
                    this.preset.height = int.Parse(value);
                }
                catch
                { /* ignore */ }
            }
        }
        public string Target
        {
            get { return this.preset.target; }
            set { this.preset.target = value; }
        }
        public int Extension
        {
            get { return this.preset.extension; }
            set { this.preset.extension = value; }
        }
        public string SavePath
        {
            get { return this.preset.save_path; }
            set { this.preset.save_path = value; }
        }
        public int SubFolderNameRule
        {
            get { return this.preset.sub_folder_name_rule; }
            set { this.preset.sub_folder_name_rule = value; }
        }
        public string SubFolderName
        {
            get { return this.preset.sub_folder_name; }
            set { this.preset.sub_folder_name = value; }
        }
        public int FilenameRule
        {
            get { return this.preset.filename_rule; }
            set { this.preset.filename_rule = value; }
        }
        public string Filename2
        {
            get { return this.preset.filename; }
            set { this.preset.filename = value; }
        }
    }
}
