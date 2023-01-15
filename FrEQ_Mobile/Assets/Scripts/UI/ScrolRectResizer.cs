using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolRectResizer : MonoBehaviour
{
    [SerializeField] private Canvas thisCanvas;
    [SerializeField] private RectTransform scrollRect;

    [SerializeField] private float newScale;
    private float screenHeightScaled;
    private float modulesHeightScaled;

    void Start()
    {
        newScale = thisCanvas.GetComponent<RectTransform>().localScale.y * 100;
        screenHeightScaled = Screen.height * newScale;
        modulesHeightScaled = 1015 * newScale;
        //scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, screenHeightScaled - modulesHeightScaled);
        scrollRect.sizeDelta = new Vector2(scrollRect.sizeDelta.x, Screen.height - 1015);
    }
}
