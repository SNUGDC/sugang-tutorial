using UnityEngine;
using UnityEngine.UI;
using System;

public class CommonPopup : MonoBehaviour {
    public Text Title;
    public Text FirstLine;
    public Text SecondLine;
    public Button YesButton;
    public Button NoButton;
    public Text onClickYesText;
    public Text onClickNoText;
    
    private Action onClickYes;
    private Action onClickNo;
    
    public void Setup(string title, string firstLine, string secondLine, string yesClickText, Action onClickYes, string noButtonText, Action onClickNo)
    {
        this.Title.text = title;
        this.FirstLine.text = firstLine;
        this.SecondLine.text = secondLine;
        this.onClickYes = onClickYes;
        this.onClickNo = onClickNo;
        this.onClickYesText.text = yesClickText;
        this.onClickNoText.text = noButtonText;

        if (this.onClickYesText.text == "")
        {
            YesButton.gameObject.SetActive(false);
        }
        if (this.onClickNoText.text == "")
        {
            NoButton.gameObject.SetActive(false);
        }
    }

    public void OnYesClicked()
    {
        if (onClickYes == null) {
            Debug.LogError("No Yes Callback.");
        } else {
            onClickYes();
        }
        Destroy(gameObject);
    }

    public void OnNoClicked() {
        if (onClickNo == null) {
            Debug.LogError("No No Callback.");
        } else {
            onClickNo();
        }
        Destroy(gameObject);
    }
}
