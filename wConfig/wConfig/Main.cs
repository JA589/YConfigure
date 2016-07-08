using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wConfig
{
    public partial class Main : Form
    {
        private STRUCT_FILE_CONFIG Configure;

        public Main()
        {
            InitializeComponent();
            Initialize();
        }

        #region Initialize Fields
        private void Initialize()
        {
            if (Exists())
            {
                View();
            }
            else
            {
                Enabled = false;

                if (MessageBox.Show("Could not find the file.  To create a new settings file?", "YConfigure 1.0", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Configure = new STRUCT_FILE_CONFIG();

                    ENCDEC.Encrypt("Config.bin", Configure);

                    View();

                    Enabled = true;
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        #endregion

        #region Check file exists
        private bool Exists()
        {
            if (File.Exists("Config.bin"))
            {
                return true;
            }

            return false;
        }
        #endregion
        #region View informations of file
        private void View()
        {
            if (ENCDEC.Decrypt<STRUCT_FILE_CONFIG>("Config.bin", ref Configure))
            { 
                Version.Text =      Configure.VERSION.ToString();

                Resource.Text =     Configure.RES.ToString();
                Animation.Text =    Configure.ANIMATION.ToString();

                Server.Text =       Configure.SERVER.ToString();

                Bright.Text =       Configure.BRIGHT.ToString();
                Cursor.Text =       Configure.CURSOR.ToString();

                Sound.Text =        Configure.SOUND.ToString();
                Music.Text =        Configure.MUSIC.ToString();

                Window.Text =       Configure.WINDOW.ToString();
                Classic.Text =      Configure.CLASSIC.ToString();

                Demo.Text =         Configure.DEMO.ToString();
                CamRotate.Text =    Configure.CAMERAROTATE.ToString();

                DXT.Text =          Configure.DXT.ToString();
                KeyType.Text =      Configure.KEYTYPE.ToString();
                CamView.Text =      Configure.CAMERAVIEW.ToString();

                Status.Text = "The file has been successfully read.";
                Status.ForeColor = Color.Green;
            }
            else
            {
                Status.Text = "An error occurred while trying to read the file.";
                Status.ForeColor = Color.Red;
            }
        }
        #endregion

        #region Save
        private void TNSave_Click(object sender, EventArgs e)
        {
            Configure.VERSION = Int16.Parse(Version.Text);

            Configure.RES = Int16.Parse(Resource.Text);
            Configure.ANIMATION = Int16.Parse(Animation.Text);

            Configure.SERVER = Int16.Parse(Server.Text);

            Configure.BRIGHT = Int16.Parse(Bright.Text);
            Configure.CURSOR = Int16.Parse(Cursor.Text);

            Configure.SOUND = Int16.Parse(Sound.Text);
            Configure.MUSIC = Int16.Parse(Music.Text);

            Configure.WINDOW = Int16.Parse(Window.Text);
            Configure.CLASSIC = Int16.Parse(Classic.Text);

            Configure.DEMO = Int16.Parse(Demo.Text);
            Configure.CAMERAROTATE = Int16.Parse(CamRotate.Text);

            Configure.DXT = Int16.Parse(DXT.Text);
            Configure.KEYTYPE = Int16.Parse(KeyType.Text);
            Configure.CAMERAVIEW = Int16.Parse(CamView.Text);

            ENCDEC.Encrypt("Config.bin", Configure);

            MessageBox.Show("The file was saved successfully.", "YConfigure 1.0", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        #endregion
        #region Help
        private void TNAbout_Click(object sender, EventArgs e)
        {
            String Message = "This program was developed to configure game settings With Your Destiny.\n\nDeveloped by: Jonatan Acahú (Yescool-BR)\nVersion 1.0\n\nCredits to: Woz Farias, Nando, Douglas (Rikimaru), Luis Gustavo (AgateOwz), André Oliveira (ptr0x), Victor, Erick Mota, Eric Santos, Moe~ (the structure), and the whole community of WYD.";

            MessageBox.Show(Message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
