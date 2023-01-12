using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public RuntimeAnimatorController[] animatorControllers;
    
    void Start()
    {
        GetComponent<Animator>().runtimeAnimatorController =
            animatorControllers[Random.Range(0, animatorControllers.Length)];
        
        Invoke(nameof(Kill), 8f);
    }

    private void Kill()
    {
        DestroyImmediate(this.gameObject);
    }
}
