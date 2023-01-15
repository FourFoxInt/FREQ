using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class dbTest : MonoBehaviour
{
    private Globals glbScr;
    private ModuleController modCon;
    private NetworkGlobals netGlbScr;
    public bool canHalfMark = false;

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
    [SerializeField] private TextMeshProUGUI playText;
    public int curEx = 1;
    [SerializeField] private GameObject closeTestCanvas;
    [SerializeField] private Button closeTestBtn;
    [SerializeField] private GameObject testSubErrorCanvas;
    [SerializeField] private GameObject successText;


    //Verification
    [SerializeField] private bool freqSelected = false;
    [SerializeField] private bool cutBoostSelected = false;
    public bool testRunning = false;
    public bool testComplete = false;

    //Choices
    [SerializeField] private string ranCutBoost1String;
    [SerializeField] private string ranFreq1String;
    [SerializeField] private float ranFreq1;
    [SerializeField] private string ranCutBoost2String;
    [SerializeField] private string ranFreq2String;
    [SerializeField] private float ranFreq2;
    [SerializeField] private string curAnsString;
    public int score;
    [SerializeField] private float previousAns1;
    [SerializeField] private float previousAns2;

    //Audio

    public float userFreq1;
    public string userFreq1string;
    public float userFreq2;
    public string userFreq2string;
    public string userCb1;
    public string userCb2;
    FMOD.Studio.EventInstance fmodEvent;
    public bool isPlaying = false;
    public bool eqOn = false;
    public string ranCb1;
    public string ranCb2;
    public float gain1 = 1.5f;
    public float gain2 = 1.5f;
    [SerializeField] private bool firstPlay = true;
    [SerializeField] private AudioSource audSource;
    [SerializeField] private AudioClip newExClip;
    //Example Intro Audio Clips. 
    [SerializeField] private AudioClip ex1Clip;[SerializeField] private AudioClip ex2Clip;[SerializeField] private AudioClip ex3Clip;[SerializeField] private AudioClip ex4Clip;[SerializeField] private AudioClip ex5Clip;
    [SerializeField] private AudioClip ex6Clip;[SerializeField] private AudioClip ex7Clip;[SerializeField] private AudioClip ex8Clip;[SerializeField] private AudioClip ex9Clip;[SerializeField] private AudioClip ex10Clip;

    //First Option Answers
    public float ex1CorrectAnswer1; public string ex1CorrectAnswerText1; public float ex2CorrectAnswer1; public string ex2CorrectAnswerText1;
    public float ex3CorrectAnswer1; public string ex3CorrectAnswerText1;public float ex4CorrectAnswer1; public string ex4CorrectAnswerText1;
    public float ex5CorrectAnswer1; public string ex5CorrectAnswerText1;public float ex6CorrectAnswer1; public string ex6CorrectAnswerText1;
    public float ex7CorrectAnswer1; public string ex7CorrectAnswerText1;public float ex8CorrectAnswer1; public string ex8CorrectAnswerText1;
    public float ex9CorrectAnswer1; public string ex9CorrectAnswerText1;public float ex10CorrectAnswer1; public string ex10CorrectAnswerText1;

    public string ex1correctCbAns1;
    public string ex2correctCbAns1;
    public string ex3correctCbAns1;
    public string ex4correctCbAns1;
    public string ex5correctCbAns1;
    public string ex6correctCbAns1;
    public string ex7correctCbAns1;
    public string ex8correctCbAns1;
    public string ex9correctCbAns1;
    public string ex10correctCbAns1;

    public float ex1UserAnswer1; public string ex1UserAnswerText1;
    public float ex2UserAnswer1; public string ex2UserAnswerText1;
    public float ex3UserAnswer1; public string ex3UserAnswerText1;
    public float ex4UserAnswer1; public string ex4UserAnswerText1;
    public float ex5UserAnswer1; public string ex5UserAnswerText1;
    public float ex6UserAnswer1; public string ex6UserAnswerText1;
    public float ex7UserAnswer1; public string ex7UserAnswerText1;
    public float ex8UserAnswer1; public string ex8UserAnswerText1;
    public float ex9UserAnswer1; public string ex9UserAnswerText1;
    public float ex10UserAnswer1; public string ex10UserAnswerText1;

    public string ex1userCbAns1;
    public string ex2userCbAns1;
    public string ex3userCbAns1;
    public string ex4userCbAns1;
    public string ex5userCbAns1;
    public string ex6userCbAns1;
    public string ex7userCbAns1;
    public string ex8userCbAns1;
    public string ex9userCbAns1;
    public string ex10userCbAns1;


    //SCECOND OPTION ANSWERS
    public float ex1CorrectAnswer2; public string ex1CorrectAnswerText2; public float ex2CorrectAnswer2; public string ex2CorrectAnswerText2;
    public float ex3CorrectAnswer2; public string ex3CorrectAnswerText2; public float ex4CorrectAnswer2; public string ex4CorrectAnswerText2;
    public float ex5CorrectAnswer2; public string ex5CorrectAnswerText2; public float ex6CorrectAnswer2; public string ex6CorrectAnswerText2;
    public float ex7CorrectAnswer2; public string ex7CorrectAnswerText2; public float ex8CorrectAnswer2; public string ex8CorrectAnswerText2;
    public float ex9CorrectAnswer2; public string ex9CorrectAnswerText2; public float ex10CorrectAnswer2; public string ex10CorrectAnswerText2;

    public string ex1correctCbAns2;
    public string ex2correctCbAns2;
    public string ex3correctCbAns2;
    public string ex4correctCbAns2;
    public string ex5correctCbAns2;
    public string ex6correctCbAns2;
    public string ex7correctCbAns2;
    public string ex8correctCbAns2;
    public string ex9correctCbAns2;
    public string ex10correctCbAns2;

    public float ex1UserAnswer2; public string ex1UserAnswerText2;
    public float ex2UserAnswer2; public string ex2UserAnswerText2;
    public float ex3UserAnswer2; public string ex3UserAnswerText2;
    public float ex4UserAnswer2; public string ex4UserAnswerText2;
    public float ex5UserAnswer2; public string ex5UserAnswerText2;
    public float ex6UserAnswer2; public string ex6UserAnswerText2;
    public float ex7UserAnswer2; public string ex7UserAnswerText2;
    public float ex8UserAnswer2; public string ex8UserAnswerText2;
    public float ex9UserAnswer2; public string ex9UserAnswerText2;
    public float ex10UserAnswer2; public string ex10UserAnswerText2;

    public string ex1userCbAns2;
    public string ex2userCbAns2;
    public string ex3userCbAns2;
    public string ex4userCbAns2;
    public string ex5userCbAns2;
    public string ex6userCbAns2;
    public string ex7userCbAns2;
    public string ex8userCbAns2;
    public string ex9userCbAns2;
    public string ex10userCbAns2;

    private int answer1true = 0;
    private int answer1cBtrue = 0;
    
    [SerializeField] private GameObject resultsCanvas;

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
        Freq1Change();
        Freq2Change();

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
            playText.text = "PLAY EX " + curEx.ToString() + " out of 10";
            if (closeTestBtn != null)
            {
                closeTestBtn.interactable = true;
            }
        }

        if (isPlaying || firstPlay)
        {
            submitBtn.GetComponent<Button>().interactable = false;
        }
        else if (!isPlaying)
        {
            submitBtn.GetComponent<Button>().interactable = true;
        }

        title = glbScr.currentTitle;
        desc = glbScr.currentDesc;

        titleText.text = title;
        descText.text = desc;
    }

    void ButtonActivations()
    {
        if (glbScr.cutOrBoost == "Boost" && glbScr.pinkOrMusic == "PN" || glbScr.cutOrBoost == "Cut" && glbScr.pinkOrMusic == "PN")
        {
            audioDropdown.SetActive(false);
            freq1CutBoostFrame.SetActive(false);
            freq2CutBoostFrame.SetActive(false);
        }
        else if (glbScr.cutOrBoost == "Boost" && glbScr.pinkOrMusic == "MUS" || glbScr.cutOrBoost == "Cut" && glbScr.pinkOrMusic == "MUS")
        {
            audioDropdown.SetActive(true);
            freq1CutBoostFrame.SetActive(false);
            freq2CutBoostFrame.SetActive(false);
        }
        else if (glbScr.cutOrBoost == "Both" && glbScr.pinkOrMusic == "PN")
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
    
    public void PlayButtonClick()
    {
        if (curEx == 1)
        {
            testRunning = true;
        }
        if (!isPlaying)
        {
            StartCoroutine(PlayExercise());
        }
    }
    IEnumerator PlayExercise()
    {
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
        IntroClip();
        isPlaying = true;
        yield return new WaitForSeconds(0.1f);
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
        if (glbScr.cutOrBoost == "Boost" || glbScr.cutOrBoost == "Cut")
        {
            CutOrBoostAnswersCheck();
        }
        else if (glbScr.cutOrBoost == "Both")
        {
            BothAnswerCheck();
        }

        if (curEx != 10)
        {
            curEx += 1;
        }
        else if (curEx == 10)
        {
            testRunning = false;
            Results();
            if (score >= glbScr.passMark)
            {
                TestLevelCheck();
            }
        }
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
    void Results()
    {
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
            ex1CorrectAnswer1 = ranFreq1;
            ex1CorrectAnswer2 = ranFreq2;
            ex1UserAnswer1 = userFreq1;
            ex1UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex1correctCbAns1 = ranCb1;
                ex1correctCbAns2 = ranCb2;
                ex1userCbAns1 = userCb1;
                ex1userCbAns2 = userCb2;

                ex1CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex1CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex1UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex1UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }

            ex1CorrectAnswerText1 = ranFreq1String;
            ex1CorrectAnswerText2 = ranFreq2String;
            ex1UserAnswerText1 = userFreq1string;
            ex1UserAnswerText2 = userFreq2string;
        }
        if (curEx == 2)
        {
            ex2CorrectAnswer1 = ranFreq1;
            ex2CorrectAnswer2 = ranFreq2;
            ex2UserAnswer1 = userFreq1;
            ex2UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex2correctCbAns1 = ranCb1;
                ex2correctCbAns2 = ranCb2;
                ex2userCbAns1 = userCb1;
                ex2userCbAns2 = userCb2;

                ex2CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex2CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex2UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex2UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex2CorrectAnswerText1 = ranFreq1String;
            ex2CorrectAnswerText2 = ranFreq2String;
            ex2UserAnswerText1 = userFreq1string;
            ex2UserAnswerText2 = userFreq2string;
        }
        if (curEx == 3)
        {
            ex3CorrectAnswer1 = ranFreq1;
            ex3CorrectAnswer2 = ranFreq2;
            ex3UserAnswer1 = userFreq1;
            ex3UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex3correctCbAns1 = ranCb1;
                ex3correctCbAns2 = ranCb2;
                ex3userCbAns1 = userCb1;
                ex3userCbAns2 = userCb2;

                ex3CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex3CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex3UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex3UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex3CorrectAnswerText1 = ranFreq1String;
            ex3CorrectAnswerText2 = ranFreq2String;
            ex3UserAnswerText1 = userFreq1string;
            ex3UserAnswerText2 = userFreq2string;
        }
        if (curEx == 4)
        {
            ex4CorrectAnswer1 = ranFreq1;
            ex4CorrectAnswer2 = ranFreq2;
            ex4UserAnswer1 = userFreq1;
            ex4UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex4correctCbAns1 = ranCb1;
                ex4correctCbAns2 = ranCb2;
                ex4userCbAns1 = userCb1;
                ex4userCbAns2 = userCb2;

                ex4CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex4CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex4UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex4UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex4CorrectAnswerText1 = ranFreq1String;
            ex4CorrectAnswerText2 = ranFreq2String;
            ex4UserAnswerText1 = userFreq1string;
            ex4UserAnswerText2 = userFreq2string;
        }
        if (curEx == 5)
        {
            ex5CorrectAnswer1 = ranFreq1;
            ex5CorrectAnswer2 = ranFreq2;
            ex5UserAnswer1 = userFreq1;
            ex5UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex5correctCbAns1 = ranCb1;
                ex5correctCbAns2 = ranCb2;
                ex5userCbAns1 = userCb1;
                ex5userCbAns2 = userCb2;

                ex5CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex5CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex5UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex5UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex5CorrectAnswerText1 = ranFreq1String;
            ex5CorrectAnswerText2 = ranFreq2String;
            ex5UserAnswerText1 = userFreq1string;
            ex5UserAnswerText2 = userFreq2string;
        }
        if (curEx == 6)
        {
            ex6CorrectAnswer1 = ranFreq1;
            ex6CorrectAnswer2 = ranFreq2;
            ex6UserAnswer1 = userFreq1;
            ex6UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex6correctCbAns1 = ranCb1;
                ex6correctCbAns2 = ranCb2;
                ex6userCbAns1 = userCb1;
                ex6userCbAns2 = userCb2;

                ex6CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex6CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex6UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex6UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex6CorrectAnswerText1 = ranFreq1String;
            ex6CorrectAnswerText2 = ranFreq2String;
            ex6UserAnswerText1 = userFreq1string;
            ex6UserAnswerText2 = userFreq2string;
        }
        if (curEx == 7)
        {
            ex7CorrectAnswer1 = ranFreq1;
            ex7CorrectAnswer2 = ranFreq2;
            ex7UserAnswer1 = userFreq1;
            ex7UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex7correctCbAns1 = ranCb1;
                ex7correctCbAns2 = ranCb2;
                ex7userCbAns1 = userCb1;
                ex7userCbAns2 = userCb2;

                ex7CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex7CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex7UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex7UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex7CorrectAnswerText1 = ranFreq1String;
            ex7CorrectAnswerText2 = ranFreq2String;
            ex7UserAnswerText1 = userFreq1string;
            ex7UserAnswerText2 = userFreq2string;
        }
        if (curEx == 8)
        {
            ex8CorrectAnswer1 = ranFreq1;
            ex8CorrectAnswer2 = ranFreq2;
            ex8UserAnswer1 = userFreq1;
            ex8UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex8correctCbAns1 = ranCb1;
                ex8correctCbAns2 = ranCb2;
                ex8userCbAns1 = userCb1;
                ex8userCbAns2 = userCb2;

                ex8CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex8CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex8UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex8UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex8CorrectAnswerText1 = ranFreq1String;
            ex8CorrectAnswerText2 = ranFreq2String;
            ex8UserAnswerText1 = userFreq1string;
            ex8UserAnswerText2 = userFreq2string;
        }
        if (curEx == 9)
        {
            ex9CorrectAnswer1 = ranFreq1;
            ex9CorrectAnswer2 = ranFreq2;
            ex9UserAnswer1 = userFreq1;
            ex9UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex9correctCbAns1 = ranCb1;
                ex9correctCbAns2 = ranCb2;
                ex9userCbAns1 = userCb1;
                ex9userCbAns2 = userCb2;

                ex9CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex9CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex9UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex9UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex9CorrectAnswerText1 = ranFreq1String;
            ex9CorrectAnswerText2 = ranFreq2String;
            ex9UserAnswerText1 = userFreq1string;
            ex9UserAnswerText2 = userFreq2string;
        }
        if (curEx == 10)
        {
            ex10CorrectAnswer1 = ranFreq1;
            ex10CorrectAnswer2 = ranFreq2;
            ex10UserAnswer1 = userFreq1;
            ex10UserAnswer2 = userFreq2;

            if (glbScr.cutOrBoost == "Both")
            {
                ex10correctCbAns1 = ranCb1;
                ex10correctCbAns2 = ranCb2;
                ex10userCbAns1 = userCb1;
                ex10userCbAns2 = userCb2;

                ex10CorrectAnswerText1 = ranCb1.ToString() + " " + ranFreq1String;
                ex10CorrectAnswerText2 = ranCb2.ToString() + " " + ranFreq2String;
                ex10UserAnswerText1 = userCb1.ToString() + " " + userFreq1string;
                ex10UserAnswerText2 = userCb2.ToString() + " " + userFreq2string;
            }
            ex10CorrectAnswerText1 = ranFreq1String;
            ex10CorrectAnswerText2 = ranFreq2String;
            ex10UserAnswerText1 = userFreq1string;
            ex10UserAnswerText2 = userFreq2string;
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
        else if (curEx == 9)
        {
            audSource.clip = ex9Clip;
        }
        else if (curEx == 10)
        {
            audSource.clip = ex10Clip;
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
    public void ResetAllButtons()
    {
        cutBoostSelected = false;
        cutBoostSelected = false;
        freqSelected = false;
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
        form.AddField("studentID", netGlbScr.userID.ToString());
        form.AddField("appTestID", glbScr.appTestID);
        form.AddField("score", score);

        UnityWebRequest www = UnityWebRequest.Post("https://ffet.000webhostapp.com/mobilePhp/postTestResult.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            UnityEngine.Debug.Log(www.error);
            testSubErrorCanvas.SetActive(true);
        }
        else
        {
            UnityEngine.Debug.Log(www.downloadHandler.text);
            successText.SetActive(true);
            UpdateScores();
        }
        www.Dispose();
    }
    IEnumerator UpdateStats()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", netGlbScr.userID.ToString());
        form.AddField("userScore", netGlbScr.userScore);
        form.AddField("tests", netGlbScr.tests);
        form.AddField("testLevel", netGlbScr.testLevel);

        UnityWebRequest www = UnityWebRequest.Post("https://ffet.000webhostapp.com/mobilePhp/testExUpdate.php", form);
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
            modCon.CloseAppBtn();
        }
    }
    public void YesClose()
    {
        closeTestCanvas.SetActive(false);
        ResetAllButtons();
        modCon.CloseAppBtn();
        RestartTest();
    }
    public void NoClose()
    {
        closeTestCanvas.SetActive(false);
    }

    public void isHalfMark()
    {
        /*if (ranFreq == 1 && userFreq == 2)
        {
            score = score + 1;
        }
        else if (ranFreq == 2 && userFreq == 1 || ranFreq == 2 && userFreq == 3)
        {
            score = score + 1;
        }
        else if (ranFreq == 3 && userFreq == 2 || ranFreq == 3 && userFreq == 4)
        {
            score = score + 1;
        }
        else if (ranFreq == 4 && userFreq == 3 || ranFreq == 4 && userFreq == 5)
        {
            score = score + 1;
        }
        else if (ranFreq == 5 && userFreq == 4 || ranFreq == 5 && userFreq == 6)
        {
            score = score + 1;
        }
        else if (ranFreq == 6 && userFreq == 5 || ranFreq == 6 && userFreq == 7)
        {
            score = score + 1;
        }
        else if (ranFreq == 7 && userFreq == 6 || ranFreq == 7 && userFreq == 8)
        {
            score = score + 1;
        }
        else if (ranFreq == 8 && userFreq == 7 || ranFreq == 8 && userFreq == 9)
        {
            score = score + 1;
        }
        else if (ranFreq == 9 && userFreq == 8 || ranFreq == 9 && userFreq == 10)
        {
            score = score + 1;
        }
        else if (ranFreq == 10 && userFreq == 9 || ranFreq == 10 && userFreq == 11)
        {
            score = score + 1;
        }
        else if (ranFreq == 11 && userFreq == 10 || ranFreq == 11 && userFreq == 12)
        {
            score = score + 1;
        }
        else if (ranFreq == 12 && userFreq == 11 || ranFreq == 12 && userFreq == 13)
        {
            score = score + 1;
        }
        else if (ranFreq == 13 && userFreq == 12 || ranFreq == 13 && userFreq == 14)
        {
            score = score + 1;
        }
        else if (ranFreq == 14 && userFreq == 13 || ranFreq == 14 && userFreq == 15)
        {
            score = score + 1;
        }
        else if (ranFreq == 15 && userFreq == 14 || ranFreq == 15 && userFreq == 16)
        {
            score = score + 1;
        }
        else if (ranFreq == 16 && userFreq == 15 || ranFreq == 16 && userFreq == 17)
        {
            score = score + 1;
        }
        else if (ranFreq == 17 && userFreq == 6 || ranFreq == 17 && userFreq == 18)
        {
            score = score + 1;
        }
        else if (ranFreq == 18 && userFreq == 17 || ranFreq == 18 && userFreq == 19)
        {
            score = score + 1;
        }
        else if (ranFreq == 19 && userFreq == 18 || ranFreq == 19 && userFreq == 20)
        {
            score = score + 1;
        }
        else if (ranFreq == 20 && userFreq == 19 || ranFreq == 20 && userFreq == 21)
        {
            score = score + 1;
        }
        else if (ranFreq == 21 && userFreq == 20 || ranFreq == 21 && userFreq == 22)
        {
            score = score + 1;
        } 
        else if (ranFreq == 22 && userFreq == 21 || ranFreq == 22 && userFreq == 23)
        {
            score = score + 1;
        }
        else if (ranFreq == 23 && userFreq == 22 || ranFreq == 23 && userFreq == 24)
        {
            score = score + 1;
        }
        else if (ranFreq == 24 && userFreq == 23)
        {
            score = score + 1;
        }*/
    }
    public void ReSubBtn()
    {
        testSubErrorCanvas.SetActive(false);
        StartCoroutine(PostResults());
    }

    void CutOrBoostAnswersCheck()
    {
        Debug.Log("Checking answers");
        if(ranFreq1 == userFreq1)
        {
             score += 1;
             answer1true = 1;
        }
        else if (ranFreq1 == userFreq2)
        {
            score += 1;
            answer1true = 2;
        }
        else if(ranFreq1 != userFreq1 || ranFreq1 != userFreq2)
        {
             answer1true = 0;
        }

        if(answer1true == 0)
        {
            if(ranFreq2 == userFreq1)
            {
                score += 1;
            }else if(ranFreq2 == userFreq2)
            {
                score += 1;
            }
        }else if(answer1true == 1)
        {
            if(ranFreq2 == userFreq2)
            {
                score += 1;
            }
        }else if(answer1true == 2)
        {
            if(ranFreq2 == userFreq1)
            {
                score += 1;
            }
        }
        firstPlay = true;
        previousAns1 = ranFreq1;
        previousAns2 = ranFreq2;
        ResetAllButtons();
        SetAnswers();
    }
    void BothAnswerCheck()
    {
        Debug.Log("Checking answers");
        if (ranFreq1 == userFreq1)
        {
            score += 1;
            answer1true = 1;
        }
        else if (ranFreq1 == userFreq2)
        {
            score += 1;
            answer1true = 2;
        }
        else if (ranFreq1 != userFreq1 || ranFreq1 != userFreq2)
        {
            answer1true = 0;
        }

        if(ranCb1 == userCb1)
        {
            score += 1;
            answer1true = 1;
        }
        else if(ranCb1 == userCb2)
        {
            score += 1;
            answer1cBtrue = 2;
        }else if(ranCb1 != userCb1 || ranCb1 != userCb2)
        {
            answer1cBtrue = 0;
        }

        if (answer1true == 0)
        {
            if (ranFreq2 == userFreq1)
            {
                score += 1;
            }
            else if (ranFreq2 == userFreq2)
            {
                score += 1;
            }
        }
        else if (answer1true == 1)
        {
            if (ranFreq2 == userFreq2)
            {
                score += 1;
            }
        }
        else if (answer1true == 2)
        {
            if (ranFreq2 == userFreq1)
            {
                score += 1;
            }
        }

        if(answer1cBtrue == 0)
        {
            if(ranCb2 == ranCb1)
            {
                score += 1;
            }else if(ranCb2 == userCb2)
            {
                score += 1;
            }
        }else if(answer1cBtrue == 1)
        {
            if(ranCb2 == userCb2)
            {
                score += 1;
            }
        }else if(answer1cBtrue == 2)
        {
            if(ranCb2 == userCb1)
            {
                score += 1;
            }
        }

        firstPlay = true;
        previousAns1 = ranFreq1;
        previousAns2 = ranFreq2;
        ResetAllButtons();
        SetAnswers();
    }

    public void Freq1Change()
    {
        if (freq1Value == 0)
        {
            userFreq1 = 1;
            userFreq1string = "31 Hz";
        }
        else if (freq1Value == 1)
        {
            userFreq1 = 4;
            userFreq1string = "63 Hz";
        }
        else if (freq1Value == 2)
        {
            userFreq1 = 7;
            userFreq1string = "125 Hz";
        }
        else if (freq1Value == 3)
        {
            userFreq1 = 10;
            userFreq1string = "250 Hz";
        }
        else if (freq1Value == 4)
        {
            userFreq1 = 13;
            userFreq1string = "500 Hz";
        }
        else if (freq1Value == 5)
        {
            userFreq1 = 16;
            userFreq1string = "1 kHz";
        }
        else if (freq1Value == 6)
        {
            userFreq1 = 19;
            userFreq1string = "2 kHz";
        }
        else if (freq1Value == 7)
        {
            userFreq1 = 22;
            userFreq1string = "4 kHz";
        }
        else if (freq1Value == 8)
        {
            userFreq1 = 25;
            userFreq1string = "8 kHz";
        }
        else if (freq1Value == 9)
        {
            userFreq1 = 28;
            userFreq1string = "16 kHz";
        }
    }
    public void Freq2Change()
    {
        if (freq2Value == 0)
        {
            userFreq2 = 1;
            userFreq2string = "31 Hz";
        }
        else if (freq2Value == 1)
        {
            userFreq2 = 4;
            userFreq2string = "63 Hz";
        }
        else if (freq2Value == 2)
        {
            userFreq2 = 7;
            userFreq2string = "125 Hz";
        }
        else if (freq2Value == 3)
        {
            userFreq2 = 10;
            userFreq2string = "250 Hz";
        }
        else if (freq2Value == 4)
        {
            userFreq2 = 13;
            userFreq2string = "500 Hz";
        }
        else if (freq2Value == 5)
        {
            userFreq2 = 16;
            userFreq2string = "1 kHz";
        }
        else if (freq2Value == 6)
        {
            userFreq2 = 19;
            userFreq2string = "2 kHz";
        }
        else if (freq2Value == 7)
        {
            userFreq2 = 22;
            userFreq2string = "4 kHz";
        }
        else if (freq2Value == 8)
        {
            userFreq2 = 25;
            userFreq2string = "8 kHz";
        }
        else if (freq2Value == 9)
        {
            userFreq2 = 28;
            userFreq2string = "16 kHz";
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

    void UpdateScores()
    {
        if (glbScr.appTestID == "M6_T1")
        {
            if (score > glbScr.M6EQDB_T1_Score)
            {
                glbScr.M6EQDB_T1_Score = score;
            }
        }
        else if (glbScr.appTestID == "M6_T2")
        {
            if (score > glbScr.M6EQDB_T2_Score)
            {
                glbScr.M6EQDB_T2_Score = score;
            }
        }
        else if (glbScr.appTestID == "M6_T3")
        {
            if (score > glbScr.M6EQDB_T3_Score)
            {
                glbScr.M6EQDB_T3_Score = score;
            }
        }
        else if (glbScr.appTestID == "M6_T4")
        {
            if (score > glbScr.M6EQDB_T4_Score)
            {
                glbScr.M6EQDB_T4_Score = score;
            }
        }
        else if (glbScr.appTestID == "M6_T5")
        {
            if (score > glbScr.M6EQDB_T5_Score)
            {
                glbScr.M6EQDB_T5_Score = score;
            }
        }
        else if (glbScr.appTestID == "M6_T6")
        {
            if (score > glbScr.M6EQDB_T6_Score)
            {
                glbScr.M6EQDB_T6_Score = score;
            }
        }
    }
}
