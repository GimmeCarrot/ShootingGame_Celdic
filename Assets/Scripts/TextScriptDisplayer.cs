using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScriptDisplayer : MonoBehaviour {

	public GameObject textFrame;
    public GameObject charNameBox;
    public GameObject scriptBox;
    public TextAsset scriptInput;
    public TextAsset charListInput;
    public bool ReloadCharListOnEnable;

    private List<ScriptUnit> scriptList = new List<ScriptUnit>();
    private IEnumerator<ScriptUnit> scriptEnumerator = null;
    private List<string> charList = new List<string>();

    private bool toNextEnabled = false;

    private class ScriptUnit
    {
        public int CharIdx
        {
            get; private set;
        }
        public string Text
        {
            get; private set;
        }

        public ScriptUnit(float _charIdx, string _text)
		{
            CharIdx = (int)_charIdx;
			Text = _text;
		}
    }

    void Awake ()
    {
        HideAllUI();
    }

    void OnEnable ()
    {
        scriptEnumerator = null;
        JSONObject scriptJson = new JSONObject(scriptInput.text);
        ParseScript(scriptJson);

        if (charList.Count < 1 || ReloadCharListOnEnable)
        {
            JSONObject charListJson = new JSONObject(charListInput.text);
            ParseCharList(charListJson);
        }

        if (scriptList.Count > 0)
            ShowAllUI();

        scriptEnumerator = scriptList.GetEnumerator();
        ShowNextScript();
    }

    void OnDisable ()
    {
        toNextEnabled = false;
        HideAllUI();
        scriptEnumerator = null;
    }

    void Update ()
    {
        if (toNextEnabled)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowNextScript();
            }
        }
	}

    private void ShowNextScript()
    {
        toNextEnabled = false;
        if (scriptEnumerator.MoveNext())
        {
            ScriptUnit scUnit = scriptEnumerator.Current;
            string charName = charList[scUnit.CharIdx];
            charNameBox.GetComponent<Text>().text = charName;
            scriptBox.GetComponent<Text>().text = scUnit.Text;
            toNextEnabled = true;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void HideAllUI()
    {
        if (textFrame != null)
            textFrame.SetActive(false);
        if (scriptBox != null)
            scriptBox.SetActive(false);
        if (charNameBox != null)
            charNameBox.SetActive(false);
    }

    private void ShowAllUI()
    {
        if (textFrame != null)
            textFrame.SetActive(true);
        if (scriptBox != null)
            scriptBox.SetActive(true);
        if (charNameBox != null)
            charNameBox.SetActive(true);
    }

    private bool IsValidScript(JSONObject obj)
    {
        if (obj.list.Count != 2)
            return false;

        return
            obj.keys[0] == "char" && obj.keys[1] == "text" &&
            obj.list[0].type == JSONObject.Type.NUMBER &&
            obj.list[1].type == JSONObject.Type.STRING;
    }

    private void ParseScript(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                if (IsValidScript(obj))
                {
                    ScriptUnit unit = new ScriptUnit(obj.list[0].n, obj.list[1].str);
                    scriptList.Add(unit);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject subObj in obj.list)
                {
                    ParseScript(subObj);
                }
                break;
        }
    }

    private void ParseCharList(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.ARRAY:
                foreach (JSONObject subObj in obj.list)
                {
                    ParseCharList(subObj);
                }
                break;
            case JSONObject.Type.STRING:
                charList.Add(obj.str);
                break;
        }
    }
}
