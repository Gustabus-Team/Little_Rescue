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
    public GameObject loadIcon;
    public string nextLevel;

    private bool activeLoad;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (activeLoad)
        {
            loadIcon.transform.RotateAround(loadIcon.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void LevelComplete()
    {
        StartCoroutine(CompleteAnim());
    }

    public void NextLevel()
    {
        StartCoroutine(ContinueGame());
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

    IEnumerator ContinueGame()
    {
        int randomTime = Random.Range(4, 6);
        FadePanel(transitionPanel, 1, 1, true);
        activeLoadRotation(true);
        yield return new WaitForSeconds(randomTime);
        activeLoadRotation(false);
        SceneManager.LoadScene(nextLevel);

        yield break;
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        FadePanel(transitionPanel, 0, 1, false);

        yield break;
    }
    public void activeLoadRotation(bool activeIcon)
    {
        loadIcon.SetActive(activeIcon);
        activeLoad = activeIcon;
    }

    public void FadePanel(CanvasGroup panel, int alpha, float time, bool interactive)
    {
        panel.DOFade(alpha, time);
        panel.interactable = interactive;
        panel.blocksRaycasts = interactive;
    }

}
