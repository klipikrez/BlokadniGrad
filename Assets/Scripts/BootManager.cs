using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BootManager : MonoBehaviour
{
    public List<GameObject> componentsToLoad = new List<GameObject>();

public void Awake()
{
    foreach (GameObject component in componentsToLoad)
    {
        Instantiate(component,Vector3.zero,quaternion.identity);
    }
}
}
