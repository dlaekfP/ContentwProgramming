using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Graph : MonoBehaviour
{
    [Header("=== Main Groups ===")]
    public GameObject LikeGraph;
    public GameObject HateGraph;
    public GameObject[] WhyGroups;   // Why1~Why4

    [Header("=== Why Title ===")]
    public GameObject WhyTitle;

    [Header("=== End Groups ===")]
    public GameObject EndGroup;
    public GameObject Summary;
    public GameObject Problem;
    public GameObject Way;

    [Header("=== Text Group ===")]
    public GameObject TextGroup;

    [Header("=== Like / Hate ===")]
    public Image classicLikeFill;
    public Image popLikeFill;
    public Image classicHateFill;
    public Image popHateFill;

    public TextMeshProUGUI classicLikeText;
    public TextMeshProUGUI popLikeText;
    public TextMeshProUGUI classicHateText;
    public TextMeshProUGUI popHateText;

    [Header("=== Why Data ===")]
    public Image[] WhyFills;
    public TextMeshProUGUI[] WhyPercents;

    [Header("=== Animation ===")]
    public float duration = 1.2f;
    public Ease ease = Ease.OutQuart;

    int step = 0;
    bool isLocked = false;   // ⭐ 핵심 가드

    // ================= START =================

    void Start()
    {
        InitAll();
        ShowLike(); // ⭐ 최초 1회만
    }

    // ================= Init =================

    void InitAll()
    {
        LikeGraph.SetActive(false);
        HateGraph.SetActive(false);

        foreach (var w in WhyGroups)
            w.SetActive(false);

        EndGroup.SetActive(false);
        Summary.SetActive(false);
        Problem.SetActive(false);
        Way.SetActive(false);

        TextGroup.SetActive(true);
        WhyTitle.SetActive(false);

        step = 0;
        isLocked = false;
    }

    // ================= Button =================

    public void OnNextButton()
    {
        if (isLocked) return;   // ⭐ 중복 클릭 방지
        isLocked = true;

        step++;
        Debug.Log("STEP = " + step);

        switch (step)
        {
            case 1:
                ShowHate();
                break;

            case 2:
            case 3:
            case 4:
            case 5:
                ShowWhy(step - 2);
                break;

            case 6:
                ShowSummary();
                break;

            case 7:
                ShowProblem();
                break;

            case 8:
                ShowWay();
                break;
        }

        // 애니메이션 끝나면 다시 입력 허용
        Invoke(nameof(Unlock), 0.3f);
    }

    void Unlock()
    {
        isLocked = false;
    }

    // ================= Like =================

    void ShowLike()
    {
        LikeGraph.SetActive(true);
        HateGraph.SetActive(false);

        WhyTitle.SetActive(false);

        StartTween(classicLikeFill, classicLikeText, GetPercent("있다", true));
        StartTween(popLikeFill, popLikeText, GetPercent("있다", false));
    }

    // ================= Hate =================

    void ShowHate()
    {
        LikeGraph.SetActive(false);
        HateGraph.SetActive(true);

        WhyTitle.SetActive(false);

        StartTween(classicHateFill, classicHateText, GetPercent("없다", true));
        StartTween(popHateFill, popHateText, GetPercent("없다", false));
    }

    // ================= Why =================

    void ShowWhy(int index)
    {
        HateGraph.SetActive(false);
        TextGroup.SetActive(false);

        WhyTitle.SetActive(true);

        for (int i = 0; i < WhyGroups.Length; i++)
            WhyGroups[i].SetActive(false);

        WhyGroups[index].SetActive(true);

        AnimateWhy(index * 2);
        AnimateWhy(index * 2 + 1);
    }

    void AnimateWhy(int i)
    {
        if (i >= WhyFills.Length ||
            i >= WhyPercents.Length ||
            i >= Csv.Instance.BarrierData.Count)
            return;

        WhyFills[i].fillAmount = 0;
        WhyPercents[i].text = "0%";

        StartTween(
            WhyFills[i],
            WhyPercents[i],
            Csv.Instance.BarrierData[i].Percentage
        );
    }

    // ================= End =================

    void ShowSummary()
    {
        HideWhy();

        TextGroup.SetActive(false);
        EndGroup.SetActive(true);

        Summary.SetActive(true);
        Problem.SetActive(false);
        Way.SetActive(false);

        ForceVisible(Summary);
        SlideInFromRight(Summary);
    }

    void ShowProblem()
    {
        TextGroup.SetActive(false);

        Summary.SetActive(false);
        Problem.SetActive(true);
        Way.SetActive(false);

        ForceVisible(Problem);
        SlideInFromRight(Problem);
    }

    void ShowWay()
    {
        TextGroup.SetActive(false);

        Summary.SetActive(false);
        Problem.SetActive(false);
        Way.SetActive(true);

        ForceVisible(Way);
        SlideInFromRight(Way);
    }

    // ================= Utils =================

    void HideWhy()
    {
        WhyTitle.SetActive(false);

        foreach (var w in WhyGroups)
            w.SetActive(false);
    }

    void ForceVisible(GameObject obj)
    {
        CanvasGroup cg = obj.GetComponent<CanvasGroup>();
        if (cg == null) cg = obj.AddComponent<CanvasGroup>();

        cg.alpha = 1f;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    void StartTween(Image img, TextMeshProUGUI txt, float percent)
    {
        img.fillAmount = 0;
        txt.text = "0%";

        img.DOFillAmount(percent / 100f, duration).SetEase(ease);

        float val = 0;
        DOTween.To(() => val, x => val = x, percent, duration)
            .OnUpdate(() => txt.text = $"{val:F1}%");
    }

    float GetPercent(string key, bool classic)
    {
        var list = classic
            ? Csv.Instance.ClassicalIntentionData
            : Csv.Instance.PopIntentionData;

        return list.Find(d => d.ItemName.Contains(key)).Percentage;
    }

    void SlideInFromRight(GameObject obj)
{
    RectTransform rt = obj.GetComponent<RectTransform>();
    if (rt == null) return;

    float endX = rt.anchoredPosition.x;
    float startX = endX + 800f;   // 👉 오른쪽에서 시작 (필요하면 값 조절)

    rt.anchoredPosition = new Vector2(startX, rt.anchoredPosition.y);

    rt.DOAnchorPosX(endX, duration)
      .SetEase(ease);
}

}
