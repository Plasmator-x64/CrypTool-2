﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrypTool.CrypWin.Ntfs {
    using System;
    
    
    /// <summary>
    ///   Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    /// </summary>
    // Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    // -Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    // Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    // mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CrypTool.CrypWin.Ntfs.Resources", typeof(Resources).Assembly);
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
        ///   Sucht eine lokalisierte Zeichenfolge, die Access to the path &apos;{0}&apos; was denied. ähnelt.
        /// </summary>
        internal static string Error_AccessDenied_Path {
            get {
                return ResourceManager.GetString("Error_AccessDenied_Path", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Cannot create &apos;{0}&apos; because a file or directory with the same name already exists. ähnelt.
        /// </summary>
        internal static string Error_AlreadyExists {
            get {
                return ResourceManager.GetString("Error_AlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Could not find a part of the path &apos;{0}&apos;. ähnelt.
        /// </summary>
        internal static string Error_DirectoryNotFound {
            get {
                return ResourceManager.GetString("Error_DirectoryNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Could not find the drive &apos;{0}&apos;. The drive might not be ready or might not be mapped. ähnelt.
        /// </summary>
        internal static string Error_DriveNotFound {
            get {
                return ResourceManager.GetString("Error_DriveNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The file &apos;{0}&apos; already exists. ähnelt.
        /// </summary>
        internal static string Error_FileAlreadyExists {
            get {
                return ResourceManager.GetString("Error_FileAlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The specified stream name contains invalid characters. ähnelt.
        /// </summary>
        internal static string Error_InvalidFileChars {
            get {
                return ResourceManager.GetString("Error_InvalidFileChars", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The specified mode &apos;{0}&apos; is not supported. ähnelt.
        /// </summary>
        internal static string Error_InvalidMode {
            get {
                return ResourceManager.GetString("Error_InvalidMode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The specified file name &apos;{0}&apos; is not a disk-based file. ähnelt.
        /// </summary>
        internal static string Error_NonFile {
            get {
                return ResourceManager.GetString("Error_NonFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The process cannot access the file &apos;{0}&apos; because it is being used by another process. ähnelt.
        /// </summary>
        internal static string Error_SharingViolation {
            get {
                return ResourceManager.GetString("Error_SharingViolation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The specified alternate data stream &apos;{0}&apos; already exists on file &apos;{1}&apos;. ähnelt.
        /// </summary>
        internal static string Error_StreamExists {
            get {
                return ResourceManager.GetString("Error_StreamExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die The specified alternate data stream &apos;{0}&apos; does not exist on file &apos;{1}&apos;. ähnelt.
        /// </summary>
        internal static string Error_StreamNotFound {
            get {
                return ResourceManager.GetString("Error_StreamNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Sucht eine lokalisierte Zeichenfolge, die Unknown error: {0} ähnelt.
        /// </summary>
        internal static string Error_UnknownError {
            get {
                return ResourceManager.GetString("Error_UnknownError", resourceCulture);
            }
        }
    }
}
