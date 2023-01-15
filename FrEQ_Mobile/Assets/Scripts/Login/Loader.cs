using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator logoAni;

    private void Start()
    {
        StartCoroutine(LoadLogin());
    }

    IEnumerator LoadLogin()
    {
        yield return new WaitForSeconds(1);
        logoAni.SetBool("out", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
 