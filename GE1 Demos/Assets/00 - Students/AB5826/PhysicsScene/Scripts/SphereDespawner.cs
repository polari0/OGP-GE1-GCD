using UnityEngine;

namespace AB5826
{
    public class SphereDespawner : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}