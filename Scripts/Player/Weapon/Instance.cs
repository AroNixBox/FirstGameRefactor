using UnityEngine;

// For a small project this size, this is perfectly fine.
// For bigger ones, work with ScriptableObjects.
namespace Player.Weapon {
    [System.Serializable]
    public class Instance {
        [field: SerializeField] public Fire Weapon { get; private set; }
        [field: SerializeField] public Vector3 PositionOffset { get; private set; }
        [field: SerializeField] public float FireRate { get; private set; }
        [field: SerializeField] public float BulletSpeed { get; private set; } = 500f;
        [field: SerializeField] public Bullet Bullet { get; private set; }
        [field: SerializeField] public float[] BulletAmountAndSpread { get; private set; }
        [field: SerializeField] public uint ReloadTime { get; private set; }
        [field: SerializeField] public uint MaxBulletAmount { get; private set; }
        [field: SerializeField] public AudioClip ShotClip { get; private set; }
        [field: SerializeField] public AudioClip ReloadClip { get; private set; }
    }
}