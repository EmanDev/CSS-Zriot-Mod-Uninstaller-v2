using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using System.Diagnostics;

namespace material_css_zr_mod_uninstaller
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        public Form1()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private string pathX;
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize Read Only Mode = True * Property Added *
            // Initialize Control Functions
            materialRaisedButton3.Enabled = false;
            materialRaisedButton4.Enabled = false;
            materialRaisedButton5.Enabled = false;
            materialRaisedButton6.Enabled = false;
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            materialSingleLineTextField1.Text = folderBrowserDialog1.SelectedPath;
            string a = materialSingleLineTextField1.Text;
            if (a == "")
                materialRaisedButton3.Enabled = false;
            else
                materialRaisedButton3.Enabled = true;
        }

        private void materialRaisedButton3_Click(object sender, EventArgs e)
        {
            pathX = materialSingleLineTextField1.Text;
            materialSingleLineTextField2.Text = pathX + @"\steamcmd.exe";
            materialSingleLineTextField3.Text = pathX + @"\steamapps\common\Counter-Strike Source Dedicated Server\cstrike\addons";
            materialSingleLineTextField4.Text = pathX + @"\steamapps\common\Counter-Strike Source Dedicated Server\cstrike\cfg\sourcemod";
            materialSingleLineTextField5.Text = pathX + @"\steamapps\common\Counter-Strike Source Dedicated Server\cstrike\materials";
            materialSingleLineTextField6.Text = pathX + @"\steamapps\common\Counter-Strike Source Dedicated Server\cstrike\models";
            materialSingleLineTextField7.Text = pathX + @"\steamapps\common\Counter-Strike Source Dedicated Server\cstrike\sound";
            materialRaisedButton1.Enabled = false;
            materialRaisedButton4.Enabled = true;
            materialRaisedButton5.Enabled = true;
            materialRaisedButton6.Enabled = true;

        }

        private void materialRaisedButton4_Click(object sender, EventArgs e)
        {
            materialRaisedButton1.Enabled = true;
            materialRaisedButton3.Enabled = false;
            materialRaisedButton4.Enabled = false;
            materialRaisedButton5.Enabled = false;
            materialRaisedButton6.Enabled = false;
            materialSingleLineTextField1.Text = "";
            materialSingleLineTextField2.Text = "";
            materialSingleLineTextField3.Text = "";
            materialSingleLineTextField4.Text = "";
            materialSingleLineTextField5.Text = "";
            materialSingleLineTextField6.Text = "";
            materialSingleLineTextField7.Text = "";

        }

        private void materialRaisedButton5_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do you want to uninstall Zombie Riot Mod on your Server? This will delete selected folders.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                Directory.Delete(materialSingleLineTextField3.Text, true);
                Directory.Delete(materialSingleLineTextField4.Text, true);
                Directory.Delete(materialSingleLineTextField5.Text, true);
                Directory.Delete(materialSingleLineTextField6.Text, true);
                Directory.Delete(materialSingleLineTextField7.Text, true);
            }
            else
            {
                // empty value
            }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            string message = "Browse the folder with steamCmd.exe file in it.";
            string title = "Function";
            MessageBox.Show(message, title);
        }

        private void materialRaisedButton6_Click(object sender, EventArgs e)
        {
            // Run steamcmd with following arguemnts
            ProcessStartInfo steamcmd = new ProcessStartInfo();
            steamcmd.FileName = materialSingleLineTextField2.Text;
            steamcmd.Arguments = "+login anonymous +app_update 232330 validate +quit";
            steamcmd.UseShellExecute = true;
            Process proc = Process.Start(steamcmd);
        }

        private void materialRaisedButton7_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }

        private void materialRaisedButton13_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/EmanDev/zombie-riot-mod-uninstaller");
        }

        private void materialRaisedButton12_Click(object sender, EventArgs e)
        {
            Process.Start("www.paypal.me/marcaida");
        }

        private void materialRaisedButton11_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/EmanDev/zombie-riot-mod-uninstaller/issues");
        }

        private void materialRaisedButton10_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.microsoft.com/en-ph/download/details.aspx?id=17851");
        }

        private void materialRaisedButton9_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.microsoft.com/en-ph/download/details.aspx?id=21");
        }

        private int colorSchemeIndex;
        private void materialRaisedButton8_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2) colorSchemeIndex = 0;

            //These are just color schemes to be used by default
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }
    }
}
