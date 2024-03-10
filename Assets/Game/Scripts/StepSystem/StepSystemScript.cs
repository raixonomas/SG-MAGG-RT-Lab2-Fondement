using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSystemScript : MonoBehaviour
{
    [SerializeField] private StepScript[] steps;
    [SerializeField] private ScoreHandler ScoreHandler;
    [SerializeField] private int ScoreAmount = 25;

    private int NumberOfStepActivated = 0;

    public void StepTrigger()
    {
        NumberOfStepActivated++;
        ScoreHandler.AddScore(GetScoreToAdd());

        if(NumberOfStepActivated == 4)
            StartCoroutine(ResetSteps());
    }

    private IEnumerator ResetSteps()
    {
        yield return new WaitForSeconds(2);

        foreach (var step in steps)
            step.ResetStep();

        NumberOfStepActivated = 0;
        
    }

    private int GetScoreToAdd()
    {
        return Convert.ToInt32(ScoreAmount * Math.Pow(2, NumberOfStepActivated));
    }
}
