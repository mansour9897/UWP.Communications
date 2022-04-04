using System;

namespace Communications
{
    public interface ICommunication
    {
        
        bool IsConnected { get; }
        Action<object, string> MessageReceived { get; set; }

        bool Connect();
        void Write(string data);
        string Read();

        void ChangeSetting(ICommunicationSetting setting);

    }
}