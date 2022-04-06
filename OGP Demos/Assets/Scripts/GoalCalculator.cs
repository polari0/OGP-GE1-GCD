using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class GoalCalculator : NetworkBehaviour
{
    [SerializeField]
    ObjectSpawner objectSpawner_Script;
    [SerializeField]
    GameObject ball;

    private NetworkVariable<int> LeftGoal = new NetworkVariable<int>(0);

    private NetworkVariable<int> RightGoal = new NetworkVariable<int>(0);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsServer)
        {
            if (collision.tag == "LeftGoal")
            {
                GoalLeft();
                Debug.Log(LeftGoal);
                objectSpawner_Script.ResetBallPosition();

            }
            else if (collision.tag == "RightGoal")
            {
                GoalRight();
                Debug.Log(RightGoal);
                objectSpawner_Script.ResetBallPosition();

            }
        }
    }
    private void GoalLeft(int goal = 1)
    {
        if (!IsServer)
        {
            LeftGoal.Value += goal;
        }
    }

    private void GoalRight(int goal = 1)
    {
        if (!IsServer)
        {
            RightGoal.Value += goal;
        }
    }

    private void DestroyGameObject()
    {
        Destroy(ball);
    }
}
