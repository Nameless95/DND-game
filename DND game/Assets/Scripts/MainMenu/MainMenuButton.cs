using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MainMenuButton : MonoBehaviour
{
    [SerializeField] private Transform text;
    [SerializeField] private float yPosition = 2f;
    [SerializeField] private float durationTime = 0.4f;
    [SerializeField] private Image graphic;
    [SerializeField] private Color hoverColor;
    [SerializeField] private float blinkHover = 0.6f;
    [SerializeField] private float blinkNotHover = 0.8f;

    private Color startingColor;
    private float currentBlinkTime;

    // Start is called before the first frame update
    void Start()
    {
        startingColor = graphic.color;
        Vector3 targetPosition = new Vector3(text.position.x, text.position.y + yPosition, text.position.z);

        text.DOMove(targetPosition, durationTime);
        //text.GetComponent<TextMeshProUGUI>().DOFade(0.0f, blinkNotHover).SetEase(Ease.Flash).SetLoops(-1, LoopType.Yoyo);

    }

    public void OnHoverEnter()
    {
        graphic.DOColor(hoverColor, 0.7f);
    }

    public void OnHoverExit()
    {
        graphic.DOColor(startingColor, 0.1f);
    }
}
