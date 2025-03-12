using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OutlineFx;
using System;
using TMPro;

public class House : MonoBehaviour
{
    public static bool uiOpen = false;
    public static bool ClickedThisFrame = false;
    public GameObject uiMaster;
    public int houseID;
    public HideForUser hideForUser;
    public TMP_Text title;
    public TMP_Text description;

    public void Start()
    {
        CloseUi();
        title.text = BootManager.Instance.data.groups[houseID].name;
        description.text = BootManager.Instance.data.groups[houseID].description;
        gameObject.transform.Find("Graphic").gameObject.AddComponent<PolygonCollider2D>();
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
        hideForUser.Check();
    }

    public void CloseUi()
    {
        House.ClickedThisFrame = true;
        uiMaster.SetActive(false);
        uiOpen = false;
    }
}
