using UnityEngine;

public class CollisionEntity : MonoBehaviour
{
    [SerializeField] private ScoreHandler ScoreHandler;
    [SerializeField] private int ScoreAmount = 25;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ScoreHandler.AddScore(ScoreAmount);
        }
    }
}
