using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class dbPractice : MonoBehaviour
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
    [SerializeField] GameObject audioDropdown;
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
    public float userCutBoost1;


    //CB2
    [SerializeField] private GameObject freq2CutBoostFrame;
    [SerializeField] private GameObject freq2BoostBtn;[SerializeField] private GameObject freq2CutBtn;
    public bool freq2Boost = false; public bool freq2Cut = false;
    [SerializeField] private float cutBoost2Value;
    public float userCutBoost2;

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
    private bool freq1Selected = false;
    private bool freq2Selected = false;
    private bool cutBoost1Selected = false;
    private bool cutBoost2Selected = false;

    //Choices
    [SerializeField] private string userCutBoost;
    [SerializeField] private string userFreqString;

    //Audio
    [SerializeField] private string ranCutBoost1String;
    [SerializeField] private string ranFreq1String;
    [SerializeField] private float ranFreq1;
    [SerializeField] private string ranCutBoost2String;
    [SerializeField] private string ranFreq2String;
    [SerializeField] private float ranFreq2;
    [SerializeField] private string curAnsString;
    [SerializeField] private float previousAns1;
    [SerializeField] private float previousAns2;
    private float userFreq1;
    private float userFreq2;
    private string userCb1;
    private string userCb2;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool eqOn = false;
    private string ranCb1;
    private string ranCb2;
    public float gain1 = 1.5f;
    public float gain2 = 1.5f;
    [SerializeField] private bool firstPlay = true;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioClip newExClip;

    //RESULTS
    private int attempts = 0;
    private int correct = 0;
    [SerializeField] private GameObject rightGO;
    [SerializeField] private GameObject wrongGO;

    private void Start()
    {
        freq1Selected = false;
        freq2Selected = false;
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

        if (glbScr.cutOrBoost == "Both")
        {
            curAnsString = ranCutBoost1String + " " + ranFreq1String + " and " + ranCutBoost2String + " " + ranFreq2String;
        }else if(glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            curAnsString = ranFreq1String + " and " + ranFreq2String;
        }

        scoreText.text = correct.ToString() + " out of " + attempts.ToString();

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;

        if (isPlaying)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }
    }
   
    void RandomiseFreq1()
    {
        float ran = Random.Range(glbScr.minFreq, glbScr.maxFreq);

        //Ten band freqs
        if (ran >= 0 && ran <= 10)
        {
            ranFreq1 = 1;
            ranFreq1String = "31 Hz";
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            ranFreq1 = 4;
            ranFreq1String = "63 Hz";
        }
        else if (ran >= 20.01 && ran <= 30)
        {
            ranFreq1 = 7;
            ranFreq1String = "125 Hz";
        }
        else if (ran >= 30.01 && ran <= 40)
        {
            ranFreq1 = 10;
            ranFreq1String = "250 Hz";
        }
        else if (ran >= 40.01 && ran <= 50)
        {
            ranFreq1 = 13;
            ranFreq1String = "500 Hz";
        }
        else if (ran >= 50.01 && ran <= 60)
        {
            ranFreq1 = 16;
            ranFreq1String = "1 kHz";
        }
        else if (ran >= 60.01 && ran <= 70)
        {
            ranFreq1 = 19;
            ranFreq1String = "2 kHz";
        }
        else if (ran >= 70.01 && ran <= 80)
        {
            ranFreq1 = 22;
            ranFreq1String = "4 kHz";
        }
        else if (ran >= 80.01 && ran <= 90)
        {
            ranFreq1 = 25;
            ranFreq1String = "8 kHz";
        }
        else if (ran >= 90.01 && ran <= 100)
        {
            ranFreq1 = 28;
            ranFreq1String = "16 kHz";
        }

        if (ranFreq1 == previousAns1)
        {
            RandomiseFreq1();
        }
        RandomiseFreq2();
    }
    void RandonCutBoost1()
    {
        float ran = Random.Range(0, 20);
        if (ran >= 0 && ran <= 10)
        {
            ranCb1 = "Cut";
            gain1 = 2.5f;
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            ranCb1 = "Boost";
            gain1 = 1.5f;
        }
    }
    void RandomiseFreq2()
    {
        float ran = Random.Range(glbScr.minFreq, glbScr.maxFreq);

        //Ten band freqs
        if (ran >= 0 && ran <= 10)
        {
            ranFreq2 = 1;
            ranFreq2String = "31 Hz";
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            ranFreq2 = 4;
            ranFreq2String = "63 Hz";
        }
        else if (ran >= 20.01 && ran <= 30)
        {
            ranFreq2 = 7;
            ranFreq2String = "125 Hz";
        }
        else if (ran >= 30.01 && ran <= 40)
        {
            ranFreq2 = 10;
            ranFreq2String = "250 Hz";
        }
        else if (ran >= 40.01 && ran <= 50)
        {
            ranFreq2 = 13;
            ranFreq2String = "500 Hz";
        }
        else if (ran >= 50.01 && ran <= 60)
        {
            ranFreq2 = 16;
            ranFreq2String = "1 kHz";
        }
        else if (ran >= 60.01 && ran <= 70)
        {
            ranFreq2 = 19;
            ranFreq2String = "2 kHz";
        }
        else if (ran >= 70.01 && ran <= 80)
        {
            ranFreq2 = 22;
            ranFreq2String = "4 kHz";
        }
        else if (ran >= 80.01 && ran <= 90)
        {
            ranFreq2 = 25;
            ranFreq2String = "8 kHz";
        }
        else if (ran >= 90.01 && ran <= 100)
        {
            ranFreq2 = 28;
            ranFreq2String = "16 kHz";
        }

        if (ranFreq2 == previousAns2 || ranFreq2 == ranFreq1)
        {
            RandomiseFreq1();
        }
    }
    void RandonCutBoost2()
    {
        float ran = Random.Range(0, 20);
        if (ran >= 0 && ran <= 10)
        {
            ranCb2 = "Cut";
            gain2 = 2.5f;
        }
        else if (ran >= 10.01 && ran <= 20)
        {
            ranCb2 = "Boost";
            gain2 = 1.5f;
        }
    }
    void ButtonActivations()
    {
        if (glbScr.cutOrBoost == "Boost" && glbScr.pinkOrMusic == "PN" || glbScr.cutOrBoost == "Cut" && glbScr.pinkOrMusic == "PN")
        {
            audioDropdown.SetActive(false);
            freq1CutBoostFrame.SetActive(false);
            freq2CutBoostFrame.SetActive(false);
        } else if (glbScr.cutOrBoost == "Boost" && glbScr.pinkOrMusic == "MUS" || glbScr.cutOrBoost == "Cut" && glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
            freq1CutBoostFrame.SetActive(false);
            freq2CutBoostFrame.SetActive(false);
        } else if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "PN")
        {
            audioDropdown.SetActive(false);
            freq1CutBoostFrame.SetActive(true);
            freq2CutBoostFrame.SetActive(true);
        }
        else if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
            freq1CutBoostFrame.SetActive(true);
            freq2CutBoostFrame.SetActive(true);
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
    public void PlayButtonClick()
    {
        if (!isPlaying)
        {
            StartCoroutine(PlayExercise());
        }
    }
    IEnumerator PlayExercise()
    {
        modCon.appIsPlaying = true;
        if (glbScr.pinkOrMusic == "MUS")
        {
            genreDropdown.enabled = false;
        }

        if (firstPlay)
        {
            RandomiseFreq1();
            //RandomiseFreq2();
            if (glbScr.cutOrBoost == "Both")
            {
                RandonCutBoost1();
                RandonCutBoost2();
            }
        }

        isPlaying = true;
        playBtn.GetComponent<Image>().color = playing;
        audSource.clip = newExClip;
        audSource.loop = false;
        audSource.Play();

        yield return new WaitForSeconds(2);

        audSource.Stop();

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

            fmodEvent.setParameterByName("freq", ranFreq1);
            fmodEvent.setParameterByName("freq2", ranFreq2);
            fmodEvent.setParameterByName("gain", 0);
            fmodEvent.setParameterByName("gain2", 0);
            fmodEvent.start();
            isPlaying = true;
        }
        else if (!firstPlay)
        {
            fmodEvent.setPaused(false);
            isPlaying = true;
        }

        firstPlay = false;

        fmodEvent.setParameterByName("gain", 0);

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(3);
        }
        else if (glbScr.pinkOrMusic == "MUS")
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

        fmodEvent.setParameterByName("gain2", 0);
        fmodEvent.setParameterByName("gain", 0);
        eqOn = false;

        if (glbScr.pinkOrMusic == "PN")
        {
            yield return new WaitForSeconds(2);
        }
        else if (glbScr.pinkOrMusic == "MUS")
        {
            yield return new WaitForSeconds(4);
        }
        fmodEvent.setPaused(true);
        isPlaying = false;
        playBtn.GetComponent<Image>().color = waiting;
        if (glbScr.pinkOrMusic == "MUS")
        {
            genreDropdown.enabled = true;
        }
        modCon.appIsPlaying = false;
    }
    public void SubmitBtnClick()
    {
        if (glbScr.cutOrBoost == "Cut" || glbScr.cutOrBoost == "Boost")
        {
            if (ranFreq1 == userFreq1 && ranFreq2 == userFreq2 || ranFreq1 == userFreq2 && ranFreq2 == userFreq1)
            {
                previousAns1 = ranFreq1;
                previousAns2 = ranFreq2;
                attempts += 1;
                correct += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 60;
                firstPlay = true;
                previousText.text = "Previous Answer: " + curAnsString;
                StartCoroutine(ansRight());
                ResetAllButtons();
            }
            else if (ranFreq1 != userFreq1 || ranFreq2 != userFreq2 || ranFreq1 != userFreq2 || ranFreq2 != userFreq1)
            {
                previousAns1 = ranFreq1;
                previousAns2 = ranFreq2;
                attempts += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 10;
                StartCoroutine(ansWrong());
                previousText.text = "Previous Answer: " + curAnsString;
                ResetAllButtons();
            }
        }
        else if (glbScr.cutOrBoost == "Both")
        {
            if (ranFreq1 == userFreq1 && ranCb1 == userCb1 && ranFreq2 == userFreq2 && ranCb2 == userCb2
                || ranFreq1 == userFreq2 && ranCb1 == userCb2 && ranFreq2 == userFreq1 && ranCb2 == userCb1)
            {
                previousAns1 = ranFreq1;
                previousAns2 = ranFreq2;
                attempts += 1;
                correct += 1;
                netGlbScr.pracEx++;
                netGlbScr.userScore = netGlbScr.userScore + 30;
                firstPlay = true;
                previousText.text = "Previous Answer: " + curAnsString;
                StartCoroutine(ansRight());
                ResetAllButtons();
            }
            else
            {
                previousAns1 = ranFreq1;
                previousAns2 = ranFreq2;
                attempts += 1;
                netGlbScr.pracEx++;
                firstPlay = true;
                netGlbScr.userScore = netGlbScr.userScore + 10;
                previousText.text = "Previous Answer: " + curAnsString;
                StartCoroutine(ansWrong());
                ResetAllButtons();
            }
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
        freq1Selected = false;
        freq2Selected = false;
        cutBoost1Selected = false;
        cutBoost2Selected = false;
        RandomiseFreq1();
        //RandomiseFreq2();
        if (glbScr.cutOrBoost == "Both")
        {
            RandonCutBoost1();
            RandonCutBoost2();
        }else if(glbScr.cutOrBoost == "Boost")
        {
            ranCb1 = "Boost";
            ranCb2 = "Boost";
            gain1 = 1.5f;
            gain2 = 1.5f;
        }
        else if (glbScr.cutOrBoost == "Cut")
        {
            ranCb1 = "Cut";
            ranCb2 = "Cut";
            gain1 = 2.5f;
            gain2 = 2.5f;
        }
        firstPlay = true;
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
        form.AddField("studentID", netGlbScr.username);
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("pracEx", netGlbScr.pracEx);

        UnityWebRequest www = UnityWebRequest.Post("https://ffet.000webhostapp.com/mobilePhp/pracExUpdate.php", form);
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
        if (freq1Value == 0)
        {
            userFreq1 = 1;
            userFreqString = "31 Hz";
        }
        else if (freq1Value == 1)
        {
            userFreq1 = 4;
            userFreqString = "63 Hz";
        }
        else if (freq1Value == 2)
        {
            userFreq1 = 7;
            userFreqString = "125 Hz";
        }
        else if (freq1Value == 3)
        {
            userFreq1 = 10;
            userFreqString = "250 Hz";
        }
        else if (freq1Value == 4)
        {
            userFreq1 = 13;
            userFreqString = "500 Hz";
        }
        else if (freq1Value == 5)
        {
            userFreq1 = 16;
            userFreqString = "1 kHz";
        }
        else if (freq1Value == 6)
        {
            userFreq1 = 19;
            userFreqString = "2 kHz";
        }
        else if (freq1Value == 7)
        {
            userFreq1 = 22;
            userFreqString = "4 kHz";
        }
        else if (freq1Value == 8)
        {
            userFreq1 = 25; 
            userFreqString = "8 kHz";
        }
        else if (freq1Value == 9)
        {
            userFreq1 = 28;
            userFreqString = "16 kHz";
        }
    }
    public void Freq2Change()
    {
        if (freq2Value == 0)
        {
            userFreq2 = 1;
            userFreqString = "31 Hz";
        }
        else if (freq2Value == 1)
        {
            userFreq2 = 4;
            userFreqString = "63 Hz";
        }
        else if (freq2Value == 2)
        {
            userFreq2 = 7;
            userFreqString = "125 Hz";
        }
        else if (freq2Value == 3)
        {
            userFreq2 = 10;
            userFreqString = "250 Hz";
        }
        else if (freq2Value == 4)
        {
            userFreq2 = 13;
            userFreqString = "500 Hz";
        }
        else if (freq2Value == 5)
        {
            userFreq2 = 16;
            userFreqString = "1 kHz";
        }
        else if (freq2Value == 6)
        {
            userFreq2 = 19;
            userFreqString = "2 kHz";
        }
        else if (freq2Value == 7)
        {
            userFreq2 = 22;
            userFreqString = "4 kHz";
        }
        else if (freq2Value == 8)
        {
            userFreq2 = 25;
            userFreqString = "8 kHz";
        }
        else if (freq2Value == 9)
        {
            userFreq2 = 28;
            userFreqString = "16 kHz";
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
