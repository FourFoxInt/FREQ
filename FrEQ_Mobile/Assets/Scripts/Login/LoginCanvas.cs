using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginCanvas : MonoBehaviour
{
    [SerializeField] private Animator loginAni;
    [SerializeField] private Animator logoAni;
    [SerializeField] private Animator loginTextAni;
    [SerializeField] private Animator registerAni;
    [SerializeField] private Animator registerTextAni;
    [SerializeField] private Animator bkgcircleTextAni;
    [SerializeField] private Animator forgotDetailsAni;
    [SerializeField] private Animator resetUsernameAni;
    [SerializeField] private Animator resetPasswordAni;
    [SerializeField] private Animator forgotDetailsTextAni;
    [SerializeField] private TextMeshProUGUI progressText;
    [SerializeField] private GameObject loadingIcon;

    private void Start()
    {
        StartCoroutine(StartCo());
    }

    IEnumerator StartCo()
    {
        logoAni.SetBool("in", true);
        yield return new WaitForSeconds(0.25f);
        registerTextAni.SetBool("in", false);
        registerAni.SetBool("in", false);
        loginTextAni.SetBool("in", true);
        yield return new WaitForSeconds(0.25f);
        loginAni.SetBool("in", true);
    }

    public void NeedTo_RegisterBtn()
    {
        StartCoroutine(ShowRegisterCo());
    }

    public void NeedTo_LoginBtn()
    {
        StartCoroutine(ShowLoginCo());
    }

    public void ForgotDetailsBtn()
    {
        StartCoroutine(ShowForgotDetailsCo());
    }

    IEnumerator ShowLoginCo()
    {
        registerTextAni.SetBool("in", false);
        forgotDetailsTextAni.SetBool("in", false);
        yield return new WaitForSeconds(0.25f);
        registerAni.SetBool("in", false);
        forgotDetailsAni.SetBool("in", false);
        resetUsernameAni.SetBool("in", false);
        resetPasswordAni.SetBool("in", false);
        yield return new WaitForSeconds(0.5f);
        loginTextAni.SetBool("in", true);
        yield return new WaitForSeconds(0.25f);
        loginAni.SetBool("in", true);
    }

    IEnumerator ShowRegisterCo()
    {
        loginTextAni.SetBool("in", false);
        forgotDetailsTextAni.SetBool("in", false);
        yield return new WaitForSeconds(0.25f);
        forgotDetailsAni.SetBool("in", false);
        loginAni.SetBool("in", false);
        resetUsernameAni.SetBool("in", false);
        resetPasswordAni.SetBool("in", false);
        yield return new WaitForSeconds(0.5f);
        registerTextAni.SetBool("in", true);
        yield return new WaitForSeconds(0.25f);
        registerAni.SetBool("in", true);
    }

    public void GetUserData()
    {
        StartCoroutine(GetUserDataCo());
    }

    IEnumerator GetUserDataCo()
    {
        logoAni.SetBool("in", false);
        yield return new WaitForSeconds(0.25f);
        loginTextAni.SetBool("in", false);
        registerTextAni.SetBool("in", false);
        yield return new WaitForSeconds(0.25f);
        loginAni.SetBool("in", false);
        registerAni.SetBool("in", false);
        progressText.gameObject.SetActive(true);
        progressText.text = "Logging in user...";
        loadingIcon.SetActive(true);
    }

    IEnumerator LoadDashboardCo()
    {
        bkgcircleTextAni.SetBool("out", true);
        yield return new WaitForSeconds(0.25f);
        loginAni.SetBool("in", false);
        registerAni.SetBool("in", false);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(3);
    }

    IEnumerator ShowForgotDetailsCo()
    {
        loginTextAni.SetBool("in", false);
        yield return new WaitForSeconds(0.25f);
        loginAni.SetBool("in", false);
        yield return new WaitForSeconds(0.5f);
        forgotDetailsTextAni.SetBool("in", true);
        yield return new WaitForSeconds(0.25f);
        forgotDetailsAni.SetBool("in", true);
    }

}
