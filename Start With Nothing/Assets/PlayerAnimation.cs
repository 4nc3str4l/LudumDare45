using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator m_PlayerAnimator;

    private void Awake()
    {
        m_PlayerAnimator = GetComponent<Animator>();
    }

    public void Run()
    {
        m_PlayerAnimator.SetTrigger("Running");
    }

    public void Idle()
    {
        m_PlayerAnimator.SetTrigger("Idle");
    }

    public void FaceLeft()
    {
        this.transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
    }

    public void FaceRight()
    {
        this.transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
    }
}
