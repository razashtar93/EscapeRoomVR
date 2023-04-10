using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class KeypadController : MonoBehaviour
{
    public string correctPassword;
    string currentPassword = "";
    [SerializeField] private TMP_InputField input;
    [SerializeField] private float resetTime = 3f;
    [Space(5f)]
    [Header("Keypad events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;

    public void KeyEntry(int num)
    {
        currentPassword += num.ToString();
        input.text += num.ToString();
    }

    public void DeleteEntry()
    {
        if (currentPassword.Length == 0)
        {
            return;
        } else
        {
            currentPassword = currentPassword.Remove(currentPassword.Length - 1);
            input.text = currentPassword;
        }
    }

    public void CheckEntry()
    {
        if (correctPassword == currentPassword)
        {
            CorrectPassword();
        } else
        {
            IncorrectPassword();
        }
    }

    private void CorrectPassword()
    {
        onCorrectPassword.Invoke();
    }

    private void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeyboard());
    }

    IEnumerator ResetKeyboard()
    {
        yield return new WaitForSeconds(resetTime);
        currentPassword = "";
        input.text = "";
    }
}
