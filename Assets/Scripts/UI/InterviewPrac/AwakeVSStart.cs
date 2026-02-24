using UnityEngine;

public class AwakeVSStart : MonoBehaviour
{

    public Rigidbody rb;


    void Awake()
    {
        if(rb != null)
        {
            //rb = GetComponent<Rigidbody>();

            Debug.Log("Rigidbody component assigned in Awake: ");
        }

        else
        {
            rb = GameObject.Find("Player").GetComponent<Rigidbody>();
            Debug.Log("Rigidbody compoent assigned in Awake using GameObject.Find: ");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
