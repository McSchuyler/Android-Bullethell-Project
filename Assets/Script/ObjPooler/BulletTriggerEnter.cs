using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTriggerEnter : MonoBehaviour {

    public string recycleTag;
    public string bulletTag;
    public string damageEnemyTag;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("yeyeye");
        if (collision.gameObject.tag == recycleTag)
        {
            Debug.Log("yeye");
            ObjectPooler.instance.ReturnToPool(bulletTag, gameObject);
        }
    }
}
