using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Text _score;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int value)
    {
        _score.text = value.ToString();
    }
}
