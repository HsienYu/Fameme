using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.UI;

public class LogoManager : MonoBehaviour
{
    public bool IgnoreLogo = false;

    public VideoPlayer LogoVideo;
    public Image ButtonImage;
    public GameObject[] NeedDisableGameObjects;
    public GameObject[] WaitActiveGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        if (IgnoreLogo)
        {
            OnStartClick();
            return;
        }

        ActiveNeedDisableGame(false);

        LogoVideo.loopPointReached += EndReached;
    }

    private void EndReached(VideoPlayer source)
    {
        ButtonImage.DOColor(new Color(1, 1, 1, 0), 0);
        ButtonImage.gameObject.SetActive(true);
        ButtonImage.DOFade(1, 0.5f);
    }
    public void ActiveNeedDisableGame(bool enable)
    {
        var count = NeedDisableGameObjects.Length;
        for (int i = 0; i < count; i++)
        {
            if (NeedDisableGameObjects[i] == null)
            {
                continue;
            }

            NeedDisableGameObjects[i].SetActive(enable);
        }
    }

    public void ActiveWaitingGameObject(bool enable)
    {
        var count = WaitActiveGameObjects.Length;
        for (int i = 0; i < count; i++)
        {
            if (WaitActiveGameObjects[i] == null)
            {
                continue;
            }

            WaitActiveGameObjects[i].SetActive(enable);
        }
    }

    public void OnStartClick()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
        ActiveWaitingGameObject(true);
    }
}
