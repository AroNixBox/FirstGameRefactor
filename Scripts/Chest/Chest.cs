using UnityEngine;

namespace Chest {
    public class Chest : MonoBehaviour {
        // Key that gets spawned when this chest is Destroyed
        [SerializeField] private Key key;
        public void OpenChest(Transform playerTransform) {
            var spawnedKey = Instantiate(key.gameObject, transform.position, Quaternion.identity); // Spawn the Key
            spawnedKey.GetComponent<Key>().Init(playerTransform);
            Destroy(gameObject); // Destroy this Chest
        }
    }
}
