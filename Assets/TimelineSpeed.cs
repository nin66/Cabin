using UnityEngine;
using UnityEngine.Playables;
public class TimelineSpeed : MonoBehaviour
{
    public float newSpeed;
    public PlayableDirector pd;

    void Start()
    {
        pd = GetComponent<PlayableDirector>();
        pd.playableGraph.GetRootPlayable(0).SetSpeed(newSpeed);
    }
}