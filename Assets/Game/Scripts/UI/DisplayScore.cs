using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private List<UIPlayerRanking> ListOfScore;
    [SerializeField] private ScoreHandler ScoreHandle;

    void Start()
    {
        ScoreHandle.OnLoadScores();

        ScoreHandle.OnSaveScore();
        DisplayRanking();
    }

    void DisplayRanking()
    {
        int index = 0;
        foreach (var item in ScoreHandle.ListOfPlayerScores)
        {
            if (item == null) return;
            ListOfScore[index].ScoreText.text = item.Score.ToString();
            ListOfScore[index].RankText.text = item.RankID.ToString();
            ListOfScore[index].gameObject.SetActive(true);
            index++;
        }
    }
}