﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Internal.Tools.TeamMate.Platform.CodeBox.Wiki
{


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://CodeBox/services/WikiService/v1.0", ConfigurationName="CodeBox.Wiki.WikiServiceSoap")]
    public interface WikiServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetPageTitles", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPageTitles(string projectName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetPageTitles", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPageTitlesAsync(string projectName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetLatestPageContent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetLatestPageContent(string projectName, string pageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetLatestPageContent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetLatestPageContentAsync(string projectName, string pageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetPageContent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetPageContent(string projectName, string pageTitle, int pageVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/GetPageContent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPageContentAsync(string projectName, string pageTitle, int pageVersion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/AddNewPageVersion", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet AddNewPageVersion(string projectName, string pageTitle, string source, string parentPageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/AddNewPageVersion", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AddNewPageVersionAsync(string projectName, string pageTitle, string source, string parentPageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/AddNewPage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet AddNewPage(string projectName, string pageTitle, string source, string parentPageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/AddNewPage", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> AddNewPageAsync(string projectName, string pageTitle, string source, string parentPageTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/Ping", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool Ping();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://CodeBox/services/WikiService/v1.0/Ping", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> PingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WikiServiceSoapChannel : Microsoft.Internal.Tools.TeamMate.Platform.CodeBox.Wiki.WikiServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WikiServiceSoapClient : System.ServiceModel.ClientBase<Microsoft.Internal.Tools.TeamMate.Platform.CodeBox.Wiki.WikiServiceSoap>, Microsoft.Internal.Tools.TeamMate.Platform.CodeBox.Wiki.WikiServiceSoap {
        
        public WikiServiceSoapClient() {
        }
        
        public WikiServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WikiServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WikiServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WikiServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetPageTitles(string projectName) {
            return base.Channel.GetPageTitles(projectName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPageTitlesAsync(string projectName) {
            return base.Channel.GetPageTitlesAsync(projectName);
        }
        
        public System.Data.DataSet GetLatestPageContent(string projectName, string pageTitle) {
            return base.Channel.GetLatestPageContent(projectName, pageTitle);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetLatestPageContentAsync(string projectName, string pageTitle) {
            return base.Channel.GetLatestPageContentAsync(projectName, pageTitle);
        }
        
        public System.Data.DataSet GetPageContent(string projectName, string pageTitle, int pageVersion) {
            return base.Channel.GetPageContent(projectName, pageTitle, pageVersion);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPageContentAsync(string projectName, string pageTitle, int pageVersion) {
            return base.Channel.GetPageContentAsync(projectName, pageTitle, pageVersion);
        }
        
        public System.Data.DataSet AddNewPageVersion(string projectName, string pageTitle, string source, string parentPageTitle) {
            return base.Channel.AddNewPageVersion(projectName, pageTitle, source, parentPageTitle);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AddNewPageVersionAsync(string projectName, string pageTitle, string source, string parentPageTitle) {
            return base.Channel.AddNewPageVersionAsync(projectName, pageTitle, source, parentPageTitle);
        }
        
        public System.Data.DataSet AddNewPage(string projectName, string pageTitle, string source, string parentPageTitle) {
            return base.Channel.AddNewPage(projectName, pageTitle, source, parentPageTitle);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> AddNewPageAsync(string projectName, string pageTitle, string source, string parentPageTitle) {
            return base.Channel.AddNewPageAsync(projectName, pageTitle, source, parentPageTitle);
        }
        
        public bool Ping() {
            return base.Channel.Ping();
        }
        
        public System.Threading.Tasks.Task<bool> PingAsync() {
            return base.Channel.PingAsync();
        }
    }
}
