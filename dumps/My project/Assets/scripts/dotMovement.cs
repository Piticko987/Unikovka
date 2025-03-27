using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dotMovement : MonoBehaviour
{
    private float speed = 7F;
    private Vector3 move = new Vector3(-1,0,0);
    private int Score = 0;
    private TMP_Text sc;
    private GameObject colider;
    [SerializeField] private int mistnost;
    [SerializeField] private ScriptableItem[] itemsrm;
    [SerializeField] private float[] rmx;
    [SerializeField] private float[] rmy;
    [SerializeField] private ScriptableItem[] items;
    [SerializeField] private float[] x;
    [SerializeField] private float[] y;
    public void dotStart()
    {
        this.transform.Translate(1,0,0);
        //this.transform.position.Set(0,0,0);
        //if (this.transform.position.x < 100)
        //{
        //    this.transform.translate(-1, 0, 0);
        //}
        //else if (this.transform.position.x > 100)
        //{
        //    this.transform.translate(1, 0, 0);
        //}
        Debug.Log("dotStartDone");
    }
    private void Start()
    {
        //StartCoroutine(Wait());
    }
    public void Awake()
    {
        //GameObject.Find("Canvas").SetActive(false);
        StartCoroutine(Wait());
        GameObject.Find("Main Camera").transform.position=new Vector3(0,0,-10);
    }
    //public void Update()
    //{
    //    Debug.Log("Called update");
    //    StartCoroutine(Wait());
    //    dotStart();
    //}

    IEnumerator Wait()
    {
        //Debug.Log(this.tag);
        sc = GameObject.Find("sc").GetComponent<TMP_Text>();
    yield return new WaitForSeconds(0.0005F);
        if (this.transform.position.x >= 6.5F)
        {
            speed = -7F;
        }
        else if (this.transform.position.x <= -6.5F)
        {
            speed = 7F;
        }
        this.transform.Translate(speed*0.05F, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.transform.position.x >= -1F && this.transform.position.x <= 1F) Score++;
            Debug.Log(Score);
            sc.text = Score.ToString();
        }
        if (Score > 3) { 
            Debug.Log("Done");
            /*SceneManager.LoadScene(1,LoadSceneMode.Additive);
            colider = GameObject.Find("next");
            //colider = GameObject.Find("paklic");
            //Debug.Log(colider.GetType());
            //colider.SetActive(true);
            Score = 0;
            SceneManager.UnloadSceneAsync(9);*/
            GameObject.Find("saver").GetComponent<minigaeExit>().change(items,x,y,itemsrm, rmx, rmy);
            SceneManager.LoadScene(mistnost);
        }
        StartCoroutine(Wait());
    }
}
