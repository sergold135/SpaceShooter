using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Settings _settings;

    [SerializeField] private Button _start;
    [SerializeField] private Button _exit;

    private void OnEnable()
    {
        _start.onClick.AddListener(OnStartButtonClicked);
        _exit.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDisable()
    {
        _start.onClick.RemoveListener(OnStartButtonClicked);
        _exit.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
