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
    void Start()
    {
        GetPath();
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
            }
        }
    }

    public void GetPath()
    {
        ListId = new List<int>()
        {
            0,8,44,36
        };
    }
}
