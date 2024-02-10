using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {


    }

    private void LateUpdate()
    {
        movement();
    }


    private void movement()
    {
        var speedVar = speed * Time.deltaTime;
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speedVar);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pizza"))
        {
            Destroy(gameObject);
        }
    }
}

