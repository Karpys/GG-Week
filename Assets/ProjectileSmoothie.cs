using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSmoothie : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Smoothie;
    void Start()
    {
        Instantiate(Smoothie, transform.position, transform.rotation);
        transform.Rotate(0, 0, 20);
        Instantiate(Smoothie, transform.position, transform.rotation);
        transform.Rotate(0, 0, -40);
        Instantiate(Smoothie, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
