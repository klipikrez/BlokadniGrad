using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Unity.Mathematics;
using System.Reflection;

public class Login : MonoBehaviour
{
    public User user = null;
    public GameObject loginUI;
    public GameObject registerUI;
    public List<TMP_InputField> paswordFields = new List<TMP_InputField>();
    // Start is called before the first frame update
    void Start()
    {
        user = null;
        UpdateRank2();
        foreach (TMP_InputField password in paswordFields)
            password.contentType = TMP_InputField.ContentType.Password;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Image progress;
    public TMP_Text experience;
    public GameObject rankParent;

    public void UpdateRank2()
    {
        experience.text = "0";
        progress.fillAmount = 0;
        rankParent.SetActive(false);
    }
    public void UpdateRank()
    {
        //imas 4 slika i jednu ukljuci samo
        //da sredis score i obojenost tj fill (reference na tmp i gameObject)
        if (user == null)
        {
            experience.text = "0";
            progress.fillAmount = 0;
            rankParent.SetActive(false);
        }
        else
        {
            rankParent.SetActive(true);
            experience.text = user.experience.ToString();
            progress.fillAmount = UnityEngine.Random.Range(0.15f, 0.7f);
            GameObject[] child =  {
                rankParent.transform.GetChild(0).gameObject ,
                rankParent.transform.GetChild(1).gameObject ,
                rankParent.transform.GetChild(2).gameObject ,
                rankParent.transform.GetChild(3).gameObject ,
            };
            foreach (GameObject childItem in child)
            {
                childItem.SetActive(false);
            }

            user.UpdateRank();
            Debug.Log(user.rank);

            switch (user.rank)
            {
                case 1:
                    child[0].SetActive(true);
                    break;
                case 2:
                    child[1].SetActive(true);
                    break;
                case 3:
                    child[2].SetActive(true);
                    break;
                case 4:
                    child[3].SetActive(true);
                    break;
            }
        }

    }
    public void CloseLoginUi()
    {
        House.ClickedThisFrame = true;
        loginUI.SetActive(false);
        BootManager.Instance.uiOpen = false;
    }

    public void CloseRegisterUi()
    {
        House.ClickedThisFrame = false;
        registerUI.SetActive(false);
        BootManager.Instance.uiOpen = false;
    }
    public void OpenRegisterUi()
    {
        House.ClickedThisFrame = false;
        registerUI.SetActive(true);
        BootManager.Instance.uiOpen = true;
    }
    public void OpenLoginUi()
    {
        House.ClickedThisFrame = false;
        loginUI.SetActive(true);
        BootManager.Instance.uiOpen = true;
    }
    public TMP_InputField usernameLogin;
    public TMP_InputField passwordLogin;
    public GameObject LogOut;
    public GameObject logInButton;
    public void LogIn()
    {
        string username = usernameLogin.text;
        string password = passwordLogin.text;
        user = BootManager.Instance.data.LogIn(username, password);

        if (user == null)
        {
            GameObject error = BootManager.Instance.Error;
            Instantiate(error, Vector3.zero, quaternion.identity);
        }
        else
        {
            GameObject good = BootManager.Instance.Good;
            Instantiate(good, Vector3.zero, quaternion.identity);

            LogOut.SetActive(true);
            loginUI.SetActive(false);
            logInButton.SetActive(false);

            UpdateRank();

        }
        return;
    }
    public void Logout()
    {
        user = null;

        LogOut.SetActive(false);
        logInButton.SetActive(true);

        UpdateRank();

    }

    public void ActivateSignUpUI()
    {
        registerUI.SetActive(true);
        loginUI.SetActive(false);
    }

    public TMP_InputField usernameRegister;
    public TMP_InputField passwordRegister;
    public TMP_InputField indexRegister;
    public TMP_InputField studentMailRegister;
    public TMP_InputField nameRegister;
    public TMP_InputField surenameRegister;
    public void SignIn()
    {
        string username = usernameRegister.text;
        string password = passwordRegister.text;
        string index = indexRegister.text;
        string studentMail = studentMailRegister.text;
        string name = nameRegister.text;
        string surename = surenameRegister.text;
        if (username == "" || password == "" || index == "" || name == "" || surename == "" || studentMail == "")
        {
            GameObject error = BootManager.Instance.Error;
            Instantiate(error, Vector3.zero, quaternion.identity);
            return;
        }

        user = BootManager.Instance.data.SignUp(username, password, index, name, surename);

        if (user == null)
        {
            GameObject error = BootManager.Instance.Error;
            Instantiate(error, Vector3.zero, quaternion.identity);
        }
        else
        {
            GameObject good = BootManager.Instance.Good;
            Instantiate(good, Vector3.zero, quaternion.identity);

            LogOut.SetActive(true);
            registerUI.SetActive(false);
            logInButton.SetActive(false);

            UpdateRank();
        }
        return;
    }

    public void OpenFile()
    {
#if UNITY_EDITOR
        string path = EditorUtility.OpenFilePanel("Izaberi fajl", "", "txt");
        if (!string.IsNullOrEmpty(path))
        {
        }
#else
#endif
    }
}
