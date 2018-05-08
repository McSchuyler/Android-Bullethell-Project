using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLinearMovement : MonoBehaviour {

    public enum Mode
    {
        normal,
        slowDown,
        speedUp
    };

    public Mode currentMode = Mode.normal;

    public float speed = 3f;

    public float acc = 0.5f;

    private void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);

        if(currentMode ==  Mode.slowDown)
        {
            speed -= acc * Time.deltaTime;
        }
    }
}
