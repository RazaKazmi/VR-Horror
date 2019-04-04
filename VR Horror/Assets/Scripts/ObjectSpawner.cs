using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject toSpawn; //what object to spawn
    public float spawnRate; //how often it should spawn in seconds
    private float minX, minY, minZ, maxX, maxY, maxZ;
    private float yPos;



    // Start is called before the first frame update
    void Start()
    {
        minX = gameObject.GetComponent<BoxCollider>().bounds.min.x;
        //minY = gameObject.GetComponent<BoxCollider>().bounds.min.y;
        minZ = gameObject.GetComponent<BoxCollider>().bounds.min.z;

        maxX = gameObject.GetComponent<BoxCollider>().bounds.max.x;
        //maxY = gameObject.GetComponent<BoxCollider>().bounds.max.y;
        maxZ = gameObject.GetComponent<BoxCollider>().bounds.max.z;

        yPos = gameObject.transform.position.y;

        InvokeRepeating("SpawnObject", spawnRate, spawnRate);
    }

    void SpawnObject()
    {
        float randX = Random.Range(minX, maxX);
        //float randY = Random.RandomRange(minY, maxY);
        float randZ = Random.Range(minZ, maxZ);

        Vector3 randomLocation = new Vector3(randX, yPos, randZ);

        //Spawn the object at the random location within the collider
        Instantiate(toSpawn, randomLocation, Quaternion.identity);
    }

}
