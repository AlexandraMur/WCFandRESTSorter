﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFArrayGenerator.Reciever {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Reciever.IReciever")]
    public interface IReciever {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReciever/Recieve", ReplyAction="http://tempuri.org/IReciever/RecieveResponse")]
        void Recieve(int[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReciever/Recieve", ReplyAction="http://tempuri.org/IReciever/RecieveResponse")]
        System.Threading.Tasks.Task RecieveAsync(int[] data);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReciever/GetSortedArray", ReplyAction="http://tempuri.org/IReciever/GetSortedArrayResponse")]
        int[] GetSortedArray();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IReciever/GetSortedArray", ReplyAction="http://tempuri.org/IReciever/GetSortedArrayResponse")]
        System.Threading.Tasks.Task<int[]> GetSortedArrayAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IRecieverChannel : WCFArrayGenerator.Reciever.IReciever, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class RecieverClient : System.ServiceModel.ClientBase<WCFArrayGenerator.Reciever.IReciever>, WCFArrayGenerator.Reciever.IReciever {
        
        public RecieverClient() {
        }
        
        public RecieverClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public RecieverClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecieverClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public RecieverClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void Recieve(int[] data) {
            base.Channel.Recieve(data);
        }
        
        public System.Threading.Tasks.Task RecieveAsync(int[] data) {
            return base.Channel.RecieveAsync(data);
        }
        
        public int[] GetSortedArray() {
            return base.Channel.GetSortedArray();
        }
        
        public System.Threading.Tasks.Task<int[]> GetSortedArrayAsync() {
            return base.Channel.GetSortedArrayAsync();
        }
    }
}
