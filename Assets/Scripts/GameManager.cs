using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject obstacleSpawn;
    public GameObject powerSpawn;
    public GameObject plyrSpawn;
    public GameObject retyBtn;


    [SerializeField] private GameObject _gameOverCanvas;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        retyBtn.SetActive(true);
    }

    public void PlayGame()
    {
        obstacleSpawn.SetActive(true);
        powerSpawn.SetActive(true);
        plyrSpawn.SetActive(true);
    }

    public void RestartGame()
    {  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit game");
    }
}
