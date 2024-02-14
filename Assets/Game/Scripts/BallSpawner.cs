using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int numberToInstanciate;
    private GameObject[] balls;

    private void Awake()
    {
        balls = new GameObject[numberToInstanciate];
        for (int i = 0; i < numberToInstanciate; i++)
        {
            balls[i] = Instantiate(ballPrefab);
            balls[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // TODO: remove me, debug
        if(Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("asd");
            SpawnBall();
        }
    }

    public bool SpawnBall()
    {
        GameObject ball = GetAvailableBall();
        if (ball == null)
            return false;
        ball.transform.position = transform.position;
        ball.gameObject.SetActive(true);
        return true;
    }

    private GameObject GetAvailableBall()
    {
        foreach (GameObject ball in balls)
        {
            if (!ball.gameObject.activeSelf) return ball;
        }
        return null;
    }
}
