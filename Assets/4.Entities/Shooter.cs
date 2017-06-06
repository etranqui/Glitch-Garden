using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectilePrefab;
    private GameObject projectileParent;
    [SerializeField]
    private GameObject projectileSpawn;
    private Animator animComponent;
    private AttackerSpawner myLaneSpawner;


    private void Start()
    {
        // Look for existing empty game object as projectile folder. If not, create it
        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }

        // Get game object Animator component
        animComponent = gameObject.GetComponent<Animator>();
        // Get Lane spawner reference
        SetMyLaneSpawner();
    }


    private void FireProjectile()
    {
        // Create new projectile, set parent empty GO and spawn location transform
        GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = projectileSpawn.transform.position;    
    }

    private void Update()
    {
        if (AttackerAheadinLane())
        {
            animComponent.SetBool("IsAttacking", true);
        } else
        {
            animComponent.SetBool("IsAttacking", false);
        }
    }

    private bool AttackerAheadinLane()
    {
        // if no attacker in lane, return false
        if (myLaneSpawner.transform.childCount <= 0)
            return false;

        foreach (Transform child in myLaneSpawner.transform)
        {
            if (child.transform.position.x >= transform.position.x)
                return true;
        }





        //Attacker[] attackerArray = myLaneSpawner.GetComponentsInChildren<Attacker>();

        //foreach (Attacker attacker in attackerArray)
        //{
        //    if (attacker.transform.position.x > transform.position.x)
        //    {
        //        return true;
        //    }
        //}

        return false;
    }

    // loop through all AttackSpawner and assign the one with the same Y position
    private void SetMyLaneSpawner()
    {
        AttackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return ;
            }
        }

        Debug.Log("No Attacker Spawner in Lane");
    }

}
