using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class FadeInOut : MonoBehaviour
{
    #region FIELDS
    public Image fadeOutUIImage;
    public float fadeSpeed = 0.8f;
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }
    #endregion
    #region MONOBHEAVIOR
    void OnEnable()
    {
        
    }

    public void RadFadeIn()
    {
        StartCoroutine(Fade(FadeDirection.In, 0.3f));
    }
    public void RadFadeOut()
    {
        StartCoroutine(Fade(FadeDirection.In, 0f));
    }


    public void StartFade()
    {
        StartCoroutine(FadeAndLoadScene(FadeDirection.In, SceneManager.GetActiveScene().buildIndex, 1));
    }
    #endregion
    #region FADE
    private IEnumerator Fade(FadeDirection fadeDirection, float opacity)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        float fadeEndValue = opacity;
        if (fadeDirection == FadeDirection.Out)
        {
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha <= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion
    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, int sceneToLoad, float opacity)
    {
        yield return Fade(fadeDirection, opacity);
        SceneManager.LoadScene(sceneToLoad);
        this.gameObject.SetActive(false);
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? -1 : 1);
    }
    #endregion
}
