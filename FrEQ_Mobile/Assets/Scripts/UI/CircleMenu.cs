using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleMenu : MonoBehaviour
{
    private NetworkGlobals networkGlobals;
    [SerializeField] private Animator menuCircleAni;
    [SerializeField] private Animator profileCircleAni;
    [SerializeField] private Animator menuBtnAni;
    [SerializeField] private Animator profileBtnAni;

    private bool menuIn = false;
    private bool profileMenuIn = false;

    void Start(){
        networkGlobals = FindObjectOfType<NetworkGlobals>();
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

    public void EditProfile(){

    }
}
