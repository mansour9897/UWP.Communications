using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Communications
{
    public class NetSocket : ICommunication
    {
        

        private readonly string _portNumber;
        private readonly HostName _hostIp;
        private static StreamSocket _client;

        DataWriter writer;
        DataReader reader;

        private bool connected;
        public bool IsConnected => connected;
        public Action<object, string> MessageReceived { get; set;}

        public NetSocket()
        {
            _portNumber = "8080";
            _hostIp = new HostName("192.168.1.240");
            _client = new StreamSocket();
        }

        public NetSocket(string hostIp, int portNumber)
        {
            _portNumber = portNumber.ToString();
            _hostIp = new HostName(hostIp);
            _client = new StreamSocket();
        }

        public void ChangeSetting(ICommunicationSetting setting)
        {
            throw new NotImplementedException();
        }

        public bool Connect()
        {
            if (IsConnected) return IsConnected;

            try
            {
                _client.ConnectAsync(_hostIp, _portNumber).AsTask().Wait();
                writer = new DataWriter(_client.OutputStream);
                reader = new DataReader(_client.InputStream);
                connected = true;
                Debug.WriteLine($"Connecting to {_hostIp.DisplayName}:{_portNumber} successfully!");
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Connection Failed!");
                Debug.WriteLine(ex.Message);
            }

            return IsConnected;
        }

        public string Read()
        {
            StringBuilder strBuilder;
            string tr = "";
            try
            {
                strBuilder = new StringBuilder();

                reader.InputStreamOptions = InputStreamOptions.Partial;

                var stringHeader = reader.LoadAsync(255);
                //tr = reader.ReadString(1);
                while (reader.UnconsumedBufferLength > 0)
                {
                    tr += reader.ReadString(1);
                    if (tr.Contains("\n")) break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Read Socket Stream Error!!!!");
                Debug.WriteLine(ex.Message);
            }
            return tr;
        }

        public void Write(string data)
        {
            if (IsConnected == false) Connect();
            try
            {
                if (reader.UnconsumedBufferLength > 0)
                {
                    string str = reader.ReadString(reader.UnconsumedBufferLength);
                }
                string sendData = data;
                writer.WriteString(sendData);
                writer.StoreAsync().AsTask().Wait();
            }
            catch (Exception exception)
            {
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                }
            }

            Task.Delay(5).Wait();
        }
    }
}