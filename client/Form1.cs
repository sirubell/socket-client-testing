using System.Net.Sockets;
using System.Text;

namespace client
{
    public partial class formgame : Form
    {
        TcpClient? client = null;

        string dir = "";
        int num_player = 0;
        List<PictureBox> blocks = new List<PictureBox>();
        List<PictureBox> players = new List<PictureBox>();
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

        private void create()
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Visible = true;
            pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            blocks.Add(pictureBox);

            for (int i = 0; i < 4; i++)
            {
                pictureBox = new PictureBox();
                pictureBox.Visible = false;
                pictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                blocks.Add(pictureBox);
            }
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
                    //esponseData = Encoding.ASCII.GetString(data, 0, bytes);
                    responseData = "1,2,3,4,5,klafj|1,2,3,4,1|32|lkfjdkls\njkfdakj\n";
                    string[] first = responseData.Split('\n');
                    string[] second = first[0].Split('|');
                    string[] platform_strs = second[2].Split(',');
                    int platform_x = int.Parse(platform_strs[0]);
                    int platform_y = int.Parse(platform_strs[1]);
                    int platform_w = int.Parse(platform_strs[2]);
                    int platform_h = int.Parse(platform_strs[3]);
                    int platform_type = int.Parse(platform_strs[4]);
                    string[] player = second[1].Split(',');
                    int player_x = int.Parse(player[0]);
                    int player_y = int.Parse(player[1]);
                    int player_w = int.Parse(player[2]);
                    int player_h = int.Parse(player[3]);
                    int player_heart = int.Parse(player[4]);
                    string player_name = new string(player[5]);
                    Console.WriteLine(player_x);
                }
                catch (Exception)
                {

                }

                foreach (var player in players)
                {
                    player.Visible = false;
                }

                int x = 0, y = 0;
                var f = "";
                var cur = "";
                foreach (var player in players)
                {
                    if(player.Name == cur)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            PictureBox? temp = players.Find(x => x.Name == f);
                            if (temp != null)
                            {
                                temp.Size = new Size(x, y);
                                temp.Location = new Point(x, y);
                                temp.Visible = true;
                                temp.BackColor = Color.White;
                                player.Parent = temp;
                            }
                            else
                            {
                                temp = new PictureBox();
                                temp.Name = f;
                                temp.Size = new Size(x, y);
                                temp.Location = new Point(x, y);
                                temp.Visible = true;
                                temp.BackColor = Color.White;
                                player.Parent = temp;

                                players.Add(temp);
                            }
                        }

                        player.BackColor = Color.Black;
                        break;
                    }
                }
                
                for (int i = 0; i < blocks.Count; i++)
                {
                    blocks[i].Location = new Point(x, y);
                    blocks[i].Size = new Size(x, y);
                }

                DateTime now = DateTime.Now;
                do
                {
                    Application.DoEvents();
                } while ((DateTime.Now - now).TotalMilliseconds < 10);
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