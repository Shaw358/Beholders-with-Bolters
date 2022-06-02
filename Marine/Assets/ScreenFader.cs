using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] float faderStrength;
    [SerializeField] Image image;
    [SerializeField] UnityEvent action;

    private void Start()
    {
        StartFadeOut();
    }

    public void StartFadeOut()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while (image.color.a > 0)
        {
            Color newColor = new Color(image.color.r, image.color.g, image.color.b, image.color.a - (faderStrength / 1000));
            image.color = newColor;
            yield return null;
        }
        action?.Invoke();
    }
}
