using UnityEngine;
using UnityEngine.UI;

public class MirrorText : MonoBehaviour
{
    public Text source;
    public Text output;
    
    public void OnEnable()
    {
        output.text = "· 웹 주소  " + source.text + "  이(가) 정확한지 확인하세요";
    }
}
