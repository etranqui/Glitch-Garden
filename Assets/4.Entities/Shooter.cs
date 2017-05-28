using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private GameObject projectileParent;


    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        Debug.Log(name + " firing.");    
    }
}
