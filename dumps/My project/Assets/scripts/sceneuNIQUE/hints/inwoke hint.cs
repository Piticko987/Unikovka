using System.Collections;
using UnityEngine;

public class inwokehint : MonoBehaviour
{
    private hintGiver hintGiver;

    private void Awake()
    {
       
        GetComponent<Itemclass>().destroyFromMemory();
    }
   
    public void setTimeHint(int delay, int maxStage, int minStage)
    {
        StartCoroutine(TimeHint(delay, maxStage, minStage));
    }
    public void setHint( int maxStage, int minStage)
    {
        hintGiver = GameObject.Find("hints(Clone)").GetComponent<hintGiver>();
        this.hintGiver.setNextHint(maxStage, minStage);
    }
    private IEnumerator TimeHint(int delay,int maxStage,int minStage)
    {
        yield return new WaitForSeconds(delay);
        this.hintGiver.setNextHint(maxStage, minStage);
    }
}
