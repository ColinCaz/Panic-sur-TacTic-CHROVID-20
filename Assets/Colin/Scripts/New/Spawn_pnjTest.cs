using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_pnjTest : MonoBehaviour
{
    public int zoneEffect = 10;
    public int nbPnjBleu = 20;
    public int nbPnjVert = 5;
    public GameObject pnjBleu;
    public GameObject pnjVert;

    private float spawnX;
    private float spawnZ;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < nbPnjBleu; i++)
        {
            spawnX = transform.position.x + Random.Range(-zoneEffect, zoneEffect);
            spawnZ = transform.position.z + Random.Range(-zoneEffect, zoneEffect);
            Instantiate(pnjBleu, new Vector3(spawnX, 0, spawnZ), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        }
        for(int i = 0; i < nbPnjVert; i++)
        {
            spawnX = transform.position.x + Random.Range(-zoneEffect, zoneEffect);
            spawnZ = transform.position.z + Random.Range(-zoneEffect, zoneEffect);
            Instantiate(pnjVert, new Vector3(spawnX, 0, spawnZ), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
