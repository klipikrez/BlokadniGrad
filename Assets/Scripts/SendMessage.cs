using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendMessage : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject prefabMessage;
    public void Send()
    {
        Message message = Instantiate(prefabMessage, transform).GetComponent<Message>();
        message.SetText(input.text);
        input.text = "";
    }
}
