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

    public IEnumerator moveForeward(GameObject pizza)
    {
        int i = 0;
        while (i < 10)
        {
            // Count to Ten
            i++;
            pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
            yield return null;
        }
        Destroy(pizza, delay);
    }


    public void moveForeward1(GameObject pizza)
    {
       // pizza.GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Time.deltaTime);
        pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        pizza.transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(pizza, delay);
    }

}
