using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public Rigidbody2D rb;
    public GameObject pizzaSlice;
    public GameObject pizzaPlate;
    bool pizzaEquipped = false;
    bool pizzaPlateTouched = false;
    GameObject pizza;

    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        processInput();
    }

    private void FixedUpdate()
    {
        move();
    }

    void processInput()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(Input.GetKeyDown(KeyCode.Space) && pizzaEquipped)
        {
            throwPizza(pizza);
        }
        if (Input.GetKeyDown(KeyCode.E) && !pizzaEquipped && (pizzaPlate.CompareTag("PizzaPlate")) && pizzaPlateTouched)
        {
            Debug.Log("Is Touching2");
            pickupPizza(pizzaPlate);
        }
    }

    void move()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }

     void pickupPizza(GameObject pizzaPlate)
    {   
        Debug.Log("Is Picked");
        pizza = Instantiate(pizzaPlate.GetComponent<PizzaPlate>().pickupPizza(), gameObject.transform, true);
        pizza.transform.position = gameObject.transform.position + new Vector3(0, 0.5f, 0);
        pizzaEquipped = true;
    }

    void throwPizza(GameObject pizza)
    {
        Debug.Log("Is Thrown");
        gameObject.transform.DetachChildren();
        pizzaSlice.GetComponent<PizzaSlice>().moveForeward(pizza);
        pizzaEquipped = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pizzaPlate = collision.gameObject;
        pizzaPlateTouched = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pizzaPlateTouched = false;
    }

}
