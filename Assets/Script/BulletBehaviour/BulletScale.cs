using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScale : MonoBehaviour {

    public Vector3 scaleFactor;
    public Vector3 minScale;
    public Vector3 maxScale;

    public string bulletTag;

    public void Update()
    {
        transform.localScale += scaleFactor * Time.deltaTime;

        if (transform.localScale.x <= minScale.x ||
           transform.localScale.y <= minScale.y ||
           transform.localScale.z <= minScale.z)
        {
            ObjectPooler.instance.ReturnToPool(bulletTag, gameObject);
            transform.localScale = Vector3.one;
        }

        if (transform.localScale.x >= maxScale.x ||
          transform.localScale.y >= maxScale.y ||
          transform.localScale.z >= maxScale.z)
        {
            ObjectPooler.instance.ReturnToPool(bulletTag, gameObject);
            transform.localScale = Vector3.one;
        }
    }
}
