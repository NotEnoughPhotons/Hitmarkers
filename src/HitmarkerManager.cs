using System.Collections.Generic;

using UnityEngine;

using BoneLib;
using Il2CppInterop.Runtime.Attributes;
using NEP.Hitmarkers.Data;

namespace NEP.Hitmarkers
{
    public static class HitmarkerManager
    {
        [HideFromIl2Cpp]
        public static MarkerSkin Skin { get; private set; }
        [HideFromIl2Cpp]
        public static MarkerSkin FavoriteSkin => DataManager.GetMarkerSkin(Options.FavoriteSkin);
        [HideFromIl2Cpp]
        public static MarkerSkin DefaultSkin => DataManager.GetMarkerSkin("Default");

        private static List<Hitmarker> _hitmarkers;
        private static List<Hitmarker> _finishers;

        private static int _markerCount = 64;

        private static Transform _poolHitmarker;
        private static Transform _poolFinisher;

        internal static void Initialize()
        {
            BuildPools();

            _hitmarkers = new List<Hitmarker>();
            _finishers = new List<Hitmarker>();

            for(int i = 0; i < _markerCount; i++)
            {
                _hitmarkers.Add(BuildHitmarker(isFinisher: false));
                _finishers.Add(BuildHitmarker(isFinisher: true));
            }
        }

        private static void BuildPools()
        {
            _poolHitmarker = new GameObject("Hitmarker Pool").transform;
            _poolFinisher = new GameObject("Finisher Pool").transform;
        }

        private static Hitmarker BuildHitmarker(bool isFinisher)
        {
            string name = !isFinisher ? "Hitmarker" : "Finisher";
            GameObject marker = GameObject.Instantiate(Data.DataManager.GetGameObject("Hitmarker"));

            marker.name = name;
            marker.hideFlags = HideFlags.DontUnloadUnusedAsset;

            marker.transform.parent = !isFinisher ? _poolHitmarker : _poolFinisher;

            // stops the loudest noise i've ever heard
            marker.gameObject.SetActive(false);

            return marker.AddComponent<Hitmarker>();
        }

        private static Hitmarker GetInactiveMarker(bool finisher)
        {
            var list = !finisher ? _hitmarkers : _finishers;

            for(int i = 0; i < list.Count; i++)
            {
                if (!list[i].gameObject.activeInHierarchy)
                {
                    return list[i];
                }
            }

            return null;
        }

        public static void SetMarkerSkin(MarkerSkin skin)
        {
            Skin = skin;
        }

        public static void SpawnMarker(Vector3 position, bool finisher = false)
        {
            if (!Data.Options.EnableHitmarkers)
            {
                return;
            }

            Hitmarker marker = GetInactiveMarker(finisher);
            marker.IsFinisher = finisher;
            marker.transform.position = position;
            marker.gameObject.SetActive(true);

            float distance = Vector3.Distance(marker.transform.position, Player.Head.position);

            if(distance < 5)
            {
                marker.transform.localScale = Vector3.one;
            }
            else
            {
                marker.transform.localScale = Vector3.one * Mathf.Pow(2f, 1 + (distance / 50));
            }
        }
    }
}
