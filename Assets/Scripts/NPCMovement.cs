using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class NPCMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction; //vector2 because needs x and y component

    private Rigidbody2D _rigidbody2D;
    public Vector2 startPosicion;
    
    public Transform target;
    private bool keepMovingTowardsTarget = true;

    
    
    // Start is called before the first frame update
    void Start()
    {
        startPosicion = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        direction = - Vector2.one.normalized;
        
    }
    
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = -direction * speed;
    }

    private void Update()
    {
        if (keepMovingTowardsTarget == false)
        {
            float step = speed * 6 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y; 
        }
        else if (collision.gameObject.CompareTag("SideWall"))
        {
            direction.x = -direction.x;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            keepMovingTowardsTarget = false;

            
            Destroy(gameObject,2.0f);

            
            //transform.position = Vector3.MoveTowards(transform.position,target.transform.position,10f*Time.deltaTime);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Health.health--;
        }
    }

    
    public void Reset()
    {
        keepMovingTowardsTarget = true;
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = startPosicion;
        direction = Vector2.one.normalized;
        speed += 0.05f;
        
    }
}
