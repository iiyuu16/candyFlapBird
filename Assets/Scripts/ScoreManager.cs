using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _highScoreText;

    private int _score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentScoreText.text = _score.ToString();

        _highScoreText.text = PlayerPrefs.GetInt("High Score", 0).ToString();
        UpdateHighScore();
    }

    public void UpdateHighScore()
    {
        if (_score > PlayerPrefs.GetInt("High Score"))
        {
            PlayerPrefs.SetInt("High Score", _score);
            _highScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        UpdateHighScore();
    }

    public void CandyPower()
    {
        _score += 5;
        UpdateScore();
    }
}
