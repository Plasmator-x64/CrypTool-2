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

using System.ComponentModel;
using System;
using System.Windows.Controls;
using M209Analyzer;
using CrypTool.PluginBase.Utils;

namespace CrypTool.Plugins.M209Analyzer
{
    public enum UnknownSymbolHandlingMode
    {
        Ignore = 0,
        Remove = 1,
        Replace = 2
    }

    public enum KeyFormat
    {
        Digits,
        LatinLetters
    }

    // HOWTO: Change author name, email address, organization and URL.
    [Author("Josef Matwich", "josef.matwich@student.uni-siegen.de", "CrypTool 2 Team", "https://www.cryptool.org")]
    // HOWTO: Change plugin caption (title to appear in CT2) and tooltip.
    // You can (and should) provide a user documentation as XML file and an own icon.
    [PluginInfo("M209 Analyzer", "Analyze the Hagelin M209", "M209Analyzer/userdoc.xml", new[] { "CrypWin/images/default.png" })]
    // HOWTO: Change category to one that fits to your plugin. Multiple categories are allowed.
    [ComponentCategory(ComponentCategory.CryptanalysisGeneric)]
    public class M209Analyzer : ICrypComponent
    {
        #region Private Variables

        // HOWTO: You need to adapt the settings class as well, see the corresponding file.
        private readonly M209AnalyzerSettings settings = new M209AnalyzerSettings();
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWKXY";

        private PinSetting BestPins = new PinSetting();
        private LugSettings BestLugs = new LugSettings(new string[27] {
            "36","06","16","15","45","04","04","04","04",
            "20","20","20","20","20","20","20","20","20",
            "20","25","25","05","05","05","05","05","05"
        });

        #endregion

        #region Data Properties

        /// <summary>
        /// HOWTO: Input interface to read the input data. 
        /// You can add more input properties of other type if needed.
        /// </summary>
        [PropertyInfo(Direction.InputData, "Ciphertext", "Ciphertext only")]
        public string Ciphertext
        {
            get;
            set;
        }

        [PropertyInfo(Direction.InputData, "Knowntext", "")]
        public string Knowntext
        {
            get;
            set;
        }

        [PropertyInfo(Direction.InputData, "P", "Putative decryption")]
        public string P
        {
            get;
            set;
        }

        #endregion

        #region IPlugin Members

        /// <summary>
        /// Provide plugin-related parameters (per instance) or return null.
        /// </summary>
        public ISettings Settings
        {
            get { return settings; }
        }

        /// <summary>
        /// Provide custom presentation to visualize the execution or return null.
        /// </summary>
        public UserControl Presentation
        {
            get { return null; }
        }

        /// <summary>
        /// Called once when workflow execution starts.
        /// </summary>
        public void PreExecution()
        {
        }

        /// <summary>
        /// Called every time this plugin is run in the workflow execution.
        /// </summary>
        public void Execute()
        {
            //the settings gramsType is between 0 and 4. Thus, we have to add 1 to cast it to a "GramsType", which starts at 1
            Grams grams = LanguageStatistics.CreateGrams(settings.Language, (LanguageStatistics.GramsType)(settings.GramsType + 1), false);
            grams.Normalize(10_000_000);

            // HOWTO: Use this to show the progress of a plugin algorithm execution in the editor.
            ProgressChanged(0, 1);
            try
            {
                // HC - Hill climb
                // SA - Simulated Anealing
                switch (settings.AttackMode)
                {
                    case AttackMode.CiphertextOnly:
                        break;
                    case AttackMode.KnownPlaintext:
                        break;
                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                GuiLogMessage(string.Format("Exception occured: {0}", ex.Message), NotificationLevel.Error);
            }

            ProgressChanged(1, 1);
        }

        private string HCOuter(string ciphertext, string VersionOfInstruction)
        {
            BestLugs.Randomize();
            BestPins.Randomize();

            bool stuck = false;
            do
            {
                stuck = true;

                LugSetting[] candidateLugs = BestLugs.GetNeighborLugs("V");
                PinSetting[] candidatePins;

                for (int i = 0; i < candidateLugs.Length; i++)
                {
                    candidatePins = SAInner(ciphertext, candidateLugs[i], "V");
                }

            } while (stuck == true);
            return "BestLugs, BestPins";
        }

        private PinSetting[] SAInner(string chiphertext, LugSetting lug, string versionOfInstruction)
        {
            return new PinSetting[] { new PinSetting()};
        }

        private double LogMonograms(string P)
        {
            double result = 0.0;
            for (int i = 0; i < settings.c; i++)
            {
                result += FrequencyOfCharInP(ALPHABET[i], P) * Math.Log(GetPropabilityOfCharInLanguage(ALPHABET[i]));
            }
            return result;
        }

        private double GetPropabilityOfCharInLanguage(char character)
        {
            return 0.0;
        }

        private int FrequencyOfCharInP(char character, string P)
        {
            return 0;
        }

        /// <summary>
        /// Called once after workflow execution has stopped.
        /// </summary>
        public void PostExecution()
        {
        }

        /// <summary>
        /// Triggered time when user clicks stop button.
        /// Shall abort long-running execution.
        /// </summary>
        public void Stop()
        {
        }

        /// <summary>
        /// Called once when plugin is loaded into editor workspace.
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        /// Called once when plugin is removed from editor workspace.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #region Event Handling

        public event StatusChangedEventHandler OnPluginStatusChanged;

        public event GuiLogNotificationEventHandler OnGuiLogNotificationOccured;

        public event PluginProgressChangedEventHandler OnPluginProgressChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private void GuiLogMessage(string message, NotificationLevel logLevel)
        {
            EventsHelper.GuiLogMessage(OnGuiLogNotificationOccured, this, new GuiLogEventArgs(message, this, logLevel));
        }

        private void OnPropertyChanged(string name)
        {
            EventsHelper.PropertyChanged(PropertyChanged, this, new PropertyChangedEventArgs(name));
        }

        private void ProgressChanged(double value, double max)
        {
            EventsHelper.ProgressChanged(OnPluginProgressChanged, this, new PluginProgressEventArgs(value, max));
        }

        #endregion
    }
}
