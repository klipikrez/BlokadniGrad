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
    public GameObject Login;
    [SerializeField]
    public AllData data;
    [NonSerialized]
    public PlayerMovement playerMovement;
    //public PlayerMovement town;
    public static BootManager Instance;

    public void Awake()
    {
        Instance = this;
        playerMovement = Instantiate(playerPrefab, Vector3.zero, quaternion.identity).GetComponent<PlayerMovement>();
        Instantiate(townPrefab, Vector3.zero, quaternion.identity);
        Instantiate(EventSystemPrefab, Vector3.zero, quaternion.identity);
        Instantiate(Grass, Vector3.zero, quaternion.identity);
        Instantiate(Login, Vector3.zero, quaternion.identity);
    }

}
