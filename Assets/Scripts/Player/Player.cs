using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;
    public bool invincibleOn;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }
    void Start()
    {
        _currentHealth = _maxHealth;
        invincibleOn = false;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = (Mathf.Clamp(_currentHealth, 0, _maxHealth));
        Debug.Log("Player's health: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if (invincibleOn)
        {
            return;
        }
        _currentHealth -= amount;
        Debug.Log("Player's health: " + _currentHealth);
        if (_currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (invincibleOn)
        {
            return;
        }
        gameObject.SetActive(false);
    }
}
