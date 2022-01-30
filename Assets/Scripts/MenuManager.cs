using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject titlePanel;
    public GameObject settingsPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
        titlePanel.SetActive(true);
        AudioListener.volume = GameManager.instance.MasterVolume();
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("OperationGameHand");
    }

    public void OnSettingButtonClick()
    {
        titlePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }

    public void OnBackButtonClick()
    {
        settingsPanel.SetActive(false);
        titlePanel.SetActive(true);
    }

    public void ChangeVolume()
    {
        AudioListener.volume = FindObjectOfType<Slider>().value;
        GameManager.instance.setVolume(FindObjectOfType<Slider>().value);
    }

    public void ChangeFontSize()
    {
        GameManager.instance.setFontSize(FindObjectOfType<Slider>().value);
    }
}
