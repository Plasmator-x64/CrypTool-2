/*
   Copyright CrypTool 2 Team <ct2contact@cryptool.org>

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using CrypTool.PluginBase;
using CrypTool.PluginBase.Miscellaneous;
using LanguageStatisticsLib;
using System.ComponentModel;

namespace CrypTool.Plugins.DictionaryAdvanced
{

    public enum CharCase
    {
        Lowercase,
        Titlecase,
        Uppercase
    }

    public enum CharDir
    {
        Forward,
        Reverse
    }

    public class DictionaryAdvancedSettings : ISettings
    {
        private string _LanguageCode = "en"; // Set Default Language to English
        private CharCase _CharCase = CharCase.Uppercase; // Set Default Char Case to Upper
        private CharDir _CharDir = CharDir.Forward; // Set Default Char Direction to Forward

        [TaskPane("DictionaryCaption", "DictionaryTooltip", null, 0, false, ControlType.LanguageSelector)]
        public int Language
        {
            get => LanguageStatistics.LanguageId(_LanguageCode);
            set
            {
                if (value != LanguageStatistics.LanguageId(_LanguageCode))
                {
                    _LanguageCode = LanguageStatistics.LanguageCode(value);
                    OnPropertyChanged(nameof(Language));
                }
            }
        }

        [TaskPane("CharCaseCaption", "CharCaseTooltip", null, 1, false, ControlType.ComboBox, new string[] { "Lowercase", "Titlecase", "Uppercase" })]
        public CharCase CharacterCase
        {
            get
            {
                return _CharCase;
            }
            set
            {
                _CharCase = value;
                OnPropertyChanged(nameof(CharacterCase));
            }
        }

        [TaskPane("CharDirCaption", "CharDirTooltip", null, 1, false, ControlType.ComboBox, new string[] { "Forward", "Reverse" })]
        public CharDir CharacterDirection
        {
            get
            {
                return _CharDir;
            }
            set
            {
                _CharDir = value;
                OnPropertyChanged(nameof(CharacterDirection));
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void Initialize()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            EventsHelper.PropertyChanged(PropertyChanged, this, propertyName);
        }

        #endregion

    }
}
