using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleMenu : MonoBehaviour
{
    [SerializeField] private Animator menuCircleAni;
    [SerializeField] private Animator profileCircleAni;
    [SerializeField] private Animator menuBtnAni;
    [SerializeField] private Animator profileBtnAni;

    private bool menuIn = false;
    private bool profileMenuIn = false;

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
}
