using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
    using UnityEditor;
#endif


public class StressUpdater : MonoBehaviour {

    private const float INITIAL_ANXIETY = 0.35f;
#if UNITY_EDITOR
    [Header("Volume Anxiety")]
    [Range(0,1f)]
#endif
    public float anxiety;

	void Awake () {
        anxiety = INITIAL_ANXIETY;	
	}


    public float getAnxiety()
    {
        return anxiety;
    }

    public void increaseAnxiety(float theAnxiety)
    {
        anxiety += theAnxiety;
    }

    public void decreaseAnxiety(float theAnxiety)
    {
        if (anxiety - theAnxiety < 0)
            anxiety = 0;
        else
            anxiety -= theAnxiety;
    }

    
}


