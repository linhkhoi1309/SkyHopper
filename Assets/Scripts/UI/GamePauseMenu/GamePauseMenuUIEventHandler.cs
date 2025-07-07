using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class GamePauseMenuUIEventHandler : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button continueButton;
    [SerializeField] Button quitButton;

    [SerializeField] TextMeshProUGUI pauseText;
    [SerializeField] Image pauseBackgroundImage;

    [SerializeField] float continueButtonScaleDuration = 0.5f;
    [SerializeField] float continueButtonScaleFactor = 1.2f;

    Player player;

    private void Awake() {
        player = FindFirstObjectByType<Player>();
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        quitButton.onClick.AddListener(OnQuitButtonClicked);

        continueButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pauseBackgroundImage.gameObject.SetActive(false);
        HidePauseMenu();
        AnimateContinueButton();
    }

    private void AnimateContinueButton()
    {
        continueButton.transform.DOScale(continueButtonScaleFactor, continueButtonScaleDuration) // Grow to 1.2x size over 1 second
                    .SetEase(Ease.InOutSine) 
                    .SetLoops(-1, LoopType.Yoyo) 
                    .SetUpdate(true); 
    }

    private void HidePauseMenu()
    {
        continueButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        pauseText.gameObject.SetActive(false);
        pauseBackgroundImage.gameObject.SetActive(false);
    }

    private void ShowPauseMenu()
    {
        continueButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        pauseText.gameObject.SetActive(true);
        pauseBackgroundImage.gameObject.SetActive(true);
    }

    private void OnPauseButtonClicked()
    {
        Time.timeScale = 0;
        ShowPauseMenu();
        player.Pause();
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
    }

    private void OnContinueButtonClicked()
    {
        Time.timeScale = 1;
        HidePauseMenu();
        player.Continue();
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
    }
    private void OnQuitButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(GlobalConfig.LEVEL_SCENE_BUILD_INDEX);
        AudioManager.instance.PlaySound(AudioManager.instance.buttonClickedSound);
    }

    private void OnDestroy()
    {
        pauseButton.onClick.RemoveListener(OnPauseButtonClicked);
        continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        quitButton.onClick.RemoveListener(OnQuitButtonClicked);

        DOTween.Kill(continueButton.transform);
    }
}
