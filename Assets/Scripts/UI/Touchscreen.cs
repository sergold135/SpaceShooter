using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Touchscreen : MonoBehaviour
{
    [SerializeField] private Button _attack;

    public event UnityAction AttackButtonPressed;

    private void OnEnable()
    {
        _attack.onClick.AddListener(OnAttackButtonClicked);
    }

    private void OnDisable()
    {
        _attack.onClick.RemoveListener(OnAttackButtonClicked);
    }

    private void OnAttackButtonClicked()
    {
        AttackButtonPressed?.Invoke();
    }
}
