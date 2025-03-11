using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public static bool uiOpen = false;
    public static bool ClickedThisFrame = false;
    public GameObject uiMaster;

    public void Start()
    {
        CloseUi();
    }

    public void Select()
    {

    }

    public void DeSelect()
    {

    }

    public void Click()
    {
        OpenUi();
    }

    public void OpenUi()
    {
        uiMaster.SetActive(true);
        uiOpen = true;
    }

    public void CloseUi()
    {
        House.ClickedThisFrame = true;
        uiMaster.SetActive(false);
        uiOpen = false;
    }
}
