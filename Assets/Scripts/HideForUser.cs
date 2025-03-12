using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForUser : MonoBehaviour
{
    public House house = null;

    // Start is called before the first frame update
    public void Check()
    {

        Debug.Log("babababa");
        string userInex = BootManager.Instance.login.user != null ? BootManager.Instance.login.user.index : "babababababa";

        gameObject.SetActive(BootManager.Instance.data.groups[house.houseID].IsAdmin(userInex));
        Debug.Log(gameObject.activeSelf + " " + BootManager.Instance.data.groups[house.houseID].user_role[0].index + " " + BootManager.Instance.data.groups[house.houseID].user_role[0].role);
    }


}
