using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class GoalCalculator : NetworkBehaviour
{
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
                ResetBallPosition();
                DestroyGameObject();
            }
            else if (collision.tag == "RightGoal")
            {
                GoalRight();
                Debug.Log(RightGoal);
                ResetBallPosition();
                DestroyGameObject();

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

    internal void ResetBallPosition()
    {
        if (IsServer)
        {
            GameObject go = Instantiate(ball, Vector3.zero, Quaternion.identity);
            go.transform.localScale = new Vector3(10, 10, 10);
            NetworkObject no = go.GetComponent<NetworkObject>();
            no.Spawn();
        }
    }
}
