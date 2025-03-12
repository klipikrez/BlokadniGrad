using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public User user = null;
    public TMP_InputField[] paswordFields;
    public GameObject loginUI;
    public GameObject registerUI;
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
    public void CloseLoginUi()
    {
        Debug.Log("closeui " + gameObject.name);
        House.ClickedThisFrame = true;
        loginUI.SetActive(false);
        BootManager.Instance.uiOpen  = false;
    }

    public void CloseRegisterUi()
    {
        Debug.Log("closeui " + gameObject.name);
        House.ClickedThisFrame = false;
        registerUI.SetActive(false);
        BootManager.Instance.uiOpen = false;
    }
    public void OpenRegisterUi()
    {
        Debug.Log("closeui " + gameObject.name);
        House.ClickedThisFrame = false;
        registerUI.SetActive(true);
        BootManager.Instance.uiOpen = true;
    }
    public void OpenLoginUi()
    {
        Debug.Log("closeui " + gameObject.name);
        House.ClickedThisFrame = false;
        loginUI.SetActive(true);
        BootManager.Instance.uiOpen = true;
    }

    public void LogIn()
    {
        string username = "";
        string password = "";
        user = BootManager.Instance.data.LogIn(username,password);

        return;
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
