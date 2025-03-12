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
    public GameObject Put;
    public GameObject Ambient;

    public GameObject Error;
    public GameObject Good;
    public bool uiOpen = false;
    [SerializeField]
    public Data data;
    [NonSerialized]
    public PlayerMovement playerMovement;
    //public PlayerMovement town;
    public static BootManager Instance;
    [NonSerialized]
    public Login login;

    public void Awake()
    {
        data = new Data();

        Instance = this;
        playerMovement = Instantiate(playerPrefab, Vector3.zero, quaternion.identity).GetComponent<PlayerMovement>();
        Instantiate(townPrefab, Vector3.zero, quaternion.identity);
        Instantiate(EventSystemPrefab, Vector3.zero, quaternion.identity);
        Instantiate(Grass, Vector3.zero, quaternion.identity);
        login = Instantiate(Login, Vector3.zero, quaternion.identity).GetComponent<Login>();
        Instantiate(Put, new Vector3(1, -1.3f, 0), quaternion.identity);
        Instantiate(Ambient, Vector3.zero, quaternion.identity);
    }

}
