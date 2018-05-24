using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotation : MonoBehaviour {

    public float rotationRate;

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationRate);
    }
}
