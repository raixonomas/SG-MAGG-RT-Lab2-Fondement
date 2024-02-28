using UnityEngine;

public class BallSpawner : Manager<BallSpawner>
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private int numberToInstanciate;
    [SerializeField] private bool multiBallMode;
    private GameObject[] balls;
    public int currentBallCount { get; private set; }

    protected override void Awake()
    {
        balls = new GameObject[numberToInstanciate];
        for (int i = 0; i < numberToInstanciate; i++)
        {
            balls[i] = Instantiate(ballPrefab);
            balls[i].gameObject.SetActive(false);
        }
        currentBallCount = numberToInstanciate;
    }

    private void Update()
    {
        // TODO: remove me, debug
        if (Input.GetKeyDown(KeyCode.T))
        {
            bool spawned = SpawnBall();
            Debug.Log("Ball Spawn: " + spawned);
        }
        //TODO: replace me
        if (Input.GetKeyDown(KeyCode.G))
        {
            multiBallMode = !multiBallMode;
            Debug.Log("Multi ball: " + multiBallMode);
        }
    }

    public bool SpawnBall()
    {
        if (BallInPlay() && !multiBallMode)
            return false;
        if (currentBallCount <= 0)
            return false;

        GameObject ball = GetAvailableBall();
        if (ball == null)
            return false;
        ball.transform.position = transform.position;
        ball.gameObject.SetActive(true);
        currentBallCount--;
        return true;
    }

    public bool BallInPlay()
    {
        foreach (GameObject ball in balls)
        {
            if (ball.gameObject.activeSelf) return true;
        }
        return false;
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
