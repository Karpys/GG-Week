using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Spawn> Spawner;
    public int MaxId;
    public List<GameObject> ListEnSpawn;
    public List<float> TimeBetweenSpawn;
    public int IdWave;
    public float Timer;
    public CreateGridTransform Trans;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CreateWave(IdWave);
        }
        
        if(Timer<=0 && ListEnSpawn.Count>0)
        {
            SpawnEn();
        }else if(ListEnSpawn.Count==0 && Spawner.Count>0)
        {
            CreateWave(IdWave);
        }


        Timer -= Time.deltaTime;
    }


    public void SpawnEn()
    {
        GameObject En = Instantiate(ListEnSpawn[0], transform.position, transform.rotation);
        En.GetComponent<Ennemy>().Trans = Trans;
        Timer = TimeBetweenSpawn[0];
        ListEnSpawn.Remove(ListEnSpawn[0]);
        TimeBetweenSpawn.Remove(TimeBetweenSpawn[0]);
    }
    public void CreateWave(int id)
    {
        int MaxId = 0;
        for (int i = 0; i < Spawner[id].spawn.Count; i++)
        {
            MaxId += Spawner[id].spawn[i].Nbr;
        }
        MaxId += Spawner[id].spawn.Count;
        int ResetLoop = 0;
        int ActualSpawner = 0;
        for (int j = 0; j < MaxId; j++)
        {
            if (ResetLoop != Spawner[id].spawn[ActualSpawner].Nbr)
            {
                ListEnSpawn.Add(Spawner[id].spawn[ActualSpawner].En);
                TimeBetweenSpawn.Add(Spawner[id].spawn[ActualSpawner].TimeBtw);
                ResetLoop += 1;
            }
            else
            {
                ResetLoop = 0;
                ActualSpawner += 1;
            }
        }
        Spawner.Remove(Spawner[0]);
        /*IdWave += 1;*/
    }
}
