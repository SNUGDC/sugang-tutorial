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

    public static IEnumerator OpenCoroutine(string title, string firstLine, string secondLine, string yesButtonText, Action onClickYes, string noButtonText, Action onClickNo)
    {
        GameObject commonPopupPrefab = (GameObject)Resources.Load("CommonPopup");
        GameObject popup = Instantiate<GameObject>(commonPopupPrefab);
        
        bool isClosed = false;

        var popupComponent = popup.GetComponent<CommonPopup>();
        popupComponent.Setup(title: title, firstLine: firstLine, secondLine: secondLine, yesClickText: yesButtonText,
            onClickYes: () => {
                onClickYes();
                isClosed = true;
            }, noButtonText: noButtonText,
            onClickNo: () => {
                onClickNo();
                isClosed = true;
            });

        while(!isClosed)
        {
            yield return null;
        }
    }

    public static void OpenSimpleErrorPopup(string errorMessage)
    {
        Open(
            title: "Error",
            firstLine: errorMessage,
            secondLine: "",
            yesButtonText: "OK",
            onClickYes: () => {},
            noButtonText: "Cancel",
            onClickNo: () => {}
        );
    }

    public static void OpenSimpleSuccessPopup(string successMessage, Action onClickYes, Action onClickNo)
    {
        Open(
            title: "Success",
            firstLine: successMessage,
            secondLine: "",
            yesButtonText: "OK",
            onClickYes: onClickYes,
            noButtonText: "Cancel",
            onClickNo: onClickNo
        );
    }

    public static IEnumerator OpenSimpleSuccessPopupCoroutine(string successMessage)
    {
        return OpenCoroutine(
            title: "Success",
            firstLine: successMessage,
            secondLine: "",
            yesButtonText: "OK",
            onClickYes: () => {},
            noButtonText: "Cancel",
            onClickNo: () => {}
        );
    }
}
