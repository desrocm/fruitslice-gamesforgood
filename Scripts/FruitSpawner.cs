using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{

    public GameObject fruit;
    public GameObject bomb;
    public float maxX;
    public float force;
    public float time;

    public static FruitSpawner instance;
    // Start is called before the first frame update

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnFruitGroups", 1, 5f);
    }
    
    public void StopSpawning()
    {
        CancelInvoke("SpawnFruitGroups");
        StopCoroutine("SpawnFruit");
    }
    public void SpawnFruitGroups() 
    {
        StartCoroutine("SpawnFruit");
        if(Random.Range(0,6) > 2)
        {
            SpawnBomb();
        }
    }
    IEnumerator SpawnFruit()
    {
        for (int i = 0; i < 5; i++)
        {

            float Rand = Random.Range(-maxX, maxX);
            float Force = Random.Range(force, force+6);
            float Time = Random.Range(time, time + 1);
            Vector3 pos = new Vector3(Rand, transform.position.y, 0);
            GameObject f = Instantiate(fruit, pos, Quaternion.identity) as GameObject;
            f.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Force), ForceMode2D.Impulse);
            f.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-30f, 30f));
            yield return new WaitForSeconds(Time);
        }
    }

    void SpawnBomb()
    {
        float Rand = Random.Range(-maxX, maxX);
        float Force = Random.Range(force+2, force+6);
        Vector3 pos = new Vector3(Rand, transform.position.y, 0);
        GameObject b = Instantiate(bomb, pos, Quaternion.identity) as GameObject;
        b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Force), ForceMode2D.Impulse);
        b.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-60f, 60f));
    }
}
