using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float velocity = 5.0f;
    public float moveSpeed = 5f;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] public KeyCode LeftControl;
    [SerializeField] public KeyCode RightControl;
    [SerializeField] public KeyCode UpControl;
    [SerializeField] public KeyCode DownControl;
    public bool facingRight;
    public float horizontalValue;
    private GameObject player;
    public Camera cam;

    private Vector2 mousePos;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Walk();
        Flip();

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void Walk()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        horizontalValue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

    }

    void Flip()
    {
        if ((horizontalValue < 0 && facingRight) || (horizontalValue > 0 && !facingRight))
        {
            facingRight = !facingRight;
            
            transform.Rotate(0f,180f,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health.health--;
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        //_rigidbody2D.rotation = angle;
    }
}
    
    
