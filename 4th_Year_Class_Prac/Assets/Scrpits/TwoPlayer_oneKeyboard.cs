using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
public class TwoPlayer_oneKeyboard : MonoBehaviour
{
    [Header("Action")]
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;
    [SerializeField] private InputActionReference p1Jump;
    [SerializeField] private InputActionReference p2Jump;

    [Header("Player")]
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;


    [SerializeField] private float speed = 5f;
    [SerializeField] private float JumpH = 5f;

    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();
        p1Jump.action.Enable();
        p2Jump.action.Enable();

    }
    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();
        p1Jump.action.Disable();
        p2Jump.action.Disable();
    }

    private void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();

        var j1 = p1Jump.action.ReadValue<float>();
        var j2 = p2Jump.action.ReadValue<float>();

        if (p1) p1.transform.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (p2) p2.transform.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;

        if (j1 > 0) p1.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpH);
        if (j2 > 0) p2.GetComponent<Rigidbody>().AddForce(Vector3.up * JumpH);

    }
}




