using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BootManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public PlayerMovement playerMovement;

public void Awake()
{

        playerMovement = Instantiate(playerPrefab,Vector3.zero,quaternion.identity).GetComponent<PlayerMovement>();
    
}

}
