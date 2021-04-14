using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float Timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Timer -= Time.fixedDeltaTime;
        if(Timer<=0)
        {
            Destroy(gameObject);
        }
    }
}
