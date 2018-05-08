using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public float focusSpeed = 1.0f;

    private float currentSpeed;

    private void Start()
    {
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

        transform.Translate(h, v, 0);
    }

    public void ToggleMovement(PlayerState.State state)
    {
        if (state == PlayerState.State.normal)
            currentSpeed = moveSpeed;
        else if (state == PlayerState.State.focus)
            currentSpeed = focusSpeed;
    }
}
