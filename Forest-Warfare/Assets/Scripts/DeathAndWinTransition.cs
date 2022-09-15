using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAndWinTransition : MonoBehaviour
{
    public RectTransform fader;

    public void StartTransition()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, Vector3.zero, 0f).setIgnoreTimeScale(true);
        LeanTween.scale(fader, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(true);
    }

    public void EndTransition()
    {
        fader.gameObject.SetActive(true);

        LeanTween.scale(fader, new Vector3(1, 1, 1), 0).setIgnoreTimeScale(true);
        LeanTween.scale(fader, Vector3.zero, 1.5f).setIgnoreTimeScale(true).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        {
            fader.gameObject.SetActive(false);
        });
    }
    public void LoadLevelSelect()
    {
        AudioManager.Stop("Music");
        SceneManager.LoadScene("LevelSelect");
    }
    public void RestartLevel()
    {
        CheckpointManager.LoadLastCheckpoint();
    }
}
