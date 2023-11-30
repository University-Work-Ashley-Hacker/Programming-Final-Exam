using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int HighScore;

    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

    }

    public static void CheckForNewHighScore()
    {
        if (GameManager.Gems > HighScore)
            HighScore = GameManager.Gems;
    }

}
