using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 1f;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] public KeyCode LeftControl;
    [SerializeField] public KeyCode RightControl;
    [SerializeField] public KeyCode UpControl;
    [SerializeField] public KeyCode DownControl;
    public bool facingRight;
    public float horizontalValue;
    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
        if (Input.GetKey(LeftControl))
        {
            transform.Translate(x:-velocity,0f,0f);
        }
        //Move DOWN
        else if (Input.GetKey(RightControl))
        {
            transform.Translate(velocity,y:0f,0f);
        }
        if (Input.GetKey(UpControl))
        {
            transform.Translate(x:0f,y:velocity,0f);
        }
        //Move DOWN
        else if (Input.GetKey(DownControl))
        {
            transform.Translate(x:0f,y:-velocity,0f);
        }
        
    }
    void Flip()
    {
        if ((horizontalValue > 0 && facingRight) || (horizontalValue < 0 && !facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
