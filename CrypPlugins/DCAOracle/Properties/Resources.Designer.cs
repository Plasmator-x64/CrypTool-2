﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCAOracle.Properties {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DCAOracle.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        ///   Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Difference of messages ähnelt.
        /// </summary>
        internal static string MessageDifferenceInput {
            get {
                return ResourceManager.GetString("MessageDifferenceInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Specifies the difference between the messages of a pair. ähnelt.
        /// </summary>
        internal static string MessageDifferenceInputToolTip {
            get {
                return ResourceManager.GetString("MessageDifferenceInputToolTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Number of message pair ähnelt.
        /// </summary>
        internal static string MessagePairsCountInput {
            get {
                return ResourceManager.GetString("MessagePairsCountInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Specifies the number of message pairs to be generated ähnelt.
        /// </summary>
        internal static string MessagePairsCountInputToolTip {
            get {
                return ResourceManager.GetString("MessagePairsCountInputToolTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Message pairs ähnelt.
        /// </summary>
        internal static string MessagePairsOutput {
            get {
                return ResourceManager.GetString("MessagePairsOutput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Output of message pairs with specified difference ähnelt.
        /// </summary>
        internal static string MessagePairsOutputToolTip {
            get {
                return ResourceManager.GetString("MessagePairsOutputToolTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die DCA Oracle ähnelt.
        /// </summary>
        internal static string PluginCaption {
            get {
                return ResourceManager.GetString("PluginCaption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die This component generates randomly selected message pairs, where the messages of a pair have a definable difference. ähnelt.
        /// </summary>
        internal static string PluginTooltip {
            get {
                return ResourceManager.GetString("PluginTooltip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The number of message pairs must be greater than 0! ähnelt.
        /// </summary>
        internal static string WarningMessageCountMustBeSpecified {
            get {
                return ResourceManager.GetString("WarningMessageCountMustBeSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die block size ähnelt.
        /// </summary>
        internal static string WorSizeParameter {
            get {
                return ResourceManager.GetString("WorSizeParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die This parameter specifies the block size of the cipher used. Each message contains exactly one block. ähnelt.
        /// </summary>
        internal static string WorSizeParameterToolTip {
            get {
                return ResourceManager.GetString("WorSizeParameterToolTip", resourceCulture);
            }
        }
    }
}
