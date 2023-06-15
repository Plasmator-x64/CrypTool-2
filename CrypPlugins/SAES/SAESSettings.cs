﻿/*
   Copyright 2023 Nils Kopal, CrypTool project

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
using static CrypTool.PluginBase.Miscellaneous.BlockCipherHelper;
using System.ComponentModel;

namespace CrypTool.Plugins.SAES
{
    public class SAESSettings : ISettings
    {
        private CipherAction _action = CipherAction.Encrypt;
        private BlockMode _blockMode = BlockMode.ECB;
        private PaddingType _padding = PaddingType.None;

        [TaskPane("ActionCaption", "ActionTooltip", null, 0, false, ControlType.ComboBox, new string[] { "ActionList1", "ActionList2" })]
        public CipherAction Action
        {
            get => _action;
            set
            {
                if (_action != value)
                {
                    _action = value;
                    OnPropertyChanged(nameof(Action));
                }
            }
        }

        [TaskPane("BlockModeCaption", "BlockModeTooltip", null, 1, false, ControlType.ComboBox, new string[] { "BlockModeList1", "BlockModeList2", "BlockModeList3", "BlockModeList4" })]
        public BlockMode BlockMode
        {
            get => _blockMode;
            set
            {
                if (_blockMode != value)
                {
                    _blockMode = value;
                    OnPropertyChanged(nameof(BlockMode));
                }
            }
        }

        [TaskPane("PaddingCaption", "PaddingTooltip", null, 2, false, ControlType.ComboBox, new string[] { "PaddingList1", "PaddingList2", "PaddingList3", "PaddingList4", "PaddingList5", "PaddingList6" })]
        public PaddingType Padding
        {
            get => _padding;
            set
            {
                if (_padding != value)
                {
                    _padding = value;
                    OnPropertyChanged(nameof(Padding));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            EventsHelper.PropertyChanged(PropertyChanged, this, propertyName);
        }

        public void Initialize()
        {

        }
    }
}
