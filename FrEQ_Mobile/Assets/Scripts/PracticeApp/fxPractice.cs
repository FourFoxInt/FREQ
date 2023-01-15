using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class fxPractice : MonoBehaviour
{
    private Globals glbScr;
    private ModuleController modCon;
    private NetworkGlobals netGlbScr;

    //COLOURS
    [SerializeField] private Color selected;
    [SerializeField] private Color notSelected;
    [SerializeField] private Color playing;
    [SerializeField] private Color waiting;

    [SerializeField] private GameObject noChangeFrame;
    [SerializeField] private GameObject noChangeBtn;
    [SerializeField] private bool noChangeSel;

    //Music dropdown
    [SerializeField] GameObject audioDropdown;
    [SerializeField] TMP_Dropdown genreDropdown;
    [SerializeField] private int genreValue;

    //Amp Buttons
    [SerializeField] private GameObject ampTitle;
    [SerializeField] private GameObject ampFrame;
    [SerializeField] private GameObject b3Btn;[SerializeField] private GameObject c3Btn;[SerializeField] private GameObject b3dBtn;[SerializeField] private GameObject c3dBtn;

    //Amp Bools
    [SerializeField] private bool b3BtnSel;[SerializeField] private bool c3BtnSel;[SerializeField] private bool b3dBtnSel;[SerializeField] private bool c3dBtnSel;

    //Dist Buttons
    [SerializeField] private GameObject distTitle;
    [SerializeField] private GameObject distFrame;
    [SerializeField] private GameObject sDistBtn;[SerializeField] private GameObject gDistBtn;

    //Dist Bools
    [SerializeField] private bool sDistSel;[SerializeField] private bool gDistSel;

    //Stereo Buttons
    [SerializeField] private GameObject stereoTitle;
    [SerializeField] private GameObject stereoFrame;
    [SerializeField] private GameObject LRflipedBtn;[SerializeField] private GameObject stereoToMonoBtn;[SerializeField] private GameObject monoToStereoBtn;

    //Stereo Bools
    [SerializeField] private bool LRflipedSel;[SerializeField] private bool stereoToMonoSel;[SerializeField] private bool monoToStereoSel;

    //UI
    [SerializeField] private TextMeshProUGUI playBtnText;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button submitBtn;
    public string title;
    public string desc;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI previousText;
    [SerializeField] private TextMeshProUGUI playText;

    //Verification
    private bool answerSelected = false;

    //Choices
    [SerializeField] private float userEx;
    [SerializeField] private string userExString;
    [SerializeField] private string ranExString;
    [SerializeField] private float ranEx;
    [SerializeField] private string curAnsString;
    [SerializeField] private float previousAns;

    //Audio
    private float userFreq;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool fxOn = false;
    public bool cut = false;
    public float volume;
    public float pan;
    public float dist;
    public bool startMono = false;
    public float speed = 0.5f;
    public bool during = false;
    [SerializeField] private bool firstPlay = true;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioClip newExClip;
    private string effectType;

    //RESULTS
    private int attempts = 0;
    private int correct = 0;
    [SerializeField] private GameObject rightGO;
    [SerializeField] private GameObject wrongGO;

    private void Start()
    {
        answerSelected = false;
        modCon = GameObject.Find("Canvas_Main").GetComponent<ModuleController>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        RandomiseEx();
        ButtonActivations();

        MusicDropdownActivation();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }
    private void Update()
    {
        GenreChange();

        if (!isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = true;

        }
        else if (isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = false;
        }

        scoreText.text = correct.ToString() + " out of " + attempts.ToString();
        titleText.text = title;
        descText.text = desc;
        curAnsString = ranExString;

        if (!cut)
        {
            if (volume <= 4 && fxOn && during)
            {
                volume += 1 * speed * Time.deltaTime;
                fmodEvent.setParameterByName("volume", volume);
            }
        }
        else if (cut)
        {
            if (volume >= -4 && fxOn && during)
            {
                volume -= 1 * speed * Time.deltaTime;
                fmodEvent.setParameterByName("volume", volume);
            }
        }

        if (isPlaying)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying && answerSelected)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }
        else if (!isPlaying && !answerSelected)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
    }
    void RandomiseEx()
    {
        float ran2 = Random.Range(0, 100);

        if (ran2 >= 0 && ran2 <= 18)
        {
            ranEx = 0;
            ranExString = "No Change";
            volume = 0;
            dist = 0;
            pan = 0;
            during = false;
            cut = false;
            startMono = false;

            if (ranEx == previousAns)
            {
                Debug.Log("randomised again");
                RandomiseEx();
            }
        }
        else
        {

            float ran = Random.Range(glbScr.minFx, glbScr.maxFx);

            if (ran >= 0 && ran <= 10)
            {
                effectType = "Amplitude";
                ranEx = 1;
                ranExString = "3 dB Boost";
                volume = 4;
                during = false;
                cut = false;
                pan = 0;
                dist = 0;
                startMono = false;
            }
            else if (ran >= 10.01 && ran <= 20)
            {
                effectType = "Amplitude";
                ranEx = 2;
                ranExString = "3 dB Cut";
                volume = -4;
                during = false;
                cut = true;
                dist = 0;
                pan = 0;
                startMono = false;
            }
            else if (ran >= 20.01 && ran <= 30)
            {
                effectType = "Amplitude";
                ranEx = 3;
                ranExString = "3 dB Boost During";
                volume = 4;
                during = true;
                cut = false;
                dist = 0;
                pan = 0;
                startMono = false;
            }
            else if (ran >= 30.01 && ran <= 40)
            {
                effectType = "Amplitude";
                ranEx = 4;
                ranExString = "3 dB Cut During";
                volume = -4;
                during = true;
                dist = 0;
                cut = true;
                pan = 0;
                startMono = false;
            }
            else if (ran >= 40.01 && ran <= 50)
            {
                effectType = "Distortion";
                ranEx = 5;
                ranExString = "Gross Distortion";
                dist = 2.5f;
                startMono = false;
                volume = 0;
            }
            else if (ran >= 50.01 && ran <= 60)
            {
                effectType = "Distortion";
                ranEx = 6;
                ranExString = "Slight Distortion";
                dist = 1.5f;
                pan = 0;
                startMono = false;
                volume = 0;
            }
            else if (ran >= 60.01 && ran <= 70)
            {
                effectType = "Stereo";
                ranEx = 7;
                ranExString = "Left & Right Flipped";
                pan = 1.5f;
                startMono = false;
                dist = 0;
                volume = 0;
            }
            else if (ran >= 70.01 && ran <= 80)
            {
                effectType = "Stereo";
                ranEx = 8;
                ranExString = "Stereo to Mono";
                pan = 2.5f;
                startMono = false;
                dist = 0;
                volume = 0;
            }
            else if (ran >= 80.01 && ran <= 90)
            {
                effectType = "Stereo";
                ranEx = 9;
                ranExString = "Mono to Stereo";
                pan = 0.5f;
                startMono = true;
                dist = 0;
                volume = 0;
            }

            if (ranEx == previousAns)
            {
                Debug.Log("randomised again"); 
                RandomiseEx();
            }
        }
    }
    void ButtonActivations()
    {
        if (glbScr.canNoChange)
        {
            noChangeFrame.SetActive(true);
        }else if(glbScr.canNoChange == false)
        {
            noChangeFrame.SetActive(false);
        }

        if (glbScr.anserBtnsType == "Amplitude")
        {
            ampTitle.SetActive(true);
            ampFrame.SetActive(true);
            distTitle.SetActive(false);
            distFrame.SetActive(false);
            stereoFrame.SetActive(false);
            stereoTitle.SetActive(false);
        }
        else if (glbScr.anserBtnsType == "Stereo")
        {
            ampTitle.SetActive(false);
            ampFrame.SetActive(false);
            distTitle.SetActive(false);
            distFrame.SetActive(false);
            stereoFrame.SetActive(true);
            stereoTitle.SetActive(true);
        }
        else if (glbScr.anserBtnsType == "Distortion")
        {
            ampTitle.SetActive(false);
            ampFrame.SetActive(false);
            distTitle.SetActive(true);
            distFrame.SetActive(true);
            stereoFrame.SetActive(false);
            stereoTitle.SetActive(false);
        }
        else if (glbScr.anserBtnsType == "AmpDist")
        {
            ampTitle.SetActive(true);
            ampFrame.SetActive(true);
            distTitle.SetActive(true);
            distFrame.SetActive(true);
            stereoFrame.SetActive(false);
            stereoTitle.SetActive(false);
        }
        else if (glbScr.anserBtnsType == "DistStereo")
        {
            ampTitle.SetActive(false);
            ampFrame.SetActive(false);
            distTitle.SetActive(true);
            distFrame.SetActive(true);
            stereoFrame.SetActive(true);
            stereoTitle.SetActive(true);
        }
        else if (glbScr.anserBtnsType == "All")
        {
            ampTitle.SetActive(true);
            ampFrame.SetActive(true);
            distTitle.SetActive(true);
            distFrame.SetActive(true);
            stereoFrame.SetActive(true);
            stereoTitle.SetActive(true);
        }
    }

    /// <summary>
    /// FX BUTTON FUNCTIONS
    /// </summary>
    public void noChangeBtnClick()
    {
        noChangeSel = true;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        noChangeBtn.GetComponent<Image>().color = selected;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 0;
        userExString = "No Change";
    }
    public void b3BtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = true;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = selected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 1;
        userExString = "3 dB Boost";
    }
    public void c3BtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = true;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = selected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 2;
        userExString = "3 dB Cut";
    }
    public void b3dBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = true;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = selected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 3;
        userExString = "3 dB Boost During";
    }
    public void c3dBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = true;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = selected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 4;
        userExString = "3 dB Cut During";
    }
    public void gDistBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = true;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = selected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 5;
        userExString = "Gross Distortion";
    }
    public void sDistBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = true;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = selected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        answerSelected = true;
        userEx = 6;
        userExString = "Slight Distortion";
    }
    public void LRflippedBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = true;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = selected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        pan = 1.5f;
        startMono = false;
        userEx = 7;
        userExString = "Left & Right Flipped";
        answerSelected = true;
    }
    public void StereoToMonoBntClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = true;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = selected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        pan = 2.5f;
        startMono = false;
        userEx = 8;
        userExString = "Stereo to Mono";
        answerSelected = true;
    }
    public void MonoToStereoBtnClick()
    {
        noChangeSel = false;
        noChangeBtn.GetComponent<Image>().color = notSelected;
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = true;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = selected;
        pan = 0.5f;
        startMono = true;
        userEx = 9;
        userExString = "Mono to Stereo";
        answerSelected = true;
    }

    void MusicDropdownActivation()
    {
        if (glbScr.pinkOrMusic == "PN")
        {
            audioDropdown.SetActive(false);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
        }
    }
    public void GenreDropdown()
    {
        genreValue = genreDropdown.value;
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        firstPlay = true;
    }
    public void PlayButtonClick()
    {
        if (!isPlaying)
        {
            //RANDOMISE THE EXERCISE.
            if (firstPlay)
            {
                RandomiseEx();
            }


            if (glbScr.anserBtnsType == "Amplitude")
            {
                StartCoroutine(PlayAmplitudeExercise());
            }
            else if (glbScr.anserBtnsType == "Distortion")
            {
                StartCoroutine(PlayDistortionExercise());
            }
            else if (glbScr.anserBtnsType == "Stereo")
            {
                StartCoroutine(PlayStereoExercice());
            }
            else if (glbScr.anserBtnsType == "AmpDist")
            {
                if (effectType == "Amplitude")
                {
                    StartCoroutine(PlayAmplitudeExercise());
                }
                else if (effectType == "Distortion")
                {
                    StartCoroutine(PlayDistortionExercise());
                }
            }
            else if (glbScr.anserBtnsType == "DistStereo")
            {
                if (effectType == "Stereo")
                {
                    StartCoroutine(PlayStereoExercice());
                }
                else if (effectType == "Distortion")
                {
                    StartCoroutine(PlayDistortionExercise());
                }
            }
            else if (glbScr.anserBtnsType == "All")
            {
                if (effectType == "Stereo")
                {
                    StartCoroutine(PlayStereoExercice());
                }
                else if (effectType == "Distortion")
                {
                    StartCoroutine(PlayDistortionExercise());
                }
                else if (effectType == "Amplitude")
                {
                    StartCoroutine(PlayAmplitudeExercise());
                }
            }
        }
    }
    IEnumerator PlayAmplitudeExercise()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;

        //START THE INTRODUCTION INTRO
        isPlaying = true;
        playBtn.GetComponent<Image>().color = playing;
        audSource.clip = newExClip;
        audSource.loop = false;
        audSource.Play();

        yield return new WaitForSeconds(2);
        audSource.Stop();

        /*        if (firstPlay)
                {
                    fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
                    fmodEvent.setParameterByName("volume", 0);
                    fmodEvent.start();
                }
                else if (!firstPlay)
                {
                    fmodEvent.setPaused(false);
                }*/

        fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        fmodEvent.setParameterByName("volume", 0);
        fmodEvent.start();

        yield return new WaitForSeconds(9);
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        if (during)
        {
            volume = 0;
        }
        fxOn = true;

        if (!during)
        {
            fmodEvent.setParameterByName("volume", volume);
        }
        else if (during)
        {

        }

        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(9);

        //PAUSE AFTER X SECONDS AND THEN PLAY WITH EFFECT OFF
        if (during)
        {
            volume = 0;
        }
        fxOn = false;
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        //fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        fmodEvent.setParameterByName("volume", 0);
        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(5);

        //RESET EVERYTHING
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        playBtnText.text = "PLAY";
        playBtn.GetComponent<Image>().color = waiting;
        genreDropdown.enabled = true;
        isPlaying = false;
        firstPlay = false;
        modCon.appIsPlaying = false;
    }
    IEnumerator PlayDistortionExercise()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;

        //RANDOMISE THE EXERCISE.
        if (firstPlay)
        {
            RandomiseEx();
        }

        //START THE INTRODUCTION INTRO
        isPlaying = true;
        playBtn.GetComponent<Image>().color = playing;
        audSource.clip = newExClip;
        audSource.loop = false;
        audSource.Play();

        yield return new WaitForSeconds(2);
        audSource.Stop();

        /*        if (firstPlay)
                {
                    fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
                    fmodEvent.setParameterByName("dist", 0);
                    fmodEvent.start();
                }
                else if (!firstPlay)
                {
                    fmodEvent.setPaused(false);
                }*/

        fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        fmodEvent.setParameterByName("dist", 0);
        fmodEvent.start();

        yield return new WaitForSeconds(9);
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        fxOn = true;
        fmodEvent.setParameterByName("dist", dist);

        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(9);

        //PAUSE AFTER X SECONDS AND THEN PLAY WITH EFFECT OFF
        fxOn = false;
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        //fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        fmodEvent.setParameterByName("dist", 0);
        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(5);

        //RESET EVERYTHING
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        playBtnText.text = "PLAY";
        playBtn.GetComponent<Image>().color = waiting;
        genreDropdown.enabled = true;
        isPlaying = false;
        firstPlay = false;
        modCon.appIsPlaying = false;
    }
    IEnumerator PlayStereoExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;

        //RANDOMISE THE EXERCISE.
        if (firstPlay)
        {
            RandomiseEx();
        }

        //START THE INTRODUCTION INTRO
        isPlaying = true;
        playBtn.GetComponent<Image>().color = playing;
        audSource.clip = newExClip;
        audSource.loop = false;
        audSource.Play();

        yield return new WaitForSeconds(2);
        audSource.Stop();

        /*        if (firstPlay)
                {
                    fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
                    if (startMono)
                    {
                        fmodEvent.setParameterByName("pan", 2.5f);
                    }
                    else if (!startMono)
                    {
                        fmodEvent.setParameterByName("pan", 0);
                    }
                    fmodEvent.start();
                }
                else if (!firstPlay)
                {
                    fmodEvent.setPaused(false);
                }*/

        fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        if (startMono)
        {
            fmodEvent.setParameterByName("pan", 2.5f);
        }
        else if (!startMono)
        {
            fmodEvent.setParameterByName("pan", 0);
        }
        fmodEvent.start();

        yield return new WaitForSeconds(9);
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        fxOn = true;
        fmodEvent.setParameterByName("pan", pan);

        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(9);

        //PAUSE AFTER X SECONDS AND THEN PLAY WITH EFFECT OFF
        fxOn = false;
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        //fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        if (startMono)
        {
            fmodEvent.setParameterByName("pan", 2.5f);
        }
        else if (!startMono)
        {
            fmodEvent.setParameterByName("pan", 0);
        }

        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(5);

        //RESET EVERYTHING
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        playBtnText.text = "PLAY";
        playBtn.GetComponent<Image>().color = waiting;
        genreDropdown.enabled = true;
        isPlaying = false;
        firstPlay = false;
        modCon.appIsPlaying = false;
    }
    public void SubmitBtnClick()
    {
        if(ranExString == userExString)
        {
            previousAns = ranEx;
            attempts += 1;
            correct += 1;
            netGlbScr.pracEx++;
            netGlbScr.userScore = netGlbScr.userScore + 30;
            firstPlay = true;
            previousText.text = "Previous Answer: " + curAnsString;
            StartCoroutine(ansRight());
            ResetAllButtons();
        }
        else if (ranExString != userExString)
        {
            previousAns = ranEx;
            attempts += 1;
            netGlbScr.pracEx++;
            netGlbScr.userScore = netGlbScr.userScore + 10;
            StartCoroutine(ansWrong());
            previousText.text = "Previous Answer: " + curAnsString;
            ResetAllButtons();
        }
        StartCoroutine(UpdateStats());
    }
    public IEnumerator ansRight()
    {
        rightGO.SetActive(true);
        yield return new WaitForSeconds(1);
        rightGO.SetActive(false);
    }
    public IEnumerator ansWrong()
    {
        wrongGO.SetActive(true);
        yield return new WaitForSeconds(1);
        wrongGO.SetActive(false);
    }
    void ResetAllButtons()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3BtnSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        answerSelected = false;
    }
    void GenreChange()
    {
        if (genreValue == 0)
        {
            //genreValue = "Acoustic";
            fmodEvent.setParameterByName("track", 0.5f);
        }
        else if (genreValue == 1)
        {
            //genre = "Rock";
            fmodEvent.setParameterByName("track", 1.5f);
        }
        else if (genreValue == 2)
        {
            //genre = "Pop";
            fmodEvent.setParameterByName("track", 2.5f);
        }
        else if (genreValue == 3)
        {
            //genre = "Indie";
            fmodEvent.setParameterByName("track", 1.5f);
        }
    }
    //NETWORKING
    IEnumerator UpdateStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.userID.ToString());
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("pracEx", netGlbScr.pracEx);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/pracExUpdate.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

        }
        www.Dispose();
    }
}
