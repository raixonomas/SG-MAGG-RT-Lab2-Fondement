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
            SortPlayer();
            FileReader.Serialize(SaveFileName, ListOfPlayerScores);
        }
    }
//need to do a custom sort
    private void SortPlayer()
    {
       var SortItem = ListOfPlayerScores.ToArray().OrderBy(item =>item.Score);
       int index = 1;
       foreach (var item in SortItem)
       {
           item.RankID = index;
           index++;
       }

       ListOfPlayerScores = SortItem.ToHashSet();
       foreach (var item in ListOfPlayerScores)
       {
           Debug.Log("Rank" + item.RankID + " Score " + item.Score);
       }
    }

    public bool HasBeatRank(ScoreItem scoreItem)
    {
        if (ListOfPlayerScores.Count < 4)
        {
            
            scoreItem.RankID = Mathf.Clamp(ListOfPlayerScores.Count + 1, 1, 5);
            if (ListOfPlayerScores.Count == 0)
            {
                ListOfPlayerScores.Add(scoreItem);
                return true;
            }

            foreach (var item in ListOfPlayerScores)
            {
                if (scoreItem.Score > item.Score)
                {
                    ListOfPlayerScores.Add(scoreItem);
                    return true;
                }
            }

            return false;
        }

        foreach (var item in ListOfPlayerScores)
        {
            if (scoreItem.Score > item.Score)
            {
                item.Score = scoreItem.Score;
                scoreItem.RankID = item.RankID;
                return true;
            }
        }

        return false;
    }
    

    public void ResetPlayerScore()
    {
        PlayerData.Score = 0;
        PlayerData.RankID = -1;
    }
}


