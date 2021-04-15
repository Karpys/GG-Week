using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    public CreateGridTransform Trans;
    public List<int> ListId;
    public int ActualId;
    public float Speed;
    public float SpeedSet;
    public bool Loop;
    public GameObject Target;
    public CharacherAnim Anim;
    public EnemiesWeapon Weapon;
    public GameObject Ondie;
    public GameObject OnHit;
    public SpawnerSystem Spawn;
    public bool Right;
    public Color Blank;
    public Color Full;
    public float Timef;

    [Header("Health")]
    public int maxHealth = 3;
    [SerializeField]
    private int currentHealth;
    void Start()
    {
        GetPath();
        SpeedSet = Speed;
        transform.position = Trans.ListTransform[ListId[0]].transform.position;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timef<1)
        {
        Timef += Time.deltaTime;
        GetComponent<SpriteRenderer>().color = Color.Lerp(Blank, Full, Timef );
        }
        if(transform.position!=Trans.ListTransform[ListId[ActualId]].transform.position)
        {
            transform.position=Vector3.MoveTowards(transform.position, Trans.ListTransform[ListId[ActualId]].transform.position, Speed * Time.deltaTime);
        }else
        {
            
            ActualId += 1;
            if (ListId.Count==ActualId)
            {
                ActualId = 0;
                if(!Loop)
                {
                GetPath();
                }

            }
        }

        if(transform.position.x>Target.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            Right = false;
        }
        else
        {
            Right = true;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void GetPath()
    {
        int rdm = Random.Range(0, Trans.ListPath.Count);
        ListId = Trans.ListPath[rdm];
    }

    /*public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
        Debug.Log("Enemy - 1");

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);

            Time.timeScale = 0;
        }
    }*/
}
