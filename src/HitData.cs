using UnityEngine;

using Il2CppSLZ.Marrow;
using Il2CppSLZ.Marrow.AI;
using Il2CppSLZ.Marrow.PuppetMasta;
using Il2CppSLZ.Marrow.Combat;

namespace NEP.Hitmarkers
{
    public struct HitData
    {
        public Projectile projectile;
        public Vector3 worldHit;
        public Collider collider;
        public Attack attack;

        public BehaviourBaseNav behaviour;
        public AIBrain brain;
    }
}
