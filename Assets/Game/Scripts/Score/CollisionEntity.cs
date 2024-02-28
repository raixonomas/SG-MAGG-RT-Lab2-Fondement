using UnityEngine;

public class CollisionEntity : MonoBehaviour
{
    [SerializeField] private ScoreHandler ScoreHandler;
    [SerializeField] private int ScoreAmount = 25;
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ScoreHandler.AddScore(ScoreAmount);
        }
    }
}
