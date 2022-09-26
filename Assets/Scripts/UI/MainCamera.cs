using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MainCamera : MonoBehaviour
{
    private PostProcessVolume _postProcessVolume;

    private Animator _animator;

    [HideInInspector] public float focusDistanse;
    //private DepthOfField DOF;
    // Start is called before the first frame update
    void Start()
    {
        _postProcessVolume = GetComponent<PostProcessVolume>();
        _animator = GetComponent<Animator>();
        
        //_postProcessVolume.profile.TryGetSettings(out DOF);
        //DOF.enabled.value = false;
        
        GameEvents.current.OnLevelComplete += StartAnimation;
    }

    // Update is called once per frame
    void Update()
    {
        //DOF.focusDistance.value = focusDistanse;
    }

    private void StartAnimation()
    {
        _animator.SetBool("levelComplete", true);
        //DOF.enabled.value = true;
    }
}
