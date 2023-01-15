using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileMenu : MonoBehaviour
{
    [SerializeField] private Animator bkgAni;
    [SerializeField] private Animator circleAni;
    [SerializeField] private Animator btnAni;

    private bool menuIn = false;

    public void ProfileMenu_BtnClick()
    {
        if (menuIn)
        {
            menuIn = false;
            bkgAni.SetBool("in", false);
            circleAni.SetBool("in", false);
            //btnAni.SetBool("in", false);
        }
        else if (!menuIn)
        {
            menuIn = true;
            bkgAni.SetBool("in", true);
            circleAni.SetBool("in", true);
            //btnAni.SetBool("in", true);
        }
    }
}
