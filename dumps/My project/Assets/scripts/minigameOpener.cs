using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigameOpener : MonoBehaviour
{
    [SerializeField]private float delay;
    [SerializeField]private string scene;
    [SerializeField]private bool sceneactive;
    [SerializeField]private GameObject locked;
    private GameObject UI;
    public void SceneChange() {
        Debug.Log("startnuto");
        if (this.locked != null)
        {
            Debug.Log("1if");
            if (this.sceneactive) { return; }
        }
        Debug.Log("2if");
        this.sceneactive = true;
        UI.SetActive(false);
        StartCoroutine(ChangeScene());
       
    }
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("2metoda");
        SceneManager.LoadScene(scene,LoadSceneMode.Additive);
    }
    public void Awake()
    {
        UI = GameObject.Find("UIManager");
    }
}
