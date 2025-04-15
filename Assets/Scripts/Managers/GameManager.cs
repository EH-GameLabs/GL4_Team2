using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
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
}
