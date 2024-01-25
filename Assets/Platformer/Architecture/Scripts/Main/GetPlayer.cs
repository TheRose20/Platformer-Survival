using TarodevController;
using UnityEngine;

public class GetPlayer : MonoBehaviour
{
    [SerializeField] private Transform _mainPlayer;

    public static GetPlayer instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Transform GetPlayerTransform() => _mainPlayer;

    private void OnValidate()
    {
        if (_mainPlayer == null)
        {
            Debug.LogWarning("Player is null", this);
            _mainPlayer = FindAnyObjectByType<PlayerController>().transform;
        }
    }
}
