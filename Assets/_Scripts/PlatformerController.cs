using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D m_rigidBody;
    
    [SerializeField]
    private Joystick m_joystick; // Lives on UI 

    [SerializeField]
    private Animator m_animator; 

    [SerializeField]
    private bool m_Jumping = false; 
    [SerializeField]
    private bool m_Grounded = false; 

    [SerializeField]
    private float horizontalSpeed; 
    [SerializeField]
    private float verticalSpeed; 

    [SerializeField]
    SpriteRenderer m_renderer;
    void Start()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_rigidBody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>(); 

        // If not set inspector for some reason 
        if(m_joystick == null)
        {
            m_joystick = FindObjectOfType<Joystick>();  
        } 
    }

    // Update is called once per frame
    void Update()
    {

        if(m_Grounded)
        {     
            if(m_joystick.Horizontal < 0)
            {
                m_renderer.flipX = true;
                m_animator.SetInteger("RunState", 1);
                m_rigidBody.velocity = new Vector2(-horizontalSpeed, m_rigidBody.velocity.y);  
            } 
            else if(m_joystick.Horizontal > 0) 
            {
                m_renderer.flipX = false;
                m_animator.SetInteger("RunState", 1);
                m_rigidBody.velocity = new Vector2(horizontalSpeed, m_rigidBody.velocity.y);  
            }
            else if(m_joystick.Horizontal == 0)
            {
                m_animator.SetInteger("RunState", 0); 
            }
        }

        if(m_joystick.Vertical > 0)
        {
            if(!m_Jumping)
            {
                m_animator.SetTrigger("Jump");
                m_animator.SetBool("Grounded", false);
                m_rigidBody.velocity = new Vector2(m_rigidBody.velocity.x * 4, verticalSpeed);
                m_Jumping = true;
                m_Grounded = false; 
            }
        }

        if(m_rigidBody.velocity.y == 0)
        {
            m_Jumping = false;
            m_Grounded = true;   
            m_animator.SetBool("Grounded", true);
        } 
    }
}
