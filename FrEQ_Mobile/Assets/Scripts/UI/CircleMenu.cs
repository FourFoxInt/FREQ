using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CircleMenu : MonoBehaviour
{
    [SerializeField] private Animator bkgAni;
    [SerializeField] private Animator menuCircleAni;
    [SerializeField] private Animator profileCircleAni;
    [SerializeField] private Animator menuBtnAni;
    [SerializeField] private Animator profileBtnAni;

    [SerializeField] private GameObject bkg;

    private bool menuIn = false;
    private bool profileMenuIn = false;

    private void Start()
    {
        bkg.SetActive(false);
    }
    public void Menu_BtnClick()
    {
        if (!profileMenuIn)
        {
            if (menuIn)
            {
                menuIn = false;
                StartCoroutine(bkgOut());
                menuCircleAni.SetBool("in", false);
                menuBtnAni.SetBool("in", false);
                profileBtnAni.SetBool("menuIn", false);
            }
            else if (!menuIn)
            {
                menuIn = true;
                bkg.SetActive(true);
                bkgAni.SetBool("in", true);
                menuCircleAni.SetBool("in", true);
                menuBtnAni.SetBool("in", true); 
                profileBtnAni.SetBool("menuIn", true);
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
                StartCoroutine(bkgOut());
                profileCircleAni.SetBool("in", false);
                profileBtnAni.SetBool("in", false);
            }
            else if (!profileMenuIn)
            {
                profileMenuIn = true;
                bkg.SetActive(true);
                bkgAni.SetBool("in", true);
                profileCircleAni.SetBool("in", true);
                profileBtnAni.SetBool("in", true);
            }
        }
    }
    IEnumerator bkgOut()
    {
        bkgAni.SetBool("in", false);
        yield return new WaitForSeconds(1);
        bkg.SetActive(false);
    }

    //MENU BTNS
    public void ExamBtn()
    {
        SceneManager.LoadScene(12);
    }
}
