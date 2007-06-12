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
        
        private System.Threading.SendOrPostCallback UserAuthorizeByUsernameOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserIsLoggedInOperationCompleted;
        
        private System.Threading.SendOrPostCallback UserLogoutOperationCompleted;
        
        private System.Threading.SendOrPostCallback DictionaryLookupOperationCompleted;
        
        private System.Threading.SendOrPostCallback TranslationLookupOperationCompleted;
        
        private System.Threading.SendOrPostCallback LanguageListOperationCompleted;
        
        private System.Threading.SendOrPostCallback LanuageNameQueryByIdOperationCompleted;
        
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
        public event UserAuthorizeByUsernameCompletedEventHandler UserAuthorizeByUsernameCompleted;
        
        /// <remarks/>
        public event UserIsLoggedInCompletedEventHandler UserIsLoggedInCompleted;
        
        /// <remarks/>
        public event UserLogoutCompletedEventHandler UserLogoutCompleted;
        
        /// <remarks/>
        public event DictionaryLookupCompletedEventHandler DictionaryLookupCompleted;
        
        /// <remarks/>
        public event TranslationLookupCompletedEventHandler TranslationLookupCompleted;
        
        /// <remarks/>
        public event LanguageListCompletedEventHandler LanguageListCompleted;
        
        /// <remarks/>
        public event LanuageNameQueryByIdCompletedEventHandler LanuageNameQueryByIdCompleted;
        
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserAuthorizeByUsername", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public User UserAuthorizeByUsername(string username, string md5password) {
            object[] results = this.Invoke("UserAuthorizeByUsername", new object[] {
                        username,
                        md5password});
            return ((User)(results[0]));
        }
        
        /// <remarks/>
        public void UserAuthorizeByUsernameAsync(string username, string md5password) {
            this.UserAuthorizeByUsernameAsync(username, md5password, null);
        }
        
        /// <remarks/>
        public void UserAuthorizeByUsernameAsync(string username, string md5password, object userState) {
            if ((this.UserAuthorizeByUsernameOperationCompleted == null)) {
                this.UserAuthorizeByUsernameOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserAuthorizeByUsernameOperationCompleted);
            }
            this.InvokeAsync("UserAuthorizeByUsername", new object[] {
                        username,
                        md5password}, this.UserAuthorizeByUsernameOperationCompleted, userState);
        }
        
        private void OnUserAuthorizeByUsernameOperationCompleted(object arg) {
            if ((this.UserAuthorizeByUsernameCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserAuthorizeByUsernameCompleted(this, new UserAuthorizeByUsernameCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/UserLogout", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UserLogout() {
            this.Invoke("UserLogout", new object[0]);
        }
        
        /// <remarks/>
        public void UserLogoutAsync() {
            this.UserLogoutAsync(null);
        }
        
        /// <remarks/>
        public void UserLogoutAsync(object userState) {
            if ((this.UserLogoutOperationCompleted == null)) {
                this.UserLogoutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUserLogoutOperationCompleted);
            }
            this.InvokeAsync("UserLogout", new object[0], this.UserLogoutOperationCompleted, userState);
        }
        
        private void OnUserLogoutOperationCompleted(object arg) {
            if ((this.UserLogoutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UserLogoutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/LanguageList", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Language[] LanguageList() {
            object[] results = this.Invoke("LanguageList", new object[0]);
            return ((Language[])(results[0]));
        }
        
        /// <remarks/>
        public void LanguageListAsync() {
            this.LanguageListAsync(null);
        }
        
        /// <remarks/>
        public void LanguageListAsync(object userState) {
            if ((this.LanguageListOperationCompleted == null)) {
                this.LanguageListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLanguageListOperationCompleted);
            }
            this.InvokeAsync("LanguageList", new object[0], this.LanguageListOperationCompleted, userState);
        }
        
        private void OnLanguageListOperationCompleted(object arg) {
            if ((this.LanguageListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LanguageListCompleted(this, new LanguageListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://omniproject.org/LanuageNameQueryById", RequestNamespace="http://omniproject.org/", ResponseNamespace="http://omniproject.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string LanuageNameQueryById(int lang_id, int dst_lang_id) {
            object[] results = this.Invoke("LanuageNameQueryById", new object[] {
                        lang_id,
                        dst_lang_id});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LanuageNameQueryByIdAsync(int lang_id, int dst_lang_id) {
            this.LanuageNameQueryByIdAsync(lang_id, dst_lang_id, null);
        }
        
        /// <remarks/>
        public void LanuageNameQueryByIdAsync(int lang_id, int dst_lang_id, object userState) {
            if ((this.LanuageNameQueryByIdOperationCompleted == null)) {
                this.LanuageNameQueryByIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLanuageNameQueryByIdOperationCompleted);
            }
            this.InvokeAsync("LanuageNameQueryById", new object[] {
                        lang_id,
                        dst_lang_id}, this.LanuageNameQueryByIdOperationCompleted, userState);
        }
        
        private void OnLanuageNameQueryByIdOperationCompleted(object arg) {
            if ((this.LanuageNameQueryByIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LanuageNameQueryByIdCompleted(this, new LanuageNameQueryByIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://omniproject.org/")]
    public partial class User {
        
        private string nameField;
        
        private string usernameField;
        
        private string emailField;
        
        private int idField;
        
        private string descriptionField;
        
        private System.DateTime reg_dateField;
        
        private System.DateTime log_dateField;
        
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public string username {
            get {
                return this.usernameField;
            }
            set {
                this.usernameField = value;
            }
        }
        
        /// <remarks/>
        public string email {
            get {
                return this.emailField;
            }
            set {
                this.emailField = value;
            }
        }
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime reg_date {
            get {
                return this.reg_dateField;
            }
            set {
                this.reg_dateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime log_date {
            get {
                return this.log_dateField;
            }
            set {
                this.log_dateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.312")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://omniproject.org/")]
    public partial class Language {
        
        private int idField;
        
        private string codeField;
        
        /// <remarks/>
        public int id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
            }
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
    public delegate void UserAuthorizeByUsernameCompletedEventHandler(object sender, UserAuthorizeByUsernameCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UserAuthorizeByUsernameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UserAuthorizeByUsernameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public User Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((User)(this.results[0]));
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
    public delegate void UserLogoutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void LanguageListCompletedEventHandler(object sender, LanguageListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LanguageListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LanguageListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Language[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Language[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    public delegate void LanuageNameQueryByIdCompletedEventHandler(object sender, LanuageNameQueryByIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.312")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LanuageNameQueryByIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LanuageNameQueryByIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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