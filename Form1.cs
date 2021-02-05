using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows;
using PewPew.math;
using System.Windows;
using System.Media;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

using System.ComponentModel;

namespace SprayExternal
{
    public partial class Form1 : Form
    {




        public static int ShotsFired = 0;
        static Vector3 Angle;
        static Vector3 AimPunch;
        static Vector3 OldAngle;
        static IntPtr ClientDll, EngineDll;
        static IntPtr ServerDll;
        static IntPtr ClientState, LocalPlayer;

        public static string proccess = "csgo";
        public static int bClient, bEngine;

        public static float brightness = 0;
        public static int fired = 0;
        public static int delay = 0;


        public static bool? TriggerBot = false;
        public static bool? Bhop = false;
        public static bool? Glow_esp = false;
        public static bool? TriggerOn = true;
        public static bool? Chams = false;
        public static bool playerChams = false;
        public static bool? healthesp = false;
        public static bool? FOV = false, FOV2 = true;
        public static bool? RcsBool = false;
        public static bool? NoFlashBool = false;
        public static bool? RadarBool = false;
        public static bool? SkinChnagerbool = true;
        public static bool? NoHands = false;
        public static bool? AimbotBool = false;
        public static bool? HitShoud = false;

        public static VAMemory vam = new VAMemory(proccess);


        public static float r = 255, g, b;
        public static float r2, g2, b2 = 255;
        public static byte r3 = 255, g3, b3;
        public static byte r4, g4, b4 = 255;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public static float divide = 255;
        int stattrack;

        public static int gunid, gunid2;
        public static int skinid, skinid2;
        public static string gunname;
        public bool STATTRACK = false;

        public static int key, key2 = 16;
        public static bool extra = false, extra2 = false, extra3 = false, extra4 = false, extra5 = false;

        public static int FOVvalue = 90;
        public static int closest;
        public static int BoneId = 8;
        public static int AimbotFov = 10;
        public static int aimbotkey;
        public static int Smooth = 0;
        public static int LockType = 0;
        public static int mov, movX, movY;
        public static bool visible = true;

        public FormWindowState windowState { get; set; }
        public Form1()
        {

            InitializeComponent();
            checkBox11.TextAlign = ContentAlignment.MiddleCenter;
            checkBox8.TextAlign = ContentAlignment.MiddleCenter;
            checkBox6.TextAlign = ContentAlignment.MiddleCenter;
            checkBox5.TextAlign = ContentAlignment.MiddleCenter;
            checkBox4.TextAlign = ContentAlignment.MiddleCenter;
            checkBox3.TextAlign = ContentAlignment.MiddleCenter;
            checkBox13.TextAlign = ContentAlignment.MiddleCenter;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 1;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            
            Thread start = new Thread(Main);
            start.Start();

            

        }

        public static int fAttack;

        private void Main()
        {


           

            if (GetModuleAddy())
            {

                


                Memory.Initialize("csgo");

                key = Convert.ToInt32(textBox2.Text);
                var path2 = Path.Combine(Directory.GetCurrentDirectory(), @"Offsets.txt");
                string[] lines = File.ReadAllLines(path2);

                int z = 0;
                // Offset grabber
                foreach (string line in lines)
                {
                    z++;
                    if (z == 2)
                    {
                        Offsets.LocalPlayer = Convert.ToInt32(line, 16);
                        Console.Beep();
                    }
                    if (z == 4)
                    {
                        Offsets.Team = Convert.ToInt32(line, 16);
                    }
                    if (z == 6)
                    {
                        Offsets.EntityList = Convert.ToInt32(line, 16);
                    }
                    if (z == 8)
                    {
                        Offsets.Dormant = Convert.ToInt32(line, 16);
                    }
                    if (z == 10)
                    {
                        Offsets.GlowIndex = Convert.ToInt32(line, 16);
                    }
                    if (z == 12)
                    {
                        Offsets.GlowObject = Convert.ToInt32(line, 16);
                    }
                    if (z == 14)
                    {
                        Offsets.Health = Convert.ToInt32(line, 16);
                    }
                    if (z == 16)
                    {
                        Offsets.CrossHairId = Convert.ToInt32(line, 16);
                    }
                    if (z == 18)
                    {

                        Offsets.Attack = Convert.ToInt32(line, 16);
                    }
                    if (z == 20)
                    {

                        Offsets.flag = Convert.ToInt32(line, 16);
                    }
                    if (z == 22)
                    {

                        Offsets.forceJump = Convert.ToInt32(line, 16);


                    }
                    if (z == 24)
                    {
                        Offsets.FOV = Convert.ToInt32(line, 16);

                    }
                    if (z == 26)
                    {
                        Offsets.ISscoped = Convert.ToInt32(line, 16);

                    }
                    if (z == 28)
                    {
                        Offsets.clientstate = Convert.ToInt32(line, 16);
                    }
                    if (z == 30)
                    {
                        Offsets.ViewAngles = Convert.ToInt32(line, 16);
                    }
                    if (z == 32)
                    {
                        Offsets.ShotsFired = Convert.ToInt32(line, 16);
                    }
                    if (z == 34)
                    {
                        Offsets.aimPunchAngle = Convert.ToInt32(line, 16);
                    }
                    if (z == 36)
                    {
                        Offsets.viewpunchangle = Convert.ToInt32(line, 16);
                    }
                    if (z == 38)
                    {
                        Offsets.FlashDuration = Convert.ToInt32(line, 16);

                    }
                    if (z == 40)
                    {
                        Offsets.Spotted = Convert.ToInt32(line, 16);

                    }
                    if (z == 42)
                    {
                        Offsets.MyWeapons = Convert.ToInt32(line, 16);
                    }
                    if (z == 44)
                    {
                        Offsets.ItemDefinitionIndex = Convert.ToInt32(line, 16);
                    }
                    if (z == 46)
                    {
                        Offsets.FallBackPaintKit = Convert.ToInt32(line, 16);
                    }
                    if (z == 48)
                    {
                        Offsets.FallBackSeed = Convert.ToInt32(line, 16);
                    }
                    if (z == 50)
                    {
                        Offsets.FallBackWear = Convert.ToInt32(line, 16);
                    }
                    if (z == 52)
                    {
                        Offsets.FallBackStatTrak = Convert.ToInt32(line, 16);
                    }
                    if (z == 54)
                    {
                        Offsets.CustomName = Convert.ToInt32(line, 16);
                    }
                    if (z == 56)
                    {
                        Offsets.ItemIDHigh = Convert.ToInt32(line, 16);
                    }
                    if (z == 58)
                    {
                        Offsets.AccountID = Convert.ToInt32(line, 16);
                        
                    }
                    if (z == 60)
                    {
                        Offsets.OrifinalOwnerLow = Convert.ToInt32(line, 16);
                    }
                    if (z == 62)
                    {
                        Offsets.VecOrgin = Convert.ToInt32(line, 16);
                    }
                    if (z == 64)
                    {
                        Offsets.VecViewOffset = Convert.ToInt32(line, 16); ;
                    }
                    if (z == 66)
                    {
                        Offsets.BoneMatrix = Convert.ToInt32(line, 16);
                        
                    }
                    if (z == 68)
                    {
                        Offsets.ModelIndex = Convert.ToInt32(line, 16);
                    }
                    if (z == 70)
                    {
                        Offsets.DeltaTics = Convert.ToInt32(line, 16);
                    }
                    if (z == 72)
                    {
                        Offsets.HitsOnServer = Convert.ToInt32(line, 16);
                        Console.Beep();
                    }

                    fAttack = bClient + Offsets.Attack;
                    //intptr dlls
                    ClientDll = Memory.GetModuleBaseAddress("client.dll");

                    EngineDll = Memory.GetModuleBaseAddress("engine.dll");
                    ServerDll = Memory.GetModuleBaseAddress("server.dll");

                  
                    
                }








               
                while (true)
                {
                   
                    Thread.Sleep(50);

                 
                  

                    if (GetAsyncKeyState(35) != 0) // End
                    {
                        brightness = 0;
                        r3 = 255;
                        r4 = 255;
                        g3 = 255;
                        g4 = 255;
                        b3 = 255;
                        b4 = 255;

                        Console.Beep(350, 750);
                        Environment.Exit(0);
                    }

                    // activate threads
                    if (TriggerBot == true)
                    {
                        Thread triggerBotstart = new Thread(triggerbot);
                        triggerBotstart.Start();
                        TriggerBot = null;

                    }


                    if (Bhop == true)
                    {
                        Thread Bhopstart = new Thread(Bhopvoid);
                        Bhopstart.Start();
                        Bhop = null;


                    }



                    if (Glow_esp == true)
                    {
                        Thread startesp = new Thread(Glowesp);
                        startesp.Start();
                        Glow_esp = null;
                    }


                    if (Chams == true)
                    {
                        Thread startChams = new Thread(Chams1);
                        startChams.Start();
                        Chams = null;
                    }
                    if (FOV == true)
                    {
                        Thread StartFOV = new Thread(FOVgo);
                        StartFOV.Start();
                        FOV = null;
                    }
                    if (RcsBool == true)
                    {


                        new Thread(() => RCS()).Start();
                        RcsBool = null;

                    }
                    if (NoFlashBool == true)
                    {
                        Thread NoFlashStart = new Thread(NoFlash);
                        NoFlashStart.Start();
                        NoFlashBool = null;
                    }
                    if (RadarBool == true)
                    {
                        Thread Radarstart = new Thread(Radaresp);
                        Radarstart.Start();
                        RadarBool = null;

                    }
                    if (SkinChnagerbool == true)
                    {
                        Thread SkinStart = new Thread(skinchangervoid);
                        SkinStart.Start();
                        SkinChnagerbool = false;

                        
                    }
                    if (AimbotBool == true)
                    {
                        Thread Start = new Thread(aimbotVoid);
                        Start.Start();
                        AimbotBool = null;
                    }
                    if (NoHands == true)
                    {
                        Thread Start = new Thread(NohandVoid);
                        Start.Start();
                        NoHands = null;
                    }
                    if (HitShoud == true)
                    {
                        Thread Start = new Thread(HitsoundVoid);
                        Start.Start();
                        HitShoud = null;
                    }
                }
            }
        }
   



        private void HitsoundVoid()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"HitMarkerSound.wav");
            int Bruh = vam.ReadInt32((IntPtr)ClientDll + Offsets.LocalPlayer);
            SoundPlayer player = new SoundPlayer(path);
            int Hits1 = vam.ReadInt32((IntPtr)Bruh + Offsets.HitsOnServer);
            
            while (true)
            {
                int Hits2 = vam.ReadInt32((IntPtr)Bruh + Offsets.HitsOnServer);             
                Thread.Sleep(10);
                if (Hits1 != Hits2)
                {
                    Hits1 = Hits2;
                  
                   
                    player.Play();
                    player.Play();
                    player.Play();

                }
                
                if (HitShoud == false)
                    break;

            }
        }
                
            private void NohandVoid()

        {
            
            while (true)
            {
                int aLocalPlayer = vam.ReadInt32((IntPtr)ClientDll + Offsets.LocalPlayer);
                int hand = aLocalPlayer + Offsets.ModelIndex;
                
                while (vam.ReadInt32((IntPtr)aLocalPlayer + Offsets.ModelIndex) != 0)
                {
                    int clientstate = vam.ReadInt32((IntPtr)EngineDll + Offsets.clientstate);

                    vam.WriteInt32((IntPtr)hand, 0);

                    vam.WriteInt32((IntPtr)clientstate + Offsets.DeltaTics, -1);
                }
                Thread.Sleep(10);
                if (NoHands == false)
                {
                    while(vam.ReadInt32((IntPtr)aLocalPlayer + Offsets.ModelIndex) == 0)
                    {
                        int clientstate = vam.ReadInt32((IntPtr)EngineDll + Offsets.clientstate);

                        vam.WriteInt32((IntPtr)aLocalPlayer + Offsets.ModelIndex, 1 );
                        vam.WriteInt32((IntPtr)clientstate + Offsets.DeltaTics, -1);

                    }
                    if (vam.ReadInt32((IntPtr)aLocalPlayer + Offsets.ModelIndex) == 1 && NoHands == false)
                    {
                        break;
                    }
                }

            }
        }
        
        struct angles
        {
            public float X, Y;
        }
        
         angles Clamp(angles Angle)
        {
            if (Angle.X > 89.0f)
                Angle.X = 88.0f;

            if (Angle.X < -89.0f)
                Angle.X = -88.0f;

            while (Angle.Y > 180)
                Angle.Y -= 360;

            while (Angle.Y < -180)
                Angle.Y += 360; ;
            return Angle;
        }
        float GetDistance(Vector3 to , Vector3 from)
        {
            float deltaX = to.X - from.X;
            float deltaY = to.Y - from.Y;
            float deltaZ = to.Z - from.Z;
            
            return (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ );

        }
        int BestEntiy()
        {
            closest = 0;
            int curBest = -1;
            float minDist = float.MaxValue;
            float dist;
            for (int i = 1; i < 65; i++)
            {

                
                int Localplaye1 = Memory.Read<Int32>((IntPtr)bClient + Offsets.LocalPlayer);
                IntPtr LocalPlaye2 = Memory.Read<IntPtr>(ClientDll + Offsets.LocalPlayer);

                IntPtr EntityList = Memory.Read<IntPtr>(ClientDll + Offsets.EntityList + (i) * 0x10);
                if (EntityList == IntPtr.Zero)
                    continue;
                
                IntPtr Bonematrix = Memory.Read<IntPtr>(EntityList + Offsets.BoneMatrix);
                Vector3 BonePos = new Vector3(Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0xC), Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0x1C), Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0x2C));

                IntPtr Engine = Memory.Read<IntPtr>(EngineDll + Offsets.clientstate);
                

                Vector3 EyePosition = Memory.Read<Vector3>(LocalPlaye2 + Offsets.VecViewOffset);
                Vector3 orgin = Memory.Read<Vector3>(LocalPlaye2 + Offsets.VecOrgin);
                Vector3 idk = orgin + EyePosition;
                Vector3 EyePosition2 = Memory.Read<Vector3>(EntityList + Offsets.VecViewOffset);
                Vector3 orgin2 = Memory.Read<Vector3>(EntityList + Offsets.VecOrgin);
                Vector3 idk2 = orgin2 + EyePosition2;




                angles Look = Memory.Read<angles>(Engine + Offsets.ViewAngles);

                Vector3 viewangle = Memory.Read<Vector3>(Engine + Offsets.ViewAngles);
               
                int Team = Memory.Read<int>(EntityList + Offsets.Team);
                int MyTeam = Memory.Read<int>(LocalPlaye2 + Offsets.Team);
                bool Dormant = Memory.Read<bool>(EntityList + Offsets.Dormant);
                int healt = Memory.Read<int>(EntityList + Offsets.Health);

                if (Memory.Read<Int32>((IntPtr)EntityList + Offsets.Health) < 1)
                    continue;

                if (MyTeam == Team)
                    continue;
                if (Memory.Read<Boolean>((IntPtr)EntityList + Offsets.Dormant))
                    continue;
                angles Aimat = CalcAngle(idk, BonePos);
               

                
                    
                


                float fovAimY = Aimat.Y - viewangle.Y;
                float FovaimX = Aimat.X = viewangle.X;
                if (fovAimY > 180) fovAimY -= 360;
                if (fovAimY < -180) fovAimY += 360;
                if (FovaimX > 89.0f) FovaimX = 88.0f;
                if (FovaimX < -89.0f) FovaimX = -88.0f;
              float  fovAim2y = Math.Abs(fovAimY);
                float fovaim2X = Math.Abs(FovaimX);
                if (LockType == 0)
                {
                    dist = GetDistance(idk, BonePos);
                }
                else
                {
                     dist = fovAim2y;
                }
                


                if (dist < minDist)
                {
                    if (fovAim2y < AimbotFov && fovaim2X < AimbotFov )
                    {

                        curBest = i;
                        minDist = dist;
                    }
                   

                }
                

            }
           
            
            return curBest;
            
        }
        static angles CalcAngle(Vector3 src, Vector3 dst)
            {
                angles angles;
                double[] delta = { (src.X - dst.X), (src.Y - dst.Y), (src.Z - dst.Z) };
            double hyp = Math.Sqrt(delta[0] * delta[0] + delta[1] * delta[1]);
            angles.X = (float)(Math.Asin(delta[2] / hyp) * 57.295779513082f);
            angles.Y = (float)(Math.Atan(delta[1] / delta[0]) * 57.295779513082f);
            if (delta[0] >= 0.0)
                angles.Y += 180.0f;

            return angles;
        }
        
        //Threads
        private void aimbotVoid()
        {
            key = 81;
            
            while (true)
            {
                if (AimbotBool == false)
                    break;
                this.Invoke(new Action(() => { fovv.Text = Convert.ToString(hScrollBar2.Value); }));
                
                try
                {
                     key = Convert.ToInt32(textBox7.Text);
                }
                catch
                {
                    ;
                }
                Thread.Sleep(10);
                if (GetAsyncKeyState(key) != aimbotkey)
                {


                    

                        if (aimbotkey == 0)
                        {


                            if (GetAsyncKeyState(key) == 0)
                            {
                            continue;
                            }
                        }
                            closest = BestEntiy();
                    Thread.Sleep(10);
                    if (closest == 0)
                        continue;
                        
                        IntPtr LocalPlaye2 = Memory.Read<IntPtr>(ClientDll + Offsets.LocalPlayer);

                        IntPtr EntityList = Memory.Read<IntPtr>(ClientDll + Offsets.EntityList + (closest) * 0x10);

                        IntPtr Bonematrix = Memory.Read<IntPtr>(EntityList + Offsets.BoneMatrix);
                        Vector3 BonePos = new Vector3(Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0xC), Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0x1C), Memory.Read<float>((IntPtr)Bonematrix + 0x30 * BoneId + 0x2C));

                        IntPtr Engine = Memory.Read<IntPtr>(EngineDll + Offsets.clientstate);
                        Vector3 Angles = Memory.Read<Vector3>(Engine + Offsets.ViewAngles);

                        Vector3 EyePosition = Memory.Read<Vector3>(LocalPlaye2 + Offsets.VecViewOffset);
                        Vector3 orgin = Memory.Read<Vector3>(LocalPlaye2 + Offsets.VecOrgin);
                        Vector3 idk = orgin + EyePosition;
                        angles Look = Memory.Read<angles>(Engine + Offsets.ViewAngles);
                        if (Memory.Read<Int32>((IntPtr)EntityList + Offsets.Health) < 1)
                            continue;
                       
                        if (EntityList == IntPtr.Zero)
                            continue;
                       
                        angles Aimat = CalcAngle(idk, BonePos);
                        if (Smooth != 0 && Smooth != 1)
                        {


                            angles Diffs;

                            Diffs.X = Look.X - Aimat.X;
                            Diffs.Y = Look.Y - Aimat.Y;
                            Diffs = Clamp(Diffs);

                            Aimat.X += Diffs.X / Smooth;
                            Aimat.Y += Diffs.Y / Smooth;
                        }
                        Aimat = Clamp(Aimat);
                        



                        
              
                        if (Aimat.X != 0 || Aimat.Y != 0) ;
                        {
                            
                            Memory.Write<angles>((IntPtr)Engine + Offsets.ViewAngles, Aimat);
                            
                        }


                    }
                    

                }
            }
            
        
  
    
    public class weaponsIds
        {
           public  const int awp = 9;
           public const int usps = 61;
            public const int CZ75 = 63;
            public const int Deagle = 1;
            public const int R8Revolver = 64;
            public const int Brettas = 2;
            public const int FiveSeven = 3;
            public const int Glock18 = 4;
            public const int p2000 = 32;
            public const int P250 = 36;
            public const int Tec9 = 30;
            public const int AK47 = 7;
            public const int AUG = 8;
            public const int FAMAS = 10;
            public const int G3SG1 = 11;
            public const int GalilAR = 13;
            public const int M4A1s = 60;
            public const int M4A4 = 16;
            public const int SCAR20 = 38;
            public const int SG553 = 39;
            public const int MAC10 = 17;
            public const int MP7 = 33;
            public const int MP9 = 34;
            public const int Bizon = 26;
            public const int P90 = 19;
            public const int UMP45 = 24;
            public const int M249 = 14;
            public const int Negev = 28;
            public const int SawedOff = 29;
            public const int XM1014 = 25;
            public const int Nova = 35;
            public const int MAG7 = 27;
        }

        public void skinchangervoid()
        {
            
            bool update = false;
          while (true)
            {
                Thread.Sleep(10);
               int playerbase = vam.ReadInt32((IntPtr)ClientDll + Offsets.LocalPlayer);
                if (playerbase == 0)
                    continue;
                


                    for (int i = 0; i < 8; i++)
                    {
                    skinid = 0;
                   
                    int clientstate = vam.ReadInt32((IntPtr)EngineDll + Offsets.clientstate);
                    

                    int CurrentWeaponEntity = vam.ReadInt32((IntPtr)playerbase + Offsets.MyWeapons + i * 0x4) & 0xFFF;
                        CurrentWeaponEntity = vam.ReadInt32((IntPtr)ClientDll + Offsets.EntityList + (CurrentWeaponEntity - 1) * 0x10);

                        if (CurrentWeaponEntity == 0)
                            continue;

                        int CurrentweaponID = vam.ReadInt32((IntPtr)CurrentWeaponEntity + Offsets.ItemDefinitionIndex);
                    int Accuntid = vam.ReadInt32((IntPtr)CurrentWeaponEntity + Offsets.OrifinalOwnerLow);

                    switch (CurrentweaponID)
                    {
                        case weaponsIds.awp:
                            skinid = SkinIds.AWPSkin;
                            break;
                        case weaponsIds.usps:
                            skinid = SkinIds.UspsSkin;
                            break;
                        case weaponsIds.CZ75:
                            skinid = SkinIds.Cz75skin;
                            
                            break;
                        case weaponsIds.Deagle:
                            skinid = SkinIds.DeagleSkin;
                            break;
                        case weaponsIds.R8Revolver:
                            skinid = SkinIds.R8RevolverSkin;
                            break;
                        case weaponsIds.Brettas:
                            skinid = SkinIds.BerettasSkin;
                            break;
                        case weaponsIds.FiveSeven:
                            skinid = SkinIds.FiveSevenSkin;
                            break;
                        case weaponsIds.Glock18:
                            skinid = SkinIds.Glock18Skin;
                            break;
                        case weaponsIds.p2000:
                            skinid = SkinIds.P2000Skin;
                            break;
                        case weaponsIds.P250:
                            skinid = SkinIds.P250Skin;
                            break;
                        case weaponsIds.Tec9:
                            skinid = SkinIds.Tec9Skin;
                            break;
                        case weaponsIds.AK47:
                            skinid = SkinIds.AK47Skin;
                            break;
                        case weaponsIds.AUG:
                            skinid = SkinIds.AUGSkin;
                            break;
                        case weaponsIds.FAMAS:
                            skinid = SkinIds.FAMASskin;
                            break;
                        case weaponsIds.G3SG1:
                            skinid = SkinIds.G3SG1Skin;
                            break;
                        case weaponsIds.GalilAR:
                            skinid = SkinIds.GALILARSkin;
                            break;
                        case weaponsIds.M4A1s:
                            skinid = SkinIds.M4A1Sskin;
                            break;
                        case weaponsIds.M4A4:
                            skinid = SkinIds.M4A4skin;
                            break;
                        case weaponsIds.SCAR20:
                            skinid = SkinIds.SCAR20Skin;
                            break;
                        case weaponsIds.SG553:
                            skinid = SkinIds.SG553Skin;
                            break;
                        case weaponsIds.MAC10:
                            skinid = SkinIds.MAC10skin;
                            break;
                        case weaponsIds.MP7:
                            skinid = SkinIds.MP7skin;
                            break;
                        case weaponsIds.MP9:
                            skinid = SkinIds.MP9skin;
                            break;
                        case weaponsIds.Bizon:
                            skinid = SkinIds.BizonSkin;
                            break;
                        case weaponsIds.P90:
                            skinid = SkinIds.P90skin;
                            break;
                        case weaponsIds.UMP45:
                            skinid = SkinIds.UMP45skin;
                            break;
                        case weaponsIds.M249:
                            skinid = SkinIds.M249Skin;
                            break;
                        case weaponsIds.Negev:
                            skinid = SkinIds.NegevSkin;
                            break;
                        case weaponsIds.SawedOff:
                            skinid = SkinIds.SawedOffSkin;
                            break;
                        case weaponsIds.XM1014:
                            skinid = SkinIds.XM1014skin;
                            break;
                        case weaponsIds.Nova:
                            skinid = SkinIds.NovaSkin;
                            break;
                        case weaponsIds.MAG7:
                            skinid = SkinIds.MAG7skin;
                            break;

                    }


                    if (skinid != 0)
                    {
                        if (vam.ReadInt32((IntPtr)CurrentWeaponEntity + Offsets.FallBackPaintKit) == skinid)
                        {
                            ;
                        }
                        else
                        {
                            
                            vam.WriteInt32((IntPtr)CurrentWeaponEntity + Offsets.AccountID, Accuntid);
                            vam.WriteInt32((IntPtr)CurrentWeaponEntity + Offsets.ItemIDHigh, -1);
                            vam.WriteInt32((IntPtr)CurrentWeaponEntity + Offsets.FallBackPaintKit, skinid);
                            vam.WriteFloat((IntPtr)CurrentWeaponEntity + Offsets.FallBackWear, 0.0001f);
                            vam.WriteInt32((IntPtr)CurrentWeaponEntity + Offsets.FallBackStatTrak, stattrack);
                            vam.WriteStringASCII((IntPtr)CurrentWeaponEntity + Offsets.CustomName, gunname);
                            vam.WriteInt32((IntPtr)CurrentWeaponEntity + 0x2FAC, 3);
                            
                            update = true;


                        }
                       
                        if (update == true)
                        {
                            vam.WriteInt32((IntPtr)clientstate + Offsets.DeltaTics, -1);
                            update = false;
                        }


                    }
                   
                    

                }
            }
        }

                            
                        



        private void Radaresp()
        {


            while (true)
            {
                if (vam.ReadInt32((IntPtr)ClientDll + Offsets.LocalPlayer) == 0)
                    continue;
                if (RadarBool == false)
                {
                    break;
                }
                Thread.Sleep(10);
                for (int i = 1; i < 64; i++)
                {
                    int adress = bClient + Offsets.EntityList + i * 0x10;
                    int EntityList = vam.ReadInt32((IntPtr)adress);
                    vam.WriteBoolean((IntPtr)EntityList + Offsets.Spotted, true);
                    Thread.Sleep(20);
                    if (RadarBool == false)
                    {
                        vam.WriteBoolean((IntPtr)EntityList + Offsets.Spotted, false);
                        Thread.Sleep(10);

                    }

                }


            }
        }




        private void NoFlash()
        {
            while (true)
            {

                if (NoFlashBool == false)
                {
                    break;
                }
                int oLocalplayer = vam.ReadInt32((IntPtr)bClient + Offsets.LocalPlayer);
                if (oLocalplayer == 0)
                    continue;

                int FlashDuration = vam.ReadInt32((IntPtr)oLocalplayer + Offsets.FlashDuration);
                if (FlashDuration != 0)

                {
                    vam.WriteInt32((IntPtr)oLocalplayer + Offsets.FlashDuration, 0);
                }
            }





        }
        public void RCS()
        {

            while (true)
            {
                if (vam.ReadInt32((IntPtr)ClientDll + Offsets.LocalPlayer) == 0)
                    continue;
                if (RcsBool == false)
                {
                    break;
                }

                if (checkBox9.Checked == false)
                {
                    if (GetAsyncKeyState(key2) != 0 && GetAsyncKeyState(0x01) != 0)
                    {
                        ControlSpray();
                    }
                }
                else
                {
                    if (API.GetAsyncKeyState(0x01)) ControlSpray();
                }


            }





        }
        public void ControlSpray()
        {

            LocalPlayer = Memory.Read<IntPtr>(ClientDll + Offsets.LocalPlayer);
            
            ClientState = Memory.Read<IntPtr>(EngineDll + Offsets.clientstate);

            ShotsFired = Memory.Read<int>(LocalPlayer + Offsets.ShotsFired);
            Thread.Sleep(10);


            if (ShotsFired > 1)
            {

                Angle = Memory.Read<Vector3>(LocalPlayer + Offsets.aimPunchAngle);
                AimPunch = OldAngle - Angle * 2;
                ClampAngle(AimPunch);
                Memory.Write<Vector3>((IntPtr)ClientState + Offsets.ViewAngles, AimPunch);
                ;

            }
            else
            {
                OldAngle = Memory.Read<Vector3>(ClientState + Offsets.ViewAngles);
               
            }
            Thread.Sleep(10);
        }
        private void FOVgo()
        {
            int LocalPlayer = vam.ReadInt32((IntPtr)bClient + Offsets.LocalPlayer);
           
                
            

            while (true)
            {

                if (LocalPlayer == 0)
                    continue;

                if (FOV2 == false)
                {
                    FOV = false;
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 90);
                    break;

                }
                if (vam.ReadInt32((IntPtr)LocalPlayer + Offsets.FOV) != FOVvalue)
                {
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, FOVvalue);
                }
                
                Thread.Sleep(10);


            }
        }
    
                    
                     
                    
                    
                
                
            
        
        private void Chams1()
        {


            extra5 = true;

            while (true)
            {
                
                int a = 1;
                if (Chams == false)
                {
                    break;
                }
               
                do
                {


                    int address = bClient + Offsets.LocalPlayer;
                    int Player = vam.ReadInt32((IntPtr)address);
                   
                    
                    if (Player == 0)
                        continue;
                    address = Player + Offsets.Team;
                    int MyTeam = vam.ReadInt32((IntPtr)address);

                    address = bClient + Offsets.EntityList + (a - 1) * 0x10;
                    int EntityList = vam.ReadInt32((IntPtr)address);

                    address = EntityList + Offsets.Team;
                    int HisTeam = vam.ReadInt32((IntPtr)address);

                    address = EntityList + Offsets.Dormant;
                    if (!vam.ReadBoolean((IntPtr)address))
                    {
                        if (MyTeam != HisTeam)
                        {
                            vam.WriteByte((IntPtr)EntityList + 0x70, r3);
                            vam.WriteByte((IntPtr)EntityList + 0x71, g3);
                            vam.WriteByte((IntPtr)EntityList + 0x72, b3);
                            int thisPtr = (int)(EngineDll + 0x59205C - 0x2c);
                            byte[] bytearray = BitConverter.GetBytes(brightness);
                            int intbrightness = BitConverter.ToInt32(bytearray, 0);
                            int xored = intbrightness ^ thisPtr;
                            vam.WriteInt32((IntPtr)EngineDll + 0x59205C, xored);
                        }
                        else
                        {
                            vam.WriteByte((IntPtr)EntityList + 0x70, r4);
                            vam.WriteByte((IntPtr)EntityList + 0x71, g4);
                            vam.WriteByte((IntPtr)EntityList + 0x72, b4);
                            
                        }
                        if (playerChams == true)
                        {

                            vam.WriteByte((IntPtr)Player + 0x70, r3);
                            vam.WriteByte((IntPtr)Player + 0x71, g3);
                            vam.WriteByte((IntPtr)Player + 0x72, b3);
                            Console.Beep();
                        }
                        
                        
                        //0x59205C


                    }
                    a++;

                }
                while (a < 20);
                Thread.Sleep(10);


            }
        }
        private void Glowesp()
        {




            GlowStruct Enemy = new GlowStruct()
            {

                a = 1,
                rwo = true,
                rwuo = true
            };
            GlowStruct Team = new GlowStruct()
            {
                a = 1,
                rwo = true,
                rwuo = true
            };

            extra3 = true;
            while (true)
            {
              
                if (Glow_esp == false)
                {
                    break;
                }

                for (int i = 1; i < 65; i++)
                {
                    int adress = bClient + Offsets.LocalPlayer;
                    int Player = vam.ReadInt32((IntPtr)adress);
                    if (Player == 0)
                        continue;


                    adress = Player + Offsets.Team;
                    int MyTeam = vam.ReadInt32((IntPtr)adress);

                    adress = bClient + Offsets.EntityList + i  * 0x10;
                    int EntityList = vam.ReadInt32((IntPtr)adress);
                    adress = EntityList + Offsets.Health;
                    int health = vam.ReadInt32((IntPtr)adress);
                    if (health <= 0)
                        continue;
                    

                    adress = EntityList + Offsets.Team;
                    int PICTeam = vam.ReadInt32((IntPtr)adress);
                    adress = EntityList + Offsets.Dormant;
                   
                    if (healthesp == true)
                    {
                        r2 = 0;
                        b2 = 0;
                        g2 = 0;


                        if (health > 75 || health == 75)
                        {
                            r = 0;
                            g = 1;
                            b = 0;

                        }
                        if ( health < 75 && health > 30 || health == 30)
                        {
                            r = 1;
                            g = 1;
                            b = 0;
                        }
                        if (health < 30 || health == 30)
                        {
                            r = 1;
                            g = 0;
                            b = 0;

                        }
                     
                        
                    }
                    if (!vam.ReadBoolean((IntPtr)adress))
                    {

                        adress = EntityList + Offsets.GlowIndex;
                        int GlowIndex = vam.ReadInt32((IntPtr)adress);

                        if (MyTeam == PICTeam)
                        {



                            adress = bClient + Offsets.GlowObject;
                            int GlowObject = vam.ReadInt32((IntPtr)adress);

                            int calculations = GlowIndex * 0x38 + 0x4;
                            int current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, r2);//red

                            calculations = GlowIndex * 0x38 + 0x8;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, g2);//green

                            calculations = GlowIndex * 0x38 + 0xC;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, b2);//blue

                            calculations = GlowIndex * 0x38 + 0x10;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, Team.a);

                            calculations = GlowIndex * 0x38 + 0x24;
                            current = GlowObject + calculations;
                            vam.WriteBoolean((IntPtr)current, Team.rwo);

                           



                        }
                        else
                        {


                            adress = bClient + Offsets.GlowObject;
                            int GlowObject = vam.ReadInt32((IntPtr)adress);

                            int calculations = GlowIndex * 0x38 + 0x4;
                            int current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, r);

                            calculations = GlowIndex * 0x38 + 0x8;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, g);

                            calculations = GlowIndex * 0x38 + 0xC;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, b);

                            calculations = GlowIndex * 0x38 + 0x10;
                            current = GlowObject + calculations;
                            vam.WriteFloat((IntPtr)current, Enemy.a);

                            calculations = GlowIndex * 0x38 + 0x24;
                            current = GlowObject + calculations;
                            vam.WriteBoolean((IntPtr)current, Enemy.rwo);

                           



                        }
                    }


                    
                }
                

            }
            Thread.Sleep(20);
        }
            
        
        
        private void triggerbot()
        {
            extra = true;
            
            while (true)
            {

               if (TriggerBot == false)
                {
                    break;
                }
                if (GetAsyncKeyState(0x73) != 0 && extra4 == false)
                {
                    Console.Beep();
                    TriggerOn = true;
                    extra4 = true;
                
                }
                
                if (TriggerOn == true)
                {
                    
                    


                    if (GetAsyncKeyState(key) != 0)
                    {




                        Thread.Sleep(1);

                        int adress = bClient + Offsets.LocalPlayer;
                        int oLocalPlayer = vam.ReadInt32((IntPtr)adress);
                        if (oLocalPlayer == 0)
                            continue;




                        adress = oLocalPlayer + Offsets.Team;
                        int MYTeam = vam.ReadInt32((IntPtr)adress);


                        adress = oLocalPlayer + Offsets.CrossHairId;

                        int PlayerInCoross = vam.ReadInt32((IntPtr)adress);

                        ;
                        if (PlayerInCoross > 0 && PlayerInCoross < 65)
                        {

                            adress = bClient + Offsets.EntityList + (PlayerInCoross - 1) * 0x10;
                            int PtrToPIC = vam.ReadInt32((IntPtr)adress);


                            adress = PtrToPIC + Offsets.Health;
                            int PICHealth = vam.ReadInt32((IntPtr)adress);

                            adress = PtrToPIC + Offsets.Team;
                            int PICTeam = vam.ReadInt32((IntPtr)adress);

                            if ((PICTeam != MYTeam) && (PICHealth > 0) && PICTeam > 1)
                            {


                                Thread.Sleep(delay);
                                vam.WriteInt32((IntPtr)fAttack, 1);
                                Thread.Sleep(10);
                                vam.WriteInt32((IntPtr)fAttack, 4);

                            }


                        }
                    }
                    Thread.Sleep(5);
                }
                else
                {
                    
                    

                        Thread.Sleep(1);

                        int adress = bClient + Offsets.LocalPlayer;
                        int oLocalPlayer = vam.ReadInt32((IntPtr)adress);




                        adress = oLocalPlayer + Offsets.Team;
                        int MYTeam = vam.ReadInt32((IntPtr)adress);


                        adress = oLocalPlayer + Offsets.CrossHairId;

                        int PlayerInCoross = vam.ReadInt32((IntPtr)adress);

                        ;
                        if (PlayerInCoross > 0 && PlayerInCoross < 65)
                        {
                            

                            adress = bClient + Offsets.EntityList + (PlayerInCoross - 1) * 0x10;
                            int PtrToPIC = vam.ReadInt32((IntPtr)adress);


                            adress = PtrToPIC + Offsets.Health;
                            int PICHealth = vam.ReadInt32((IntPtr)adress);

                            adress = PtrToPIC + Offsets.Team;
                            int PICTeam = vam.ReadInt32((IntPtr)adress);

                            if ((PICTeam != MYTeam) && (PICHealth > 0) && PICTeam > 1)
                            {

                                
                                Thread.Sleep(delay);
                                vam.WriteInt32((IntPtr)fAttack, 1);
                                Thread.Sleep(5);
                                vam.WriteInt32((IntPtr)fAttack, 4);

                            }

                        
                    }


                }
            }
            Thread.Sleep(10);
        }
        private void Bhopvoid()
        {
            extra2 = true;
            while (true)
            {
               if (Bhop == false)
                {
                    break;
                }


                int fJump = bClient + Offsets.forceJump;
                int aLocalPlayer = bClient + Offsets.LocalPlayer;
                int LocalPlayer = vam.ReadInt32((IntPtr)aLocalPlayer);
                if (LocalPlayer == 0)
                {
                    continue;
                }

                int aFlags = LocalPlayer + Offsets.flag;
                if (GetAsyncKeyState(0x20) != 0)
                {

                    int Flags = vam.ReadInt32((IntPtr)aFlags);
                    if (Flags == 257)
                    {
                        vam.WriteInt32((IntPtr)fJump, 5);
                        Thread.Sleep(5);
                        vam.WriteInt32((IntPtr)fJump, 4);

                    }
                }
            }
            Thread.Sleep(5);
        }
    



        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        static bool GetModuleAddy()
        {
            try
            {
                Process[] p = Process.GetProcessesByName(proccess);
                if (p.Length > 0)
                {
                    foreach (ProcessModule m in p[0].Modules)
                    {
                        if (m.ModuleName == "client.dll")
                        {
                            bClient = (int)m.BaseAddress;
                            return true;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        static bool GetModuleAddyengine()
        {
            try
            {
                Process[] p = Process.GetProcessesByName(proccess);
                if (p.Length > 0)
                {
                    foreach (ProcessModule m in p[0].Modules)
                    {
                        if (m.ModuleName == "engine.dll")
                        {
                           bEngine = (int)m.BaseAddress;
                            return true;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public struct GlowStruct
        {
            public float r;
            
            public float  g;
            public float b;
            public float a;
            public bool rwo;
            public bool rwuo;

        }
        public struct GlowStruct2
        {
            public byte r;
            public byte g;
            public byte b;
            public byte a;
           

        }
        public class Offsets
        {
            
            public static int LocalPlayer;
            public static int Team;
            public static int EntityList;
            public static int Dormant;
            public static int GlowIndex;
            public static int GlowObject;
            public static int Health;
            public static int CrossHairId;
            public static int Attack;
            public static int flag;
            public static int forceJump;
            public static int FOV;
            public static int ISscoped;
            public static int clientstate;
            public static int ViewAngles;
            public static int ShotsFired;
            public static int aimPunchAngle;
            public static int viewpunchangle;
            public static int FlashDuration;
            public static int Spotted;
            public static int MyWeapons;
            public static int ItemDefinitionIndex;
            public static int FallBackPaintKit;
            public static int FallBackSeed;
            public static int FallBackWear;
            public static int FallBackStatTrak;
            public static int CustomName;
            public static int ItemIDHigh;
            public static int AccountID;
            public static int OrifinalOwnerLow;
            public static int VecOrgin;
            public static int VecViewOffset;
            public static int BoneMatrix;
            public static int ModelIndex;
            public static int DeltaTics;
            public static int HitsOnServer;


        }
        public class SkinIds
        {
            public static int Cz75skin;
            public static int DeagleSkin;
            public static int R8RevolverSkin;
            public static int BerettasSkin;
            public static int FiveSevenSkin;
            public static int Glock18Skin;
            public static int P2000Skin;
            public static int P250Skin;
            public static int Tec9Skin;
            public static int UspsSkin;
            public static int AK47Skin;
            public static int AUGSkin;
            public static int AWPSkin;
            public static int FAMASskin;
            public static int G3SG1Skin;
            public static int GALILARSkin;
            public static int M4A1Sskin;
            public static int M4A4skin;
            public static int SCAR20Skin;
            public static int SG553Skin;
            public static int SSG08skin;
            public static int MAC10skin;
            public static int MP7skin;
            public static int MP9skin;
            public static int P90skin;
            public static int UMP45skin;
            public static int M249Skin;
            public static int NegevSkin;
            public static int SawedOffSkin;
            public static int XM1014skin;
            public static int NovaSkin;
            public static int MAG7skin;
            public static int BizonSkin;



        }
       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Orange;
            panel8.BackColor = Color.Black;
            panel9.BackColor = Color.Black;
            panel10.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
        }
       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                delay = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                delay = 0;
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            try
            {
                Environment.Exit(0);
            }
            catch
            {
                Environment.Exit(1);
            }

           
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                linkLabel1.Show();
                checkBox3.Text = "✔";
                TriggerBot = true;
                checkBox7.Show();
                textBox2.Show();
                label1.Show();
            }
            else
            {
                if (checkBox8.Checked == false)
                {
                    linkLabel1.Hide();
                }
                checkBox3.Text = "";
                TriggerBot = false;
                checkBox7.Hide();
                textBox2.Hide();
                label1.Hide();
            }
            
        }

        

       

      

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            key2 = Convert.ToInt32(textBox3.Text);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://cherrytree.at/misc/vk.htm");
        }

        

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                NoFlashBool = true;
            }
            else
            {
                NoFlashBool = false;
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                RadarBool = true;
            }
            else
            {
                RadarBool = false;
            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                
                checkBox4.Text = "✔";
                Bhop = true;
            }
            else
            {
                checkBox4.Text = "";
                Bhop = false;
            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox5.Text = "✔";
                Glow_esp = true;
            }
            else
            {
                checkBox5.Text = "";
                Glow_esp = false;
            }
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox6.Text = "✔";
                Chams = true;
            }
            else
            {
                checkBox6.Text = "";
                Chams = false;
            }
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged_2(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox11.Text = "✔";
                RadarBool = true;
            }
            else
            {
                checkBox11.Text = "";
                RadarBool = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/frk1/hazedumper/blob/master/csgo.hpp");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                skinid = Convert.ToInt32(textBox4.Text);
            }
            catch
            {
                ;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            

            string text = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (text == "CZ75-Auto")
            {
                SkinIds.Cz75skin = int.Parse(textBox4.Text);
            }
            if (text == "Desert Eagle")
            {
                SkinIds.DeagleSkin = int.Parse(textBox4.Text);
            }
            if (text == "R8 Revolver")
            {
                SkinIds.R8RevolverSkin = int.Parse(textBox4.Text);
            }
            if (text == "Dual Berettas")
            {
                SkinIds.BerettasSkin = int.Parse(textBox4.Text);
            }
            if (text == "Five-Seven")
            {
                SkinIds.FiveSevenSkin = int.Parse(textBox4.Text);
            }
            if (text == "Glock-18")
            {
                SkinIds.Glock18Skin = int.Parse(textBox4.Text);
            }
            if (text == "P2000")
            {
                SkinIds.P2000Skin = int.Parse(textBox4.Text);
            }
            if (text == "P250")
            {
                SkinIds.P250Skin = int.Parse(textBox4.Text);
            }
            if (text == "Tec-9")
            {
                SkinIds.Tec9Skin = int.Parse(textBox4.Text);
            }
            if (text == "USP-S")
            {

                SkinIds.UspsSkin= int.Parse(textBox4.Text);
            }
            if (text == "AK-47")
            {
                SkinIds.AK47Skin = int.Parse(textBox4.Text);
            }
            if (text == "AUG")
            {
                SkinIds.AUGSkin = int.Parse(textBox4.Text);
            }
            if (text == "AWP")
            {
                SkinIds.AWPSkin = int.Parse(textBox4.Text);
            }
            if (text == "FAMAS")
            {
                SkinIds.FAMASskin = int.Parse(textBox4.Text);
            }
            if (text == "G3SG1")
            {
                SkinIds.G3SG1Skin = int.Parse(textBox4.Text);
            }
            if (text == "Galil AR")
            {
                SkinIds.GALILARSkin= int.Parse(textBox4.Text);
            }
            if (text == "M4A1-s")
            {
                SkinIds.M4A1Sskin = int.Parse(textBox4.Text);
            }
            if (text == "M4A4")
            {
                SkinIds.M4A4skin= int.Parse(textBox4.Text);
            }
            if (text == "SCAR-20")
            {
                SkinIds.SCAR20Skin = int.Parse(textBox4.Text);
            }
            if (text == "SG 553")
            {
                SkinIds.SG553Skin = int.Parse(textBox4.Text);
            }
            if (text == "SSG08")
            {
                SkinIds.SSG08skin = int.Parse(textBox4.Text);
            }
            if (text == "MAC 10")
            {
                SkinIds.MAC10skin = int.Parse(textBox4.Text);
            }
            if (text == "MP7")
            {
                SkinIds.MP7skin = int.Parse(textBox4.Text);
            }
            if (text == "MP9")
            {
                SkinIds.MP9skin = int.Parse(textBox4.Text);
            }
            if (text == "Bizon")
            {
                SkinIds.BizonSkin = int.Parse(textBox4.Text);
            }
            if (text == "P90")
            {
                SkinIds.P90skin = int.Parse(textBox4.Text);
            }
            if (text == "UMP-45")
            {
                SkinIds.UMP45skin = int.Parse(textBox4.Text);
            }
            if (text == "M249")
            {
                SkinIds.M249Skin = int.Parse(textBox4.Text);
            }
            if (text == "Negev")
            {
                SkinIds.NegevSkin = int.Parse(textBox4.Text);
            }
            if (text == "Sawed Off")
            {
                SkinIds.SawedOffSkin = int.Parse(textBox4.Text);
            }
            if (text == "XM1014")
            {
                SkinIds.XM1014skin = int.Parse(textBox4.Text);
            }
            if (text == "Nova")
            {
                SkinIds.NovaSkin = int.Parse(textBox4.Text);
            }
            if (text == "MAG-7")
            {
                SkinIds.MAG7skin = int.Parse(textBox4.Text);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            gunname = textBox5.Text;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                stattrack = Convert.ToInt32(textBox6.Text);
            }
            catch
            {
                ;
            }
             
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void button4_Click_2(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Black;
            panel8.BackColor = Color.Orange;
            panel9.BackColor = Color.Black;
            panel10.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Show();
           
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox13_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {

                checkBox13.Text = "✔";
                AimbotBool = true;
                label67.Show();
                comboBox2.Show();
                label68.Show();
                textBox7.Show();
                comboBox3.Show();
                label69.Show();
                label66.Show();
                label62.Show();
                checkBox12.Show();
                fovv.Show();
                hScrollBar2.Show();
                hScrollBar3.Show();
                label65.Show();



            }
            else
            {

                checkBox13.Text = "";
                AimbotBool = false;
                label67.Hide();
                comboBox2.Hide();
                label68.Hide();
                textBox7.Hide();
                fovv.Hide();
                label69.Hide();
                label66.Hide();
                label65.Hide();
                checkBox12.Hide();
                hScrollBar2.Hide();
                hScrollBar3.Hide();
                comboBox3.Hide();
                label62.Hide();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            if (text == "Head")
                BoneId = 8;
            if (text == "Chest")
                BoneId = 6;
            if (text == "Pelvis")
                BoneId = 3;
            if (text == "Neck")
                BoneId = 7;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                aimbotkey = 1;
            }
            else
            {
                aimbotkey = 0;
            }
        }

       

      

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                NoHands = true;
            }
            else
            {
                NoHands = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                HitShoud = true;
            }
            else
            {
                HitShoud = false;
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.unknowncheats.me/forum/cs-go-releases/100856-cs-offset-dumper.html");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = this.comboBox3.GetItemText(this.comboBox3.SelectedItem);
            if (text == "Closest to Crosshair")
            {
                LockType = 1;
            }
            else
            {
                LockType = 0;
            }
        }

        

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            FOVvalue = hScrollBar1.Value;
            label63.Text = Convert.ToString(hScrollBar1.Value);
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            AimbotFov = hScrollBar1.Value;
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            int value = hScrollBar3.Value;
            label65.Text = Convert.ToString(hScrollBar3.Value) + "%";
            if (value == 0)
                Smooth = 0;
            else if (value > 0 && value <= 20)
                Smooth = 6;
            else if (value > 20 && value <= 40)
                Smooth = 5;
            else if (value > 40 && value <= 60)
                Smooth = 4;
            else if (value > 60 && value <= 80)
                Smooth = 3;
            else if (value > 80 && value <= 100)
                Smooth = 2;

        }

        private void hScrollBar5_Scroll(object sender, ScrollEventArgs e)
        {
            g = hScrollBar5.Value / divide;
        }

        private void hScrollBar6_Scroll(object sender, ScrollEventArgs e)
        {
            b = hScrollBar6.Value / divide;
        }

        private void hScrollBar7_Scroll(object sender, ScrollEventArgs e)
        {
            r2 = hScrollBar7.Value / divide;
        }

        private void hScrollBar8_Scroll(object sender, ScrollEventArgs e)
        {
            g2 = hScrollBar8.Value / divide;
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            visible = false;
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

                    Graphics mgraphics = e.Graphics;
                    Pen pen = new Pen(Color.FromArgb(20, 20, 20), 1);
                    Rectangle area = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
                    LinearGradientBrush lgb = new LinearGradientBrush(area, Color.FromArgb(60, 60, 60), Color.FromArgb(20, 20, 20), LinearGradientMode.Vertical);
                    mgraphics.FillRectangle(lgb, area);
                    mgraphics.DrawRectangle(pen, area);
                    
                    
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.windowState == FormWindowState.Normal)
            {
                this.Refresh();
            }
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void panel6_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void hScrollBar9_Scroll(object sender, ScrollEventArgs e)
        {
            b2 = hScrollBar9.Value / divide;
        }

        private void hScrollBar16_Scroll(object sender, ScrollEventArgs e)
        {
            r3 = Convert.ToByte(hScrollBar16.Value);
        }

        private void hScrollBar15_Scroll(object sender, ScrollEventArgs e)
        {
            g3 = Convert.ToByte(hScrollBar15.Value);
        }

        private void hScrollBar14_Scroll(object sender, ScrollEventArgs e)
        {
            b3 = Convert.ToByte(hScrollBar14.Value);
        }

        private void hScrollBar13_Scroll(object sender, ScrollEventArgs e)
        {
            r4 = Convert.ToByte(hScrollBar13.Value);
        }

        private void hScrollBar11_Scroll(object sender, ScrollEventArgs e)
        {
            g4 = Convert.ToByte(hScrollBar11.Value);
        }

        private void hScrollBar10_Scroll(object sender, ScrollEventArgs e)
        {
            b4 = Convert.ToByte(hScrollBar10.Value);
        }

        private void hScrollBar12_Scroll(object sender, ScrollEventArgs e)
        {
            brightness = hScrollBar12.Value;
        }

        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            r = hScrollBar4.Value / divide;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Black;
            panel8.BackColor = Color.Black;
            panel9.BackColor = Color.Orange;
            panel10.BackColor = Color.Black;
            panel7.BackColor = Color.Black;
           
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
            panel5.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://steamcommunity.com/sharedfiles/filedetails/?id=880595913");
        }

        private void checkBox8_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                linkLabel1.Show();
                checkBox8.Text = "✔";
                RcsBool = true;
                label2.Show();
                checkBox9.Show();
                textBox3.Show();

            }
            else
            {
                if (checkBox3.Checked == false)
                {
                    linkLabel1.Hide();
                }
                checkBox8.Text = "";
                RcsBool = false;
                label2.Hide();
                checkBox9.Hide();
                textBox3.Hide();

            }
        }

        

      

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (TriggerOn == false)
            {
                TriggerOn = true;
            }
            else
            {
                TriggerOn = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(textBox2.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (healthesp == false)
            {
                healthesp = true;
               
            }
            else
            {
                healthesp = false;
                
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Black;
            panel8.BackColor = Color.Black;
            panel9.BackColor = Color.Black;
            panel10.BackColor = Color.Orange;
            panel7.BackColor = Color.Black;
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
        }

    
        

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (FOV == false)
            {
                FOV = true;
                FOV2 = true;

                hScrollBar1.Show();
                label63.Show();
            }
            else
            {
                FOV = false;
                FOV2 = false;

                hScrollBar1.Hide();
                label63.Hide();
            }
        }

        
       

        private void button2_Click(object sender, EventArgs e)
        {
            panel11.BackColor = Color.Black;
            panel8.BackColor = Color.Black;
            panel9.BackColor = Color.Black;
            panel10.BackColor = Color.Black;
            panel7.BackColor = Color.Orange;
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel4.Hide();
            panel5.Hide();
        }
        
        public static Vector3 ClampAngle(Vector3 Angle)
        {
            if (Angle[0] > 89.0f)
                Angle[0] = 89.0f;

            if (Angle[0] < -89.0f)
                Angle[0] = -89.0f;

            while (Angle[1] > 180)
                Angle[1] -= 360;

            while (Angle[1] < -180)
                Angle[1] += 360;

            Angle.Z = 0;

            return Angle;
        }
        





    }
}
