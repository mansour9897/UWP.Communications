using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.SerialCommunication;


namespace Communications
{
    public class SerialComminucation : ICommunication
    {
        //private readonly SerialDevice _port;

        //delegate void MessageReceivedHandler(object sender, string message);
        //event MessageReceivedHandler MessageReceived;
        public SerialComminucation()
        {
            //var ports = SerialDevice.GetPortNames();
            //_port = new SerialPort();
            //if (ports.Length > 0)
            //    _port.PortName = ports[0];
            //_port.BaudRate = 115200;

            //Thread trd = new Thread(backWork);
            //trd.IsBackground = true;
            //trd.Start();
        }
        public SerialComminucation(string portName, int buad)
        {
            //_port = new SerialPort(portName, buad)
            //{
            //    ReadTimeout = 1000,
            //    WriteTimeout = 1000
            //};

            ////_port.DataReceived += new SerialDataReceivedEventHandler(_port_DataReceived);

            //Thread trd = new Thread(backWork);
            //trd.IsBackground = true;
            //trd.Start();
        }

        //private void _port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    string msg = Read();
        //    MessageReceived?.Invoke(this, msg);
        //}

        private async void backWork()
        {
            while (true)
            {
                string msg = await Read();
                MessageReceived?.Invoke(this, msg);
            }
        }
        //public bool IsConnected => _port.IsOpen;

        public Action<object, string> MessageReceived { get; set; }

        public bool IsConnected => throw new NotImplementedException();

        public bool Connect()
        {
            //if (_port.IsOpen) return true;

            try
            {
                //_port.Open();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
            }
        }

        public async Task<string> Read()
        {
            string res = "";
            //if (_port.IsOpen == false)
            //{
            //    if (!Connect())
            //    {
            //        return "";
            //    }
            //}
            try
            {
                //return _port.ReadLine().Trim();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //return "";
            }
            finally
            {
                await Task.Delay(1);
            }

            return res;
        }

        public void Write(string data)
        {
            //if (_port.IsOpen == false)
            //{
            //    if (!Connect()) return;
            //}

            //_port.Write(data);

        }

        public void ChangeSetting(ICommunicationSetting setting)
        {
            try
            {
                SerialSetting st = (SerialSetting)setting;
                //_port.Close();
                //_port.BaudRate = st.Baudrate;
                //_port.PortName = st.PortName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}