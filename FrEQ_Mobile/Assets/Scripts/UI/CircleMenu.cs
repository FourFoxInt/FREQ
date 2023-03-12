using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CircleMenu : MonoBehaviour
{
    private NetworkGlobals networkGlobals;
    private Globals globals;
    [SerializeField] private Animator menuCircleAni;
    [SerializeField] private Animator profileCircleAni;
    [SerializeField] private Animator menuBtnAni;
    [SerializeField] private Animator profileBtnAni;
    [SerializeField] private GameObject buttons;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Slider masterVolSlider;
    FMOD.Studio.Bus masterBus;

    private bool menuIn = false;
    private bool profileMenuIn = false;

    void Awake()
    {
        networkGlobals = FindObjectOfType<NetworkGlobals>();
        globals = FindObjectOfType<Globals>();
        masterVolSlider.value = globals.masterVolume;
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }
    public void Menu_BtnClick()
    {
        if (!profileMenuIn)
        {
            if (menuIn)
            {
                menuIn = false;
                menuCircleAni.SetBool("in", false);
            }
            else if (!menuIn)
            {
                menuIn = true;
                menuCircleAni.SetBool("in", true);
            }
        }
    }
    public void ProfileMenu_BtnClick()
    {
        if (!menuIn)
        {
            if (profileMenuIn)
            {
                profileMenuIn = false;
                profileCircleAni.SetBool("in", false);
            }
            else if (!profileMenuIn)
            {
                profileMenuIn = true;
                profileCircleAni.SetBool("in", true);
            }
        }
    }

    //MENU BTNS
    public void ExamBtn()
    {
        SceneManager.LoadScene(12);
    }

    public void SettingsBtn()
    {
        masterVolSlider.value = globals.masterVolume;
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        buttons.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void SettingsCloseBtn()
    {
        buttons.SetActive(true);
        settingsMenu.SetActive(false);
        Menu_BtnClick();
    }


    //Profile Btns
    public void LogoutBtnClick()
    {
        StartCoroutine(Logout());
    }
    IEnumerator Logout()
    {
        PlayerPrefs.SetInt("Autologin", 0);
        //PlayerPrefs.SetString("StudentID", "");
        PlayerPrefs.SetString("Password", "");
        yield return new WaitForSeconds(0.25f);
        networkGlobals.username = "";
        networkGlobals.userEmail = "";
        networkGlobals.firstName = "";
        networkGlobals.lastName = "";
        networkGlobals.classYear = "";
        networkGlobals.userScore = 0;
        networkGlobals.listenEx = 0;
        networkGlobals.pracEx = 0;
        networkGlobals.tests = 0;
        networkGlobals.testLevel = 0;
        networkGlobals.loggedIn = false;
        Destroy(GameObject.Find("NetworkGlobals"));
        Destroy(GameObject.Find("globals"));
        SceneManager.LoadScene(0);
    }

    public void EditProfile()
    {

    }

    /////
    //Settings
    ////
    public void MasterVolumeSlider()
    {
        globals.masterVolume = masterVolSlider.value;
        masterBus.setVolume(globals.masterVolume);
        PlayerPrefs.SetFloat("MasterVolume", globals.masterVolume);
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(3);
    }
}
