using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField] private float maxStrength;
    [SerializeField] private string ballTag;
    private float currentStrength;
    private List<GameObject> ballsToLaunch;
    private bool isHolding;

    private void Awake()
    {
        ballsToLaunch = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ballTag))
        {
            AddBall(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ballsToLaunch.Contains(collision.gameObject))
            ballsToLaunch.Remove(collision.gameObject);
    }

    private void Update()
    {
        // TODO: remove this, debug
        if (Input.GetKeyDown(KeyCode.V))
        {
            BeginHold();
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Release();
        }

        if (isHolding)
        {
            currentStrength += Time.deltaTime;
        }
    }

    public void BeginHold()
    {
        isHolding = true;
    }

    public void Release()
    {
        isHolding = false;
        currentStrength = Mathf.Clamp(currentStrength, 0, 1);
        Vector2 force = Vector2.zero;
        force.y = 1 + (currentStrength * maxStrength);
        foreach (GameObject ball in ballsToLaunch)
        {
            ball.GetComponent<Rigidbody2D>().AddForce(force, ForceMode2D.Impulse);
        }
        currentStrength = 0;
    }

    private void AddBall(GameObject ballObject)
    {
        if (!ballsToLaunch.Contains(ballObject))
        {
            ballsToLaunch.Add(ballObject);
        }
    }
}
