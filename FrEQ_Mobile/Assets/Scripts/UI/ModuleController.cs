using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModuleController : MonoBehaviour
{
    private Listener listenerScr;
    [SerializeField] private Animator listenAni;
    [SerializeField] private Animator practiceAni;
    [SerializeField] private Animator testAni;
    [SerializeField] private GameObject moreInfoGO;
    [SerializeField] private GameObject listenerApp;
    [SerializeField] private GameObject practiceApp;
    [SerializeField] private GameObject testApp;
    public bool appIsPlaying = false;
    public string currentApp;

    private void Start()
    {
        listenerScr = GameObject.Find("Listener").GetComponent<Listener>();
    }
    public void ListenBtnClick()
    {
        listenAni.SetBool("in", true);
        practiceAni.SetBool("in", false);
        testAni.SetBool("in", false);
    }

    public void ListenStartClick()
    {
        listenerApp.SetActive(true);
        if (GameObject.Find("Listener").GetComponent<ListenerSections>() != null)
        {
            GameObject.Find("Listener").GetComponent<ListenerSections>().ChangeListenSections();
        }
        currentApp = "Listener";
    }

    public void PracticeBtnClick()
    {
        listenAni.SetBool("in", false);
        practiceAni.SetBool("in", true);
        testAni.SetBool("in", false);
    }

    public void PracticeStartClick()
    {
        practiceApp.SetActive(true);
        if (GameObject.Find("Practice").GetComponent<PracticeSections>() != null)
        {
            GameObject.Find("Practice").GetComponent<PracticeSections>().ChangePracticeSections();
        }
        currentApp = "Practice";
    }

    public void TestBtnClick()
    {
        listenAni.SetBool("in", false);
        practiceAni.SetBool("in", false);
        testAni.SetBool("in", true);
    }

    public void TestStartClick()
    {
        testApp.SetActive(true);
        if (GameObject.Find("Test").GetComponent<TestSections>() != null)
        {
            GameObject.Find("Test").GetComponent<TestSections>().ChangeTestSections();
        }
        currentApp = "Test";
    }

    public void MoreInfoClick()
    {
        moreInfoGO.SetActive(true);
    }

    public void MoreInfoClose()
    {
        moreInfoGO.SetActive(false);
    }

    public void CloseAppBtn()
    {
        if (!appIsPlaying)
        {
            listenerApp.SetActive(false);
            practiceApp.SetActive(false);
            if (currentApp == "Test")
            {
                testApp.SetActive(false);
            }
        }
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(3);
    }

    public void BackBtn()
    {
        if (PlayerPrefs.HasKey("lastScene"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("lastScene"));
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
