using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroInfoController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject moreInfoGO;
    [SerializeField] private GameObject quizCanvas;
    [SerializeField] private Animator audioSpecAni;
    [SerializeField] private Animator pinkNoiseAni;
    [SerializeField] private Animator lowAni;
    [SerializeField] private Animator midAni;
    [SerializeField] private Animator highAni;
    [SerializeField] private Animator quizAni;
    [SerializeField] TextMeshProUGUI hz80Text;
    [SerializeField] TextMeshProUGUI k2Text;
    [SerializeField] TextMeshProUGUI k8Text;
    [SerializeField] TextMeshProUGUI pNText;
    FMOD.Studio.EventInstance hz80Event;
    FMOD.Studio.EventInstance k2Event;
    FMOD.Studio.EventInstance k8Event;
    FMOD.Studio.EventInstance pNEvent;

    [Header("Settings")]
    public int currentPos = 0;
    private bool hz80playing = false;
    private bool k2playing = false;
    private bool k8playing = false;
    private bool pNplaying = false;

    void Start()
    {
        StartCoroutine(AudioSpecInCo());
        pNEvent = FMODUnity.RuntimeManager.CreateInstance("event:/pnEx");
        hz80Event = FMODUnity.RuntimeManager.CreateInstance("event:/80Hz");
        k2Event = FMODUnity.RuntimeManager.CreateInstance("event:/2kHz");
        k8Event = FMODUnity.RuntimeManager.CreateInstance("event:/8kHz");
    }

    private void Update()
    {
        FMOD.Studio.PLAYBACK_STATE pnState;
        pNEvent.getPlaybackState(out pnState);
        if (pnState.ToString() == "STOPPED")
        {
            pNplaying = false;
            pNText.text = "CLICK TO HEAR PINK NOISE";
        }

        FMOD.Studio.PLAYBACK_STATE h80State;
        hz80Event.getPlaybackState(out h80State);
        if (h80State.ToString() == "STOPPED")
        {
            hz80playing = false;
            hz80Text.text = "CLICK TO HEAR AN 80HZ TONE";
        }

        FMOD.Studio.PLAYBACK_STATE k2State;
        k2Event.getPlaybackState(out k2State);
        if (k2State.ToString() == "STOPPED")
        {
            k2playing = false;
            k2Text.text = "CLICK TO HEAR AN 2KHZ TONE";
        }

        FMOD.Studio.PLAYBACK_STATE k8State;
        k8Event.getPlaybackState(out k8State);
        if (k8State.ToString() == "STOPPED")
        {
            k8playing = false;
            k8Text.text = "CLICK TO HEAR AN 8KHZ TONE";
        }
    }

    IEnumerator AudioSpecInCo()
    {
        pinkNoiseAni.SetBool("in", false);
        lowAni.SetBool("in", false);
        midAni.SetBool("in", false);
        highAni.SetBool("in", false);
        quizAni.SetBool("in", false);
        yield return new WaitForSeconds(0.2f);
        audioSpecAni.SetBool("in", true);
    }

    IEnumerator PinkNoiseInCo()
    {
        audioSpecAni.SetBool("in", false);
        lowAni.SetBool("in", false);
        midAni.SetBool("in", false);
        highAni.SetBool("in", false);
        quizAni.SetBool("in", false);
        yield return new WaitForSeconds(0.2f);
        pinkNoiseAni.SetBool("in", true);
    }

    IEnumerator LowInCo()
    {
        audioSpecAni.SetBool("in", false);
        pinkNoiseAni.SetBool("in", false);
        midAni.SetBool("in", false);
        highAni.SetBool("in", false);
        quizAni.SetBool("in", false);
        yield return new WaitForSeconds(0.2f);
        lowAni.SetBool("in", true);
    }

    IEnumerator MidInCo()
    {
        audioSpecAni.SetBool("in", false);
        pinkNoiseAni.SetBool("in", false);
        lowAni.SetBool("in", false);
        highAni.SetBool("in", false);
        quizAni.SetBool("in", false);
        yield return new WaitForSeconds(0.2f);
        midAni.SetBool("in", true);
    }

    IEnumerator HighInCo()
    {
        audioSpecAni.SetBool("in", false);
        pinkNoiseAni.SetBool("in", false);
        lowAni.SetBool("in", false);
        midAni.SetBool("in", false);
        quizAni.SetBool("in", false);
        yield return new WaitForSeconds(0.2f);
        highAni.SetBool("in", true);

    }

    IEnumerator QuizInCo()
    {
        pinkNoiseAni.SetBool("in", false);
        audioSpecAni.SetBool("in", false);
        lowAni.SetBool("in", false);
        midAni.SetBool("in", false);
        highAni.SetBool("in", false);
        yield return new WaitForSeconds(0.4f);
        quizAni.SetBool("in", true);
    }

    public void NextBtn()
    {
        StopAllAudioExamples();
        currentPos += 1;
        if (currentPos >= 5) { currentPos = 5; }

        switch (currentPos)
        {
            case 0:
                StartCoroutine(AudioSpecInCo());
                break;
            case 1:
                StartCoroutine(PinkNoiseInCo());
                break;
            case 2:
                StartCoroutine(LowInCo());
                break;
            case 3:
                StartCoroutine(MidInCo());
                break;
            case 4:
                StartCoroutine(HighInCo());
                break;
            case 5:
                StartCoroutine(QuizInCo());
                break;
        }
    }

    public void PreviousBtn()
    {
        StopAllAudioExamples();
        currentPos -= 1;
        if (currentPos <= 0) { currentPos = 0; }

        switch (currentPos)
        {
            case 0:
                StartCoroutine(AudioSpecInCo());
                break;
            case 1:
                StartCoroutine(PinkNoiseInCo());
                break;
            case 2:
                StartCoroutine(LowInCo());
                break;
            case 3:
                StartCoroutine(MidInCo());
                break;
            case 4:
                StartCoroutine(HighInCo());
                break;
            case 5:
                StartCoroutine(QuizInCo());
                break;
        }
    }

    public void PlayPnBtnClick()
    {
        if (!pNplaying)
        {
            pNEvent = FMODUnity.RuntimeManager.CreateInstance("event:/pnEx");
            pNEvent.start();
            pNplaying = true;
            pNText.text = "CLICK TO STOP PINK NOISE";
        }
        else if (pNplaying)
        {
            pNEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            pNplaying = false;

            pNText.text = "CLICK TO HEAR PINK NOISE";
        }
    }
    public void Play80HzBtnClick()
    {
        if (!hz80playing)
        {
            hz80Event = FMODUnity.RuntimeManager.CreateInstance("event:/80Hz");
            hz80Event.start();
            hz80Text.text = "CLICK TO STOP TONE";
            hz80playing = true;
        }
        else if (hz80playing)
        {
            hz80Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            hz80Text.text = "CLICK TO HEAR AN 80HZ TONE";
            hz80playing = false;
        }
    }
    public void Play2kHzBtnClick()
    {
        if (!k2playing)
        {
            k2Event = FMODUnity.RuntimeManager.CreateInstance("event:/2kHz");
            k2Event.start();
            k2Text.text = "CLICK TO STOP TONE";
            k2playing = true;
        }
        else if (k2playing)
        {
            k2Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            k2Text.text = "CLICK TO HEAR AN 2 KHZ TONE";
            k2playing = false;
        }
    }
    public void Play8kHzBtnClick()
    {
        if (!k8playing)
        {
            k8Event = FMODUnity.RuntimeManager.CreateInstance("event:/8kHz");
            k8Event.start();
            k8Text.text = "CLICK TO STOP TONE";
            k8playing = true;
        }
        else if (k8playing)
        {
            k8Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            k8Text.text = "CLICK TO HEAR AN 8 KHZ TONE";
            k8playing = false;
        }
    }

    void StopAllAudioExamples()
    {
        pNEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        pNplaying = false;
        pNText.text = "CLICK TO HEAR PINK NOISE";
        hz80Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        hz80Text.text = "CLICK TO HEAR AN 80HZ TONE";
        hz80playing = false;
        k2Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        k2Text.text = "CLICK TO HEAR AN 2 KHZ TONE";
        k2playing = false;
        k8Event.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        k8Text.text = "CLICK TO HEAR AN 8 KHZ TONE";
        k8playing = false;
    }

    public void QuizBtnClick()
    {
        quizCanvas.SetActive(true);
    }

    public void MoreInfoClick()
    {
        moreInfoGO.SetActive(true);
    }

    public void MoreInfoClose()
    {
        moreInfoGO.SetActive(false);
    }
}
