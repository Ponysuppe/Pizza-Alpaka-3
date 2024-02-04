using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    // public Rigidbody2D rb;
    [SerializeField] public float speed;
    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speedVar = speed * Time.deltaTime;

        Vector2 tempVector2 = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        transform.position = new Vector3(tempVector2.x, tempVector2.y, transform.position.z);

        //this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speedVar);
    }
}
