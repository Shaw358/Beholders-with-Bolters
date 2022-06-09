using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Intended to replace the button class that requires a canvas in worldspace to work - still needs a collider to function
/// </summary>

public class GameobjectButton : MonoBehaviour
{
    [SerializeField] public UnityEvent onClick;

    private void OnMouseDown()
    {
        onClick.Invoke();
    }
}