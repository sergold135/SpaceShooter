using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private Text _score;
    [SerializeField] private Text _records;

    private RectTransform _rectTransform;

    private void OnEnable()
    {
        _rectTransform = GetComponent<RectTransform>();

        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        StartCoroutine(Animating());
    }

    private IEnumerator Animating()
    {
        float scaleY = 0;

        while (scaleY < 1)
        {
            scaleY += Time.deltaTime * _speed;
            _rectTransform.localScale = new Vector3(1, scaleY, 1);
            yield return null;
        }

        
        yield return new WaitForSeconds(1);
        _gameOverMenu.SetActive(true);
        _score.text = $"Счёт: {_player.Score}";

        if (_player.Score > PlayerPrefs.GetInt("Record"))
        {
            _records.text = "Новый рекорд!";
        }
        else
        {
            _records.text = $"Рекорд: {PlayerPrefs.GetInt("Record")}";
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
