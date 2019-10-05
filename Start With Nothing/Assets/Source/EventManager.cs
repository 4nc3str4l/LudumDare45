public class EventManager
{
    public delegate void OnInteractionRange(Interactive _interactive);

    public static event OnInteractionRange OnInteractiveObjectInRange;
    public static void FireOnInteractiveObjectInRange(Interactive _interactive)
    {
        if (OnInteractiveObjectInRange != null)
        {
            OnInteractiveObjectInRange(_interactive);
        }
    }


    public static event OnInteractionRange OnInteractiveObjectOutRange;
    public static void FireOnInteractiveObjectOutRange(Interactive _interactive)
    {
        if(OnInteractiveObjectOutRange != null)
        {
            OnInteractiveObjectOutRange(_interactive);
        }
    }

    public static event System.Action OnInteract;

    public static void FireOnInteract()
    {
        if(OnInteract != null)
        {
            OnInteract();
        }
    }

}

