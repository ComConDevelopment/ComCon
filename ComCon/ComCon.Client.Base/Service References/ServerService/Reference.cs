﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18047
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComCon.Client.Base.ServerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatMessage", Namespace="http://schemas.datacontract.org/2004/07/ComCon.Shared.Classes")]
    [System.SerializableAttribute()]
    public partial class ChatMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeStampField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ComCon.Client.Base.ServerService.ChatUser UserField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime TimeStamp {
            get {
                return this.TimeStampField;
            }
            set {
                if ((this.TimeStampField.Equals(value) != true)) {
                    this.TimeStampField = value;
                    this.RaisePropertyChanged("TimeStamp");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ComCon.Client.Base.ServerService.ChatUser User {
            get {
                return this.UserField;
            }
            set {
                if ((object.ReferenceEquals(this.UserField, value) != true)) {
                    this.UserField = value;
                    this.RaisePropertyChanged("User");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatUser", Namespace="http://schemas.datacontract.org/2004/07/ComCon.Shared.Classes")]
    [System.SerializableAttribute()]
    public partial class ChatUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsAdminField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsVisibleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsAdmin {
            get {
                return this.IsAdminField;
            }
            set {
                if ((this.IsAdminField.Equals(value) != true)) {
                    this.IsAdminField = value;
                    this.RaisePropertyChanged("IsAdmin");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsVisible {
            get {
                return this.IsVisibleField;
            }
            set {
                if ((this.IsVisibleField.Equals(value) != true)) {
                    this.IsVisibleField = value;
                    this.RaisePropertyChanged("IsVisible");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServerService.IServerFunctions", CallbackContract=typeof(ComCon.Client.Base.ServerService.IServerFunctionsCallback))]
    public interface IServerFunctions {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/ConnectToServer", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToServerResponse")]
        void ConnectToServer(string pName);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/ConnectToServer", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToServerResponse")]
        System.IAsyncResult BeginConnectToServer(string pName, System.AsyncCallback callback, object asyncState);
        
        void EndConnectToServer(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/DisconnectFromServer", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromServerResponse")]
        void DisconnectFromServer();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/DisconnectFromServer", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromServerResponse")]
        System.IAsyncResult BeginDisconnectFromServer(System.AsyncCallback callback, object asyncState);
        
        void EndDisconnectFromServer(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/Send", ReplyAction="http://tempuri.org/IServerFunctions/SendResponse")]
        void Send(ComCon.Client.Base.ServerService.ChatMessage cm);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/Send", ReplyAction="http://tempuri.org/IServerFunctions/SendResponse")]
        System.IAsyncResult BeginSend(ComCon.Client.Base.ServerService.ChatMessage cm, System.AsyncCallback callback, object asyncState);
        
        void EndSend(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/ConnectToChannel", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToChannelResponse")]
        void ConnectToChannel();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/ConnectToChannel", ReplyAction="http://tempuri.org/IServerFunctions/ConnectToChannelResponse")]
        System.IAsyncResult BeginConnectToChannel(System.AsyncCallback callback, object asyncState);
        
        void EndConnectToChannel(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/DisconnectFromChannel", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromChannelResponse")]
        void DisconnectFromChannel();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/DisconnectFromChannel", ReplyAction="http://tempuri.org/IServerFunctions/DisconnectFromChannelResponse")]
        System.IAsyncResult BeginDisconnectFromChannel(System.AsyncCallback callback, object asyncState);
        
        void EndDisconnectFromChannel(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/GetChannels", ReplyAction="http://tempuri.org/IServerFunctions/GetChannelsResponse")]
        string[] GetChannels();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/GetChannels", ReplyAction="http://tempuri.org/IServerFunctions/GetChannelsResponse")]
        System.IAsyncResult BeginGetChannels(System.AsyncCallback callback, object asyncState);
        
        string[] EndGetChannels(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/GetUser", ReplyAction="http://tempuri.org/IServerFunctions/GetUserResponse")]
        ComCon.Client.Base.ServerService.ChatUser GetUser(string pName);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/GetUser", ReplyAction="http://tempuri.org/IServerFunctions/GetUserResponse")]
        System.IAsyncResult BeginGetUser(string pName, System.AsyncCallback callback, object asyncState);
        
        ComCon.Client.Base.ServerService.ChatUser EndGetUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServerFunctions/GetUsers", ReplyAction="http://tempuri.org/IServerFunctions/GetUsersResponse")]
        ComCon.Client.Base.ServerService.ChatUser[] GetUsers();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/GetUsers", ReplyAction="http://tempuri.org/IServerFunctions/GetUsersResponse")]
        System.IAsyncResult BeginGetUsers(System.AsyncCallback callback, object asyncState);
        
        ComCon.Client.Base.ServerService.ChatUser[] EndGetUsers(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerFunctionsCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServerFunctions/ShowMessage")]
        void ShowMessage(ComCon.Client.Base.ServerService.ChatMessage cm);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/ShowMessage")]
        System.IAsyncResult BeginShowMessage(ComCon.Client.Base.ServerService.ChatMessage cm, System.AsyncCallback callback, object asyncState);
        
        void EndShowMessage(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServerFunctions/UpdateUserList")]
        void UpdateUserList();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, AsyncPattern=true, Action="http://tempuri.org/IServerFunctions/UpdateUserList")]
        System.IAsyncResult BeginUpdateUserList(System.AsyncCallback callback, object asyncState);
        
        void EndUpdateUserList(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerFunctionsChannel : ComCon.Client.Base.ServerService.IServerFunctions, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetChannelsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetChannelsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUserCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUserCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ComCon.Client.Base.ServerService.ChatUser Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ComCon.Client.Base.ServerService.ChatUser)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUsersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUsersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public ComCon.Client.Base.ServerService.ChatUser[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((ComCon.Client.Base.ServerService.ChatUser[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerFunctionsClient : System.ServiceModel.DuplexClientBase<ComCon.Client.Base.ServerService.IServerFunctions>, ComCon.Client.Base.ServerService.IServerFunctions {
        
        private BeginOperationDelegate onBeginConnectToServerDelegate;
        
        private EndOperationDelegate onEndConnectToServerDelegate;
        
        private System.Threading.SendOrPostCallback onConnectToServerCompletedDelegate;
        
        private BeginOperationDelegate onBeginDisconnectFromServerDelegate;
        
        private EndOperationDelegate onEndDisconnectFromServerDelegate;
        
        private System.Threading.SendOrPostCallback onDisconnectFromServerCompletedDelegate;
        
        private BeginOperationDelegate onBeginSendDelegate;
        
        private EndOperationDelegate onEndSendDelegate;
        
        private System.Threading.SendOrPostCallback onSendCompletedDelegate;
        
        private BeginOperationDelegate onBeginConnectToChannelDelegate;
        
        private EndOperationDelegate onEndConnectToChannelDelegate;
        
        private System.Threading.SendOrPostCallback onConnectToChannelCompletedDelegate;
        
        private BeginOperationDelegate onBeginDisconnectFromChannelDelegate;
        
        private EndOperationDelegate onEndDisconnectFromChannelDelegate;
        
        private System.Threading.SendOrPostCallback onDisconnectFromChannelCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetChannelsDelegate;
        
        private EndOperationDelegate onEndGetChannelsDelegate;
        
        private System.Threading.SendOrPostCallback onGetChannelsCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUserDelegate;
        
        private EndOperationDelegate onEndGetUserDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUsersDelegate;
        
        private EndOperationDelegate onEndGetUsersDelegate;
        
        private System.Threading.SendOrPostCallback onGetUsersCompletedDelegate;
        
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
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ConnectToServerCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DisconnectFromServerCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> SendCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> ConnectToChannelCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> DisconnectFromChannelCompleted;
        
        public event System.EventHandler<GetChannelsCompletedEventArgs> GetChannelsCompleted;
        
        public event System.EventHandler<GetUserCompletedEventArgs> GetUserCompleted;
        
        public event System.EventHandler<GetUsersCompletedEventArgs> GetUsersCompleted;
        
        public void ConnectToServer(string pName) {
            base.Channel.ConnectToServer(pName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginConnectToServer(string pName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConnectToServer(pName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndConnectToServer(System.IAsyncResult result) {
            base.Channel.EndConnectToServer(result);
        }
        
        private System.IAsyncResult OnBeginConnectToServer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string pName = ((string)(inValues[0]));
            return this.BeginConnectToServer(pName, callback, asyncState);
        }
        
        private object[] OnEndConnectToServer(System.IAsyncResult result) {
            this.EndConnectToServer(result);
            return null;
        }
        
        private void OnConnectToServerCompleted(object state) {
            if ((this.ConnectToServerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConnectToServerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConnectToServerAsync(string pName) {
            this.ConnectToServerAsync(pName, null);
        }
        
        public void ConnectToServerAsync(string pName, object userState) {
            if ((this.onBeginConnectToServerDelegate == null)) {
                this.onBeginConnectToServerDelegate = new BeginOperationDelegate(this.OnBeginConnectToServer);
            }
            if ((this.onEndConnectToServerDelegate == null)) {
                this.onEndConnectToServerDelegate = new EndOperationDelegate(this.OnEndConnectToServer);
            }
            if ((this.onConnectToServerCompletedDelegate == null)) {
                this.onConnectToServerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConnectToServerCompleted);
            }
            base.InvokeAsync(this.onBeginConnectToServerDelegate, new object[] {
                        pName}, this.onEndConnectToServerDelegate, this.onConnectToServerCompletedDelegate, userState);
        }
        
        public void DisconnectFromServer() {
            base.Channel.DisconnectFromServer();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDisconnectFromServer(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDisconnectFromServer(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndDisconnectFromServer(System.IAsyncResult result) {
            base.Channel.EndDisconnectFromServer(result);
        }
        
        private System.IAsyncResult OnBeginDisconnectFromServer(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginDisconnectFromServer(callback, asyncState);
        }
        
        private object[] OnEndDisconnectFromServer(System.IAsyncResult result) {
            this.EndDisconnectFromServer(result);
            return null;
        }
        
        private void OnDisconnectFromServerCompleted(object state) {
            if ((this.DisconnectFromServerCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DisconnectFromServerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DisconnectFromServerAsync() {
            this.DisconnectFromServerAsync(null);
        }
        
        public void DisconnectFromServerAsync(object userState) {
            if ((this.onBeginDisconnectFromServerDelegate == null)) {
                this.onBeginDisconnectFromServerDelegate = new BeginOperationDelegate(this.OnBeginDisconnectFromServer);
            }
            if ((this.onEndDisconnectFromServerDelegate == null)) {
                this.onEndDisconnectFromServerDelegate = new EndOperationDelegate(this.OnEndDisconnectFromServer);
            }
            if ((this.onDisconnectFromServerCompletedDelegate == null)) {
                this.onDisconnectFromServerCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDisconnectFromServerCompleted);
            }
            base.InvokeAsync(this.onBeginDisconnectFromServerDelegate, null, this.onEndDisconnectFromServerDelegate, this.onDisconnectFromServerCompletedDelegate, userState);
        }
        
        public void Send(ComCon.Client.Base.ServerService.ChatMessage cm) {
            base.Channel.Send(cm);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginSend(ComCon.Client.Base.ServerService.ChatMessage cm, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginSend(cm, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndSend(System.IAsyncResult result) {
            base.Channel.EndSend(result);
        }
        
        private System.IAsyncResult OnBeginSend(object[] inValues, System.AsyncCallback callback, object asyncState) {
            ComCon.Client.Base.ServerService.ChatMessage cm = ((ComCon.Client.Base.ServerService.ChatMessage)(inValues[0]));
            return this.BeginSend(cm, callback, asyncState);
        }
        
        private object[] OnEndSend(System.IAsyncResult result) {
            this.EndSend(result);
            return null;
        }
        
        private void OnSendCompleted(object state) {
            if ((this.SendCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.SendCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void SendAsync(ComCon.Client.Base.ServerService.ChatMessage cm) {
            this.SendAsync(cm, null);
        }
        
        public void SendAsync(ComCon.Client.Base.ServerService.ChatMessage cm, object userState) {
            if ((this.onBeginSendDelegate == null)) {
                this.onBeginSendDelegate = new BeginOperationDelegate(this.OnBeginSend);
            }
            if ((this.onEndSendDelegate == null)) {
                this.onEndSendDelegate = new EndOperationDelegate(this.OnEndSend);
            }
            if ((this.onSendCompletedDelegate == null)) {
                this.onSendCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnSendCompleted);
            }
            base.InvokeAsync(this.onBeginSendDelegate, new object[] {
                        cm}, this.onEndSendDelegate, this.onSendCompletedDelegate, userState);
        }
        
        public void ConnectToChannel() {
            base.Channel.ConnectToChannel();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginConnectToChannel(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginConnectToChannel(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndConnectToChannel(System.IAsyncResult result) {
            base.Channel.EndConnectToChannel(result);
        }
        
        private System.IAsyncResult OnBeginConnectToChannel(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginConnectToChannel(callback, asyncState);
        }
        
        private object[] OnEndConnectToChannel(System.IAsyncResult result) {
            this.EndConnectToChannel(result);
            return null;
        }
        
        private void OnConnectToChannelCompleted(object state) {
            if ((this.ConnectToChannelCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ConnectToChannelCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ConnectToChannelAsync() {
            this.ConnectToChannelAsync(null);
        }
        
        public void ConnectToChannelAsync(object userState) {
            if ((this.onBeginConnectToChannelDelegate == null)) {
                this.onBeginConnectToChannelDelegate = new BeginOperationDelegate(this.OnBeginConnectToChannel);
            }
            if ((this.onEndConnectToChannelDelegate == null)) {
                this.onEndConnectToChannelDelegate = new EndOperationDelegate(this.OnEndConnectToChannel);
            }
            if ((this.onConnectToChannelCompletedDelegate == null)) {
                this.onConnectToChannelCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnConnectToChannelCompleted);
            }
            base.InvokeAsync(this.onBeginConnectToChannelDelegate, null, this.onEndConnectToChannelDelegate, this.onConnectToChannelCompletedDelegate, userState);
        }
        
        public void DisconnectFromChannel() {
            base.Channel.DisconnectFromChannel();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginDisconnectFromChannel(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDisconnectFromChannel(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public void EndDisconnectFromChannel(System.IAsyncResult result) {
            base.Channel.EndDisconnectFromChannel(result);
        }
        
        private System.IAsyncResult OnBeginDisconnectFromChannel(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginDisconnectFromChannel(callback, asyncState);
        }
        
        private object[] OnEndDisconnectFromChannel(System.IAsyncResult result) {
            this.EndDisconnectFromChannel(result);
            return null;
        }
        
        private void OnDisconnectFromChannelCompleted(object state) {
            if ((this.DisconnectFromChannelCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DisconnectFromChannelCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DisconnectFromChannelAsync() {
            this.DisconnectFromChannelAsync(null);
        }
        
        public void DisconnectFromChannelAsync(object userState) {
            if ((this.onBeginDisconnectFromChannelDelegate == null)) {
                this.onBeginDisconnectFromChannelDelegate = new BeginOperationDelegate(this.OnBeginDisconnectFromChannel);
            }
            if ((this.onEndDisconnectFromChannelDelegate == null)) {
                this.onEndDisconnectFromChannelDelegate = new EndOperationDelegate(this.OnEndDisconnectFromChannel);
            }
            if ((this.onDisconnectFromChannelCompletedDelegate == null)) {
                this.onDisconnectFromChannelCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDisconnectFromChannelCompleted);
            }
            base.InvokeAsync(this.onBeginDisconnectFromChannelDelegate, null, this.onEndDisconnectFromChannelDelegate, this.onDisconnectFromChannelCompletedDelegate, userState);
        }
        
        public string[] GetChannels() {
            return base.Channel.GetChannels();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetChannels(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetChannels(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndGetChannels(System.IAsyncResult result) {
            return base.Channel.EndGetChannels(result);
        }
        
        private System.IAsyncResult OnBeginGetChannels(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetChannels(callback, asyncState);
        }
        
        private object[] OnEndGetChannels(System.IAsyncResult result) {
            string[] retVal = this.EndGetChannels(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetChannelsCompleted(object state) {
            if ((this.GetChannelsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetChannelsCompleted(this, new GetChannelsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetChannelsAsync() {
            this.GetChannelsAsync(null);
        }
        
        public void GetChannelsAsync(object userState) {
            if ((this.onBeginGetChannelsDelegate == null)) {
                this.onBeginGetChannelsDelegate = new BeginOperationDelegate(this.OnBeginGetChannels);
            }
            if ((this.onEndGetChannelsDelegate == null)) {
                this.onEndGetChannelsDelegate = new EndOperationDelegate(this.OnEndGetChannels);
            }
            if ((this.onGetChannelsCompletedDelegate == null)) {
                this.onGetChannelsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetChannelsCompleted);
            }
            base.InvokeAsync(this.onBeginGetChannelsDelegate, null, this.onEndGetChannelsDelegate, this.onGetChannelsCompletedDelegate, userState);
        }
        
        public ComCon.Client.Base.ServerService.ChatUser GetUser(string pName) {
            return base.Channel.GetUser(pName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetUser(string pName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUser(pName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public ComCon.Client.Base.ServerService.ChatUser EndGetUser(System.IAsyncResult result) {
            return base.Channel.EndGetUser(result);
        }
        
        private System.IAsyncResult OnBeginGetUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string pName = ((string)(inValues[0]));
            return this.BeginGetUser(pName, callback, asyncState);
        }
        
        private object[] OnEndGetUser(System.IAsyncResult result) {
            ComCon.Client.Base.ServerService.ChatUser retVal = this.EndGetUser(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUserCompleted(object state) {
            if ((this.GetUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserCompleted(this, new GetUserCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserAsync(string pName) {
            this.GetUserAsync(pName, null);
        }
        
        public void GetUserAsync(string pName, object userState) {
            if ((this.onBeginGetUserDelegate == null)) {
                this.onBeginGetUserDelegate = new BeginOperationDelegate(this.OnBeginGetUser);
            }
            if ((this.onEndGetUserDelegate == null)) {
                this.onEndGetUserDelegate = new EndOperationDelegate(this.OnEndGetUser);
            }
            if ((this.onGetUserCompletedDelegate == null)) {
                this.onGetUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserDelegate, new object[] {
                        pName}, this.onEndGetUserDelegate, this.onGetUserCompletedDelegate, userState);
        }
        
        public ComCon.Client.Base.ServerService.ChatUser[] GetUsers() {
            return base.Channel.GetUsers();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BeginGetUsers(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUsers(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public ComCon.Client.Base.ServerService.ChatUser[] EndGetUsers(System.IAsyncResult result) {
            return base.Channel.EndGetUsers(result);
        }
        
        private System.IAsyncResult OnBeginGetUsers(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BeginGetUsers(callback, asyncState);
        }
        
        private object[] OnEndGetUsers(System.IAsyncResult result) {
            ComCon.Client.Base.ServerService.ChatUser[] retVal = this.EndGetUsers(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUsersCompleted(object state) {
            if ((this.GetUsersCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUsersCompleted(this, new GetUsersCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUsersAsync() {
            this.GetUsersAsync(null);
        }
        
        public void GetUsersAsync(object userState) {
            if ((this.onBeginGetUsersDelegate == null)) {
                this.onBeginGetUsersDelegate = new BeginOperationDelegate(this.OnBeginGetUsers);
            }
            if ((this.onEndGetUsersDelegate == null)) {
                this.onEndGetUsersDelegate = new EndOperationDelegate(this.OnEndGetUsers);
            }
            if ((this.onGetUsersCompletedDelegate == null)) {
                this.onGetUsersCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUsersCompleted);
            }
            base.InvokeAsync(this.onBeginGetUsersDelegate, null, this.onEndGetUsersDelegate, this.onGetUsersCompletedDelegate, userState);
        }
    }
}
