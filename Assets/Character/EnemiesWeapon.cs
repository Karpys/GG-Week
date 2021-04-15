using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesWeapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPosRight;
    public Transform shotPosLeft;
    private float timeBtwShots;
    public float startTimeBtwShots;
    public bool Shooting;
    public Ennemy En;


    public void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }
    private void Update()
    {
        // Weapon Rotation
        if(Shooting)
        {

        

        if (timeBtwShots <= 0)
        {
            En.Anim.Attacking = true;
            timeBtwShots = startTimeBtwShots;

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        }
        Vector2 direction = new Vector2(En.Target.transform.position.x - transform.position.x, En.Target.transform.position.y - transform.position.y);
        transform.up = direction;
    }

    public void Shoot()
    {
        if(En.Right)
        {
            Instantiate(projectile, shotPosLeft.position, shotPosLeft.rotation);
            
        }else
        {
            Instantiate(projectile, shotPosRight.position, shotPosRight.rotation);
        }
    }
}
