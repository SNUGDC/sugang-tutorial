using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NateonChatElement : MonoBehaviour {
    public Text WriterText;
    public Text BodyText;

    public void Setup(string writer, string body)
    {
        this.WriterText.text = writer + " 님의 말:";
        this.BodyText.text = body;
    }
}
