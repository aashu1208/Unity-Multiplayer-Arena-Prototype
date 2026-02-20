using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : NetworkBehaviour
{

    private CharacterController _controller;

    [Header("Mobile Input")]
    public VirtualJoystick joystick;

    [Header("Movement Settings")]
    public float PlayerSpeed = 2f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {

        if(!Object.HasStateAuthority)
        {
            
            return;
        }
        // FixedUpdateNetwork is only executed on the StateAuthority
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // if joystick exist 
        if(joystick != null)
        {
            
            Vector2 joyInput = joystick.Direction;
            h += joyInput.x;
            v += joyInput.y;
        }

        Vector3 move = new Vector3(h, 0, v);

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * PlayerSpeed * Runner.DeltaTime);

        if(move != Vector3.zero)
        {
            
            gameObject.transform.forward = move;
        }
    }

    public override void Spawned()
    {
        if(Object.HasInputAuthority)
        {
            // Find the joystick in the scene and assign it to the player
            joystick = FindObjectOfType<VirtualJoystick>();
            Button attackButton = GameObject.Find("Button")?.GetComponent<Button>();

            if(attackButton)
            {
                attackButton.onClick.AddListener(Fire);
            }
        }
    }


    public void Fire()
    {

        if(!Object.HasInputAuthority)
        {
            
            return;
        }
        Runner.Spawn(
            bulletPrefab, firePoint.position, firePoint.rotation,
            Object.InputAuthority);
    }
}
