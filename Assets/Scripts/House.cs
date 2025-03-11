using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OutlineFx;

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
        GameObject graphic = transform.Find("Graphic").gameObject;
        graphic.GetComponent<OutlineFx.OutlineFx>().enabled = true;
    }

    public void DeSelect()
    {
        GameObject graphic = transform.Find("Graphic").gameObject;
        graphic.GetComponent<OutlineFx.OutlineFx>().enabled = false;
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
