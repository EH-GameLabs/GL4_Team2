using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public enum GameUI
    {
        NONE,
        MainMenu,
        HUD,
        Dialogue,
        Pause,
        Win,
        Lose,
        Option,
    }

    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();
    public Transform UIContainer;
    private GameUI currentActiveUI = GameUI.NONE;
    public GameUI startingGameUI;
    public GameObject dialoguePanel;

    public void RegisterUI(GameUI uiType, IGameUI uiToRegister)
    {
        registeredUIs.Add(uiType, uiToRegister);
    }

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(gameObject);
        instance = this;

        foreach (IGameUI enumeratedUI in UIContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUI.GetUIType(), enumeratedUI);
        }

        ShowUI(startingGameUI); // TODO -> SHOW MAIN MENU FIRST
    }

    public void ShowUI(GameUI uiType)
    {
        foreach (KeyValuePair<GameUI, IGameUI> kvp in registeredUIs)
        {
            kvp.Value.SetActive(kvp.Key == uiType);
        }

        currentActiveUI = uiType;
    }

    public GameUI GetCurrentActiveUI()
    {
        return currentActiveUI;
    }

    // Prints text to the dialogue panel for a given duration
    public void PrintDialogue(string _text, float _duration)
    {
        TextMeshProUGUI dialogueBox = dialoguePanel.GetComponentInChildren<TextMeshProUGUI>();
        dialogueBox.text = _text;
        dialoguePanel.SetActive(true);
        dialoguePanel.GetComponent<DialogueUI>().SetTime(_duration);
    }
}