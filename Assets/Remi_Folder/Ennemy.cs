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
    public bool Right;
    void Start()
    {
        GetPath();
        SpeedSet = Speed;
        transform.position = Trans.ListTransform[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
}
