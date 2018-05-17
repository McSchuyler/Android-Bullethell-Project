using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

    public string bulletSpawnTag;
    private GameObject objSpawn;

    public void SpwanBullet(Vector3 position, Quaternion rotation)
    {
        ObjectPooler.instance.SpawnFromPool(bulletSpawnTag, position, rotation);
    }
}
