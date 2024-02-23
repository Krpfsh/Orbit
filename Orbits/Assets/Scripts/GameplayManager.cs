using System.Collections;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _scorePrefab;

    [SerializeField] private TMP_Text _scoreTextFinal;
    [SerializeField] private TMP_Text _bestScoreTextFinal;
    [SerializeField] private GameObject _gameOverObj;
    [SerializeField] private GameObject _playerObj;

    private int score;

    private void Awake()
    {
        GameManager.Instance.IsInitialized = true;

        score = 0;
        _scoreText.text = score.ToString();
        SpawnScore();
    }

    public void UpdateScore()
    {
        score++;
        _scoreText.text = score.ToString();
        SpawnScore();
    }

    private void SpawnScore()
    {
        Instantiate(_scorePrefab);
    }

    public void GameEnded()
    {
        GameManager.Instance.CurrentScore = score;

        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if (highScore < currentScore)
        {
            GameManager.Instance.HighScore = currentScore;
        }
        _scoreTextFinal.text = GameManager.Instance.CurrentScore.ToString();
        _bestScoreTextFinal.text = GameManager.Instance.HighScore.ToString();
        _playerObj.gameObject.SetActive(false);
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        _gameOverObj.SetActive(true);

    }
    public void RestartButton()
    {
        GameManager.Instance.GoToGameplay();
    }
}
