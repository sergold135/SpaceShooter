using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject _closableObject;

    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnCloseButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnCloseButtonClicked);
    }

    private void OnCloseButtonClicked()
    {
        _closableObject.SetActive(false);
    }
}
