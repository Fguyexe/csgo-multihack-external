using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Windows;
using PewPew.math;


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
         static IntPtr  ClientState, LocalPlayer;
        
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
        public static bool? healthesp = false;
        public static bool? FOV = false, FOV2 = true;
        public static bool? RcsBool = false;
        public static bool? NoFlashBool = false;
        public static bool? RadarBool = false;
        public static bool? SkinChnagerbool = true;
        public static bool? SkinChamgerBool2 = false;

        public static VAMemory vam = new VAMemory(proccess);

       
        public static float r = 255, g ,b;
        public static float r2, g2, b2 = 255;
        public static byte r3 = 255, g3, b3;
        public static byte r4, g4, b4 = 255;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        public static float divide = 255;


        public static int gunid;
        public static int skinid;


        public static int key, key2 = 16;
        public static bool extra = false, extra2 = false, extra3 = false, extra4 = false, extra5 = false;
        public   Form1()
        {
            
            InitializeComponent();
            checkBox11.TextAlign = ContentAlignment.MiddleCenter;
            checkBox8.TextAlign = ContentAlignment.MiddleCenter;
            checkBox6.TextAlign = ContentAlignment.MiddleCenter;
            checkBox5.TextAlign = ContentAlignment.MiddleCenter;
            checkBox4.TextAlign = ContentAlignment.MiddleCenter;
            checkBox3.TextAlign = ContentAlignment.MiddleCenter;

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
                        Console.Beep();
                    }

                    fAttack = bClient + Offsets.Attack;
                    //intptr dlls
                    ClientDll = Memory.GetModuleBaseAddress("client.dll");
                    EngineDll = Memory.GetModuleBaseAddress("engine.dll");
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
                    if(SkinChnagerbool == true)
                    {
                        Thread SkinStart = new Thread(skinchangervoid);
                        SkinStart.Start();
                        SkinChnagerbool = null;
                    }
                  


                }
            }
        }


        //Threads

     

        public void skinchangervoid()
        {
            int myWeapons = 0x2DF8, m_iItemDefinitionIndex = 0x2FAA, m_nFallbackPaintKit = 0x31C8, m_nFallbackSeed = 0x31CC, m_flFallbackWear = 0x31D0, m_nFallbackStatTrak = 0x31D4, m_iEntityQuality = 0x2FAC, m_szCustomName = 0x303C, m_iItemIDHigh = 0x2FC0;
            while (true)
            {
                Thread.Sleep(10);
                
                
                int playerbase = vam.ReadInt32((IntPtr)bClient + Offsets.LocalPlayer);
                for (int i = 0; i < 8; i++)
                {
                    int currentWeaponEntity = vam.ReadInt32((IntPtr)playerbase + myWeapons + i * 0x4) & 0xFF;
                    currentWeaponEntity = vam.ReadInt32((IntPtr)bClient + Offsets.EntityList + (currentWeaponEntity - 1) * 0x10);
                    if (currentWeaponEntity == 0)
                    {
                        continue;
                    }
                    int CurrentWeaponID = vam.ReadInt32((IntPtr)currentWeaponEntity + m_iItemDefinitionIndex);

                    int Clientstate = vam.ReadInt32((IntPtr)EngineDll + Offsets.clientstate);
                    int fallbackPaint = skinid;
                    
                    const float fallbackWear = 0.0001f;

                    if (SkinChamgerBool2 == true)
                    {


                        if (CurrentWeaponID == gunid)
                        {


                            if (vam.ReadInt32((IntPtr)currentWeaponEntity + m_nFallbackPaintKit) == fallbackPaint)
                            {
                                
                                break;
                            }
                            else
                            {
                                vam.WriteInt32((IntPtr)Clientstate + 0x174, -1);
                            }
                        }


                        if (CurrentWeaponID == gunid)
                        {

                            vam.WriteInt32((IntPtr)(EngineDll + Offsets.clientstate) + 0x174, -1);
                            vam.WriteInt32((IntPtr)currentWeaponEntity + m_iItemIDHigh, -1);
                            vam.WriteInt32((IntPtr)currentWeaponEntity + m_nFallbackPaintKit, fallbackPaint);
                            vam.WriteFloat((IntPtr)currentWeaponEntity + m_flFallbackWear, fallbackWear);

                        }

                    }
                }
            }
        }
     
        private void Radaresp()
        {


            while (true)
            {

                if (RadarBool == false)
                {
                    break;
                }

                for (int i = 1; i < 64; i++)
                {
                    int adress = bClient + Offsets.EntityList + i * 0x10;
                    int EntityList = vam.ReadInt32((IntPtr)adress);
                    vam.WriteBoolean((IntPtr)EntityList + Offsets.Spotted, true);
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
                if (RcsBool == false)
                {
                    break;
                }

                if(checkBox9.Checked == false)
                {
                    if (GetAsyncKeyState(key2)!=0 && GetAsyncKeyState(0x01) != 0)
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
            int address = LocalPlayer + Offsets.ISscoped;

            while (true)
            {

                if (FOV2 == false)
                {
                    FOV = false;                   
                    break;
                    
                }
               
                
               
                int IsScoped = vam.ReadInt32((IntPtr)address);
                if (IsScoped == 0)
                {
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    vam.WriteInt32((IntPtr)LocalPlayer + Offsets.FOV, 120);
                    Thread.Sleep(10);
                }
                
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
                            
                        }
                        else
                        {
                            vam.WriteByte((IntPtr)EntityList + 0x70, r4);
                            vam.WriteByte((IntPtr)EntityList + 0x71, g4);
                            vam.WriteByte((IntPtr)EntityList + 0x72, b4);
                            
                        }

                        
                        int thisPtr = (int)(EngineDll + 0x59205C - 0x2c);
                        byte[] bytearray = BitConverter.GetBytes(brightness);
                        int intbrightness = BitConverter.ToInt32(bytearray, 0);
                        int xored = intbrightness ^ thisPtr;
                        vam.WriteInt32((IntPtr)EngineDll + 0x59205C, xored);
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
                int i = 1;
                if (Glow_esp == false)
                {
                    break;
                }

                do
                {
                    int adress = bClient + Offsets.LocalPlayer;
                    int Player = vam.ReadInt32((IntPtr)adress);


                    adress = Player + Offsets.Team;
                    int MyTeam = vam.ReadInt32((IntPtr)adress);

                    adress = bClient + Offsets.EntityList + (i - 1) * 0x10;
                    int EntityList = vam.ReadInt32((IntPtr)adress);
                    adress = EntityList + Offsets.Health;
                    int health = vam.ReadInt32((IntPtr)adress);



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


                    i++;
                }
                while (i < 65);

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

        }
       

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();


        }
       

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            r3 = Convert.ToByte(trackBar9.Value);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            g3 = Convert.ToByte(trackBar8.Value);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            b3 = Convert.ToByte(trackBar7.Value);
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

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            brightness = trackBar13.Value;
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
            string text = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (text == "CZ75-Auto")
            {
                gunid = 63;
            }
            if (text == "Desert Eagle")
            {
                gunid = 1;
            }
            if (text == "R8 Revolver")
            {
                gunid = 64;
            }
            if (text == "Dual Berettas")
            {
                gunid = 2;
            }
            if (text == "Five-Seven")
            {
                gunid = 3;
            }
            if (text == "Glock-18")
            {
                gunid = 4;
            }
            if (text == "P2000")
            {
                gunid = 32;
            }
            if (text == "P250")
            {
                gunid = 36;
            }
            if (text == "Tec-9")
            {
                gunid = 30;
            }
            if (text == "USP-S")
            {
                gunid = 61;
            }
            if (text == "AK-47")
            {
                gunid = 7;

            }
            if (text == "AUG")
            {
                gunid = 8;
            }
            if (text == "AWP")
            {
                gunid = 9;
            }
            if (text == "FAMAS")
            {
                gunid = 10;
            }
            if (text == "G3SG1")
            {
                gunid = 11;
            }
            if (text == "Galil AR")
            {
                gunid = 13;
            }
            if (text == "M4A1-s")
            {
                gunid = 60;
            }
            if (text == "M4A4")
            {
                gunid = 16;
            }
            if (text == "SCAR-20")
            {
                gunid = 38;
            }
            if (text == "SG 553")
            {
                gunid = 39;
            }
            if (text == "SSG08")
            {
                gunid = 40;
            }
            if (text == "MAC 10")
            {
                gunid = 17;
            }
            if (text == "MP7")
            {
                gunid = 33;
            }
            if (text == "MP9")
            {
                gunid = 34;
            }
            if (text == "Bizon")
            {
                gunid = 26;
            }
            if (text == "P90")
            {
                gunid = 19;
            }
            if (text == "UMP-45")
            {
                gunid = 24;
            }
            if (text == "M249")
            {
                gunid = 14;
            }
            if (text == "Negev")
            {
                gunid = 28;
            }
            if (text == "Sawed Off")
            {
                gunid = 29;
            }
            if (text == "XM1014")
            {
                gunid = 25;
            }
            if (text == "Nova")
            {
                gunid = 35;
            }
            if (text == "MAG-7")
            {
                gunid = 27;
            }

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
            SkinChamgerBool2 = true;
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

        private void button11_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
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
            panel1.Hide();
            panel2.Show();
            panel3.Hide();

        }

    
        

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            if (FOV == false)
            {
                FOV = true;
                FOV2 = true;
            }
            else
            {
                FOV = false;
                FOV2 = false;
            }
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            r4 = Convert.ToByte(trackBar12.Value);
        }
        
        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            g4 = Convert.ToByte(trackBar11.Value);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            b4 = Convert.ToByte(trackBar10.Value);
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

            panel1.Hide();
            panel2.Hide();
            panel3.Show();
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

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            r2 = trackBar4.Value / divide;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            g2 = trackBar5.Value / divide;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            b2 = trackBar6.Value / divide;
        }

       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r = trackBar1.Value / divide ;

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            g = trackBar2.Value / divide;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           b =  trackBar3.Value / divide ;

        }
    }
}
