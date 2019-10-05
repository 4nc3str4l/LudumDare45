using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation m_PlayerAnimation;
    private Rigidbody2D m_RigidBody;
    private float m_MovementSmoothing = 0.5f;

    private float m_JumpForce = 400;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    private bool m_Grounded = true;

    private void Awake()
    {
        m_PlayerAnimation = GetComponentInChildren<PlayerAnimation>();
        m_RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_PlayerAnimation.Run();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_PlayerAnimation.Idle();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_PlayerAnimation.Run();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_PlayerAnimation.Idle();

        }
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


        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
