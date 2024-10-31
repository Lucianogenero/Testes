﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyCompany.Communication.Response.ResourceMessagesException {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceMessageExceptions {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceMessageExceptions() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MyCompany.Communication.Response.ResourceMessagesException.ResourceMessageExcepti" +
                            "ons", typeof(ResourceMessageExceptions).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Esse cnpj já foi cadastrado..
        /// </summary>
        public static string CNPJ_ALREADY_EXISTS {
            get {
                return ResourceManager.GetString("CNPJ_ALREADY_EXISTS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O cnpj deve ser informado..
        /// </summary>
        public static string CNPJ_EMPTY {
            get {
                return ResourceManager.GetString("CNPJ_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O cnpj não pode ser maior que 14 numeros..
        /// </summary>
        public static string CNPJ_MAXIMUM_SIZE {
            get {
                return ResourceManager.GetString("CNPJ_MAXIMUM_SIZE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O cnpj não pode ser menor que 14 numeros..
        /// </summary>
        public static string CNPJ_MINIMUM_SIZE {
            get {
                return ResourceManager.GetString("CNPJ_MINIMUM_SIZE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O cnpj deve conter apenas numeros.
        /// </summary>
        public static string CNPJ_ONLY_NUMBERS {
            get {
                return ResourceManager.GetString("CNPJ_ONLY_NUMBERS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O email email deve ser informado..
        /// </summary>
        public static string EMAIL_EMPTY {
            get {
                return ResourceManager.GetString("EMAIL_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O email está incorreto..
        /// </summary>
        public static string EMAIL_INCORRET_FORMAT {
            get {
                return ResourceManager.GetString("EMAIL_INCORRET_FORMAT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O tamanho maximo é de 60 caracteres..
        /// </summary>
        public static string EMAIL_MAXIMUM_SIZE {
            get {
                return ResourceManager.GetString("EMAIL_MAXIMUM_SIZE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro Desconhecido.
        /// </summary>
        public static string EXCEPT_UNKCNOWN {
            get {
                return ResourceManager.GetString("EXCEPT_UNKCNOWN", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fornecedor não encontrado..
        /// </summary>
        public static string FORNECEDOR_NOT_FOUND {
            get {
                return ResourceManager.GetString("FORNECEDOR_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O id deve ser maior que zero..
        /// </summary>
        public static string INVALID_ID {
            get {
                return ResourceManager.GetString("INVALID_ID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome deve ser informado.
        /// </summary>
        public static string NAME_EMPTY {
            get {
                return ResourceManager.GetString("NAME_EMPTY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome não pode ser maior que 60 caracteres..
        /// </summary>
        public static string NAME_MAXIMUM_SIZE {
            get {
                return ResourceManager.GetString("NAME_MAXIMUM_SIZE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O nome não pode ser menor que 3 caracteres..
        /// </summary>
        public static string NAME_MINIMUM_SIZE {
            get {
                return ResourceManager.GetString("NAME_MINIMUM_SIZE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sem resultados..
        /// </summary>
        public static string NO_RESULTS {
            get {
                return ResourceManager.GetString("NO_RESULTS", resourceCulture);
            }
        }
    }
}