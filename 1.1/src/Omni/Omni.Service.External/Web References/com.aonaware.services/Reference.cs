﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3074
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3074.
// 
#pragma warning disable 1591

namespace Omni.Service.External.com.aonaware.services {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DictServiceSoap", Namespace="http://services.aonaware.com/webservices/")]
    public partial class DictService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ServerInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback DictionaryListOperationCompleted;
        
        private System.Threading.SendOrPostCallback DictionaryListExtendedOperationCompleted;
        
        private System.Threading.SendOrPostCallback DictionaryInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback DefineOperationCompleted;
        
        private System.Threading.SendOrPostCallback DefineInDictOperationCompleted;
        
        private System.Threading.SendOrPostCallback StrategyListOperationCompleted;
        
        private System.Threading.SendOrPostCallback MatchOperationCompleted;
        
        private System.Threading.SendOrPostCallback MatchInDictOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DictService() {
            this.Url = global::Omni.Service.External.Properties.Settings.Default.Omni_Service_External_com_aonaware_services_DictService;
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
        public event ServerInfoCompletedEventHandler ServerInfoCompleted;
        
        /// <remarks/>
        public event DictionaryListCompletedEventHandler DictionaryListCompleted;
        
        /// <remarks/>
        public event DictionaryListExtendedCompletedEventHandler DictionaryListExtendedCompleted;
        
        /// <remarks/>
        public event DictionaryInfoCompletedEventHandler DictionaryInfoCompleted;
        
        /// <remarks/>
        public event DefineCompletedEventHandler DefineCompleted;
        
        /// <remarks/>
        public event DefineInDictCompletedEventHandler DefineInDictCompleted;
        
        /// <remarks/>
        public event StrategyListCompletedEventHandler StrategyListCompleted;
        
        /// <remarks/>
        public event MatchCompletedEventHandler MatchCompleted;
        
        /// <remarks/>
        public event MatchInDictCompletedEventHandler MatchInDictCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/ServerInfo", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ServerInfo() {
            object[] results = this.Invoke("ServerInfo", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ServerInfoAsync() {
            this.ServerInfoAsync(null);
        }
        
        /// <remarks/>
        public void ServerInfoAsync(object userState) {
            if ((this.ServerInfoOperationCompleted == null)) {
                this.ServerInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnServerInfoOperationCompleted);
            }
            this.InvokeAsync("ServerInfo", new object[0], this.ServerInfoOperationCompleted, userState);
        }
        
        private void OnServerInfoOperationCompleted(object arg) {
            if ((this.ServerInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ServerInfoCompleted(this, new ServerInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/DictionaryList", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Dictionary[] DictionaryList() {
            object[] results = this.Invoke("DictionaryList", new object[0]);
            return ((Dictionary[])(results[0]));
        }
        
        /// <remarks/>
        public void DictionaryListAsync() {
            this.DictionaryListAsync(null);
        }
        
        /// <remarks/>
        public void DictionaryListAsync(object userState) {
            if ((this.DictionaryListOperationCompleted == null)) {
                this.DictionaryListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDictionaryListOperationCompleted);
            }
            this.InvokeAsync("DictionaryList", new object[0], this.DictionaryListOperationCompleted, userState);
        }
        
        private void OnDictionaryListOperationCompleted(object arg) {
            if ((this.DictionaryListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DictionaryListCompleted(this, new DictionaryListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/DictionaryListExtended", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Dictionary[] DictionaryListExtended() {
            object[] results = this.Invoke("DictionaryListExtended", new object[0]);
            return ((Dictionary[])(results[0]));
        }
        
        /// <remarks/>
        public void DictionaryListExtendedAsync() {
            this.DictionaryListExtendedAsync(null);
        }
        
        /// <remarks/>
        public void DictionaryListExtendedAsync(object userState) {
            if ((this.DictionaryListExtendedOperationCompleted == null)) {
                this.DictionaryListExtendedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDictionaryListExtendedOperationCompleted);
            }
            this.InvokeAsync("DictionaryListExtended", new object[0], this.DictionaryListExtendedOperationCompleted, userState);
        }
        
        private void OnDictionaryListExtendedOperationCompleted(object arg) {
            if ((this.DictionaryListExtendedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DictionaryListExtendedCompleted(this, new DictionaryListExtendedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/DictionaryInfo", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DictionaryInfo(string dictId) {
            object[] results = this.Invoke("DictionaryInfo", new object[] {
                        dictId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void DictionaryInfoAsync(string dictId) {
            this.DictionaryInfoAsync(dictId, null);
        }
        
        /// <remarks/>
        public void DictionaryInfoAsync(string dictId, object userState) {
            if ((this.DictionaryInfoOperationCompleted == null)) {
                this.DictionaryInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDictionaryInfoOperationCompleted);
            }
            this.InvokeAsync("DictionaryInfo", new object[] {
                        dictId}, this.DictionaryInfoOperationCompleted, userState);
        }
        
        private void OnDictionaryInfoOperationCompleted(object arg) {
            if ((this.DictionaryInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DictionaryInfoCompleted(this, new DictionaryInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/Define", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WordDefinition Define(string word) {
            object[] results = this.Invoke("Define", new object[] {
                        word});
            return ((WordDefinition)(results[0]));
        }
        
        /// <remarks/>
        public void DefineAsync(string word) {
            this.DefineAsync(word, null);
        }
        
        /// <remarks/>
        public void DefineAsync(string word, object userState) {
            if ((this.DefineOperationCompleted == null)) {
                this.DefineOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDefineOperationCompleted);
            }
            this.InvokeAsync("Define", new object[] {
                        word}, this.DefineOperationCompleted, userState);
        }
        
        private void OnDefineOperationCompleted(object arg) {
            if ((this.DefineCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DefineCompleted(this, new DefineCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/DefineInDict", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public WordDefinition DefineInDict(string dictId, string word) {
            object[] results = this.Invoke("DefineInDict", new object[] {
                        dictId,
                        word});
            return ((WordDefinition)(results[0]));
        }
        
        /// <remarks/>
        public void DefineInDictAsync(string dictId, string word) {
            this.DefineInDictAsync(dictId, word, null);
        }
        
        /// <remarks/>
        public void DefineInDictAsync(string dictId, string word, object userState) {
            if ((this.DefineInDictOperationCompleted == null)) {
                this.DefineInDictOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDefineInDictOperationCompleted);
            }
            this.InvokeAsync("DefineInDict", new object[] {
                        dictId,
                        word}, this.DefineInDictOperationCompleted, userState);
        }
        
        private void OnDefineInDictOperationCompleted(object arg) {
            if ((this.DefineInDictCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DefineInDictCompleted(this, new DefineInDictCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/StrategyList", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Strategy[] StrategyList() {
            object[] results = this.Invoke("StrategyList", new object[0]);
            return ((Strategy[])(results[0]));
        }
        
        /// <remarks/>
        public void StrategyListAsync() {
            this.StrategyListAsync(null);
        }
        
        /// <remarks/>
        public void StrategyListAsync(object userState) {
            if ((this.StrategyListOperationCompleted == null)) {
                this.StrategyListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnStrategyListOperationCompleted);
            }
            this.InvokeAsync("StrategyList", new object[0], this.StrategyListOperationCompleted, userState);
        }
        
        private void OnStrategyListOperationCompleted(object arg) {
            if ((this.StrategyListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.StrategyListCompleted(this, new StrategyListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/Match", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DictionaryWord[] Match(string word, string strategy) {
            object[] results = this.Invoke("Match", new object[] {
                        word,
                        strategy});
            return ((DictionaryWord[])(results[0]));
        }
        
        /// <remarks/>
        public void MatchAsync(string word, string strategy) {
            this.MatchAsync(word, strategy, null);
        }
        
        /// <remarks/>
        public void MatchAsync(string word, string strategy, object userState) {
            if ((this.MatchOperationCompleted == null)) {
                this.MatchOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMatchOperationCompleted);
            }
            this.InvokeAsync("Match", new object[] {
                        word,
                        strategy}, this.MatchOperationCompleted, userState);
        }
        
        private void OnMatchOperationCompleted(object arg) {
            if ((this.MatchCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MatchCompleted(this, new MatchCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://services.aonaware.com/webservices/MatchInDict", RequestNamespace="http://services.aonaware.com/webservices/", ResponseNamespace="http://services.aonaware.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public DictionaryWord[] MatchInDict(string dictId, string word, string strategy) {
            object[] results = this.Invoke("MatchInDict", new object[] {
                        dictId,
                        word,
                        strategy});
            return ((DictionaryWord[])(results[0]));
        }
        
        /// <remarks/>
        public void MatchInDictAsync(string dictId, string word, string strategy) {
            this.MatchInDictAsync(dictId, word, strategy, null);
        }
        
        /// <remarks/>
        public void MatchInDictAsync(string dictId, string word, string strategy, object userState) {
            if ((this.MatchInDictOperationCompleted == null)) {
                this.MatchInDictOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMatchInDictOperationCompleted);
            }
            this.InvokeAsync("MatchInDict", new object[] {
                        dictId,
                        word,
                        strategy}, this.MatchInDictOperationCompleted, userState);
        }
        
        private void OnMatchInDictOperationCompleted(object arg) {
            if ((this.MatchInDictCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MatchInDictCompleted(this, new MatchInDictCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Dictionary {
        
        private string idField;
        
        private string nameField;
        
        /// <remarks/>
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class DictionaryWord {
        
        private string dictionaryIdField;
        
        private string wordField;
        
        /// <remarks/>
        public string DictionaryId {
            get {
                return this.dictionaryIdField;
            }
            set {
                this.dictionaryIdField = value;
            }
        }
        
        /// <remarks/>
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Strategy {
        
        private string idField;
        
        private string descriptionField;
        
        /// <remarks/>
        public string Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class Definition {
        
        private string wordField;
        
        private Dictionary dictionaryField;
        
        private string wordDefinitionField;
        
        /// <remarks/>
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
            }
        }
        
        /// <remarks/>
        public Dictionary Dictionary {
            get {
                return this.dictionaryField;
            }
            set {
                this.dictionaryField = value;
            }
        }
        
        /// <remarks/>
        public string WordDefinition {
            get {
                return this.wordDefinitionField;
            }
            set {
                this.wordDefinitionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://services.aonaware.com/webservices/")]
    public partial class WordDefinition {
        
        private string wordField;
        
        private Definition[] definitionsField;
        
        /// <remarks/>
        public string Word {
            get {
                return this.wordField;
            }
            set {
                this.wordField = value;
            }
        }
        
        /// <remarks/>
        public Definition[] Definitions {
            get {
                return this.definitionsField;
            }
            set {
                this.definitionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void ServerInfoCompletedEventHandler(object sender, ServerInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ServerInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ServerInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DictionaryListCompletedEventHandler(object sender, DictionaryListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DictionaryListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DictionaryListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Dictionary[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Dictionary[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DictionaryListExtendedCompletedEventHandler(object sender, DictionaryListExtendedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DictionaryListExtendedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DictionaryListExtendedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Dictionary[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Dictionary[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DictionaryInfoCompletedEventHandler(object sender, DictionaryInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DictionaryInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DictionaryInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DefineCompletedEventHandler(object sender, DefineCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DefineCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DefineCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WordDefinition Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WordDefinition)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void DefineInDictCompletedEventHandler(object sender, DefineInDictCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DefineInDictCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DefineInDictCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WordDefinition Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WordDefinition)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void StrategyListCompletedEventHandler(object sender, StrategyListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class StrategyListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal StrategyListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Strategy[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Strategy[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void MatchCompletedEventHandler(object sender, MatchCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MatchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MatchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DictionaryWord[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DictionaryWord[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    public delegate void MatchInDictCompletedEventHandler(object sender, MatchInDictCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MatchInDictCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MatchInDictCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public DictionaryWord[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DictionaryWord[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591