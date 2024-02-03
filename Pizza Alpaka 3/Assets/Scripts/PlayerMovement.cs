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

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private Vector2 moveDirection;
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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

        if(moveX > 0)
        {
            transform.localScale = new Vector3(1,1,1);
        }
        else if(moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        handleAnimation(moveX, moveY);
        

        moveDirection = new Vector2(moveX, moveY).normalized;

        if(Input.GetKeyDown(KeyCode.Space) && pizzaEquipped)
        {
            throwPizza(pizza);
        }
        if (Input.GetKeyDown(KeyCode.E) && !pizzaEquipped && (pizzaPlate.CompareTag("PizzaPlate")) && pizzaPlateTouched)
        {
            Debug.Log("Is Touching2");
            pickupPizza(pizzaPlate);
            anim.SetTrigger("StartHolding");
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
        //gameObject.transform.DetachChildren();
        pizza.GetComponent<Transform>().parent = null;
        //pizzaSlice.GetComponent<PizzaSlice>().moveForeward(pizza);
        pizzaSlice.GetComponent<PizzaSlice>().throwPizza(pizza, moveDirection);
        pizzaEquipped = false;
    }

    public void handleAnimation(float moveX, float moveY)
    {
        if (moveX == 0 && moveY == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (!pizzaEquipped)
        {
            anim.SetBool("isHolding", false);
        }
        else
        {
            anim.SetBool("isHolding", true);
        }
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
