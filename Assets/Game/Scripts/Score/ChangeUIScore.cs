using TMPro;
using UnityEngine;

public class ChangeUIScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextScore;
    [SerializeField] private ScoreHandler ScoreHandler;

    private void Start()
    {
        ScoreHandler.OnScoreChange.AddListener(UpdateText);
        UpdateText();
    }

    private void UpdateText()
    {
        TextScore.text = ScoreHandler.PlayerData.Score.ToString();
    }

    private void OnDestroy()
    {
        ScoreHandler.OnScoreChange.RemoveListener(UpdateText);

    }
}
