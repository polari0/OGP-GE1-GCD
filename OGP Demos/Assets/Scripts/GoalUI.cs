using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class GoalUI : NetworkBehaviour
{
    [SerializeField]
    TextMeshProUGUI rightScore;
    [SerializeField]
    TextMeshProUGUI leftScore;

    [SerializeField]
    GoalCalculator goalCalculator_Script;

    private void Start()
    {
        if (IsServer)
        {
            rightScore.text = goalCalculator_Script.rightGoal.Value.ToString() + " Goals";
            leftScore.text = goalCalculator_Script.leftGoal.Value.ToString() + " Goals";
        }
    }

    public void UpdateGoals()
    {
        if (IsServer)
        {
            rightScore.text = goalCalculator_Script.rightGoal.Value.ToString() + " Goals";
            leftScore.text = goalCalculator_Script.leftGoal.Value.ToString() + " Goals"; 
        }
    }
}
