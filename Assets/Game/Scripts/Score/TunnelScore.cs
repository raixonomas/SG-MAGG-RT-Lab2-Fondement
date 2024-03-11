using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScore : MonoBehaviour
{
    [SerializeField] private ScoreHandler ScoreHandler;
    [SerializeField] private int Score = 50;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ScoreHandler.AddScore(Score);
        }
    } 
}
