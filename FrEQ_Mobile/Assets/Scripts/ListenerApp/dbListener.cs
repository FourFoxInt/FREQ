using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class dbListener : MonoBehaviour
{
    private Globals glbScr;
    private ModuleController modCon;
    private NetworkGlobals netGlbScr;

    //COLOURS
    [SerializeField] private Color selected;
    [SerializeField] private Color notSelected;
    [SerializeField] private Color playing;
    [SerializeField] private Color waiting;

    //Music dropdown
    [SerializeField] GameObject musicFrame;
    [SerializeField] TMP_Dropdown genreDropdown;
    [SerializeField] private int genreValue;

    //Freq1
    [SerializeField] GameObject freq1DropdownGO;
    [SerializeField] TMP_Dropdown freq1Dropdown;
    [SerializeField] private int freq1Value;
    //Freq2
    [SerializeField] GameObject freq2DropdownGO;
    [SerializeField] TMP_Dropdown freq2Dropdown;
    [SerializeField] private int freq2Value;

    //CB1
    [SerializeField] private GameObject freq1CutBoostFrame;
    [SerializeField] private GameObject freq1BoostBtn;[SerializeField] private GameObject freq1CutBtn;
    public bool freq1Boost = false; public bool freq1Cut = false;
    [SerializeField] private float cutBoost1Value;

    //CB2
    [SerializeField] private GameObject freq2CutBoostFrame;
    [SerializeField] private GameObject freq2BoostBtn;[SerializeField] private GameObject freq2CutBtn;
    public bool freq2Boost = false; public bool freq2Cut = false;
    [SerializeField] private float cutBoost2Value;

    //UI
    [SerializeField] private TextMeshProUGUI playBtnText;
    [SerializeField] private Button playBtn;
    public string title;
    public string desc;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descText;

    //Choices
    [SerializeField] private string userCutBoost;
    [SerializeField] private string userFreqString;

    //Audio
    private float userFreq1;
    private float userFreq2;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool eqOn = false;
    public float gain1;
    public float gain2;
    [SerializeField] private bool firstPlay = true;

    private void Start()
    {
        modCon = GameObject.Find("Canvas_Main").GetComponent<ModuleController>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        if (glbScr.pinkOrMusic == "PN")
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/dbpn");
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/dbmusic");
        }

        if (glbScr.cutOrBoost == "Cut")
        {
            gain1 = 2.5f;
            gain2 = 2.5f;
        }
        else if (glbScr.cutOrBoost == "Boost")
        {
            gain1 = 1.5f;
            gain2 = 1.5f;
        }else if(glbScr.cutOrBoost == "Both")
        {
            gain1 = cutBoost1Value;
            gain2 = cutBoost2Value;
        }

        ButtonActivations();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }

    private void Update()
    {
        GenreChange();
        Freq1Change();
        Freq2Change();
      
        if (!isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = true;
        }
        else if (isPlaying)
        {
            playBtn.GetComponent<Button>().interactable = false;
        }

        if (glbScr.cutOrBoost == "Cut")
        {
            gain1 = 2.5f;
            gain2 = 2.5f;
        }
        else if (glbScr.cutOrBoost == "Boost")
        {
            gain1 = 1.5f;
            gain2 = 1.5f;
        }
        else if (glbScr.cutOrBoost == "Both")
        {
            gain1 = cutBoost1Value;
            gain2 = cutBoost2Value;
        }

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }

    void ButtonActivations()
    {
        if (glbScr.pinkOrMusic == "MUS")
        {
            musicFrame.SetActive(true);
        }
        else if (glbScr.pinkOrMusic == "PN")
        {
            musicFrame.SetActive(false);
        }

        if (glbScr.cutOrBoost == "Both")
        {
            freq1CutBoostFrame.SetActive(true);
            freq2CutBoostFrame.SetActive(true);
        }
        else if (glbScr.cutOrBoost == "Cut" || glbScr.cutOrBoost == "Boost")
        {
            freq1CutBoostFrame.SetActive(false);
            freq2CutBoostFrame.SetActive(false);
        }
    }
    public void GenreDropdown()
    {
        genreValue = genreDropdown.value;
        fmodEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        firstPlay = true;
    }

    public void Freq1BoostBtn()
    {
        freq1Boost = true;
        freq1Cut = false;
        freq1BoostBtn.GetComponent<Image>().color = selected;
        freq1CutBtn.GetComponent<Image>().color = notSelected;
        cutBoost1Value = 1.5f;
    }
    public void Freq1CutBtn()
    {
        freq1Boost = false;
        freq1Cut = true;
        freq1BoostBtn.GetComponent<Image>().color = notSelected;
        freq1CutBtn.GetComponent<Image>().color = selected;
        cutBoost1Value = 2.5f;
    }
    public void Freq2BoostBtn()
    {
        freq2Boost = true;
        freq2Cut = false;
        freq2BoostBtn.GetComponent<Image>().color = selected;
        freq2CutBtn.GetComponent<Image>().color = notSelected;
        cutBoost2Value = 1.5f;
    }
    public void Freq2CutBtn()
    {
        freq2Boost = false;
        freq2Cut = true;
        freq2BoostBtn.GetComponent<Image>().color = notSelected;
        freq2CutBtn.GetComponent<Image>().color = selected;
        cutBoost2Value = 2.5f;
    }
    /// <summary>
    /// Audio Player Code
    /// </summary>
    public void PlayButtonClick()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayExercice());
        }
    }
    IEnumerator PlayExercice()
    {
        modCon.appIsPlaying = true;
        genreDropdown.enabled = false;
        isPlaying = true;
        fmodEvent.setParameterByName("freq", userFreq1);
        fmodEvent.setParameterByName("freq2", userFreq2);
        playBtnText.text = "PLAYING";

        if (firstPlay)
        {
            if (glbScr.pinkOrMusic == "PN")
            {
                fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/dbpn");
            }
            else if (glbScr.pinkOrMusic == "MUS")
            {
                fmodEvent = FMODUnity.RuntimeManager.CreateInstance("event:/dbmusic");
            }
            fmodEvent.setParameterByName("freq", userFreq1);
            fmodEvent.setParameterByName("freq2", userFreq2);
            fmodEvent.setParameterByName("gain", 0);
            fmodEvent.setParameterByName("gain2", 0);
            fmodEvent.start();
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
        }

        playBtn.GetComponent<Image>().color = playing;
        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }else if(glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(6);
        }
        eqOn = true;
        fmodEvent.setParameterByName("gain", gain1);
        fmodEvent.setParameterByName("gain2", gain2);

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(6);
        }
        eqOn = false;
        fmodEvent.setParameterByName("gain", 0);
        fmodEvent.setParameterByName("gain2", 0);
        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(2);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(4);
        }
        fmodEvent.setPaused(true);
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
            fmodEvent.setParameterByName("track", 1);
        }
        else if (genreValue == 1)
        {
            //genre = "Rock";
            fmodEvent.setParameterByName("track", 2);
        }
        else if (genreValue == 2)
        {
            //genre = "Pop";
            fmodEvent.setParameterByName("track", 3);
        }
        else if (genreValue == 3)
        {
            //genre = "Indie";
            fmodEvent.setParameterByName("track", 4);
        }
    }

    //NETWORKING
    IEnumerator UpdateStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.userID.ToString());
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("listenEx", netGlbScr.listenEx);

        UnityWebRequest www = UnityWebRequest.Post("https://ffet.000webhostapp.com/mobilePhp/listenExUpdate.php", form);
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

    public void Freq1Change()
    {
        if(freq1Value == 0)
        {
            userFreq1 = 1;
        }else if(freq1Value == 1)
        {
            userFreq1 = 4;
        }
        else if (freq1Value == 2)
        {
            userFreq1 = 7;
        }
        else if (freq1Value == 3)
        {
            userFreq1 = 10;
        }
        else if (freq1Value == 4)
        {
            userFreq1 = 13;
        }
        else if (freq1Value == 5)
        {
            userFreq1 = 16;
        }
        else if (freq1Value == 6)
        {
            userFreq1 = 19;
        }
        else if (freq1Value == 7)
        {
            userFreq1 = 22;
        }
        else if (freq1Value == 8)
        {
            userFreq1 = 25;
        }
        else if (freq1Value == 9)
        {
            userFreq1 = 28;
        }
    }
    public void Freq2Change()
    {
        if (freq2Value == 0)
        {
            userFreq2 = 1;
        }
        else if (freq2Value == 1)
        {
            userFreq2 = 4;
        }
        else if (freq2Value == 2)
        {
            userFreq2 = 7;
        }
        else if (freq2Value == 3)
        {
            userFreq2 = 10;
        }
        else if (freq2Value == 4)
        {
            userFreq2 = 13;
        }
        else if (freq2Value == 5)
        {
            userFreq2 = 16;
        }
        else if (freq2Value == 6)
        {
            userFreq2 = 19;
        }
        else if (freq2Value == 7)
        {
            userFreq2 = 22;
        }
        else if (freq2Value == 8)
        {
            userFreq2 = 25;
        }
        else if (freq2Value == 9)
        {
            userFreq2 = 28;
        }
    }

    public void Freq1Dropdown()
    {
        freq1Value = freq1Dropdown.value;
    }
    public void Freq2Dropdown()
    {
        freq2Value = freq2Dropdown.value;
    }
}

