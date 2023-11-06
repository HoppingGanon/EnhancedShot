using System;
using System.Collections.Generic;
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
        public string preset;
        public string sub_folder;
        public string filename;

        public MenuSettings()
        {
            this.preset = "";
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

        public CommonSettings()
        {
            this.top_most = false;
            this.shortcut_rec = false;
            this.shortcut_shot = false;
            this.shortcut_play = false;
        }
    }

    internal class PresetSettings
    {
        public string name;
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

        public FlatSettings() {
            
            this.preset = new PresetSettings();
        }

        public string Preset
        {
            get { return this.menu.preset; }
            set { this.menu.preset = value; }
        }
        public string SubFolder;
        public string Filename;

        public bool TopMost;
        public bool ShortcutRec;
        public bool ShortcutShot;
        public bool ShortcutPlay;

        public string Name;
        public int X;
        public int Y;
        public int Width;
        public int Height;
        public string Target;
        public int Extension;
        public string SavePath;
        public int SubFolderNameRule;
        public string SubFolderName;
        public int FilenameRule;
        public string Filename2;
    }
}
