using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGridTransform : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ListTransform;
    public GameObject Base;
    public int Height;
    public int Width;
    public float SizeEcart;
    public List<List<int>> ListPath = new List<List<int>>
    {
        new List<int>(){0, 8, 44, 36},
        new List<int>(){3,25,39,18},
        new List<int>(){0,8,36,44},
        new List<int>(){20,36,44,23,8,0}
    };
    void Start()
    {
        for(int i = 0;i<Height;i++)
        {
            for(int j =0;j<Width;j++)
            {
                GameObject Trans = Instantiate(Base, transform.position + new Vector3(j*SizeEcart, -i*SizeEcart, 0), transform.rotation,this.gameObject.transform);
                Trans.name = ListTransform.Count.ToString();
                ListTransform.Add(Trans);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
