using System.Net.Sockets;
using System.Text;

namespace client
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        public Form1()
        {
            InitializeComponent();
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

        private string talkToServer(string message)
        {
            Byte[] data = Encoding.ASCII.GetBytes(message);
            
            try
            {
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                data = new Byte[256];
                String responseData = String.Empty;

                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);

                return responseData;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty)
            {
                textBox2.Text = this.talkToServer(this.textBox1.Text);
            }
            else
            {
                textBox2.Text = String.Empty;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!this.Connect("127.0.0.1"))
            {
                this.Close();
            }
        }
        private void Form1_Closing(object sender, EventArgs e)
        {
            if (this.client != null)
            {
                this.client.Close();
            }
            
        }

    }
}