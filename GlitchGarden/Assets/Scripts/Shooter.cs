using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner laneSpawner;


    private void Start()
    {
        animator = GetComponent<Animator>();

        projectileParent = GameObject.Find("Projectiles");

        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacked", true);
        }
        else
        {
            animator.SetBool("isAttacked", false);
        }

        SetMyLaneSpwner();
    }

    void SetMyLaneSpwner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach(Spawner spawner in spawnerArray)
        {
            if(spawner.transform.position.y == transform.position.y)
            {
                laneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }


    bool IsAttackerAheadInLane()
    {
        SetMyLaneSpwner();
        // Exit if no attackers in lane
        if (laneSpawner.transform.childCount < 1)
        {
            return false;
        }

        foreach(Transform attackers in laneSpawner.transform)
        {
            if(attackers.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        // Attackers in lane but behind defender
        return false;
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = gun.transform.position;
    }


}
