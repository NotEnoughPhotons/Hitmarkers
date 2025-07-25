using MelonLoader;

using UnityEngine;

using BoneLib.BoneMenu;

using Il2CppSLZ.Marrow.Utilities;

using NEP.Hitmarkers.Data;

namespace NEP.Hitmarkers
{
    public static class BuildInfo
    {
        public const string Name = "Hitmarkers"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Simple hitmarkers mod for BONELAB."; // Description for the Mod.  (Set as null if none)
        public const string Author = "Not Enough Photons"; // Author of the Mod.  (MUST BE SET)
        public const string Company = "Not Enough Photons"; // Company that made the Mod.  (Set as null if none)
        public const string Version = "2.9.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://thunderstore.io/c/bonelab/p/NotEnoughPhotons/Hitmarkers/"; // Download Link for the Mod.  (Set as null if none)
    }
    
    public class Main : MelonMod
    {
        public static MelonLogger.Instance Logger;

        internal const string EmbeddedModule = "NEP.Hitmarkers.Resources.HitmarkersFusionModule.dll";

        public override void OnInitializeMelon()
        {
            Logger = new MelonLogger.Instance("Hitmarkers");

            if (FindMelon("LabFusion", "Lakatrazz") != null)
            {
                var moduleData = BoneLib.HelperMethods.GetResourceBytes(System.Reflection.Assembly.GetExecutingAssembly(), EmbeddedModule);
                var loadedModule = System.Reflection.Assembly.Load(moduleData);

                loadedModule.GetType("NEP.Hitmarkers.ModuleLoader").GetMethod("LoadModule").Invoke(null, null);
            }
            
            DataManager.Initialize();
            Options.Initialize();

            SetupBoneMenu();

            MarrowGame.RegisterOnReadyAction(new System.Action(() => OnMarrowGameStart()));

            BoneLib.Hooking.OnLevelLoaded += (data) =>
            {
                HitmarkerManager.Initialize();
            };
        }

        public void OnMarrowGameStart()
        {
            HitDirector.Initialize();
        }

        private void SetupBoneMenu()
        {
            Page nepPage = Page.Root.CreatePage("Not Enough Photons", Color.white, maxElements: 8, createLink: true);
            Page hitmarkersPage = nepPage.CreatePage("Hitmarkers", Color.white, maxElements: 0, createLink: true);
            Page customMarkersPage = hitmarkersPage.CreatePage("Skins", Color.white, maxElements: 8, createLink: true);

            hitmarkersPage.CreateBool(
                "Enable Hitmarkers", 
                Color.white, 
                Options.EnableHitmarkers, 
                (value) => Options.SetEnableHitmarkers(value));

            hitmarkersPage.CreateFloat(
                "Hitmarker SFX", 
                Color.white,
                Options.HitmarkerSFX,
                10f, 
                0f, 
                100f, 
                (value) => Options.SetHitmarkerVolume(value));

            hitmarkersPage.CreateFloat(
                "Hitmarker Pitch", 
                Color.white, 
                Options.HitmarkerPitch, 
                0.25f, 
                0f, 
                2f, 
                (value) => Options.SetHitmarkerPitch(value));

            var favMarkerPage = hitmarkersPage.CreatePage(
                "Set Default Marker",
                Color.white,
                maxElements: 8);

            for (int i = 0; i < DataManager.Skins.Length; i++)
            {
                int index = i;
                customMarkersPage.CreateFunction(DataManager.Skins[index].SkinName, Color.white, () =>
                {
                    HitmarkerManager.SetMarkerSkin(DataManager.Skins[index]);
                });
            }

            for (int i = 0; i < DataManager.Skins.Length; i++)
            {
                int index = i;
                favMarkerPage.CreateFunction(DataManager.Skins[index].SkinName, Color.white, () =>
                {
                    Options.SetDefaultSkin(DataManager.Skins[index].SkinName);
                });
            }
        }
    }
}