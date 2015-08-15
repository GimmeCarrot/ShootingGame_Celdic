using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextScriptDisplayer : MonoBehaviour {

	public SpriteRenderer textBoxRender;
	public GameObject bgObject;
    public string jsonInput;

    private class DisplayUnit
    {
		private int charIdx;
		private string text;

		public DisplayUnit(int _charIdx, string _text)
		{
			charIdx = _charIdx;
			text = _text;
		}
    }

	// Use this for initialization
	void Start () {
		
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
}
