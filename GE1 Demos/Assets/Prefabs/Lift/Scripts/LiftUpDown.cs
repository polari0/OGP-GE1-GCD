using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftUpDown : MonoBehaviour
{
    private Vector3 liftPos;
    [SerializeField]
    GameObject lift;

    private void Awake()
    {
        liftPos = lift.transform.position;
    }    

    private void Update()
    {
        Vector3 PosA = new Vector3(0, 0, 0);
        Vector3 PosB = new Vector3(0, 9, 0);

        //LiftUpDownFunction();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("press detected");
            liftPos = lift.transform.position + PosB;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("press detected");
            liftPos = lift.transform.position - PosB;
        }
        transform.position = liftPos;
    }
}
