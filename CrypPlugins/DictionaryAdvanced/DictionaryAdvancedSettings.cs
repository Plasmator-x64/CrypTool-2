﻿/*
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
using System.Windows;

namespace CrypTool.Plugins.DictionaryAdvanced
{
    #region Private Enum

    public enum CharFormat
    {
        LowerCase,
        TitleCase,
        UpperCase,
        BasicL33T,
        MediumL33T,
        HardL33T
    }

    public enum CharDir
    {
        Forward,
        Reverse
    }

    public enum OutputType
    {
        Loop,
        Single
    }

    #endregion

    public class DictionaryAdvancedSettings : ISettings
    {
        private int _LanguageCode = 0; // Set Default Language to English
        private CharFormat _CharFormat = CharFormat.UpperCase; // Set Default Char Format to UpperCase
        private CharDir _CharDir = CharDir.Forward; // Set Default Char Direction to Forward
        private OutputType _OutputType = OutputType.Single; // Set Default Output Type to Single String

        #region TaskPane Definitions

        [TaskPane("DictionaryLangCaption", "DictionaryLangTooltip", null, 0, false, ControlType.ComboBox, new string[] {
            "English", "German", "French", "Spanish", "Italian", "Hungarian", "Russian", "Slovak",
            "Latin", "Greek", "Dutch", "Swedish", "Portuguese ", "Polish", "Turkish", "UserDefined" })]
        public int Language
        {
            get
            {
                return _LanguageCode;
            }
            set
            {
                if (value != _LanguageCode)
                {
                    _LanguageCode = value;
                    OnPropertyChanged(nameof(Language));
                }
            }
        }

        [TaskPane("CharFormatCaption", "CharFormatTooltip", null, 1, false, ControlType.ComboBox, new string[] { "LowerCase", "TitleCase", "UpperCase", "BasicL33T", "MediumL33T", "HardL33T" })]
        public CharFormat CharacterFormat
        {
            get
            {
                return _CharFormat;
            }
            set
            {
                _CharFormat = value;
                OnPropertyChanged(nameof(CharacterFormat));
            }
        }

        [TaskPane("CharDirCaption", "CharDirTooltip", null, 2, false, ControlType.ComboBox, new string[] { "Forward", "Reverse" })]
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

        [TaskPane("DictionaryStringOutputCaption", "DictionaryStringOutputTypeTooltip", null, 3, false, ControlType.ComboBox, new string[] { "Loop", "Single" })]
        public OutputType StringOutputType
        {
            get
            {
                return _OutputType;
            }
            set
            {
                _OutputType = value;
                OnPropertyChanged(nameof(StringOutputType));
            }
        }

        #endregion

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
