using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.sub_folder_name_rule = 0;
            this.sub_folder_name = "";
            this.filename_rule = 0;
            this.filename = "";
        }
    }

    internal class FlatSettings : Settings
    {
        public PresetSettings preset;
        public string preset2;

        public FlatSettings() {
            this.preset = new PresetSettings();
        }

        public int Preset
        {
            get { return this.menu.preset; }
            set { this.menu.preset = value; }
        }
        public string SubFolder
        {
            get { return this.menu.sub_folder; }
            set { this.menu.sub_folder = value; }
        }
        public string Filename
        {
            get { return this.menu.filename; }
            set { this.menu.filename = value; }
        }

        public bool TopMost
        {
            get { return this.common.top_most; }
            set { this.common.top_most = value; }
        }
        public bool ShortcutRec
        {
            get { return this.common.shortcut_rec; }
            set { this.common.shortcut_rec = value; }
        }
        public bool ShortcutShot
        {
            get { return this.common.shortcut_shot; }
            set { this.common.shortcut_shot = value; }
        }
        public bool ShortcutPlay
        {
            get { return this.common.shortcut_play; }
            set { this.common.shortcut_play = value; }
        }
        public int PreviewBuffSize
        {
            get { return this.common.previewBuffSize; }
            set { this.common.previewBuffSize = value; }
        }
        public int MaxFramerate
        {
            get { return this.common.maxFramerate; }
            set { this.common.maxFramerate = value; }
        }

        public string Name
        {
            get { return this.preset.name; }
            set { this.preset.name = value; }
        }
        public int ShotPosition
        {
            get { return this.preset.shot_position; }
            set {
                Debug.Print(value.ToString());
                this.preset.shot_position = value;
            }
        }
        public int X
        {
            get { return this.preset.x; }
            set { this.preset.x = value; }
        }
        public int Y
        {
            get { return this.preset.y; }
            set { this.preset.y = value; }
        }
        public int Width
        {
            get { return this.preset.width; }
            set { this.preset.width = value; }
        }
        public int Height
        {
            get { return this.preset.height; }
            set { this.preset.height = value; }
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
        public string Preset2
        {
            get { return this.preset2; }
            set { this.preset2 = value; }
        }
    }
}
