using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    float inputX;
    float inputY;
    private Vector2 speed = new Vector2(10, 10);
    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, Time.deltaTime);

        transform.Translate(movement);
    }
}
