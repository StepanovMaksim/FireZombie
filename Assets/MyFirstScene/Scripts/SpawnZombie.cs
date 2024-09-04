using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    private void FixedUpdate()
    {
        ObjectPool.instance.SpawnFromPool("zombie", transform.position, Quaternion.identity);
    }
}
