using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public TMP_InputField[] paswordFields;
    // Start is called before the first frame update
    void Start()
    {
        foreach (TMP_InputField password in paswordFields)
            password.contentType = TMP_InputField.ContentType.Password;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenFile()
    {
#if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel("Izaberi fajl", "", "txt");
        if (!string.IsNullOrEmpty(path))
        {
            Debug.Log("Izabran fajl: " + path);
        }
#else
        Debug.Log("File dialog je dostupan samo u editoru.");
#endif
    }
}
