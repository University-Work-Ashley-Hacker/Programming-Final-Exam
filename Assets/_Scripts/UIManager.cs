using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    private void _startGame()
    {
        _startText.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.StartGame += _startGame;
        GameManager.LoseGame += _loseGame;
    }
    private void OnDisable()
    {
        GameManager.StartGame -= _startGame;
        GameManager.LoseGame -= _loseGame;
    }
    private void _loseGame()
    {
        _gameOverUI.SetActive(true);
        _scoreText.text = "Score: " + GameManager.Gems;
        _highScoreText.text = "High Score: " + ScoreManager.HighScore;
    }

    public void PlayAgainButton()
    {
        SceneManager.LoadScene("ZigZag");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
