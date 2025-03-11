using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BootManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject townPrefab;
    public GameObject EventSystemPrefab;
    public GameObject Grass;
    [NonSerialized]
    public PlayerMovement playerMovement;
    //public PlayerMovement town;

    public void Awake()
    {

        playerMovement = Instantiate(playerPrefab, Vector3.zero, quaternion.identity).GetComponent<PlayerMovement>();
        Instantiate(townPrefab, Vector3.zero, quaternion.identity);
        Instantiate(EventSystemPrefab, Vector3.zero, quaternion.identity);
        Instantiate(Grass, Vector3.zero, quaternion.identity);
    }

}
