using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton
public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public int dayReached;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }

        // load player prefs
        dayReached = PlayerPrefs.GetInt("DayReached");
    }


    // Triggers game over screen in UI
    public void GameOver()
    {
        UIManager.instance.ShowUI(UIManager.GameUI.Lose);
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


}
