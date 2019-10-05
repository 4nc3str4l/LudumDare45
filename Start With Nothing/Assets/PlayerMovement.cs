using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation m_PlayerAnimation;
    private Rigidbody2D m_RigidBody;
    private float m_MovementSmoothing = 0.5f;

    private float m_JumpForce = 400;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    private bool m_Grounded = true;

    float m_HorizontalMove = 0f;
    private const float RUN_SPEED = 40f;
    private bool m_Jump = false;
    public Transform m_GroundCheck;
    private const float GROUNDED_RADIUS = 0.07f;

    [SerializeField] private LayerMask m_GroundLayer;


    private void Awake()
    {
        m_PlayerAnimation = GetComponentInChildren<PlayerAnimation>();
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        m_HorizontalMove = Input.GetAxisRaw("Horizontal") * RUN_SPEED;

        if (Mathf.Abs(m_HorizontalMove) > 0)
        {
            m_PlayerAnimation.Run();
        }
        else
        {
            m_PlayerAnimation.Idle();
        }

        if (Input.GetButtonDown("Jump"))
        {
            m_Jump = true;
        }
        else
        {
            m_Jump = false;
        }
    }

    private void FixedUpdate()
    {
        if (!m_Grounded)
        {
            bool wasGrounded = m_Grounded;
            m_Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, GROUNDED_RADIUS, m_GroundLayer);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    if (!wasGrounded)
                    {
                        m_Grounded = true;
                    }
                }
            }
        }


        Debug.Log("Grounded " + m_Grounded);
        Move(m_HorizontalMove * Time.fixedDeltaTime, m_Jump);
    }

    private void Move(float _movement, bool _is_jumping)
    {
        Vector3 targetVelocity = new Vector2(_movement * 10f, m_RigidBody.velocity.y);
        m_RigidBody.velocity = Vector3.SmoothDamp(m_RigidBody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        if (_movement > 0 && !m_FacingRight)
        {
            Flip();
        }

        else if (_movement < 0 && m_FacingRight)
        {
            Flip();
        }

        // If the player should jump...
        if (m_Grounded && _is_jumping)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_RigidBody.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void Flip()
    {
        Debug.Log("Flip " + m_FacingRight);
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        if (!m_FacingRight)
        { 
            m_PlayerAnimation.FaceLeft();
        }
        else
        {
            m_PlayerAnimation.FaceRight();
        }
    }
}
