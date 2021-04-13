using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spawn", menuName = "Spawn")]
public class Spawn : ScriptableObject
{
    public List<Spawner> spawn;
}
[System.Serializable]
public struct Spawner
{
    public GameObject En;
    public int Nbr;
    public float TimeBtw;
}