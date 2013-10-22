﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18051
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComConClient.MessageService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MessageService.IServerFunctions", CallbackContract=typeof(ComConClient.MessageService.IServerFunctionsCallback))]
    public interface IServerFunctions {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/ConnectToServer", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToServerResponse")]
        void ConnectToServer(string pName, string pPassword);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/DisconnectFromServer", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromServerResponse")]
        void DisconnectFromServer();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/Send", ReplyAction="http://tempuri.org/IServerFunctions/SendResponse")]
        void Send(ComCon.Shared.Classes.ChatMessage cm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/ConnectToChannel", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToChannelResponse")]
        void ConnectToChannel();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/DisconnectFromChannel", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromChannelResponse")]
        void DisconnectFromChannel();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerFunctionsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServerFunctions/ShowMessage")]
        void ShowMessage(string pMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerFunctionsChannel : ComConClient.MessageService.IServerFunctions, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerFunctionsClient : System.ServiceModel.DuplexClientBase<ComConClient.MessageService.IServerFunctions>, ComConClient.MessageService.IServerFunctions {
        
        public ServerFunctionsClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServerFunctionsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServerFunctionsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerFunctionsClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerFunctionsClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ConnectToServer(string pName, string pPassword) {
            base.Channel.ConnectToServer(pName, pPassword);
        }
        
        public void DisconnectFromServer() {
            base.Channel.DisconnectFromServer();
        }
        
        public void Send(ComCon.Shared.Classes.ChatMessage cm) {
            base.Channel.Send(cm);
        }
        
        public void ConnectToChannel() {
            base.Channel.ConnectToChannel();
        }
        
        public void DisconnectFromChannel() {
            base.Channel.DisconnectFromChannel();
        }
    }
}