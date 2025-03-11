using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (House.uiOpen) return;
        if (House.ClickedThisFrame) { House.ClickedThisFrame = false; return; }
        MouseOver();
        if (Input.GetMouseButtonUp(0))
            ClickOn();
    }
    House curentlyHovering = null;
    public void MouseOver()//mozda ne treba da das da se selektuje enemyObject ako su vec selektovani uniti koji su playerObjects, i ne smes da das da se selektuju objekti koji nisu playerObjects na multycellselecting 
    {
        //algoritam, raycast i nadjes sa najmanjim orderom, ovo ne moze sa obican reycast jer kad se objekti overlapuju ne radi lepo


        // Convert Mouse Position to World Point
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("House");
        // Perform Raycast
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, float.MaxValue, layerMask);

        if (hit.collider == null)
        {
            if (curentlyHovering != null)
            {
                curentlyHovering.DeSelect();
                Debug.Log("deSelected: " + curentlyHovering.gameObject.name);
                curentlyHovering = null;

            }

        }
        else
        {
            if (curentlyHovering == null)
            {
                curentlyHovering = hit.collider.gameObject.transform.parent.GetComponent<House>();
                curentlyHovering.Select();
                Debug.Log("Selected: " + curentlyHovering.gameObject.name);
            }


        }
    }

    public void ClickOn()//mozda ne treba da das da se selektuje enemyObject ako su vec selektovani uniti koji su playerObjects, i ne smes da das da se selektuju objekti koji nisu playerObjects na multycellselecting 
    {
        //algoritam, raycast i nadjes sa najmanjim orderom, ovo ne moze sa obican reycast jer kad se objekti overlapuju ne radi lepo


        // Convert Mouse Position to World Point
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("House");
        // Perform Raycast
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, float.MaxValue, layerMask);

        if (hit.collider != null)
        {
            curentlyHovering = hit.collider.gameObject.GetComponent<House>();
            curentlyHovering.Click();

        }

    }
}
