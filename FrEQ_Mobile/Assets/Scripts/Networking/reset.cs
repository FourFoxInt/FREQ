using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class reset : MonoBehaviour
{
    private Globals glb;

    [SerializeField] public Animator loginAni;
    [SerializeField] private Animator resetAni;
    [SerializeField] private Animator resetUsernameAni;
    [SerializeField] public Animator resetPwAni;

    [SerializeField] private TextMeshProUGUI titleString;
    [SerializeField] private string emailText;
    [SerializeField] public TMP_InputField emailInput;
    private string username;

    [SerializeField] private GameObject sendEmailbtn;
    [SerializeField] private GameObject returnBtn;

    private void Start()
    {
        glb = GameObject.FindObjectOfType<Globals>();
    }
    public void SendUserName()  
    {
        StartCoroutine(CheckEmail());
    }

    public void NevermindBtn()
    {
        loginAni.SetBool("in", true);
        resetAni.SetBool("in", false);
    }

    public void ResetUserNameBtn()
    {
        resetUsernameAni.SetBool("in", true);
        resetAni.SetBool("in", false);
    }

    public void ResetPwBtn()
    {
        resetPwAni.SetBool("in", true);
        resetAni.SetBool("in", false);
    }

    public void UpdateText()
    {
        emailText = emailInput.text;
    }

    IEnumerator CheckEmail()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailText);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/checkForEmail.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if(www.downloadHandler.text == "false")
            {
                //NO EMAIL FOUND
                titleString.text = "Email address not associated with an account.";
                titleString.color = new Color32(200, 0, 0, 255);
            }
            else
            {
                username = www.downloadHandler.text;
                StartCoroutine(SendUsernameEmail());
            }
        }
        www.Dispose();
    }

    IEnumerator SendUsernameEmail()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailText);
        form.AddField("username", username);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/sendUsername.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            if (www.downloadHandler.text == "true")
            {
                titleString.color = new Color32(9, 200, 0, 255);
                titleString.text = "Check your inbox for your username.";
                emailInput.text = "";
                emailInput.gameObject.SetActive(false);
                sendEmailbtn.SetActive(false);
                returnBtn.SetActive(true);
                emailText = "";
                emailInput.text = "";
                username = "";

            }
            else if (www.downloadHandler.text == "false")
            {
                titleString.color = new Color32(200, 0, 0, 255);
                titleString.text = "There has been an error, please try again.";
                emailInput.text = "";
            }
        }
        www.Dispose();
    } 

    public void InputClick()
    {
        titleString.color = new Color32(0, 0, 0, 255);
        titleString.text = "Enter your FREQ account email address below.";
    }

    public void ReturnToLogin()
    {
        resetUsernameAni.SetBool("in", false);
        loginAni.SetBool("in", true);
        emailInput.gameObject.SetActive(true);
        emailInput.text = "";
        sendEmailbtn.SetActive(true);
        returnBtn.SetActive(false);
        titleString.color = new Color32(0, 0, 0, 255);
        titleString.text = "Enter your FREQ account email address below.";
    }
}
