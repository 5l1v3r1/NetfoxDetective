﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Netfox.NetfoxFrameworkAPI.Tests.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.1.0.0")]
    public sealed partial class PrivateKeys : global::System.Configuration.ApplicationSettingsBase {
        
        private static PrivateKeys defaultInstance = ((PrivateKeys)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PrivateKeys())));
        
        public static PrivateKeys Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\..\\..\\TestingData\\webmail\\pk.pem")]
        public string pk_pem {
            get {
                return ((string)(this["pk_pem"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\..\\..\\TestingData\\facebook\\fb_pk.pem")]
        public string fb_pk {
            get {
                return ((string)(this["fb_pk"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\..\\..\\TestingData\\lide\\lide_pk.pem")]
        public string lide_pk {
            get {
                return ((string)(this["lide_pk"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\..\\TestingData\\webmail\\pk.pem")]
        public string fw_pk_pem {
            get {
                return ((string)(this["fw_pk_pem"]));
            }
            set {
                this["fw_pk_pem"] = value;
            }
        }
    }
}