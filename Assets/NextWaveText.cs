using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NextWaveText : MonoBehaviour
{
    // Start is called before the first frame update
    public SpawnerSystem Spawner;
    public float Activate;
    public Color Blank;
    public TextMeshProUGUI Text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Activate>=0)
        {
        Activate -= Time.deltaTime;
        }

        if (Activate<0)
        {
            Spawner.CreateWave(Spawner.IdWave);
            gameObject.SetActive(false);
        }
        
    }
}
