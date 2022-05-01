using System;
using System.Threading.Tasks;

namespace Communications
{
    public interface ICommunication
    {
        
        bool IsConnected { get; }
        Action<object, string> MessageReceived { get; set; }

        bool Connect();
        void Write(string data);
        Task<string> Read();

        void ChangeSetting(ICommunicationSetting setting);

    }
}