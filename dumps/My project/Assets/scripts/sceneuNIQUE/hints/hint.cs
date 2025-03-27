using UnityEngine;

public class hint : MonoBehaviour
{
    [SerializeField] private int maxStage;
    [SerializeField] private int minStage;

 
    public void setHint()
    {
        GameObject.Find("hints(Clone)").GetComponent<hintGiver>().setNextHint(maxStage, minStage);
    }
}
