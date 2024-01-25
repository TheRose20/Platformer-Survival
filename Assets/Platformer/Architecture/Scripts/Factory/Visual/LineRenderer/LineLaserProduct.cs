using System.Collections;
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
        float elapsedTime = 0f;
        Color initialColor = lineColor.Material.color;

        while (elapsedTime < fadeTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeTime); // Переход от 1 до 0 за fadeTime секунд
            ChangeColor(alpha, lineColor);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
    //https://docs.google.com/spreadsheets/d/1phnbmf9N3sEFcAvwKx3esFnj8wStNDv0U2Co6cL_Jww/edit?usp=sharing

    private void ChangeColor(float alpha, LineLaserSO lineColor)
    {
        Color newColor = lineColor.Material.color;
        newColor.a = alpha;
        _lineRenderer.material.color = newColor;
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
