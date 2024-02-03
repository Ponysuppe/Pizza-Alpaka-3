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
    public GameObject target;
    Vector2 targetPosition;


    // Start is called before the first frame update
    void Start()
    { 
        /*if (target == null) {

		    if (GameObject.FindWithTag ("Player")!=null)*/
		    //{
			   // target = GameObject.FindWithTag("Player").GetComponent<Transform>();
		   /* }
	    }*/

       
    
    }

    // Update is called once per frame
    void Update()
    {

/*            if (target == null)
                return;
        
*/
       
       // targetPosition = new Vector2(target.position.x, target.position.y);
       

    }

    private void LateUpdate()
    {

        var speedVar = speed * Time.deltaTime;
          this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, speedVar);
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
