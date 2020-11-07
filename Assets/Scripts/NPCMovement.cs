using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed;
    private Vector2 direction; //vector2 because needs x and y component

    private Rigidbody2D _rigidbody2D;
    public Vector2 startPosicion;

     
    
    
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
            direction.x = direction.x;

        }
        
    }

    public void Reset()
    {
        _rigidbody2D.velocity = Vector2.zero;
        transform.position = startPosicion;
        direction = Vector2.one.normalized;
        speed = 4;

    }
}
