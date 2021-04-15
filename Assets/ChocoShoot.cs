using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float rot;
    public bool Parent;
    void Start()
    {
        if (Parent)
        {
            GameObject obj = Instantiate(this.gameObject, transform.position, transform.rotation);
            obj.GetComponent<ChocoShoot>().Parent = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Parent)
        {
            
            transform.Rotate(0, 0, rot*Time.deltaTime);
        }else
        {
            transform.Rotate(0, 0, -rot * Time.deltaTime);
        }
    }
}
