using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePlayer : MonoBehaviour
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

        /*Collider2D collider = Physics2D.OverlapCircle(transform.position, 10);

        if (!collider)
        {
            if (collider.gameObject.tag.Equals("Enemy"))
            {
                //other.gameObject.GetComponent<Ennemy>().HurtEnemy(damageToGive);
                Destroy(gameObject);
                Destroy(collider.gameObject);
                Debug.Log("Enemy hit");
            }
        }*/
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*Debug.Log("hit");
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.gameObject.name);*/

        if(other.gameObject.tag.Equals("Enemy"))
        {
            //other.gameObject.GetComponent<Ennemy>().HurtEnemy(damageToGive);
            Destroy(gameObject);
            Destroy(other.gameObject);
            //Debug.Log("Enemy hit");
        }
    }
}
