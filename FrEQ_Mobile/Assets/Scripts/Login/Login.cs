using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private NetworkGlobals netGlbScr;

    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private string usernameInputText;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private string passwordInputText;

    [SerializeField] private Toggle autoLoginToggle;
    private int autoLogin = 0;

    [SerializeField] private Button loginBtn;

    private bool userInfoIn = false;
    private bool loginTrack = false;

    [SerializeField] private GameObject loadingImage;
    [SerializeField] private GameObject errorBkg;
    public TextMeshProUGUI errorText;

    void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();

        autoLogin = PlayerPrefs.GetInt("Autologin");
        if (autoLogin == 1)
        {
            loginBtn.interactable = false;
            usernameInput.text = PlayerPrefs.GetString("StudentID");
            passwordInput.text = PlayerPrefs.GetString("Password");
            StartCoroutine(LoginUser());
        }
        else if (autoLogin == 0)
        {
            loginBtn.interactable = true;
            usernameInput.text = "";
            passwordInput.text = "";
        }
    }

    void Update()
    {
        VerifyInputs();
        if (userInfoIn && loginTrack)
        {
            SceneManager.LoadScene(2);
            loadingImage.SetActive(false);
        }
    }
    public void VerifyInputs()
    {
        if (usernameInput.text.Length >= 6 && passwordInput.text.Length >= 6)
        {
            loginBtn.interactable = true;
        }
        else
        {
            loginBtn.interactable = false;
        }
    }
    IEnumerator LoginUser()
    {
        loadingImage.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("studentID", usernameInputText);
        form.AddField("password", passwordInputText);

        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/loginhash.php", form);
        www.certificateHandler = new CertHandler();
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            ErrorText("network error");
            loadingImage.SetActive(false);
        }
        else
        {
            if (www.downloadHandler.text == "1")
            {
                netGlbScr.loggedIn = true;
                netGlbScr.username = usernameInput.text;
                if (autoLoginToggle.isOn == true)
                {
                    PlayerPrefs.SetString("StudentID", usernameInput.text);
                    PlayerPrefs.SetString("Password", passwordInput.text);
                    PlayerPrefs.SetInt("Autologin", 1);
                }
                SceneManager.LoadScene(2);
            }
            else if (www.downloadHandler.text == "3" || www.downloadHandler.text == "5")
            {
                //INCORRECT PASSWORD
                ErrorText("5");
            }
            else if (www.downloadHandler.text == "0")
            {
                //INCORRECT PASSWORD
                ErrorText("Network Error");
            }
        }

        www.Dispose();
    }

    public void SubmitBtn()
    {
        StartCoroutine(LoginUser());
    }
    public void UsernameInput()
    {
        usernameInputText = usernameInput.text;
    }
    public void PasswordInput()
    {
        passwordInputText = passwordInput.text;
    }

    public void UsernameClick()
    {
        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Password";
        }
    }

    public void PasswordClick()
    {
        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Username";
        }
    }

    void ErrorText(string error)
    {
        loadingImage.SetActive(false);
        usernameInput.text = "";
        passwordInput.text = "";
        if (error == "5" || error == "Incorrect password or username")
        {
            errorText.text = "Error: Incorrect login information. Please try again.";
        }
        else if (error == "Network Error")
        {
            errorText.text = "Error: Network connection lost.";
        }
        //errorText.GetComponent<TextMeshProUGUI>().text = "Error: Network connection lost.";
        errorBkg.SetActive(true);
    }

    public void ClearError()
    {
        errorBkg.SetActive(false);
    }
}
