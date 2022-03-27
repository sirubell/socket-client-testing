using System.Net.Sockets;
using System.Text;

namespace client
{
    public partial class formgame : Form
    {
        TcpClient client = null;

        string dir = "";
        int num_player = 0;
        List<PictureBox> blocks = new List<PictureBox>();
        List<PictureBox> players = new List<PictureBox>();
        public formgame()
        {
            InitializeComponent();
            

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
            if (client == null) return;
            while (client.Connected)
            {
                try
                {
                    Byte[] data = Encoding.ASCII.GetBytes(dir);
                    client.GetStream().Write(data, 0, dir.Length);
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
            if (client == null)
            {
                return;
            }
            while (client.Connected)
            {
                String responseData = String.Empty;
                Byte[] data = new Byte[256];
                Int32 bytes;

                try
                {
                    NetworkStream stream = client.GetStream();

                    while ((bytes = stream.Read(data, 0, data.Length)) > 0) {
                        responseData += Encoding.ASCII.GetString(data, 0, bytes);
                    }
                    // richTextBox1.Text = responseData;
                    
                }
                catch (Exception)
                {

                }

                //responseData = "1,2,3,4,5,klafj|1,2,3,4,1|32|lkfjdkls\njkfdakj\n";

                string[] first = responseData.Split('\n');

                string cur_player = first[0];
                string[] all_players = first[1].Split('|');
                string[] all_blocks = first[2].Split('|');

                List<int> player_x = new List<int>();
                List<int> player_y = new List<int>();
                List<int> player_w = new List<int>();
                List<int> player_h = new List<int>();
                List<int> player_heart = new List<int>();
                List<string> player_name = new List<string>();

                foreach (string p in all_players)
                {
                    var temp = p.Split(',');
                    player_x.Add(int.Parse(temp[0]));
                    player_y.Add(int.Parse(temp[1]));
                    player_w.Add(int.Parse(temp[2]));
                    player_h.Add(int.Parse(temp[3]));
                    player_heart.Add(int.Parse(temp[4]));
                    player_name.Add(temp[5]);
                }

                List<int> block_x = new List<int>();
                List<int> block_y = new List<int>();
                List<int> block_w = new List<int>();
                List<int> block_h = new List<int>();
                List<int> block_type = new List<int>();

                foreach (string b in all_blocks)
                {
                    var temp = b.Split(',');
                    block_x.Add(int.Parse(temp[0]));
                    block_y.Add(int.Parse(temp[1]));
                    block_w.Add(int.Parse(temp[2]));
                    block_h.Add(int.Parse(temp[3]));
                    block_type.Add(int.Parse(temp[4]));
                }

                foreach (var player in players)
                {
                    player.Visible = false;
                }

                foreach (var player in players)
                {
                    if(player.Name == cur_player)
                    {
                        for (int i = 0; i < player_name.Count(); i++)
                        {
                            PictureBox? temp = players.Find(x => x.Name == player_name[i]);
                            if (temp != null)
                            {
                                temp.Size = new Size(player_x[i], player_y[i]);
                                temp.Location = new Point(player_h[i], player_w[i]);
                                temp.Visible = true;
                                temp.BackColor = Color.White;
                                player.Parent = temp;
                            }
                            else
                            {
                                temp = new PictureBox();
                                temp.Name = player_name[i];
                                temp.Size = new Size(player_x[i], player_y[i]);
                                temp.Location = new Point(player_h[i], player_w[i]);
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
                    blocks[i].Location = new Point(block_x[i], block_y[i]);
                    blocks[i].Size = new Size(block_h[i], block_w[i]);
                    blocks[i].Visible = true;
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

        private void buttonStartGame_Click(object sender, EventArgs e)
        {
            Thread get = new Thread(recieve_data);
            get.Start();
            Thread set = new Thread(talkToServer);
            set.Start();

            buttonStartGame.Visible = false;
        }
    }
}