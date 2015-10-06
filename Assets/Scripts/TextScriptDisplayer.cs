using System.Collections.Generic;
using UnityEngine;

public class TextScriptDisplayer : MonoBehaviour {

	public CanvasRenderer textFrame;
    public CanvasRenderer charNameBox;
    public CanvasRenderer textBox;
    public string jsonInput;

    private List<DisplayUnit> displayList = new List<DisplayUnit>();

    private class DisplayUnit
    {
        private int displayMs;
		private int charIdx;
		private string text;

        public DisplayUnit(float _displayMs, float _charIdx, string _text)
		{
            displayMs = (int)_displayMs;
            charIdx = (int)_charIdx;
			text = _text;
		}
    }

	// Use this for initialization
	void Start () {
        JSONObject textJson = new JSONObject(jsonInput);
        ParseJSON(textJson);
	}

	// Update is called once per frame
	void Update () {
	
	}

    void OnActivate ()
    {

    }

    // GUI 
    void OnGUI()
    {
		
    }

    private bool IsValidObject(JSONObject obj)
    {
        if (obj.list.Count != 3)
            return false;

        return
            obj.keys[0] == "time" && obj.keys[1] == "char" && obj.keys[2] == "text" &&
            obj.list[0].type == JSONObject.Type.NUMBER &&
            obj.list[1].type == JSONObject.Type.NUMBER &&
            obj.list[2].type == JSONObject.Type.STRING;
    }

    private void ParseJSON(JSONObject obj)
    {
        switch (obj.type)
        {
            case JSONObject.Type.OBJECT:
                if (IsValidObject(obj))
                {
                    DisplayUnit unit = new DisplayUnit(obj.list[0].n, obj.list[1].n, obj.list[2].str);
                    displayList.Add(unit);
                }
                break;
            case JSONObject.Type.ARRAY:
                foreach (JSONObject subObj in obj.list)
                {
                    ParseJSON(subObj);
                }
                break;
        }
    }
}
