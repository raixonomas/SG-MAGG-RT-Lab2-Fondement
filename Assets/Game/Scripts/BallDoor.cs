using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] string ballTag;
    private List<GameObject> activeBalls;

    private void Awake()
    {
        activeBalls = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ballTag))
        {
            if (!activeBalls.Contains(collision.gameObject))
            {
                activeBalls.Add(collision.gameObject);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (activeBalls.Contains(collision.gameObject))
            activeBalls.Remove(collision.gameObject);
    }

    private void Update()
    {
        if (door)
            door.SetActive(activeBalls.Count == 0);
    }
}
