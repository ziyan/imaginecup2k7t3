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

namespace Omni.Web.org.omniproject {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WebServiceSoap", Namespace="http://omniproject.org/")]
    public partial class WebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InitializeOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserCaptchaOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserRegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserLoginOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserIsLoggedInOperationCompleted;
        
        private System.Threading.SendOrPostCallback DictionaryLookupOperationCompleted;
        
        private System.Threading.SendOrPostCallback TranslationLookupOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService() {
            this.Url = global::Omni.Web.Properties.Settings.Default.Omni_Web_org_omniproject_WebService;
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
        public event InitializeCompletedEventHandler InitializeCompleted;
        
        /// <remarks/>
        public event UserCaptchaCompletedEventHandler UserCaptchaCompleted;
        
        /// <remarks/>
        public event UserRegisterCompletedEventHandler UserRegisterCompleted;
        
        /// <remarks/>
        public event UserLoginCompletedEventHandler UserLoginCompleted;
        
        /// <remarks/>
        public event UserIsLoggedInCompletedEventHandler UserIsLoggedInCompleted;
        
        /// <remarks/>
        public event DictionaryLookupCompletedEventHandler DictionaryLookupCompleted;
        
        /// <remarks/>
        public event TranslationLookupCompletedEventHandler TranslationLookupCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/Initialize", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Initialize() {
            this.Invoke("Initialize", new object[0]);
        }
        
        /// <remarks/>
        public void InitializeAsync() {
            this.InitializeAsync(null);
        }
        
        /// <remarks/>
        public void InitializeAsync(object userState) {
            if ((this.InitializeOperationCompleted == null)) {
                this.InitializeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInitializeOperationCompleted);
            }
            this.InvokeAsync("Initialize", new object[0], this.InitializeOperationCompleted, userState);
        }
        
        private void OnInitializeOperationCompleted(object arg) {
            if ((this.InitializeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InitializeCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserCaptcha", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] UserCaptcha(int width, int height, string bgColor, string frontColor) {
            object[] results = this.Invoke("UserCaptcha", new object[] {
                        width,
                        height,
                        bgColor,
                        frontColor});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void UserCaptchaAsync(int width, int height, string bgColor, string frontColor) {
            this.UserCaptchaAsync(width, height, bgColor, frontColor, null);
        }
        
        /// <remarks/>
        public void UserCaptchaAsync(int width, int height, string bgColor, string frontColor, object userState) {
            if ((this.UserCaptchaOperationCompleted == null)) {
                this.UserCaptchaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserCaptchaOperationCompleted);
            }
            this.InvokeAsync("UserCaptcha", new object[] {
                        width,
                        height,
                        bgColor,
                        frontColor}, this.UserCaptchaOperationCompleted, userState);
        }
        
        private void OnUserCaptchaOperationCompleted(object arg) {
            if ((this.UserCaptchaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserCaptchaCompleted(this, new UserCaptchaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserRegister", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UserRegister(string username, string md5password, string email, string name, string description, string captcha) {
            object[] results = this.Invoke("UserRegister", new object[] {
                        username,
                        md5password,
                        email,
                        name,
                        description,
                        captcha});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UserRegisterAsync(string username, string md5password, string email, string name, string description, string captcha) {
            this.UserRegisterAsync(username, md5password, email, name, description, captcha, null);
        }
        
        /// <remarks/>
        public void UserRegisterAsync(string username, string md5password, string email, string name, string description, string captcha, object userState) {
            if ((this.UserRegisterOperationCompleted == null)) {
                this.UserRegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserRegisterOperationCompleted);
            }
            this.InvokeAsync("UserRegister", new object[] {
                        username,
                        md5password,
                        email,
                        name,
                        description,
                        captcha}, this.UserRegisterOperationCompleted, userState);
        }
        
        private void OnUserRegisterOperationCompleted(object arg) {
            if ((this.UserRegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserRegisterCompleted(this, new UserRegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserLogin", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UserLogin(string email, string md5password, string captcha) {
            object[] results = this.Invoke("UserLogin", new object[] {
                        email,
                        md5password,
                        captcha});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UserLoginAsync(string email, string md5password, string captcha) {
            this.UserLoginAsync(email, md5password, captcha, null);
        }
        
        /// <remarks/>
        public void UserLoginAsync(string email, string md5password, string captcha, object userState) {
            if ((this.UserLoginOperationCompleted == null)) {
                this.UserLoginOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserLoginOperationCompleted);
            }
            this.InvokeAsync("UserLogin", new object[] {
                        email,
                        md5password,
                        captcha}, this.UserLoginOperationCompleted, userState);
        }
        
        private void OnUserLoginOperationCompleted(object arg) {
            if ((this.UserLoginCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserLoginCompleted(this, new UserLoginCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserIsLoggedIn", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool UserIsLoggedIn() {
            object[] results = this.Invoke("UserIsLoggedIn", new object[0]);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void UserIsLoggedInAsync() {
            this.UserIsLoggedInAsync(null);
        }
        
        /// <remarks/>
        public void UserIsLoggedInAsync(object userState) {
            if ((this.UserIsLoggedInOperationCompleted == null)) {
                this.UserIsLoggedInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserIsLoggedInOperationCompleted);
            }
            this.InvokeAsync("UserIsLoggedIn", new object[0], this.UserIsLoggedInOperationCompleted, userState);
        }
        
        private void OnUserIsLoggedInOperationCompleted(object arg) {
            if ((this.UserIsLoggedInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserIsLoggedInCompleted(this, new UserIsLoggedInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/DictionaryLookup", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DictionaryLookup(int LanguageID, string SearchWord) {
            object[] results = this.Invoke("DictionaryLookup", new object[] {
                        LanguageID,
                        SearchWord});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void DictionaryLookupAsync(int LanguageID, string SearchWord) {
            this.DictionaryLookupAsync(LanguageID, SearchWord, null);
        }
        
        /// <remarks/>
        public void DictionaryLookupAsync(int LanguageID, string SearchWord, object userState) {
            if ((this.DictionaryLookupOperationCompleted == null)) {
                this.DictionaryLookupOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDictionaryLookupOperationCompleted);
            }
            this.InvokeAsync("DictionaryLookup", new object[] {
                        LanguageID,
                        SearchWord}, this.DictionaryLookupOperationCompleted, userState);
        }
        
        private void OnDictionaryLookupOperationCompleted(object arg) {
            if ((this.DictionaryLookupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DictionaryLookupCompleted(this, new DictionaryLookupCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/TranslationLookup", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TranslationLookup(int OrigLanguage, int SearchLanguage, string SearchWord) {
            object[] results = this.Invoke("TranslationLookup", new object[] {
                        OrigLanguage,
                        SearchLanguage,
                        SearchWord});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TranslationLookupAsync(int OrigLanguage, int SearchLanguage, string SearchWord) {
            this.TranslationLookupAsync(OrigLanguage, SearchLanguage, SearchWord, null);
        }
        
        /// <remarks/>
        public void TranslationLookupAsync(int OrigLanguage, int SearchLanguage, string SearchWord, object userState) {
            if ((this.TranslationLookupOperationCompleted == null)) {
                this.TranslationLookupOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTranslationLookupOperationCompleted);
            }
            this.InvokeAsync("TranslationLookup", new object[] {
                        OrigLanguage,
                        SearchLanguage,
                        SearchWord}, this.TranslationLookupOperationCompleted, userState);
        }
        
        private void OnTranslationLookupOperationCompleted(object arg) {
            if ((this.TranslationLookupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TranslationLookupCompleted(this, new TranslationLookupCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void InitializeCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void UserCaptchaCompletedEventHandler(object sender, UserCaptchaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserCaptchaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserCaptchaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void UserRegisterCompletedEventHandler(object sender, UserRegisterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserRegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserRegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void UserLoginCompletedEventHandler(object sender, UserLoginCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserLoginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserLoginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void UserIsLoggedInCompletedEventHandler(object sender, UserIsLoggedInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserIsLoggedInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserIsLoggedInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void DictionaryLookupCompletedEventHandler(object sender, DictionaryLookupCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DictionaryLookupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DictionaryLookupCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void TranslationLookupCompletedEventHandler(object sender, TranslationLookupCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TranslationLookupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TranslationLookupCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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