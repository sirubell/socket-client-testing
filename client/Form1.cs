using System.Net.Sockets;
using System.Text;

namespace client
{
    public partial class formgame : Form
    {
        TcpClient? client = null;
        string dir = "";
        
        public formgame()
        {
            InitializeComponent();
            Thread get = new Thread(recieve_data);
            get.Start();
            Thread set = new Thread(talkToServer);
            set.Start();

            KeyDown += Form_KeyDown!;
            KeyUp += Form_KeyUp!;
        }

        private bool Connect(String server)
        {
            try
            {
                Int32 port = 12345;
                client = new TcpClient(server, port);
                return true;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
                return false;
            }
        }

        private void talkToServer()
        {
            while (true)
            {
                try
                {
                    Byte[] data = Encoding.ASCII.GetBytes(dir);
                    client!.GetStream().Write(data, 0, data.Length);
                }
                catch (Exception)
                {

                }

                DateTime now = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while ((DateTime.Now - now).TotalMilliseconds < 10);
            }
        }

        private void recieve_data()
        {
            while (true)
            {
                try
                {
                    NetworkStream stream = client!.GetStream();

                    Byte[] data = new Byte[256];
                    String responseData = String.Empty;

                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = Encoding.ASCII.GetString(data, 0, bytes);

                }
                catch (Exception)
                {

                }
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    dir = "2";
                    break;

                case Keys.Right:
                case Keys.D:
                    dir = "3";
                    break;
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.A || e.KeyCode == Keys.D)
                dir = "1";
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!this.Connect("127.0.0.1"))
            {
                this.Close();
            }
        }

        private void Form_Closing(object sender, EventArgs e)
        {
            if (this.client != null)
            {
                this.client.Close();
            }
        }
    }
}