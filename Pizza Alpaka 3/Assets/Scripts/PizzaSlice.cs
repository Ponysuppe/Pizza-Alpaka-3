using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaSlice : MonoBehaviour
{
    [SerializeField] float speed;
    int delay = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void moveForeward(GameObject pizza)
    {
        pizza.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * speed;

        // pizza.GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Time.deltaTime);
        
       // pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(pizza, delay);
    }

    public void throwPizza(GameObject pizza, Vector2 direction)
    {
        pizza.GetComponent<Rigidbody2D>().velocity = direction * speed;

        Destroy(pizza, delay);
    }

}
