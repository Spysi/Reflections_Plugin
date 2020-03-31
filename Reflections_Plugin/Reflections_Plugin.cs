using MSCLoader;
using UnityEngine;
using System.Collections;
using System;

namespace Reflections_Plugin
{
    public class Reflections_Plugin : Mod
    {
        public override string ID => "Reflections_Plugin"; //Your mod ID (unique)
        public override string Name => "Reflections Plugin"; //You mod name
        public override string Author => "Spysi"; //Your Username
        public override string Version => "1.0.0"; //Version
        GameObject reflections;
        //Vector3 Player_pos;

        // Set this to true if you will be load custom assets from Assets folder.
        // This will create subfolder in Assets folder for your mod.
        public override bool UseAssetsFolder => true;

        public override void OnLoad()
        {
            AssetBundle ab = LoadAssets.LoadBundle(this, "reflections");
            //cube = ab.LoadAsset<GameObject>("Cube");
            //Player_pos = GameObject.Find("PLAYER").transform.position;
            GameObject.Destroy(GameObject.Find("MAP").transform.GetChild(10).GetChild(2).GetComponents<Component>()[3]);
            GameObject.Destroy(GameObject.Find("MAP").transform.GetChild(9).GetComponents<Component>()[2]);
            GameObject.Destroy(GameObject.Find("RefProbeGarage"));
            //cube.tag = "PART";
            //cube.layer = LayerMask.NameToLayer("Parts");
            /*
            for (int i = 0; i < 32; i++)
            {
                ModConsole.Print(LayerMask.LayerToName(i) + " " + i);
            }
            */

            reflections = ab.LoadAsset<GameObject>("Reflections");

            for (int i = 0; i < reflections.transform.childCount; i++)
            {
                reflections.transform.GetChild(i).gameObject.AddComponent<ReflectionUpdate>();
            }
            GameObject.Instantiate(reflections, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

            //GameObject.Destroy(GameObject.Find("Reflections(Clone)"));
            ab.Unload(false);
            ModConsole.Print("Reflections Plugin was loaded.");

        }
        public static Settings UpdateSlider = new Settings("update", "Time to update reflections in seconds", 7);
        public static Settings TextureSlider = new Settings("texture", "Texture resolution (16 px - 2048 px)", 4);
        public override void ModSettings()
        {
            Settings.AddSlider(this, UpdateSlider, 1, 90);
            Settings.AddSlider(this, TextureSlider, 1, 8);
        }
    }
}
