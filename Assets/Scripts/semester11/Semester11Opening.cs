using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Semester11Opening : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   StartCoroutine(ChangeScene());
	}
	
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("stage2");
    }
}
