using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class FingerHoldIndicator : MonoBehaviour
{
    private RectTransform _rect;
    private Image _image;
    [SerializeField]private Canvas parentCanvas;
    private Animator _anim;
    [SerializeField] private ParticleSystem _particle;
    private float minHoldTime = 0.15f;
    private PostProcessVolume _volume;

    // Start is called before the first frame update
    void Start()
    {
        _volume = GetComponent<PostProcessVolume>();
        _image = GetComponent<Image>();
        _rect = GetComponent<RectTransform>();
        GameEvents.current.OnNextTurn += Boom;
        GameEvents.current.OnLevelComplete += Die;
    }

    // Update is called once per frame
    void Update()
    {
        if (holdPercent >= minHoldTime && Input.GetMouseButton(0))
        {
            _rect.localScale = Vector3.one * (holdPercent / 30) * 100;
        }

    }

    private void FixedUpdate()
    {
        if (holdPercent >= minHoldTime && Input.GetMouseButton(0))
        {
            _volume.enabled = true;
            Vector2 movePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentCanvas.transform as RectTransform,
                Input.mousePosition, parentCanvas.worldCamera,
                out movePos);

            transform.position = parentCanvas.transform.TransformPoint(movePos);
            //_image.fillAmount = (holdPercent - 0.1f) * 1.112f;
            

            

        }
        else
        {
            _rect.transform.position = new Vector2(-1000, -1000);
            _volume.enabled = false;
        }
    }

    private void Boom()
    {
        if (holdPercent == 0)
        {
            _particle.Play();
        }
        
    }

    float holdPercent
    {
        get
        {
            return ControlManager.current.holdingTime / ControlManager.current.necessaryHoldingTime;
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
    
}
