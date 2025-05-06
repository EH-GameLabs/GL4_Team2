using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int dayReached;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance.gameObject);
        }

        // load player prefs
        LoadDay();
    }


    // Triggers game over screen in UI
    public void GameOverFired()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Lose);
    }

    // Triggers second game over screen in UI
    public void GameOverDead()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Lose); // TODO Change to second lose UI
    }

    // Resets the scene after a game over
    public void ReloadGame()
    {
        SceneManager.LoadScene("Giovanni"); // TODO replace with main scene name
    }

    // save player prefs
    public void SaveDay()
    {
        PlayerPrefs.SetInt("DayReached", dayReached);
    }

    public void LoadDay()
    {
        dayReached = PlayerPrefs.GetInt("DayReached");
    }

    public void ResetDays()
    {
        PlayerPrefs.SetInt("DayReached", 0);
        LoadDay();
    }


}
