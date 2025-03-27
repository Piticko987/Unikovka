using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sleepsimulator : MonoBehaviour
{
    [SerializeField] private Image image;
    private void Awake()
    {
        StartCoroutine(sleep());
    }
    private IEnumerator sleep()
    {
        for(int i = 255; i > 0; i-=5)
        {
            yield return new WaitForSeconds(0.05f);
            var tempColor = image.color;
            tempColor.a = i/255.0f;
            image.color=tempColor;
        }
        StartCoroutine(blink());

    }
    public IEnumerator blink()
    {
        for (int i = 0; i < 255; i += 5)
        {
            yield return new WaitForSeconds(0.05f);
            var tempColor = image.color;
            tempColor.a = i / 255.0f;
            image.color = tempColor;
        }
        StartCoroutine(sleep());
    }
}
