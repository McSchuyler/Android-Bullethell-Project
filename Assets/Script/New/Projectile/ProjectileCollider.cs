using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour {

    public string damageableTag;
    public float damage;

    private void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == damageableTag)
        {
            IDamageable damageable = col.gameObject.GetComponent<IDamageable>();
            damageable.Damage(damage);
        }
    }
}
