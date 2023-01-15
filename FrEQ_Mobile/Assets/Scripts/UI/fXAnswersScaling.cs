using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fXAnswersScaling : MonoBehaviour
{
    private Globals glbScr;

    [SerializeField] private GameObject answerFrame;

    // Start is called before the first frame update
    void Start()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
    }

    // Update is called once per frame
    void Update()
    {
        if(glbScr.anserBtnsType == "Amplitude")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 700);
        }else if (glbScr.anserBtnsType == "Distortion")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 700);
        }
        else if (glbScr.anserBtnsType == "Stereo")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 700);
        }
        else if (glbScr.anserBtnsType == "AmpDist")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 1400);
        }
        else if (glbScr.anserBtnsType == "DistStereo")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 1400);
        }
        else if (glbScr.anserBtnsType == "All")
        {
            answerFrame.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 1700);
        }
    }
}
