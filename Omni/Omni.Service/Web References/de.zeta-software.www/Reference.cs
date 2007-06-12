﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.312
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.312.
// 
#pragma warning disable 1591

namespace Omni.Service.de.zeta_software.www {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TranslationServiceSoap", Namespace="http://zeta-software.de/TranslationWebService")]
    public partial class TranslationService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllTranslationModesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetTranslationModeByObjectIDOperationCompleted;
        
        private System.Threading.SendOrPostCallback TranslateOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TranslationService() {
            this.Url = global::Omni.Service.Properties.Settings.Default.Omni_Service_de_zeta_software_www_TranslationService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllTranslationModesCompletedEventHandler GetAllTranslationModesCompleted;
        
        /// <remarks/>
        public event GetTranslationModeByObjectIDCompletedEventHandler GetTranslationModeByObjectIDCompleted;
        
        /// <remarks/>
        public event TranslateCompletedEventHandler TranslateCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://zeta-software.de/TranslationWebService/GetAllTranslationModes", RequestNamespace="http://zeta-software.de/TranslationWebService", ResponseNamespace="http://zeta-software.de/TranslationWebService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(IsNullable=false)]
        public TranslationMode[] GetAllTranslationModes() {
            object[] results = this.Invoke("GetAllTranslationModes", new object[0]);
            return ((TranslationMode[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllTranslationModesAsync() {
            this.GetAllTranslationModesAsync(null);
        }
        
        /// <remarks/>
        public void GetAllTranslationModesAsync(object userState) {
            if ((this.GetAllTranslationModesOperationCompleted == null)) {
                this.GetAllTranslationModesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllTranslationModesOperationCompleted);
            }
            this.InvokeAsync("GetAllTranslationModes", new object[0], this.GetAllTranslationModesOperationCompleted, userState);
        }
        
        private void OnGetAllTranslationModesOperationCompleted(object arg) {
            if ((this.GetAllTranslationModesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllTranslationModesCompleted(this, new GetAllTranslationModesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://zeta-software.de/TranslationWebService/GetTranslationModeByObjectID", RequestNamespace="http://zeta-software.de/TranslationWebService", ResponseNamespace="http://zeta-software.de/TranslationWebService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public TranslationMode GetTranslationModeByObjectID(string objectID) {
            object[] results = this.Invoke("GetTranslationModeByObjectID", new object[] {
                        objectID});
            return ((TranslationMode)(results[0]));
        }
        
        /// <remarks/>
        public void GetTranslationModeByObjectIDAsync(string objectID) {
            this.GetTranslationModeByObjectIDAsync(objectID, null);
        }
        
        /// <remarks/>
        public void GetTranslationModeByObjectIDAsync(string objectID, object userState) {
            if ((this.GetTranslationModeByObjectIDOperationCompleted == null)) {
                this.GetTranslationModeByObjectIDOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTranslationModeByObjectIDOperationCompleted);
            }
            this.InvokeAsync("GetTranslationModeByObjectID", new object[] {
                        objectID}, this.GetTranslationModeByObjectIDOperationCompleted, userState);
        }
        
        private void OnGetTranslationModeByObjectIDOperationCompleted(object arg) {
            if ((this.GetTranslationModeByObjectIDCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTranslationModeByObjectIDCompleted(this, new GetTranslationModeByObjectIDCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://zeta-software.de/TranslationWebService/Translate", RequestNamespace="http://zeta-software.de/TranslationWebService", ResponseNamespace="http://zeta-software.de/TranslationWebService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Translate(TranslationMode translationMode, string textToTranslate) {
            object[] results = this.Invoke("Translate", new object[] {
                        translationMode,
                        textToTranslate});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TranslateAsync(TranslationMode translationMode, string textToTranslate) {
            this.TranslateAsync(translationMode, textToTranslate, null);
        }
        
        /// <remarks/>
        public void TranslateAsync(TranslationMode translationMode, string textToTranslate, object userState) {
            if ((this.TranslateOperationCompleted == null)) {
                this.TranslateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTranslateOperationCompleted);
            }
            this.InvokeAsync("Translate", new object[] {
                        translationMode,
                        textToTranslate}, this.TranslateOperationCompleted, userState);
        }
        
        private void OnTranslateOperationCompleted(object arg) {
            if ((this.TranslateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TranslateCompleted(this, new TranslateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://zeta-software.de/TranslationWebService")]
    public partial class TranslationMode {
        
        private string objectIDField;
        
        private string visualNameENField;
        
        private string visualNameDEField;
        
        /// <remarks/>
        public string ObjectID {
            get {
                return this.objectIDField;
            }
            set {
                this.objectIDField = value;
            }
        }
        
        /// <remarks/>
        public string VisualNameEN {
            get {
                return this.visualNameENField;
            }
            set {
                this.visualNameENField = value;
            }
        }
        
        /// <remarks/>
        public string VisualNameDE {
            get {
                return this.visualNameDEField;
            }
            set {
                this.visualNameDEField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void GetAllTranslationModesCompletedEventHandler(object sender, GetAllTranslationModesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllTranslationModesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllTranslationModesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TranslationMode[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TranslationMode[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void GetTranslationModeByObjectIDCompletedEventHandler(object sender, GetTranslationModeByObjectIDCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTranslationModeByObjectIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTranslationModeByObjectIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public TranslationMode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((TranslationMode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void TranslateCompletedEventHandler(object sender, TranslateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TranslateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TranslateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591