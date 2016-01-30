using UnityEngine;
using System;
using System.Collections;

public class CommonPopupOpener : MonoBehaviour {
    public static void Open(string title, string firstLine, string secondLine, string yesButtonText, Action onClickYes, string noButtonText, Action onClickNo)
    {
        GameObject commonPopupPrefab = (GameObject)Resources.Load("CommonPopup");
        GameObject popup = Instantiate<GameObject>(commonPopupPrefab);
        
        var popupComponent = popup.GetComponent<CommonPopup>();
        popupComponent.Setup(title: title, firstLine: firstLine, secondLine: secondLine, yesClickText: yesButtonText, onClickYes: onClickYes, noButtonText: noButtonText, onClickNo: onClickNo);
    }
}
