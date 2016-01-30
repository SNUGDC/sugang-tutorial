using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class NateonChat : MonoBehaviour {
    public Text FriendName;
    public NateonChatElement chatElementExample;
    public GameObject chatElementParent;
    public Scrollbar scrollBar;

    private void Start()
    {
        // StartCoroutine(Test());
    }

    public void WriteText(InputField text)
    {
        AddText("나", text.text);
    }

    public void AddText(string name, string text)
    {
        var newChatElement = Instantiate<NateonChatElement>(chatElementExample);
        newChatElement.transform.SetParent(chatElementParent.transform);
        newChatElement.gameObject.SetActive(true);
        newChatElement.transform.localPosition = chatElementExample.transform.localPosition;
        newChatElement.transform.localScale = chatElementExample.transform.localScale;
        newChatElement.Setup(name, text);
     
        StartCoroutine(InvokeNextFrame(() => scrollBar.value = 0));   
    }
    
    private IEnumerator InvokeNextFrame(Action action)
    {
        yield return null;
        yield return null;
        action();
    }

    private IEnumerator Test()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            AddText("brew", "NewText " + Time.time);
        }
    }
}
