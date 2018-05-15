using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletRotation))]
[RequireComponent(typeof(BulletLinearMovement))]
public class BulletSpear : MonoBehaviour {

    public float aimTime = 2f;
    public float waitToShoot = 1f;
    public float aimRotationRate = 180f;
    public float shootSpeed = 10f;

    private GameObject target;
    private BulletLinearMovement bulletLiner;
    private BulletRotation bulletRotation;

    private enum State
    {
        aim,
        shoot
    };
    private State state;

    private void Awake()
    {
        bulletLiner = GetComponent<BulletLinearMovement>();
        bulletRotation = GetComponent<BulletRotation>();

        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        ResetBullet();
        state = State.aim;
        StartCoroutine(Aiming());
    }

    private void ResetBullet()
    {
        bulletLiner.speed = 0f;
        bulletRotation.rotationRate = 0f;

    }

    IEnumerator Aiming()
    {
        float timePass = 0f;
        while(state == State.aim)
        {
            Vector2 dir = target.transform.position - transform.position;
            dir.Normalize();
            float rotateAmount = Vector3.Cross(dir, transform.up).z;

            bulletRotation.rotationRate = -rotateAmount * aimRotationRate;

            timePass += Time.deltaTime;
            if (timePass >= aimTime)
                state = State.shoot;

            yield return null;
        }

        ResetBullet();
        Invoke("Shoot", waitToShoot);
    }

    private void Shoot()
    {
        bulletLiner.speed = shootSpeed;
        StopCoroutine(Aiming());
    }
}
