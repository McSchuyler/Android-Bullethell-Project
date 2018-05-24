using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletRotation))]
public class BulletHoming : MonoBehaviour {
    public float rotationBaseRate = 90f;

    private GameObject target;
    private BulletRotation bulletRotation;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        bulletRotation = GetComponent<BulletRotation>();
    }

    private void Update()
    {
        Vector2 dir = target.transform.position - transform.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, transform.up).z;

        bulletRotation.rotationRate = -rotateAmount*rotationBaseRate;
    }

}
