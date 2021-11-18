using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Image levelComplete;
    public CanvasGroup endLevelPanel, transitionPanel;
    public GameObject continueButton;
    public string nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        //LevelComplete();
    }

    public void LevelComplete()
    {
        StartCoroutine(CompleteAnim());
    }

    public void NextLevel()
    {
        StartCoroutine(TransitionLevel());
    }

    IEnumerator CompleteAnim()
    {
        FadePanel(endLevelPanel, 1, 2, true);
        yield return new WaitForSeconds(2);
        levelComplete.transform.DOLocalMoveY(0, 2).SetEase(Ease.OutBounce);
        levelComplete.transform.DOScaleY(1, 2).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(2);
        continueButton.SetActive(true);

        yield break;
    }

    IEnumerator TransitionLevel()
    {
        FadePanel(transitionPanel, 1, 2, true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextLevel);

        yield break;
    }

    public void FadePanel(CanvasGroup panel, int alpha, float time, bool interactive)
    {
        panel.DOFade(alpha, time);
        panel.interactable = interactive;
        panel.blocksRaycasts = interactive;
    }

}
