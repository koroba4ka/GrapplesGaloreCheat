using UnityEngine;
using MelonLoader;
using CheatGrap;
using UnityEngine.Windows;
using UnityEngine.Playables;
using Il2Cpp;
using HarmonyLib;
using Harmony;

namespace Main
{
    public class ClientMain : MelonMod
    {
        public static bool player_esp = false;
        public static bool gamnoed = false;
        public static bool timer = false;
        public static bool funktia = false;
        public static bool health = false;
        public static bool super = false;
        public static bool superGraphikHook = false;
        public static bool instakill = false;


        //player_esp = GUI.Toggle(new Rect(0, 0, 280, 30), player_esp, "Show ESP");
        //gamnoed = GUI.Toggle(new Rect(0, 30, 280, 30), gamnoed, "Show Crosshair");
        //timer = GUI.Toggle(new Rect(0, 60, 280, 30), timer, "Timer Scale");
        //funktia = GUI.Toggle(new Rect(0, 90, 280, 30), funktia, "funktia");
        public override void OnGUI()
        {
            GUI.Box(new Rect(150, 70, 300, 200), "Menu"); // Increased width and height

            GUILayout.BeginArea(new Rect(160, 90, 280, 160)); // Increased width and height

            player_esp = GUILayout.Toggle(player_esp, "Show ESP");
            gamnoed = GUILayout.Toggle(gamnoed, "Show Crosshair");
            timer = GUILayout.Toggle(timer, "Timer Scale");
            funktia = GUILayout.Toggle(funktia, "Jump Hacker");
            health = GUILayout.Toggle(health, "[BUGGY]Big Health");
            super = GUILayout.Toggle(super, "[BUGGY]super minigan");
            superGraphikHook = GUILayout.Toggle(superGraphikHook, "[BUGGY]SUPER Grappling Hook");
            instakill = GUILayout.Toggle(instakill, "InstaKill");

            GUILayout.EndArea();

            Hacks.LaunchHack();
        }

        //public override void OnUpdate()
        //{
        //    MelonLogger.Msg("[Ibanyti] Fps");
        //}

    }

    public class Hacks
    {
        public static Il2CppSystem.Collections.Generic.List<PlayerGameObjectController> AllPlayers = default!;
        public static GameObject localplayer = default!;


        public static void LaunchHack()
        {
            if (ClientMain.player_esp)
            {
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
                {
                    if (player != null && localplayer != player)
                    {

                        Render.DrawNameESP(player.transform.position, "Player_", new Color(1.0f, 0.0f, 1.0f, 1.0f));

                        
                    }
                }
            }

            if (ClientMain.gamnoed)
            {
                foreach (GameObject player in GameObject.FindGameObjectsWithTag("PlayerTag"))
                {
                    if (player != null && localplayer != player)
                    {
                        Render.DrawCross(player.transform.position, "Player_", new Color(1.0f, 0.0f, 1.0f, 1.0f));
                    }
                }
            }


            if (ClientMain.timer)
            {
                Time.timeScale = 3;
            }
            else Time.timeScale = 1;


            if (ClientMain.funktia)
            {

                PlayerMovement gamer = GameObject.Find("PlayerObject(Clone)").GetComponent<PlayerMovement>();
                gamer.jumpForce = 1600;
            }            
            
            if (ClientMain.health)
            {

                Health heal = GameObject.Find("PlayerObject(Clone)").GetComponent<Health>();
                heal.currentHealth = 13371337;
                heal.maxHealth = 13371337;
            }            
            
            if (ClientMain.super)
            {
                Weapon weapon = GameObject.Find("PlayerObject(Clone)").GetComponent<Weapon>();
                weapon.currentAmmo = 9999;
                weapon.nextTimeToFire = 100;



                RocketLauncher rocket = GameObject.Find("PlayerObject(Clone)").GetComponent<RocketLauncher>();
                rocket.currentAmmo = 9999;
                rocket.nextTimeToFire = 100;


                Shotgun shotgun = GameObject.Find("PlayerObject(Clone)").GetComponent<Shotgun>();
                shotgun.currentAmmo = 9999;
                shotgun.nextTimeToFire = 100;                
                
                
                Crossbow crossbow = GameObject.Find("PlayerObject(Clone)").GetComponent<Crossbow>();
                crossbow.currentAmmo = 9999;
                crossbow.nextTimeToFire = 100;                
                
                
                Machete machca = GameObject.Find("PlayerObject(Clone)").GetComponent<Machete>();
                machca.currentAmmo = 9999;
                machca.nextTimeToFire = 100;                
            }            
            
            if (ClientMain.super)
            {

                GrapplingHook grappling = GameObject.Find("PlayerObject(Clone)").GetComponent<GrapplingHook>();
                grappling.nextTimeToFire = 0;
                grappling.nextTimeToFire = 100;
            }            
            if (ClientMain.instakill)
            {
                Health heal = GameObject.Find("PlayerObject(Clone)").GetComponent<Health>();
                heal.currentHealth = 0;
                heal.maxHealth = 0;
            }
        }
    }
}
