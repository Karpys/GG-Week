using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damageToGive = 1;

    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("hit");

        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<CharaCircle>().HurtPlayer(damageToGive);
            Destroy(gameObject);
            //Debug.Log("player hit");
        }
    }
}
