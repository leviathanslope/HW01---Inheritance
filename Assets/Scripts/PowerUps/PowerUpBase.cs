using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] float _powerupDuration;
    float timer;
    bool powerOn;

    [SerializeField] float _movementSpeed = 1;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _powerUpParticles;
    [SerializeField] AudioClip _powerUpSound;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }

    private void Start()
    {
        powerOn = false;
        timer = _powerupDuration;
    }

    private void Update()
    {
        if (powerOn)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            PowerDown();
            powerOn = false;
            timer = _powerupDuration;
            Destroy(gameObject);
        }
    }

    protected virtual void Movement(Rigidbody rb)
    {
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            powerOn = true;
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    public abstract void PowerUp(Player player);
    public abstract void PowerDown();

    private void Feedback()
    {
        if (_powerUpParticles != null)
        {
            _powerUpParticles = Instantiate(_powerUpParticles, transform.position, Quaternion.identity);
        }

        if (_powerUpSound != null)
        {
            AudioHelper.PlayClip2D(_powerUpSound, 1f);
        }
    }
}
