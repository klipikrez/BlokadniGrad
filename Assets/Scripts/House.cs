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
    public int houseID;

    public void Start()
    {
        CloseUi();
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
        Debug.Log("openui " + gameObject.name);
        uiMaster.SetActive(true);
        uiOpen = true;
    }

    public void CloseUi()
    {
        Debug.Log("closeui " + gameObject.name);
        House.ClickedThisFrame = true;
        uiMaster.SetActive(false);
        uiOpen = false;
    }
}
