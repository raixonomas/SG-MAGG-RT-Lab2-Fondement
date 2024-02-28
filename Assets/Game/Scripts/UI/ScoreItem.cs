[System.Serializable]
public class ScoreItem
{
    public int RankID;
    public int Score;

    public ScoreItem(int RankID, int Score)
    {
        this.RankID = RankID;
        this.Score = Score;
    }
}