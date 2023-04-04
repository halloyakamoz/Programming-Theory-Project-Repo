using UnityEngine;
using UnityEngine.Events;

public class ObjectSelector : MonoBehaviour
{
    public UnityEvent ObjectSelectedEvent;

    private void OnMouseDown()
    {
        // Trigger the ObjectSelectedEvent event when the object is clicked
        ObjectSelectedEvent.Invoke();
    }
}