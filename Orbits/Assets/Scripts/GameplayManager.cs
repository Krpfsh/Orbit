using System.Collections;
using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _scorePrefab;

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
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GoToMainMenu();
    }
}
