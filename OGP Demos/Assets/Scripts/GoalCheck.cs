using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class GoalCheck : NetworkBehaviour
{
    [SerializeField]
    GoalCalculator goalCalculator_Script;
    //[SerializeField]
    //GoalUI goalUI_Script;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsServer)
        {
            if (collision.CompareTag("Ball") && transform.name == "LeftGoal")
            {
                goalCalculator_Script.GoalLeft();
                Debug.Log("leftGoal");
            }
            else if (collision.CompareTag("Ball") && transform.name == "RightGoal")
            {
                goalCalculator_Script.GoalRight();
                Debug.Log("RightGoal");
            }
        }
    }
}
