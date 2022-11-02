using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementsDeMerde : MonoBehaviour
{
    private Vector3 _direction;
    private CharacterController _Chara;
    public float _movespeed = 20f;
    private Rigidbody _r2d2;
    public float _rotationspeed = 20f;
    private float gravityValue = 9.81f;
    private bool groundedPlayer;

    void Awake()
    {
        //_Chara = GetComponent<CharacterController>();
        _r2d2 = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //transform.Translate(1, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = _Chara.isGrounded;
        if (groundedPlayer && _direction.y > 0)
        {
            _direction.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _Chara.Move(move.z * Time.deltaTime * _movespeed * transform.forward);
        // utiliser forward cam
        _r2d2.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + transform.up * move.x * _rotationspeed));
        //_Chara.Move(move.x * Time.deltaTime * _movespeed * transform.right);
        //_direction.y += gravityValue * Time.deltaTime;
    }
}