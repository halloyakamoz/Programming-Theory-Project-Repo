using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public ObjectRain objectRain; // Reference to the ObjectRain script

    public int objectIndex; // Index of the selected object from the objectToFall array

    private void OnMouseDown()
    {
        // Set the selected object index in the ObjectRain script
        objectRain.SetSelectedObjectIndex(objectIndex);
    }
}