using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateKeyCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Test;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(Test, transform.position, transform.rotation);
        }
    }
}
