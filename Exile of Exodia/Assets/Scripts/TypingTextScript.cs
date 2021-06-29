using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingTextScript : MonoBehaviour{
    string story;
    Text txt;

    void Start()
    {
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";

        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
    	foreach (char c in story.ToCharArray())
    	{
    		txt.text += c;
    		yield return new WaitForSeconds(0.2f);
    	}
    }
}
