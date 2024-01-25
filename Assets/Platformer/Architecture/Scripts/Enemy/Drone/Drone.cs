using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
[RequireComponent(typeof(DroneDeath))]
public class Drone : Enemy
{
    #region CONSTANTA
    [Header("Stats")]
    [SerializeField] private DroneSO _droneStats;

    public Action OnBlackout;
    public Action OnTakeOff;

    private bool _takeOff = true;
    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Visual")]
    [SerializeField] private SpriteRenderer _eyesSpriteRenderer;
    #endregion


    public void Initialize(DroneSO droneStats)
    {
        _droneStats = droneStats;

        _eyesSpriteRenderer.sprite = droneStats.Eyes;
        _eyesSpriteRenderer.color = droneStats.EyesColor;

        HealthInitialize(_droneStats);
        StartCoroutine(WaitForGetPlayerInstance());
    }

    private IEnumerator WaitForGetPlayerInstance()
    {
        while (GetPlayer.instance == null)
        {
            yield return null;
        }
        _target = GetPlayer.instance.GetPlayerTransform();
    }
    #region MOVE
    private void FixedUpdate()
    {
        if (_takeOff)
        {
            if (_target != null)
            {
                Move(_target);
            }
            else
            {
                Debug.Log("Target null");
            }
        }
    }
    /*
    private void Rotate()
    {
        if (transform.rotation.z != 0f)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotateMaxSpeed * Time.fixedDeltaTime);
        }
    }
    */
    protected override void Move(Transform target)
    {
        float distanceTarget = Vector2.Distance(transform.position, target.position);

        Vector2 directionToTarget = (target.position - transform.position).normalized;
        Vector2 directionOutTarget = (transform.position - target.position).normalized;


        if (distanceTarget > _droneStats.MinDistance + _droneStats.DistanceDeathZone)
        {
            Vector2 desiredVelocity = directionToTarget * _droneStats.Speed;

            MoveTowardsRigidbody(_rigidbody, desiredVelocity.x, desiredVelocity.y, _droneStats.Acceleration);
        }
        else if (distanceTarget < _droneStats.MinDistance)
        {
            Vector2 desiredVelocity = directionOutTarget * _droneStats.Speed;

            MoveTowardsRigidbody(_rigidbody, desiredVelocity.x, desiredVelocity.y, _droneStats.Deceleration);
        }
        else
        {
            MoveTowardsRigidbody(_rigidbody, 0f, 0f, _droneStats.Deceleration);
        }

    }

    private void MoveTowardsRigidbody(Rigidbody2D rigidbodyVelocity, float velocityX, float velocityY, float delta)
    {
        float newVelocityX = Mathf.MoveTowards(rigidbodyVelocity.velocity.x, velocityX, delta * Time.fixedDeltaTime);
        float newVelocityY = Mathf.MoveTowards(rigidbodyVelocity.velocity.y, velocityY, delta * Time.fixedDeltaTime);


        _rigidbody.velocity = new Vector2(newVelocityX, newVelocityY);
    }

    #endregion

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _droneStats.MinDistance);
        Gizmos.DrawWireSphere(transform.position, _droneStats.MinDistance + _droneStats.DistanceDeathZone);
    }
#endif



    #region BLACKOUT \ DEATH
    public void Blackout()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(BlackoutCoroutine(_droneStats.BlackoutTime));
        }
    }
    public void Blackout(float time)
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(BlackoutCoroutine(time));
        }
    }

    private IEnumerator BlackoutCoroutine(float rechangeTime)
    {
        _takeOff = false;
        _rigidbody.gravityScale = 1;
        OnBlackout?.Invoke();
        yield return new WaitForSeconds(rechangeTime);
        _takeOff = true;
        _rigidbody.gravityScale = 0;
        OnTakeOff?.Invoke();
    }

    private void OnEnable()
    {
        if (_target == null) _target = GetPlayer.instance.GetPlayerTransform();
        _health.OnDeath += Death;
    }

    private void OnDisable()
    {
        _health.OnDeath -= Death;
        StopAllCoroutines();
    }

    private void Death()
    {
        StopAllCoroutines();
        gameObject.SetActive(false);

    }
    #endregion

#if UNITY_EDITOR

    protected override void OnValidate()
    {
        if (_rigidbody == null)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        if (_enemyStats == null)
        {
            _enemyStats = _droneStats;
        }
        if (_eyesSpriteRenderer == null)
        {
            SpriteRenderer[] allSpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer spriteRenderer in allSpriteRenderer)
            {
                if (spriteRenderer.name == "Eyes")
                {
                    _eyesSpriteRenderer = spriteRenderer;
                    break;
                }
            }
        }

        base.OnValidate();
    }
#endif
}