using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class FxExam : MonoBehaviour
{
    private Globals glbScr;
    private NetworkGlobals netGlbScr;
    [SerializeField] private GameObject fxExamGO;

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
    [SerializeField] private Button submitBtn;
    [SerializeField] private TextMeshProUGUI playBtnText;
    [SerializeField] private Button playBtn;
    public string title;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI playText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int curEx = 1;
    [SerializeField] private GameObject closeTestCanvas;
    [SerializeField] private Button closeTestBtn;
    [SerializeField] private GameObject successText;

    //Verification
    [SerializeField] private bool answerSelected = false;
    public bool testRunning = false;
    public bool testComplete = false;

    //Choices
    [SerializeField] private float userEx;
    [SerializeField] private string userExString;
    [SerializeField] private string ranExString;
    [SerializeField] private float ranEx;
    [SerializeField] private string curAnsString;
    public int score;
    [SerializeField] private float previousAns;

    //Audio
    private float userFreq;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool fxOn = false;
    public bool cut = false;
    public float volume;
    public float speed = 0.5f;
    public float pan;
    public float dist;
    public bool startMono = false;
    public bool during = false;
    [SerializeField] private bool firstPlay = true;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioClip newExClip;
    private string effectType;

    //Example Intro Audio Clips. 
    [SerializeField] private AudioClip ex1Clip;[SerializeField] private AudioClip ex2Clip;[SerializeField] private AudioClip ex3Clip;[SerializeField] private AudioClip ex4Clip;[SerializeField] private AudioClip ex5Clip;
    [SerializeField] private AudioClip ex6Clip;[SerializeField] private AudioClip ex7Clip;[SerializeField] private AudioClip ex8Clip;

    public float ex1CorrectAnswer; public string ex1CorrectAnswerText;
    public float ex2CorrectAnswer; public string ex2CorrectAnswerText;
    public float ex3CorrectAnswer; public string ex3CorrectAnswerText;
    public float ex4CorrectAnswer; public string ex4CorrectAnswerText;
    public float ex5CorrectAnswer; public string ex5CorrectAnswerText;
    public float ex6CorrectAnswer; public string ex6CorrectAnswerText;
    public float ex7CorrectAnswer; public string ex7CorrectAnswerText;
    public float ex8CorrectAnswer; public string ex8CorrectAnswerText;

    public float ex1UserAnswer; public string ex1UserAnswerText;
    public float ex2UserAnswer; public string ex2UserAnswerText;
    public float ex3UserAnswer; public string ex3UserAnswerText;
    public float ex4UserAnswer; public string ex4UserAnswerText;
    public float ex5UserAnswer; public string ex5UserAnswerText;
    public float ex6UserAnswer; public string ex6UserAnswerText;
    public float ex7UserAnswer; public string ex7UserAnswerText;
    public float ex8UserAnswer; public string ex8UserAnswerText;

    [SerializeField] private GameObject resultsCanvas;

    private void Start()
    {
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        ButtonActivations();
        MusicDropdownActivation();

        titleText.text = title;

        RandomiseEx();
    }
    private void Update()
    {
        GenreChange();

        if (isPlaying)
        {
            playText.text = "PLAYING EX " + curEx.ToString();
            closeTestBtn.interactable = false;
        }
        else if (!isPlaying && !firstPlay)
        {
            playText.text = "REPLAY";
            closeTestBtn.interactable = true;
        }
        else if (!isPlaying)
        {
            playText.text = "PLAY EX " + curEx.ToString() + " OUT OF 8";
            if (closeTestBtn != null)
            {
                closeTestBtn.interactable = true;
            }
        }

        if (isPlaying || firstPlay)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying && answerSelected)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }

        titleText.text = title;

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
    }
    public void ButtonActivations()
    {
        if (glbScr.canNoChange)
        {
            Debug.Log("Should be showing the no change button");
            noChangeFrame.SetActive(true);
        }
        else if (glbScr.canNoChange == false)
        {
            Debug.Log("Should NOT be showing the no change button");
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
    public void noChangeBtnClick()
    {
        noChangeSel = true;
        noChangeBtn.GetComponent<Image>().color = selected;
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
    public void PlayButtonClick()
    {
        if (curEx == 1)
        {
            testRunning = true;
        }
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
        genreDropdown.enabled = false;

        if (firstPlay)
        {
            RandomiseEx();
        }
        IntroClip();
        isPlaying = true;
        yield return new WaitForSeconds(0.1f);
        audSource.loop = false;
        audSource.Play();
        yield return new WaitForSeconds(2);
        audSource.Stop();
        if (firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("volume", 0);
            fmodEvent.start();
            isPlaying = true;
        }
        else if (!firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("volume", 0);
            fmodEvent.start();
            isPlaying = true;
        }
        firstPlay = false;
        fmodEvent.setParameterByName("gain", 0);

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
        //firstPlay = false;

    }
    IEnumerator PlayDistortionExercise()
    {
        genreDropdown.enabled = false;

        if (firstPlay)
        {
            RandomiseEx();
        }
        IntroClip();
        isPlaying = true;
        yield return new WaitForSeconds(0.1f);
        audSource.loop = false;
        audSource.Play();
        yield return new WaitForSeconds(2);
        audSource.Stop();
        if (firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("dist", 0);
            fmodEvent.start();
            isPlaying = true;
        }
        else if (!firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("dist", 0);
            fmodEvent.start();
            isPlaying = true;
        }
        firstPlay = false;
        fmodEvent.setParameterByName("dist", 0);

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
        fmodEvent.setParameterByName("dist", dist);
        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(5);

        //RESET EVERYTHING
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        playBtnText.text = "PLAY";
        playBtn.GetComponent<Image>().color = waiting;
        genreDropdown.enabled = true;
        isPlaying = false;
        //firstPlay = false;
    }
    IEnumerator PlayStereoExercice()
    {
        genreDropdown.enabled = false;

        if (firstPlay)
        {
            RandomiseEx();
        }
        IntroClip();
        isPlaying = true;
        yield return new WaitForSeconds(0.1f);
        audSource.loop = false;
        audSource.Play();
        yield return new WaitForSeconds(2);
        audSource.Stop();
        if (firstPlay)
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
            isPlaying = true;
        }
        else if (!firstPlay)
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
            isPlaying = true;
        }
        firstPlay = false;
        if (startMono)
        {
            fmodEvent.setParameterByName("pan", 2.5f);
        }
        else if (!startMono)
        {
            fmodEvent.setParameterByName("pan", 0);
        }

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
        //firstPlay = false;
    }
    public void SubmitBtnClick()
    {
        if (ranEx == userEx)
        {
            firstPlay = true;
            score += 1;
            previousAns = ranEx;
            ResetAllButtons();
            SetAnswers();
        }
        else if (ranEx != userEx)
        {
            firstPlay = true;
            previousAns = ranEx;
            ResetAllButtons();
            SetAnswers();
        }

        if (curEx != 8)
        {
            curEx += 1;
        }
        else if (curEx == 8)
        {
            testRunning = false;
            Results();
            if (score >= glbScr.passMark)
            {
                TestLevelCheck();
            }
        }
    }
    void Results()
    {
        scoreText.text = score.ToString() + " out of 8"; ;
        resultsCanvas.SetActive(true);
        StartCoroutine(PostResults());

        netGlbScr.userScore += score * 10;
        netGlbScr.tests += 1;
        //StartCoroutine(UpdateStats());
        //netGlbScript.sessionTests = netGlbScript.sessionTests + 1;
        //testCanvas.SetActive(false);
    }
    void SetAnswers()
    {
        if (curEx == 1)
        {
            ex1CorrectAnswer = ranEx;
            ex1UserAnswer = userFreq;

            ex1CorrectAnswerText = ranExString;
            ex1UserAnswerText = userExString;
        }
        if (curEx == 2)
        {
            ex2CorrectAnswer = ranEx;
            ex2UserAnswer = userFreq;

            ex2CorrectAnswerText = ranExString;
            ex2UserAnswerText = userExString;
        }
        if (curEx == 3)
        {
            ex3CorrectAnswer = ranEx;
            ex3UserAnswer = userFreq;

            ex3CorrectAnswerText = ranExString;
            ex3UserAnswerText = userExString;
        }
        if (curEx == 4)
        {
            ex4CorrectAnswer = ranEx;
            ex4UserAnswer = userFreq;

            ex4CorrectAnswerText = ranExString;
            ex4UserAnswerText = userExString;
        }
        if (curEx == 5)
        {
            ex5CorrectAnswer = ranEx;
            ex5UserAnswer = userFreq;

            ex5CorrectAnswerText = ranExString;
            ex5UserAnswerText = userExString;
        }
        if (curEx == 6)
        {
            ex6CorrectAnswer = ranEx;
            ex6UserAnswer = userFreq;

            ex6CorrectAnswerText = ranExString;
            ex6UserAnswerText = userExString;
        }
        if (curEx == 7)
        {
            ex7CorrectAnswer = ranEx;
            ex7UserAnswer = userFreq;

            ex7CorrectAnswerText = ranExString;
            ex7UserAnswerText = userExString;
        }
        if (curEx == 8)
        {
            ex8CorrectAnswer = ranEx;
            ex8UserAnswer = userFreq;

            ex8CorrectAnswerText = ranExString;
            ex8UserAnswerText = userExString;
        }
    }
    void IntroClip()
    {
        if (curEx == 1)
        {
            audSource.clip = ex1Clip;
        }
        else if (curEx == 2)
        {
            audSource.clip = ex2Clip;
        }
        else if (curEx == 3)
        {
            audSource.clip = ex3Clip;
        }
        else if (curEx == 4)
        {
            audSource.clip = ex4Clip;
        }
        else if (curEx == 5)
        {
            audSource.clip = ex5Clip;
        }
        else if (curEx == 6)
        {
            audSource.clip = ex6Clip;
        }
        else if (curEx == 7)
        {
            audSource.clip = ex7Clip;
        }
        else if (curEx == 8)
        {
            audSource.clip = ex8Clip;
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
                RandomiseEx();
            }
        }
    }

    public void ResetAllButtons()
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
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
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
    }
    public void RestartTest()
    {
        ResetAllButtons();
        curEx = 1;
        score = 0;
        firstPlay = true;
        testComplete = false;
        resultsCanvas.SetActive(false);
    }
    IEnumerator PostResults()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);
        form.AddField("appTestID", glbScr.appTestID);
        form.AddField("score", score);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/postTestResult.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            successText.SetActive(true);
        }
        www.Dispose();
    }
    IEnumerator UpdateStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.username);
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("tests", netGlbScr.tests);
        form.AddField("testLevel", netGlbScr.testLevel);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/testExUpdate.php", form);
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
    void TestLevelCheck()
    {

        if (glbScr.appTestID == "Y1EQ_M1" || glbScr.globalTestId == "M1T1")
        {
            if (netGlbScr.testLevel <= 1)
            {
                netGlbScr.testLevel = 2;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M2" || glbScr.globalTestId == "M1T2")
        {
            if (netGlbScr.testLevel <= 2)
            {
                netGlbScr.testLevel = 3;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M3" || glbScr.globalTestId == "M1T3")
        {
            if (netGlbScr.testLevel <= 3)
            {
                netGlbScr.testLevel = 4;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M4" || glbScr.globalTestId == "M2T1")
        {
            if (netGlbScr.testLevel <= 4)
            {
                netGlbScr.testLevel = 5;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M5" || glbScr.globalTestId == "M2T2")
        {
            if (netGlbScr.testLevel <= 5)
            {
                netGlbScr.testLevel = 6;
            }
        }
        else if (glbScr.appTestID == "Y1EQ_M6" || glbScr.globalTestId == "M2T3")
        {
            if (netGlbScr.testLevel <= 6)
            {
                netGlbScr.testLevel = 7;
            }
        }

        //YEAR 2
        else if (glbScr.appTestID == "Y2EQ_M1" || glbScr.globalTestId == "M3T1")
        {
            if (netGlbScr.testLevel <= 7)
            {
                netGlbScr.testLevel = 8;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M2" || glbScr.globalTestId == "M3T2")
        {
            if (netGlbScr.testLevel <= 8)
            {
                netGlbScr.testLevel = 9;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M3" || glbScr.globalTestId == "M3T3")
        {
            if (netGlbScr.testLevel <= 9)
            {
                netGlbScr.testLevel = 10;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M4" || glbScr.globalTestId == "M4T1")
        {
            if (netGlbScr.testLevel <= 10)
            {
                netGlbScr.testLevel = 11;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M5" || glbScr.globalTestId == "M4T2")
        {
            if (netGlbScr.testLevel <= 11)
            {
                netGlbScr.testLevel = 12;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M6" || glbScr.globalTestId == "M4T3")
        {
            if (netGlbScr.testLevel <= 12)
            {
                netGlbScr.testLevel = 13;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M7" || glbScr.globalTestId == "M5T1")
        {
            if (netGlbScr.testLevel <= 13)
            {
                netGlbScr.testLevel = 14;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M8" || glbScr.globalTestId == "M5T2")
        {
            if (netGlbScr.testLevel <= 14)
            {
                netGlbScr.testLevel = 15;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M9" || glbScr.globalTestId == "M5T3")
        {
            if (netGlbScr.testLevel <= 15)
            {
                netGlbScr.testLevel = 16;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M10" || glbScr.globalTestId == "M6T1")
        {
            if (netGlbScr.testLevel <= 16)
            {
                netGlbScr.testLevel = 17;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M11" || glbScr.globalTestId == "M6T2")
        {
            if (netGlbScr.testLevel <= 17)
            {
                netGlbScr.testLevel = 18;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M12" || glbScr.globalTestId == "M6T3")
        {
            if (netGlbScr.testLevel <= 18)
            {
                netGlbScr.testLevel = 19;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M13" || glbScr.globalTestId == "M7T1")
        {
            if (netGlbScr.testLevel <= 19)
            {
                netGlbScr.testLevel = 20;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M14" || glbScr.globalTestId == "M7T2")
        {
            if (netGlbScr.testLevel <= 20)
            {
                netGlbScr.testLevel = 21;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M15" || glbScr.globalTestId == "M7T3")
        {
            if (netGlbScr.testLevel <= 21)
            {
                netGlbScr.testLevel = 22;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M16" || glbScr.globalTestId == "M8T1")
        {
            if (netGlbScr.testLevel <= 22)
            {
                netGlbScr.testLevel = 23;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M17" || glbScr.globalTestId == "M8T2")
        {
            if (netGlbScr.testLevel <= 23)
            {
                netGlbScr.testLevel = 24;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M18" || glbScr.globalTestId == "M8T3")
        {
            if (netGlbScr.testLevel <= 24)
            {
                netGlbScr.testLevel = 25;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M19" || glbScr.globalTestId == "M9T1")
        {
            if (netGlbScr.testLevel <= 25)
            {
                netGlbScr.testLevel = 26;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M20" || glbScr.globalTestId == "M9T2")
        {
            if (netGlbScr.testLevel <= 26)
            {
                netGlbScr.testLevel = 27;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M21" || glbScr.globalTestId == "M9T3")
        {
            if (netGlbScr.testLevel <= 27)
            {
                netGlbScr.testLevel = 28;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M22" || glbScr.globalTestId == "M10T1")
        {
            if (netGlbScr.testLevel <= 28)
            {
                netGlbScr.testLevel = 29;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M23" || glbScr.globalTestId == "M10T2")
        {
            if (netGlbScr.testLevel <= 29)
            {
                netGlbScr.testLevel = 30;
            }
        }
        else if (glbScr.appTestID == "Y2EQ_M24" || glbScr.globalTestId == "M10T3")
        {
            if (netGlbScr.testLevel <= 30)
            {
                netGlbScr.testLevel = 31;
            }
        }

        //YEAR3
        else if (glbScr.appTestID == "Y3EQ_M1" || glbScr.globalTestId == "M11T1")
        {
            if (netGlbScr.testLevel <= 31)
            {
                netGlbScr.testLevel = 32;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M2" || glbScr.globalTestId == "M11T2")
        {
            if (netGlbScr.testLevel <= 32)
            {
                netGlbScr.testLevel = 33;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M3" || glbScr.globalTestId == "M11T3")
        {
            if (netGlbScr.testLevel <= 33)
            {
                netGlbScr.testLevel = 34;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M4" || glbScr.globalTestId == "M12T1")
        {
            if (netGlbScr.testLevel <= 34)
            {
                netGlbScr.testLevel = 35;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M5" || glbScr.globalTestId == "M12T2")
        {
            if (netGlbScr.testLevel <= 35)
            {
                netGlbScr.testLevel = 36;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M6" || glbScr.globalTestId == "M12T3")
        {
            if (netGlbScr.testLevel <= 36)
            {
                netGlbScr.testLevel = 37;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M7" || glbScr.globalTestId == "M13T1")
        {
            if (netGlbScr.testLevel <= 37)
            {
                netGlbScr.testLevel = 38;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M8" || glbScr.globalTestId == "M13T2")
        {
            if (netGlbScr.testLevel <= 38)
            {
                netGlbScr.testLevel = 39;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M9" || glbScr.globalTestId == "M13T3")
        {
            if (netGlbScr.testLevel <= 39)
            {
                netGlbScr.testLevel = 40;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M10" || glbScr.globalTestId == "M14T1")
        {
            if (netGlbScr.testLevel <= 40)
            {
                netGlbScr.testLevel = 41;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M11" || glbScr.globalTestId == "M14T2")
        {
            if (netGlbScr.testLevel <= 41)
            {
                netGlbScr.testLevel = 42;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M12" || glbScr.globalTestId == "M14T3")
        {
            if (netGlbScr.testLevel <= 42)
            {
                netGlbScr.testLevel = 43;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M13" || glbScr.globalTestId == "M15T1")
        {
            if (netGlbScr.testLevel <= 43)
            {
                netGlbScr.testLevel = 44;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M14" || glbScr.globalTestId == "M15T2")
        {
            if (netGlbScr.testLevel <= 44)
            {
                netGlbScr.testLevel = 45;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M15" || glbScr.globalTestId == "M15T3")
        {
            if (netGlbScr.testLevel <= 45)
            {
                netGlbScr.testLevel = 46;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M16" || glbScr.globalTestId == "M16T1")
        {
            if (netGlbScr.testLevel <= 46)
            {
                netGlbScr.testLevel = 47;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M17" || glbScr.globalTestId == "M16T2")
        {
            if (netGlbScr.testLevel <= 47)
            {
                netGlbScr.testLevel = 48;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M18" || glbScr.globalTestId == "M16T3")
        {
            if (netGlbScr.testLevel <= 48)
            {
                netGlbScr.testLevel = 49;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M19" || glbScr.globalTestId == "M17T1")
        {
            if (netGlbScr.testLevel <= 49)
            {
                netGlbScr.testLevel = 50;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M20" || glbScr.globalTestId == "M17T2")
        {
            if (netGlbScr.testLevel <= 50)
            {
                netGlbScr.testLevel = 51;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M21" || glbScr.globalTestId == "M17T3")
        {
            if (netGlbScr.testLevel <= 51)
            {
                netGlbScr.testLevel = 52;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M22" || glbScr.globalTestId == "M18T1")
        {
            if (netGlbScr.testLevel <= 52)
            {
                netGlbScr.testLevel = 53;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M23" || glbScr.globalTestId == "M18T2")
        {
            if (netGlbScr.testLevel <= 53)
            {
                netGlbScr.testLevel = 54;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M24" || glbScr.globalTestId == "M18T3")
        {
            if (netGlbScr.testLevel <= 54)
            {
                netGlbScr.testLevel = 55;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M25" || glbScr.globalTestId == "M19T1")
        {
            if (netGlbScr.testLevel <= 55)
            {
                netGlbScr.testLevel = 56;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M26" || glbScr.globalTestId == "M19T2")
        {
            if (netGlbScr.testLevel <= 56)
            {
                netGlbScr.testLevel = 57;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M27" || glbScr.globalTestId == "M19T3")
        {
            if (netGlbScr.testLevel <= 57)
            {
                netGlbScr.testLevel = 58;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M28" || glbScr.globalTestId == "M20T1")
        {
            if (netGlbScr.testLevel <= 58)
            {
                netGlbScr.testLevel = 59;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M29" || glbScr.globalTestId == "M20T2")
        {
            if (netGlbScr.testLevel <= 59)
            {
                netGlbScr.testLevel = 60;
            }
        }
        else if (glbScr.appTestID == "Y3EQ_M30" || glbScr.globalTestId == "M20T3")
        {
            if (netGlbScr.testLevel <= 61)
            {
                netGlbScr.testLevel = 62;
            }
        }
        StartCoroutine(UpdateStats());
    }
    public void TestCloseBtn()
    {
        if (testRunning)
        {
            closeTestCanvas.SetActive(true);
        }
        else
        {
            ResetAllButtons();
            RestartTest();
            CloseAppButton();
        }
    }

    public void YesClose()
    {
        closeTestCanvas.SetActive(false);
        ResetAllButtons();
        RestartTest();
        CloseAppButton();
    }
    public void NoClose()
    {
        closeTestCanvas.SetActive(false);
    }

    void CloseAppButton()
    {
        closeTestCanvas.SetActive(false);
        fxExamGO.SetActive(false);
        resultsCanvas.SetActive(false);
    }
}