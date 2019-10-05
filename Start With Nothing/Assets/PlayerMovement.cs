using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation m_PlayerAnimation;


    private void Awake()
    {
        m_PlayerAnimation = GetComponentInChildren<PlayerAnimation>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_PlayerAnimation.Run();
            m_PlayerAnimation.FaceRight();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            m_PlayerAnimation.Idle();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_PlayerAnimation.Run();
            m_PlayerAnimation.FaceLeft();
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            m_PlayerAnimation.Idle();

        }
    }
}
