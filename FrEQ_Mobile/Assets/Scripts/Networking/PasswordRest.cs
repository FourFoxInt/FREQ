using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PasswordRest : MonoBehaviour
{
    private LoginCanvas loginCanvas;
    private reset reset;
    [SerializeField] private GameObject sendCodeBtn;
    [SerializeField] private GameObject submitCodeBtn;
    [SerializeField] private GameObject submitCodeInputGO;
    [SerializeField] private GameObject pw1InputGO;
    [SerializeField] private GameObject pw2InputGO;

    [SerializeField] private TMP_InputField codeInput;
    [SerializeField] private GameObject codeInputGO;
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private GameObject usernameInputGO;
    [SerializeField] private string username;
    private string email;
    [SerializeField] private int code;

    [SerializeField] private TextMeshProUGUI titleText;

    [SerializeField] private TMP_InputField pw1;
    [SerializeField] private GameObject pw1Go;
    [SerializeField] private TMP_InputField pw2;
    [SerializeField] private GameObject pw2Go;
    public string newpassword;
    [SerializeField] GameObject submitPwBtn;
    [SerializeField] GameObject returnToLoginBtn;
    [SerializeField] GameObject nevermindBtn;

    [SerializeField] TextMeshProUGUI expiryText;
    private bool codeSent = false;

    public float timeRemaining;
    public bool timerOn;

    private void Update()
    {
        VerifyUsername();
        VerifyPasswords();

        if (timeRemaining > 0 && timerOn)
        {
            timeRemaining -= Time.deltaTime;
            expiryText.text = "Code expires in " + timeRemaining.ToString("f0") + " seconds.";
        }

        if (timeRemaining <= 0 && codeSent && timerOn)
        {
            codeSent = false;
            StartCoroutine(CodeExpired());
        }
    }

    public void SendCodeBtn()
    {
        StartCoroutine(CheckForUsername());
    }

    public void SubmitCodeBtn()
    {
        if (codeInput.text == code.ToString())
        {
            titleText.text = "Please enter a new password.";
            submitCodeBtn.SetActive(false);
            submitCodeInputGO.SetActive(false);
            pw1InputGO.SetActive(true);
            pw2InputGO.SetActive(true);
            submitPwBtn.SetActive(true);
            timerOn = false;
            codeSent = false;
            timeRemaining = 90;
            StartCoroutine(CodeSuccess());
        }
        else if (codeInput.text != code.ToString())
        {
            titleText.text = "Incorrect code. Please try again.";
            titleText.color = new Color32(200, 0, 0, 255);
            codeInput.text = "";
        }
    }

    void VerifyUsername()
    {
        if (usernameInput.text.Length >= 5)
        {
            sendCodeBtn.GetComponent<Button>().interactable = true;
        }
        else
        {
            sendCodeBtn.GetComponent<Button>().interactable = false;
        }
    }

    void VerifyPasswords()
    {
        if (pw1.text.Length >= 6 && pw2.text.Length >= 6 && pw1.text == pw2.text)
        {
            submitPwBtn.GetComponent<Button>().interactable = true;
        }
        else
        {
            submitPwBtn.GetComponent<Button>().interactable = false;
        }

        if (codeInput.text.Length < 5)
        {
            submitCodeBtn.GetComponent<Button>().interactable = false;
        }
        else if (codeInput.text.Length == 5)
        {
            submitCodeBtn.GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator CheckForUsername()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/checkForUsername.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "false")
            {
                //No username found.
                titleText.text = "No account found with that username..";
                titleText.color = new Color32(200, 0, 0, 255);
            }
            else
            {
                //username found. Send code via email.
                username = usernameInput.text;
                email = www.downloadHandler.text;
                CreateRandomCode();
                StartCoroutine(CreateCode());
            }
        }
        www.Dispose();
    }

    void CreateRandomCode()
    {
        code = Random.Range(10000, 99999);
    }

    IEnumerator CreateCode()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("code", code);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/createPwResetCode.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "4: Insert user query failed")
            {
                //No username found.
                titleText.text = "ERROR: Please try again.";
                titleText.color = new Color32(200, 0, 0, 255);
            }
            else if (www.downloadHandler.text == "0")
            {
                StartCoroutine(SendCode());
                usernameInputGO.SetActive(false);
                sendCodeBtn.SetActive(false);
                submitCodeBtn.SetActive(true);
                expiryText.gameObject.SetActive(true);
                timerOn = true;
                timeRemaining = 90;
                codeSent = true;
                submitCodeInputGO.SetActive(true);
                titleText.text = "Please enter your 5 digit code and hit submit.";
            }
        }
        www.Dispose();
    }
    IEnumerator SendCode()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("code", code);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/sendCode.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "false")
            {
                //No username found.
                titleText.text = "No account found with that username..";
                titleText.color = new Color32(200, 0, 0, 255);
            }
            else
            {
                //username found. Send code via email.
                Debug.Log(www.downloadHandler.text);
                email = www.downloadHandler.text;
                titleText.color = new Color32(0, 0, 0, 255);
            }
        }
        www.Dispose();
    }
    IEnumerator CodeExpired()
    {
        code = 0;
        WWWForm form = new WWWForm();
        form.AddField("email", email);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/deletePwResetCode.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "false")
            {

            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                codeInput.text = "";
                codeInput.gameObject.SetActive(false);
                submitCodeBtn.SetActive(false);
                usernameInput.gameObject.SetActive(true);
                sendCodeBtn.SetActive(true);
                titleText.color = new Color32(200, 0, 0, 255);
                titleText.text = "Code expired, please request a new code.";
                expiryText.gameObject.SetActive(false);
            }
        }
        www.Dispose();
    }
    IEnumerator CodeSuccess()
    {
        code = 0;
        WWWForm form = new WWWForm();
        form.AddField("email", email);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/deletePwResetCode.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "false")
            {

            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                codeInput.text = "";
                codeInput.gameObject.SetActive(false);
                submitCodeBtn.SetActive(false);
                expiryText.gameObject.SetActive(false);
            }
        }
        www.Dispose();
    }
    public void InputClick()
    {
        titleText.color = new Color32(0, 0, 0, 255);
        titleText.text = "Enter your username below and we will send you a reset code.";
    }

    public void UpdateText()
    {
        username = usernameInput.text;
    }

    public void SubmitPasswordBtn()
    {
        submitPwBtn.GetComponent<Button>().interactable = false;
        StartCoroutine(SubmitPassword());
    }

    public void pw1update()
    {
        newpassword = pw1.text;
    }

    IEnumerator SubmitPassword()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", newpassword);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/resetPassword.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            if (www.downloadHandler.text == "false")
            {
                //No username found.
                titleText.text = "Error: please try again.";
                titleText.color = new Color32(200, 0, 0, 255);
            }
            else
            {
                pw1Go.SetActive(false);
                pw2Go.SetActive(false);
                submitPwBtn.SetActive(false);
                nevermindBtn.SetActive(false);
                titleText.text = "Password has been reset successfully.";
                titleText.color = new Color32(9, 200, 0, 255);
                returnToLoginBtn.SetActive(true);
            }
        }
        www.Dispose();
    }

    public void ReturnToLogin()
    {
        titleText.text = "Enter your username below and we will send you a reset code.";
        titleText.color = new Color32(0, 0, 0, 255);
        returnToLoginBtn.SetActive(false);
        usernameInput.gameObject.SetActive(true);
        sendCodeBtn.SetActive(true);
        reset = GameObject.FindObjectOfType<reset>();
        reset.resetPwAni.SetBool("in", false);
        reset.loginAni.SetBool("in", true);
        usernameInput.text = "";
        codeInput.text = "";
        codeInputGO.SetActive(false);
        pw1.text = "";
        pw2.text = "";
        pw1Go.SetActive(false);
        pw2Go.SetActive(false);
        nevermindBtn.SetActive(true);
        loginCanvas = FindObjectOfType<LoginCanvas>();
        loginCanvas.NeedTo_LoginBtn();
    }
}
