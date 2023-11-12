using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject[] AllCounters;
    public GameObject NearestCounter;
    float distance;
    float nearestDistance = 10000;

    // Start is called before the first frame update
    void Start()
    {
        AllCounters = GameObject.FindGameObjectsWithTag("Waiting Space");
        findCounter();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -1) * speed;
        
    }

    void findCounter()
    {

        for (int i = 0; i < AllCounters.Length; i++)
        {
            distance = Vector3.Distance(this.transform.position, AllCounters[i].transform.position);
            if (distance < nearestDistance)
            {
                NearestCounter = AllCounters[i];
                nearestDistance = distance;
            }
        }
    }
}
