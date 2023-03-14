using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [Header("References")]
    private LoginError loginError;
    //private UserAuth userAuth;
    private LoginCanvas loginCanvas;
    private NetworkGlobals networkGlobals;
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private string usernameInputText;
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private string emailInputText;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private string passwordInputText;
    [SerializeField] private TMP_InputField passwordConfirmInput;
    [SerializeField] private string passwordConfirmInputText;
    [SerializeField] private Button registerBtn;
    [SerializeField] TextMeshProUGUI statusText;
    private string[] badWords;
    public int inputFocus = 0;

    private void Awake()
    {
        //loginError = FindObjectOfType<LoginError>();
        networkGlobals = FindObjectOfType<NetworkGlobals>();
        TextAsset textAsset = (TextAsset)Resources.Load("badwords");
        badWords = textAsset.text.Split('|');
    }

    private void Update()
    {
        VerifyInputs();
        //HandleInputs();
    }

    public void UsernameInput()
    {
        usernameInputText = usernameInput.text;
    }
    public void EmailInput()
    {
        emailInputText = emailInput.text;
    }
    public void PasswordInput()
    {
        passwordInputText = passwordInput.text;
    }

    public void PasswordConfirmInput()
    {
        passwordConfirmInputText = passwordConfirmInput.text;
    }

    public void RegisterBtnClick()
    {
        if (!CheckPasswords())
        {
            InputError("password match");
            return;
        }
        CallRegister();
    }

    private void VerifyInputs()
    {
        if (usernameInputText.Length >= 3
            && emailInputText.Length >= 6
                && passwordConfirmInputText.Length >= 6
                    && passwordInputText.Length >= 6)
        {
            registerBtn.interactable = true;
        }
        else
        {
            registerBtn.interactable = false;
        }
    }

    private bool CheckPasswords()
    {
        if (passwordInputText == passwordConfirmInputText)
        {
            return true;
        }
        return false;
    }

    void InputError(string e)
    {
        switch (e)
        {
            case "password match":
                statusText.text = "Passwords do not match.";
                StartCoroutine(ErrorText1());
                passwordConfirmInputText = "";
                passwordConfirmInput.text = "";
                passwordInputText = "";
                passwordInput.text = "";
                break;
            default:
                Debug.Log("Default error");
                break;
        }
    }

    public void CallRegister()
    {
        if (HasProfanity() == false)
        {
            statusText.text = "No naughty words!";
            StartCoroutine(ErrorText1());
            return;
        }
        else if (HasProfanity() == true)
        {
            StartCoroutine(RegisterStudent());
        }
    }

    private bool HasProfanity()
    {
        for (int i = 0; i < badWords.Length; i++)
        {
            string lowerCase = usernameInput.text.ToLower();
            if (lowerCase.Contains(badWords[i]))
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator RegisterStudent()
    {
        WWWForm form = new WWWForm();
        form.AddField("studentID", usernameInputText);
        form.AddField("email", emailInputText);
        form.AddField("password", passwordInputText);
        form.AddField("class", "Year1");
        UnityWebRequest www = UnityWebRequest.Post("https://www.ffet.a2hosted.com/mobilePhp/autoRegisterUser.php", form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            if (www.downloadHandler.text == "3: Name Already exists.")
            {
                StartCoroutine(ErrorText1());
            }
            else if (www.downloadHandler.text == "0")
            {
                Registered();
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }

        www.Dispose();
    }

    void Registered()
    {
        networkGlobals.loggedIn = true;
        networkGlobals.username = usernameInput.text;
        usernameInput.text = "";
        usernameInputText = "";
        emailInput.text = "";
        emailInputText = "";
        passwordInput.text = "";
        passwordInputText = "";
        passwordConfirmInputText = "";
        passwordConfirmInput.text = "";
        SceneManager.LoadScene(2);
    }

    IEnumerator ErrorText1()
    {
        statusText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        statusText.gameObject.SetActive(false);
    }

    public void EmailClick()
    {
        inputFocus = 1;
        if (emailInput.text == "")
        {
            emailInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Username";
        }

        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Password";
        }

        if (passwordConfirmInput.text == "")
        {
            passwordConfirmInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Confirm password";
        }
    }

    public void UsernameClick()
    {
        inputFocus = 0;
        if (emailInput.text == "")
        {
            emailInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Email";
        }

        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Password";
        }

        if (passwordConfirmInput.text == "")
        {
            passwordConfirmInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Confirm password";
        }
    }

    public void PasswordClick()
    {
        inputFocus = 2;
        if (emailInput.text == "")
        {
            emailInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Email";
        }

        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Username";
        }

        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }

        if (passwordConfirmInput.text == "")
        {
            passwordConfirmInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Confirm password";
        }
    }

    public void PasswordConfirmClick()
    {
        inputFocus = 3;
        if (emailInput.text == "")
        {
            emailInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Email";
        }

        if (usernameInput.text == "")
        {
            usernameInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Username";
        }

        if (passwordInput.text == "")
        {
            passwordInput.placeholder.GetComponent<TextMeshProUGUI>().text = "Password";
        }

        if (passwordConfirmInput.text == "")
        {
            passwordConfirmInput.placeholder.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputFocus++;
            if (inputFocus >= 4)
            {
                inputFocus = 0;
            }
            switch (inputFocus)
            {
                case 0:
                    usernameInput.Select();
                    break;
                case 1:
                    emailInput.Select();
                    break;
                case 2:
                    passwordInput.Select();
                    break;
                case 3:
                    passwordConfirmInput.Select();
                    break;
            }
        }

        /* if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift))
        {
            inputFocus--;
            if (inputFocus < 0)
            {
                inputFocus = 4;
            }
            switch (inputFocus)
            {
                case 0:
                    usernameInput.Select();
                    break;
                case 1:
                    emailInput.Select();
                    break;
                case 2:
                    passwordInput.Select();
                    break;
                case 3:
                    passwordConfirmInput.Select();
                    break;
            }
        } */
    }
}
