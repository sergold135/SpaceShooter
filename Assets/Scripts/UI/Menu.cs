using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Settings _settingsWindow;

    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _settings;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnStartButtonClicked);
        _exit.onClick.AddListener(OnExitButtonClicked);
        _settings.onClick.AddListener(OnSettingsButtonClicked);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnStartButtonClicked);
        _exit.onClick.RemoveListener(OnExitButtonClicked);
        _settings.onClick.RemoveListener(OnSettingsButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void OnSettingsButtonClicked()
    {
        _settingsWindow.gameObject.SetActive(true);
    }
}
