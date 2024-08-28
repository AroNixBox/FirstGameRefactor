using Player;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour {
    [field: SerializeField] public Health Player { get; private set; }
    public static ReferenceHolder Instance;
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }
}
