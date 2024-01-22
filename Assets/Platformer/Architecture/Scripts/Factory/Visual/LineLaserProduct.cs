using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineLaserProduct : MonoBehaviour, ILineProduct
{
    [SerializeField] private LineRenderer _lineRenderer;
    public void Initialize(LineLaserSO lineStats)
    {
        _lineRenderer.startWidth = lineStats.StartWidth;
        _lineRenderer.endWidth = lineStats.EndWidth;
        _lineRenderer.startColor = lineStats.StartColor;
        _lineRenderer.endColor = lineStats.EndColor;
        _lineRenderer.material = lineStats.Material;

        StartCoroutine(DeathTimer(lineStats.DeathTime));

        if (lineStats.UseFade == true) StartCoroutine(Fade(lineStats.FadeTime, lineStats));
    }

    private IEnumerator DeathTimer(float deathTime)
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }

    private IEnumerator Fade(float fadeTime, LineLaserSO lineColor)
    {
        float alpha = 255;
        while (alpha > 0)
        {
            float alphaBlend = 255 * Time.deltaTime * fadeTime;
            alpha -= alphaBlend;
            ChangeColor(alpha, lineColor);
            yield return null;
        }
    }
    //https://docs.google.com/spreadsheets/d/1phnbmf9N3sEFcAvwKx3esFnj8wStNDv0U2Co6cL_Jww/edit?usp=sharing

    private void ChangeColor(float alpha, LineLaserSO lineColor)
    {
        Color c = 
    }

    public LineRenderer GetLineRenderer() => _lineRenderer;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!_lineRenderer)
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }
    } 
#endif
}
