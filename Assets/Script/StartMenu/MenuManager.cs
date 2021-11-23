using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int transitionTime;
    public float speedText, rotationSpeed;
    public List<string> startText;
    public List<Sprite> drawsImages;
    public CanvasGroup fadePanel, imagesPanel, title;
    public GameObject startButton, presentationPanel;
    public TextMeshProUGUI initialText;
    public GameObject continueButton, continueText;
    public GameObject loadIcon;
    public Image principlImage;
    public AudioSource source;

    public string levelToGo;

    private bool activeLoad;

    public void Start()
    {

        StartCoroutine(InitialPanel());
    }
    public void Update()
    {
        if (activeLoad)
        {
            loadIcon.transform.RotateAround(loadIcon.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void FadeMusic()
    {
        StartCoroutine(MusicFade());
    }

    IEnumerator MusicFade()
    {
        float timeElapsed = 0;
        float timeToFade = 5.25f;

        while(timeElapsed < timeToFade)
        {
            source.volume = Mathf.Lerp(source.volume, 0, timeElapsed/timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        yield break;
    }
    IEnumerator InitialPanel()
    {
        yield return new WaitForSeconds(2);
        ActivatePanel(fadePanel, 0, 2, false);
        source.Play();

        yield break;
    }
    IEnumerator StartPanel()
    {
        ActivatePanel(fadePanel, 1, 3, true);
        yield return new WaitForSeconds(transitionTime);
        presentationPanel.SetActive(true);
        ActivatePanel(fadePanel, 0, 3, false);
        activeLoadRotation(true);
        yield return new WaitForSeconds(4);
        activeLoadRotation(false);

        for (int i = 0; i < drawsImages.Count; i++)
        {
            RotateDrawsPanel(imagesPanel, 0, false, 0);
            principlImage.sprite = drawsImages[i];
            ActivatePanel(imagesPanel, 1, 2, false);
            yield return new WaitForSeconds(2); 
            if(startText[i] != null)
            {
                foreach (char c in startText[i])
                {
                    initialText.text += c;
                    yield return new WaitForSeconds(speedText);

                }
            }          
            continueText.SetActive(true);
            yield return new WaitWhile(() => !Input.GetKeyDown(KeyCode.Z));
            continueText.SetActive(false);
            initialText.text = "";
            RotateDrawsPanel(imagesPanel, 1.5f, false, 90);
            ActivatePanel(imagesPanel, 0, 2, false);
            yield return new WaitForSeconds(2);
        }
        continueButton.SetActive(true);

        yield break;
    }


    IEnumerator ContinueGame()
    {
        int randomTime = Random.Range(4, 6);
        ActivatePanel(fadePanel, 1, 1, true);
        continueButton.SetActive(false);
        activeLoadRotation(true);
        yield return new WaitForSeconds(randomTime);
        activeLoadRotation(false);
        SceneManager.LoadScene(levelToGo);

        yield break;
    }

    public void StartGame()
    {
        StartCoroutine(StartPanel());
        Debug.Log("Press");
    }

    public void GoToGame()
    {
        StartCoroutine(ContinueGame());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void activeLoadRotation (bool activeIcon)
    {
        loadIcon.SetActive(activeIcon);
        activeLoad = activeIcon;
    }

    public void ActivatePanel(CanvasGroup panel, int alpha, int timeToFade, bool activatePanel)
    {
        panel.DOFade(alpha, timeToFade);
        panel.interactable = activatePanel;
        panel.blocksRaycasts = activatePanel;
    }

    public void RotateDrawsPanel(CanvasGroup panel, float timeRotation, bool activatePanel, float angleRotation)
    {

        panel.transform.DOLocalRotate(new Vector3(0, angleRotation, 0), timeRotation);
        panel.interactable = activatePanel;
        panel.blocksRaycasts = activatePanel;
    }
}
