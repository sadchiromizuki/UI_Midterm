using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    private Vector3 originalPosition; 

    private bool isZoomOut = false;
    private bool isFlyingOut = false;
    private bool isBouncing = false;
    private bool isFlippedOut = false;

    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Fade()
    {
        imageToScale.GetComponent<CanvasRenderer>().SetAlpha(0.1f);
        imageToScale.CrossFadeAlpha(10f, 4f, false);
    }


    public void Fly()
    {
        Vector3 endPosition = isFlyingOut ? originalPosition : originalPosition + new Vector3(600f, 0, 0);
        imageToScale.transform.DOLocalMove(endPosition, 0.1f);
        isFlyingOut = !isFlyingOut;
    }

    public void Flip()
    {
        if (isFlippedOut)
        {
            float targetRotation = isFlippedOut ? 2.5f : 0f;
            imageToScale.transform.DORotate(new Vector3(0f, targetRotation, 0f), 0.25f);
        }
        else
        {
            imageToScale.transform.DORotate(new Vector3(0.0f, 180.0f, 0.0f), 0.25f);
        }

        isFlippedOut = !isFlippedOut;
    }

    public void Shake()
    {
        imageToScale.transform.DOShakePosition(0.25f, 10f, 20, 90f, false);
    }

    public void Bounce()
    {
        float bounceScale = isBouncing ? 1.0f : 1.2f;
        imageToScale.transform.DOScale(bounceScale, 0.1f).OnComplete(() =>
        {
            imageToScale.transform.DOScale(1.0f, 0.1f);
        });
        isBouncing = !isBouncing;
    }
}
