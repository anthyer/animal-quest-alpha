using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] TextMeshProUGUI missingCoinsText;
    [SerializeField] GameObject missingCoinsIcon;
    [SerializeField] GameObject coinsIcon;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] List<GameObject> animalsPrefabs;
    Vector3 spawnPos = new Vector3(0, 3, 0);

    public bool paused;
    public bool isGameActive;
    
    public static int coinsCollected;
    public static GameManager instance { get; private set; }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        isGameActive = true;
        coinsIcon.SetActive(true);
        coinsText.text = "Stars : " + 0;
        coinsCollected = 0;
        Time.timeScale = 1;

        if (MainManager.instance.playerAnimal == 1)
        {
            Instantiate(animalsPrefabs[0], spawnPos, animalsPrefabs[0].transform.rotation);
        }
        if (MainManager.instance.playerAnimal == 2)
        {
            Instantiate(animalsPrefabs[1], spawnPos, animalsPrefabs[0].transform.rotation);
        }
        if (MainManager.instance.playerAnimal == 3)
        {
            Instantiate(animalsPrefabs[2], spawnPos, animalsPrefabs[0].transform.rotation);
        }
    }

    public void CheckForPaused()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            pauseScreen.SetActive(true);            
        }
        else
        {
            paused = false;
            Time.timeScale = 1;
            pauseScreen.SetActive(false);            
        }
    }

    public void UpdateCoins(int coinsToAdd)
    {
        coinsCollected += coinsToAdd;
        coinsText.text = "Stars : " + coinsCollected;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        coinsIcon.SetActive(false);
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        CheckForPaused();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void RestartGameOver()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public IEnumerator ShowMessage (string message, float delay)
    {
        missingCoinsText.text = message;
        missingCoinsIcon.SetActive(true);
        yield return new WaitForSeconds(3);
        missingCoinsIcon.SetActive(false);
    }
}
