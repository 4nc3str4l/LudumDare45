using UnityEngine;


public abstract class Interactive : MonoBehaviour
{

    private bool m_InRange = false;

    public abstract void OnInteract();

    private void OnEnable()
    {
        EventManager.OnInteract += EventManager_OnInteract;
    }


    private void OnDisable()
    {
        EventManager.OnInteract -= EventManager_OnInteract;
    }

    private void EventManager_OnInteract()
    {
        if (!m_InRange)
            return;

        Debug.Log("Iteracting");
        OnInteract();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 9)
            return;

        m_InRange = true;
        EventManager.FireOnInteractiveObjectInRange(this);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 9)
            return;

        m_InRange = false;
        EventManager.FireOnInteractiveObjectOutRange(this);
    }
}