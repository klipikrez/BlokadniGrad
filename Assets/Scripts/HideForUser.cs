using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForUser : MonoBehaviour
{
    public House house = null;

    // Start is called before the first frame update
    void Start()
    {

        string userInex = BootManager.Instance.login.user.index;
        if (!BootManager.Instance.data.groups[house.houseID].IsAdmin(userInex)) this.gameObject.SetActive(false);
        else this.gameObject.SetActive(true);
    }


}
