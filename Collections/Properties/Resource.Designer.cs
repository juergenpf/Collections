﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Collections.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Collections.Properties.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to Duplicate key..
        /// </summary>
        internal static string DUPLICATE_KEY {
            get {
                return ResourceManager.GetString("DUPLICATE_KEY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This element is not in the binary heap..
        /// </summary>
        internal static string ELEMENT_NOT_FOUND {
            get {
                return ResourceManager.GetString("ELEMENT_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The binary heap is empty..
        /// </summary>
        internal static string EMPTY_HEAP {
            get {
                return ResourceManager.GetString("EMPTY_HEAP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The capacity value must be at least 2. .
        /// </summary>
        internal static string INVALID_CAPACITY {
            get {
                return ResourceManager.GetString("INVALID_CAPACITY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The key is not in the binary heap..
        /// </summary>
        internal static string KEY_NOT_FOUND {
            get {
                return ResourceManager.GetString("KEY_NOT_FOUND", resourceCulture);
            }
        }
    }
}
