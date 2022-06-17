using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    string levelToLoad;
    public RectTransform fader;

    public void Start()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0).setIgnoreTimeScale(true);
        LeanTween.scale(fader, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }

    public void StartTransition(string level)
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f).setIgnoreTimeScale(true);
        LeanTween.scale(fader, new Vector3(1,1,1), 0.5f).setIgnoreTimeScale(true).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            levelToLoad = level;
            StartCoroutine(Load());
        });
    }
    public void StartTransition()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f).setIgnoreTimeScale(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setIgnoreTimeScale(true).setEase(LeanTweenType.easeInOutQuad);
    }
    public void TransitionToLevelSelect()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f).setIgnoreTimeScale(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            levelToLoad = "LevelSelect";
            StartCoroutine(Load());
        });
    }
    public void EndTransition()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0).setIgnoreTimeScale(true);
        LeanTween.scale(fader, Vector3.zero, 1.5f).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(true).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }
    IEnumerator Load()
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(levelToLoad); 
    }
}
