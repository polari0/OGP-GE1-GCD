using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class GoalCalculator : NetworkBehaviour
{
    [SerializeField]
    GameObject ball;
    [SerializeField]
    GoalUI goalUI_script;

    [SerializeField]
    private GameObject leftGoal_Goal;
    [SerializeField]
    private GameObject rightGoal_Goal;

    public NetworkVariable<int> leftGoal = new NetworkVariable<int>(0);
    public NetworkVariable<int> rightGoal = new NetworkVariable<int>(0);

    //private void Awake()
    //{
    //    if (IsServer)
    //    {
    //        leftGoal_Goal = GameObject.FindGameObjectWithTag("LeftGoal");
    //        rightGoal_Goal = GameObject.FindGameObjectWithTag("RightGoal");
    //    }
    //}

    //private void Start()
    //{
    //    if (IsServer)
    //    {
    //        leftGoal_Goal.GetComponent<BoxCollider2D>();
    //        rightGoal_Goal.GetComponent<BoxCollider2D>();
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (IsServer)
    //    {
    //        if (collision.tag == "Ball" && collision.)
    //        {
    //            GoalLeft();
    //            Debug.Log(leftGoal);
    //            ResetBallPosition();
    //            DestroyGameObject();
    //        }
    //        else if (collision.tag == "Ball")
    //        {
    //            GoalRight();
    //            Debug.Log(rightGoal);
    //            ResetBallPosition();
    //            DestroyGameObject();

    //        }
    //    }
    //}
    public void GoalLeft(int goal = 1)
    {
        if (IsServer)
        {
            leftGoal.Value += goal;
            goalUI_script.UpdateGoals();
            goalUI_script.UpdateGoalsClientRPC();
        }
    }

    public void GoalRight(int goal = 1)
    {
        if (IsServer)
        {
            rightGoal.Value += goal;
            goalUI_script.UpdateGoals();
            goalUI_script.UpdateGoalsClientRPC();
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
