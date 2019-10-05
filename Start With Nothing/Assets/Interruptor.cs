using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Interruptor : Interactive
{
    public bool IsOn = true;

    [SerializeField] private Color m_OffColor;
    [SerializeField] private Color m_OnColor;

    [SerializeField] private Light2D m_light;
    [SerializeField] private SpriteRenderer m_Renderer;

    private void Awake()
    {
        SetVisuals();
    }


    public void TurnOff()
    {
        IsOn = false;
        SetVisuals();
    }

    public void TurnOn()
    {
        IsOn = true;
        SetVisuals();
    }

    private void SetVisuals()
    {
        m_light.color = GetColor();
        m_Renderer.color = GetColor();
    }

    private Color GetColor()
    {
        return IsOn ? m_OnColor : m_OffColor;
    }

    public override void OnInteract()
    {
        IsOn = !IsOn;
        SetVisuals();
    }
}
