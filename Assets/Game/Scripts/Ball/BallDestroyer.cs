using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private string tagToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tagToDestroy))
            collision.gameObject.SetActive(false);
    }
}
