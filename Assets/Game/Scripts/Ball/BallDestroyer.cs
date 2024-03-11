using UnityEngine;
using UnityEngine.Events;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private string tagToDestroy;
    [SerializeField] private UnityEvent OnEndGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToDestroy))
        {
            collision.gameObject.SetActive(false);
            if (BallSpawner.Instance.currentBallCount <= 0 && !BallSpawner.Instance.BallInPlay())
            {
                OnEndGame.Invoke();
            }
        }
    }
}