using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpDown : MonoBehaviour
{

    [SerializeField]
    Transform liftHigh;

    private float speed = 5f;
    private bool movemenLock;

    private void Update()
    {
        LiftMovement();
    }

    private void LiftMovement()
    {
        if (Input.GetKey(KeyCode.Q) && !movemenLock)
        {
            while (!movemenLock) 
            {
                transform.position = Vector3.MoveTowards(transform.position, liftHigh.position, speed * Time.deltaTime);
                if (movemenLock = true)
                {
                    break;
                }
            }
            
        }
    }

}
