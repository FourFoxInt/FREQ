using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Getcurrents : MonoBehaviour
{
    [Header("References")]
    private Globals glbScr;
    private MainMenuUI mainMenuUI;
    [SerializeField] private TextMeshProUGUI eqSectionTitle;
    [SerializeField] private TextMeshProUGUI eqModuleTitle;
    [SerializeField] private TextMeshProUGUI eqModuleDesc;
    [SerializeField] private TextMeshProUGUI fxSectionTitle;
    [SerializeField] private TextMeshProUGUI fxModuleTitle;
    [SerializeField] private TextMeshProUGUI fxModuleDesc;


    [Header("Settings")]
    public string eqtextFile;
    public string fxtextFile;
    public string eqtextContents;
    public string fxtextContents;


    void Start()
    {
        glbScr = FindObjectOfType<Globals>();
        mainMenuUI = FindObjectOfType<MainMenuUI>();

        SetCurrentEq();
        SetCurrentFx();
    }

    void SetCurrentEq()
    {
        eqtextFile = glbScr.currentEqMod;
        if ((TextAsset)Resources.Load(eqtextFile))
        {
            TextAsset textAsset1 = (TextAsset)Resources.Load(eqtextFile);
            eqtextContents = textAsset1.text;
            string[] textSplit1 = eqtextContents.Split('|');

            eqSectionTitle.text = glbScr.currentEqTitle;
            eqModuleTitle.text = textSplit1[0];
            eqModuleDesc.text = textSplit1[1];
        }
    }

    void SetCurrentFx()
    {
        fxtextFile = glbScr.currentFxMod;
        if ((TextAsset)Resources.Load(fxtextFile))
        {
            TextAsset textAsset2 = (TextAsset)Resources.Load(fxtextFile);
            fxtextContents = textAsset2.text;
            string[] textSplit2 = fxtextContents.Split('|');

            fxSectionTitle.text = glbScr.currentFxTitle;
            fxModuleTitle.text = textSplit2[0];
            fxModuleDesc.text = textSplit2[1];
        }
    }
}
