using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public GameObject chara;

    void Update()
    {
        Vector2 position = new Vector2(chara.transform.position.x, -6);

        transform.position = position;
    }
}
