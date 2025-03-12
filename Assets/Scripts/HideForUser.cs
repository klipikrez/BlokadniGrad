using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideForUser : MonoBehaviour
{
    public House house = null;
    public bool hideIfNotAdmin = false;
    public bool HideForGuest = true;
    public bool HideToNonMember = true;
    public bool ShowToNonMember = false;

    // Start is called before the first frame update
    public void Check()
    {
        gameObject.SetActive(true);
        Debug.Log("babababa");
        string userInex = BootManager.Instance.login.user != null ? BootManager.Instance.login.user.index : "babababababa";

        if (HideForGuest && gameObject.activeSelf)
        {

            gameObject.SetActive(BootManager.Instance.login.user != null);
        }

        if (hideIfNotAdmin && gameObject.activeSelf)
            gameObject.SetActive(BootManager.Instance.data.groups[house.houseID].IsAdmin(userInex));
        if (HideToNonMember && gameObject.activeSelf)
        {
            Debug.Log("HideToNonMember if not join" + BootManager.Instance.data.groups[house.houseID].IsInGroup(userInex));
            gameObject.SetActive(BootManager.Instance.data.groups[house.houseID].IsInGroup(userInex));
        }
        if (ShowToNonMember && gameObject.activeSelf)
        {
            Debug.Log("showIfNotJoined if not join" + BootManager.Instance.data.groups[house.houseID].IsInGroup(userInex));
            gameObject.SetActive(!BootManager.Instance.data.groups[house.houseID].IsInGroup(userInex));
        }

    }


}
