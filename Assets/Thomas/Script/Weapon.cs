using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPos;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public Animator Anim;
    public SoundManager Sound;
    public bool Attacking;
    public bool Attack;

    private void Update()
    {
        // Weapon Rotation
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if(timeBtwShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Sound.PlaySfx("Shoot_Weap");
                Anim.SetBool("Attack", true);
                GameObject Proj = Instantiate(projectile, shotPos.position, shotPos.rotation);
                Proj.GetComponent<ProjectilePlayer>().Sound = Sound;
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            Anim.SetBool("Attack", false);
            timeBtwShots -= Time.deltaTime;
        }
    }
}
