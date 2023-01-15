using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class fXlistener : MonoBehaviour
{
    private Globals glbScr;
    private ModuleController modCon;
    private NetworkGlobals netGlbScr;

    //COLOURS
    [SerializeField] private Color selected;
    [SerializeField] private Color notSelected;
    [SerializeField] private Color playing;
    [SerializeField] private Color waiting;
    [SerializeField] private Color fxOnColour;
    [SerializeField] private Color fxOffColour;

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
    public string title;
    public string desc;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;

    //Verification
    private bool answerSelected = false;

    //Choices
    [SerializeField] private string userAnswer;

    //Audio
    private float userFreq;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool fxOn = false;
    public bool cut = false;
    public float volume;
    public float pan;
    public float dist;
    public float speed = 0.5f;
    public bool during = false;
    [SerializeField] private bool firstPlay = true;
    private bool startMono = false;

    private void Start()
    {
        modCon = GameObject.Find("Canvas_Main").GetComponent<ModuleController>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        ButtonActivations();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }

    private void Update()
    {
        GenreChange();
        //GameObject.Find("Listener").GetComponent<AnswersScaling>().ScaleAnswers();
        if (!isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = true;
        }
        else if (isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = false;
        }

        titleText.text = title;
        descText.text = desc;

        if (!cut)
        {
            if (volume <= 4 && fxOn && during)
            {
                volume += 1 * speed * Time.deltaTime;
                fmodEvent.setParameterByName("volume", volume);
            }
        }else if (cut)
        {
            if (volume >= -4 && fxOn && during)
            {
                volume -= 1 * speed * Time.deltaTime;
                fmodEvent.setParameterByName("volume", volume);
            }
        }
    }

    void ButtonActivations()
    {
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
    public void GenreDropdown()
    {
        genreValue = genreDropdown.value;
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        firstPlay = true;
    }

    /// <summary>
    /// FX BUTTON FUNCTIONS
    /// </summary>
    public void b3BtnClick()
    {
        b3BtnSel = true;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = selected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        volume = 4;
        during = false;
        cut = false;
    }
    public void c3BtnClick()
    {
        b3BtnSel = false;
        c3BtnSel = true;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = selected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        volume = -4;
        during = false;
        cut = true;
    }
    public void b3dBtnClick()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = true;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = selected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        volume = 4;
        during = true;
        cut = false;
    }
    public void c3dBtnClick()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = true;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = selected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        volume = -4;
        during = true;
        cut = true;
    }
    public void gDistBtnClick()
    {
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
        dist = 2.5f;
    }
    public void sDistBtnClick()
    {
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
        dist = 1.5f;
    }
    public void LRflippedBtnClick()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = true;
        stereoToMonoSel = false;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = selected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        pan = 1.5f;
        startMono = false;
    }
    public void StereoToMonoBntClick()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = true;
        monoToStereoSel = false;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = selected;
        monoToStereoBtn.GetComponent<Image>().color = notSelected;
        pan = 2.5f;
        startMono = false;
    }
    public void MonoToStereoBtnClick()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3dBtnSel = false;
        gDistSel = false;
        sDistSel = false;
        LRflipedSel = false;
        stereoToMonoSel = false;
        monoToStereoSel = true;
        b3Btn.GetComponent<Image>().color = notSelected;
        c3Btn.GetComponent<Image>().color = notSelected;
        b3dBtn.GetComponent<Image>().color = notSelected;
        c3dBtn.GetComponent<Image>().color = notSelected;
        gDistBtn.GetComponent<Image>().color = notSelected;
        sDistBtn.GetComponent<Image>().color = notSelected;
        LRflipedBtn.GetComponent<Image>().color = notSelected;
        stereoToMonoBtn.GetComponent<Image>().color = notSelected;
        monoToStereoBtn.GetComponent<Image>().color = selected;
        pan = 0.5f;
        startMono = true;
    }

    void ResetAllButtons()
    {
        b3BtnSel = false;
        c3BtnSel = false;
        b3dBtnSel = false;
        c3BtnSel = false;
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
        answerSelected = false;
    }

    /// <summary>
    /// Audio Player Code
    /// </summary>
    public void PlayButtonClick()
    {
        Debug.Log("CLICKED");
        if (!isPlaying)
        {
            if (glbScr.anserBtnsType == "Amplitude")
            {
                StartCoroutine(PlayAmpExercice());
            }
            else if (glbScr.anserBtnsType == "Distortion")
            {
                StartCoroutine(PlayDistortionExercice());
            }
            else if (glbScr.anserBtnsType == "Stereo")
            {
                StartCoroutine(PlayStereoExercice());
            }
        }
    }
    IEnumerator PlayAmpExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;
        isPlaying = true;
        fmodEvent.setParameterByName("freq", userFreq);
        playBtnText.text = "PLAYING";

        //START FIRST PLAY
        if (firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("volume", 0);
            fmodEvent.start();
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
        }

        playBtn.GetComponent<Image>().color = playing;
        yield return new WaitForSeconds(9);

        //PAUSE AFTER 3 SECONDS AND THEN PLAY WITH EFFECT ON
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
        if (during)
        {
            volume = 0;
        }
        fxOn = true;
        playBtn.GetComponent<Image>().color = fxOnColour;
        playBtnText.text = "FX ON";
        //fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
        if (!during)
        {
            fmodEvent.setParameterByName("volume", volume);
        }else if (during)
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
        playBtn.GetComponent<Image>().color = playing;
        playBtnText.text = "FX OFF";
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
        modCon.appIsPlaying = false;
        netGlbScr.listenEx++;
        netGlbScr.userScore = netGlbScr.userScore + 10;
        StartCoroutine(UpdateStats());
    }
    IEnumerator PlayDistortionExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;
        isPlaying = true;
        fmodEvent.setParameterByName("freq", userFreq);
        playBtnText.text = "PLAYING";

        //START FIRST PLAY
        if (firstPlay)
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");
            fmodEvent.setParameterByName("dist", 0);
            fmodEvent.start();
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
        }

        playBtn.GetComponent<Image>().color = playing;
        yield return new WaitForSeconds(9);

        //PAUSE AFTER 3 SECONDS AND THEN PLAY WITH EFFECT ON
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);

        fxOn = true;
        playBtn.GetComponent<Image>().color = fxOnColour;
        playBtnText.text = "FX ON";
        //fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/fxMusic");

        fmodEvent.setParameterByName("dist", dist);
        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(9);

        //PAUSE AFTER X SECONDS AND THEN PLAY WITH EFFECT OFF
        fxOn = false;
        playBtn.GetComponent<Image>().color = fxOffColour;
        playBtnText.text = "FX OFF";
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
        //firstPlay = false;
        modCon.appIsPlaying = false;
        netGlbScr.listenEx++;
        netGlbScr.userScore = netGlbScr.userScore + 10;
        StartCoroutine(UpdateStats());
    }
    IEnumerator PlayStereoExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;
        isPlaying = true;
        if (startMono)
        {
            fmodEvent.setParameterByName("pan", 2.5f);
        }
        else if (!startMono)
        {
            fmodEvent.setParameterByName("pan", 0);
        }
        playBtnText.text = "PLAYING";

        //START FIRST PLAY
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
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
        }
        playBtn.GetComponent<Image>().color = playing;
        yield return new WaitForSeconds(9);

        //PAUSE AFTER 3 SECONDS AND THEN PLAY WITH EFFECT ON
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);

        fxOn = true;
        playBtn.GetComponent<Image>().color = fxOnColour;
        playBtnText.text = "FX ON";
        fmodEvent.setParameterByName("pan", pan);
        fmodEvent.setPaused(false);
        yield return new WaitForSeconds(9);

        //PAUSE AFTER X SECONDS AND THEN PLAY WITH EFFECT OFF
        fxOn = false;
        playBtn.GetComponent<Image>().color = fxOffColour;
        playBtnText.text = "FX OFF";
        fmodEvent.setPaused(true);
        yield return new WaitForSeconds(1.5f);
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
        modCon.appIsPlaying = false;
        netGlbScr.listenEx++;
        netGlbScr.userScore = netGlbScr.userScore + 10;
        StartCoroutine(UpdateStats());
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
        form.AddField("listenEx", netGlbScr.listenEx);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/listenExUpdate.php", form);
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
