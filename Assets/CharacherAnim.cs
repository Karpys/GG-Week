using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacherAnim : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Anim;
    public bool Attacking;
    public bool Attack;
    public Ennemy Ennemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Attacking)
        {
            Anim.SetBool("Attack", true);
            Ennemy.Speed = 0;
        }

        if(Attack)
        {
            Ennemy.Weapon.Shoot();
            Attack = false;
            Attacking = false;
            Ennemy.Speed = Ennemy.SpeedSet;
            Anim.SetBool("Attack", false);
        }
    }
}
