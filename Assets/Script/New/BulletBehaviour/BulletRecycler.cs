using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRecycler : MonoBehaviour {

    public bool recycleByTime;
    public float timeWaitToRecycle;
    public bool recycleByCollide;

    public string bulletTag;

    public void OnEnable()
    {
        if(recycleByTime == true)
        {
            Invoke("Recycle", timeWaitToRecycle);
        }
    }

    public void Recycle()
    {
        ObjectPooler.instance.ReturnToPool(bulletTag, gameObject);
    }
}
