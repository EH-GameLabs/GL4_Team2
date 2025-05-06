using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlackFade : MonoBehaviour
{
    [SerializeField] float fadeSpeed;
    [SerializeField] float timeToHold;
    [SerializeField] bool fadeToBlack;
    [SerializeField] bool fadeFromBlack;
    bool onlyFadeIn;

    Image blackScreen;
    TextMeshProUGUI textBox;


    private void Awake()
    {
        blackScreen = GetComponent<Image>();
        textBox = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        // pause game and start fading screen
        onlyFadeIn = false;
        fadeToBlack = true;
        textBox.text = "Day " + (DayManager.Instance.currentDayIndex + 1).ToString();
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack) { FadeToBlack(); }
        if (fadeFromBlack) { FadeFromBlack(); }
    }

    void FadeToBlack()
    {
        if(blackScreen.color.a < 1)
        {
            // Add alpha every frame
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a + fadeSpeed);
            textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, blackScreen.color.a);
        }
        else if (onlyFadeIn)
        {
            // Screen is now visible, start timescale again and unset fade
            Time.timeScale = 1.0f;
            fadeFromBlack = false;
            gameObject.SetActive(false);
        }
        else
        {
            // Done fading, start unfading
            StartCoroutine(HoldBlackScreen());
        }
    }

    public void FadeIn()
    {
       onlyFadeIn = true;
    }

    public void FadeOut()
    {
        blackScreen.color = new Color(0, 0, 0, 1); // skip to fading out step
    }

    IEnumerator HoldBlackScreen()
    {
        yield return new WaitForSecondsRealtime(timeToHold);

        fadeFromBlack = true;
        fadeToBlack = false;
    }

    void FadeFromBlack()
    {
        if (blackScreen.color.a > 0)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, blackScreen.color.a - fadeSpeed);
            textBox.color = new Color(textBox.color.r, textBox.color.g, textBox.color.b, blackScreen.color.a);
        }
        else
        {
            // Screen is now visible, start timescale again and unset fade
            Time.timeScale = 1.0f;
            fadeFromBlack = false;
            UIManager.instance.PrintDialogue(DayManager.Instance.currentDay.dialogue, DayManager.Instance.currentDay.dialogueDuration);
            gameObject.SetActive(false);
        }
    }
}
