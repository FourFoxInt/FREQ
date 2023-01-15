using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModuleText : MonoBehaviour
{
    private Globals glbScr;
    private NetworkGlobals netGlbScr;

    //Text elements
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI moreInfo;

    //TEXT DOCUMENTS
    public string textFile;
    public string textContents;

    private void Start()
    {
        netGlbScr = GameObject.Find("NetworkGlobals").GetComponent<NetworkGlobals>();
        glbScr = GameObject.Find("Globals").GetComponent<Globals>();

        textFile = glbScr.lessonID;
        TextAsset textAsset = (TextAsset)Resources.Load(textFile);
        textContents = textAsset.text;
        string[] textSplit = textContents.Split('|');

        title.text = textSplit[0];
        description.text = textSplit[1];
        moreInfo.text = textSplit[2];

        glbScr.currentTitle = textSplit[0];
        glbScr.currentDesc = textSplit[1];
    }
}
