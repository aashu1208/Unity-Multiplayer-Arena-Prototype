using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnPlayerDeath;

    public static Player Instance {get ; private set;}
    void Awake()
    {
        if(Instance == null)
        {
            
            Instance = this;
        }

        else
        {
            
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        OnPlayerDeath += HandleDeath;
    }

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Die();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            
            Die();
        }
    }

    void LateUpdate()
    {
        
    }


    void OnDisable()
    {
        OnPlayerDeath -= HandleDeath;
    }

    void OnDestroy()
    {
        
    }

    public void Die()
    {

        OnPlayerDeath?.Invoke();
        

    }

    public void HandleDeath()
    {
        Debug.Log("Player has died, handle death logic here");
    }

 

}
