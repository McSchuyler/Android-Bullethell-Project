using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningMovement : MonoBehaviour {

    public float rotationSpeed = 10f;

    private void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }
}
