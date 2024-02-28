using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class ScoreHandler : ScriptableObject
{
    public HashSet<ScoreItem> ListOfPlayerScores = new();
    public bool HasBeenLoad = false;
    [field: SerializeField] public ScoreItem PlayerData { get; private set; }

    private const string SaveFileName = "Score";


    public void OnLoadScores()
    {
        HasBeenLoad = true;
        FileReader.Deserialize(SaveFileName, out ListOfPlayerScores);
    }

    public void OnSaveScore()
    {
        if (!HasBeenLoad)
        {
            OnLoadScores();
        }

        if (HasBeatRank(PlayerData))
        {
            FileReader.Serialize(SaveFileName, ListOfPlayerScores);
        }
    }

    public bool HasBeatRank(ScoreItem scoreItem)
    {
        bool hasBeatScore = false;

        if (ListOfPlayerScores.Count < 5)
        {
            scoreItem.RankID = Mathf.Clamp(ListOfPlayerScores.Count + 1, 1, 5);
            ListOfPlayerScores.Add(scoreItem);
            hasBeatScore = true;
        }
        else
        {
            ScoreItem lowestScore = ListOfPlayerScores.OrderBy(score => score.Score).First();
            if (scoreItem.Score > lowestScore.Score)
            {
                scoreItem.RankID = lowestScore.RankID;
                ListOfPlayerScores.Remove(lowestScore);
                ListOfPlayerScores.Add(scoreItem);

                hasBeatScore = true;
            }
        }
        ListOfPlayerScores = new HashSet<ScoreItem>(ListOfPlayerScores.OrderByDescending(score => score.Score));

        int rankID = 1;
        foreach (var item in ListOfPlayerScores)
        {
            item.RankID = rankID;
            rankID++;
        }
        return hasBeatScore;
    }


    public void ResetPlayerScore()
    {
        PlayerData.Score = 0;
        PlayerData.RankID = -1;
    }
}