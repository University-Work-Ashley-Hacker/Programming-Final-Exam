using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;
    [SerializeField] private TextMeshProUGUI _UIScoreText;
    private void _startGame()
    {
        _startText.SetActive(false);
        _UIScoreText.transform.parent.gameObject.SetActive(true);
        _UIScoreText.transform.parent.transform.DOMoveX(100, 1);
    }

    private void OnEnable()
    {
        GameManager.StartGame += _startGame;
        GameManager.GemGained += ShowScore;
        GameManager.LoseGame += _loseGame;
    }
    private void OnDisable()
    {
        GameManager.StartGame -= _startGame;
        GameManager.GemGained -= ShowScore;
        GameManager.LoseGame -= _loseGame;
    }
    private void _loseGame()
    {
        _gameOverUI.SetActive(true);
        _UIScoreText.transform.parent.transform.DOMoveX(-300, 1);
        _scoreText.text = "Score: " + GameManager.Gems;
        _highScoreText.text = "High Score: " + ScoreManager.HighScore;
    }

    private void ShowScore()
    {
        _UIScoreText.text = GameManager.Gems.ToString();
    }

    public void PlayAgainButton()
    {
        _UIScoreText.transform.parent.transform.DOKill();
        SceneManager.LoadScene("ZigZag");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
