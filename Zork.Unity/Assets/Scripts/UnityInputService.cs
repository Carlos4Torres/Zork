using UnityEngine;
using Zork;
using TMPro;
using System;

public class UnityInputService : MonoBehaviour, IInputService
{
    public event EventHandler<string> InputReceived;

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            string inputString = InputField.text;
            if (string.IsNullOrWhiteSpace(inputString) == false)
            {
                InputReceived?.Invoke(this, inputString);
            }

            InputField.text = string.Empty;
        }
    }

    [SerializeField]
    private TMP_InputField InputField;
}
