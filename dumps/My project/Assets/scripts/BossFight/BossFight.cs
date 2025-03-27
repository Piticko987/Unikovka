using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    [SerializeField] private GameObject enemyHp, yourHp;
    [SerializeField] private TextMeshProUGUI log;
    private int enemyHpCount = 4, yourHpCount = 4;
    private string message;
    [SerializeField]private bool disabled = false;
    private MasterAudioManager masterAudio;

    private enum choices
    {
        me�,
        �t�t,
        p�st
    }
    private void Awake()
    {
        masterAudio = GameObject.Find("UniversalAudioManager").GetComponent<MasterAudioManager>();
    }

    public void rock()
    {
        Debug.Log("rock");
        EnemyFightBack(choices.p�st);
    }
    public void scissors()
    {
        Debug.Log("scissors");
        EnemyFightBack(choices.me�);
    }
    public void paper()
    {
        Debug.Log("paper");
        EnemyFightBack(choices.�t�t);
    }
    private void EnemyFightBack(choices type)
    {
        if (!disabled)
        {
            log.text = message = "";
            message += "Zvolil jsi: " + type + "\n";
            choices enemy = (choices)Random.Range(0, 3);
            message += "Nep��tel zvolil: " + enemy + "\n";
            if (type == enemy)
            {
                message += "rem�za" + "\n";
                check();
            }
            else
            {
                switch (type)
                {
                    case choices.p�st:
                        {
                            if (enemy == choices.�t�t) { win(); } else { loss(); }
                        }
                        break;

                    case choices.me�:
                        {
                            if (enemy == choices.p�st) { win(); } else { loss(); }
                        }
                        break;
                    case choices.�t�t:
                        {
                            if (enemy == choices.me�) { win(); } else { loss(); }
                        }
                        break;


                }

            }
            Debug.Log("Enemy: " + enemy);
            disabled = true;
        }
    }
    private void win()
    {
        message += "zasadil jsi r�nu nep��teli" + "\n";
        enemyHpCount--;
        enemyHp.transform.GetChild(enemyHpCount).gameObject.SetActive(false);
        this.check();
    }
    private void loss()
    {
        message += "schytal jsi r�nu" + "\n";
        yourHpCount--;
        yourHp.transform.GetChild(yourHpCount).gameObject.SetActive(false);
        this.check();
    }
    private void check()
    {
        StartCoroutine(writeNice());
        StartCoroutine(checkIt());

    }
    private IEnumerator writeNice()
    {
        foreach (char znak in message.ToCharArray())
        {
            yield return new WaitForSeconds(0.025f);
            log.text += znak;
        }
    }
    private IEnumerator checkIt()
    {
            yield return new WaitForSeconds(0.025f*message.Length+1);
        if (yourHpCount == 0)
        {
            GameObject loss = this.transform.GetChild(7).gameObject;
            loss.SetActive(true);
            masterAudio.PlayMusic("background");
            loss.GetComponent<changeScene>().SceneChange();
        }
        if (enemyHpCount == 0)
        {
            masterAudio.PlayMusic("outro");
            this.GetComponent<changeScene>().SceneChange();
        }
        this.disabled = false;

    }

    
    
}
