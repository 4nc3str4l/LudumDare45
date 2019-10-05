using UnityEngine;
using System;
using System.Collections;
using DG.Tweening;

public class AmbienceController : MonoBehaviour
{

    private Camera m_MainCamera;
    private Vector3 m_InitialPosition;

    [SerializeField] private AudioClip m_BackgroundExplosion;

    private void Awake()
    {
        m_MainCamera = FindObjectOfType<Camera>();
        m_InitialPosition = m_MainCamera.transform.localPosition;
        StartCoroutine(ExecuteExplosion(UnityEngine.Random.Range(0, 5)));
    }

    IEnumerator ExecuteExplosion(float time)
    {
        yield return new WaitForSeconds(time);

        AudioManager.Instance.PlaySoundRandomizePitch(m_BackgroundExplosion, 0.3f);
        m_MainCamera.transform.DOShakePosition(1, 0.1f).OnComplete(() =>
        {
            m_MainCamera.transform.localPosition = m_InitialPosition;
            StartCoroutine(ExecuteExplosion(UnityEngine.Random.Range(0, 5)));
        });
    }

    
}
