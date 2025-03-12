using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Message : MonoBehaviour
{
    public TMP_Text text;
    public void SetText(string s)
    {
        text.text = s;
    }
}
