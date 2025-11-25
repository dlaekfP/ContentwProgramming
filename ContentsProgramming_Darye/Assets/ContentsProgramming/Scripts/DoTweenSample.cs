using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using TMPro;
using UnityEngine.UI;
public class DoTweenSample : MonoBehaviour
{
    public float duration = 2f;
    public float temperature = 0f;
    public TextMeshProUGUI temperatureText;
    public Image slider;
    public RectTransform backgroundPanel;
    public CanvasGroup canvasGroup;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      temperatureText.text = "Temperature: " + temperature.ToString("F1") + "C";

      DOTween.To(() => temperature, x => temperature = x, 20f, duration).OnUpdate(
        () => temperatureText.text = "Temperature: " + temperature.ToString("F1") + "C"
      );

      slider.fillAmount = 0f;
      slider.DOFillAmount(0.8f, duration).SetEase(Ease.OutQuad);

      backgroundPanel.DOAnchorPos(new Vector2(0f, 0f),duration).SetEase(Ease.Linear).OnUpdate(
        () => canvasGroup.DOFade(1f, 0.5f)
      ).OnComplete(
        () => slider.DOColor(new Color(0f, 0f, 1f, 1f),duration)
      );

    }
    // Update is called once per frame()
    void Update()
    {
        
    }
}
