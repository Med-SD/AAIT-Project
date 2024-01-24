using UnityEngine;

public class RotationMotor : MonoBehaviour
{
    [SerializeField] private Vector3 m_Velocity;
    [SerializeField] private float m_Speed = 10f;
    void Update()
    {
        transform.Rotate(m_Velocity * m_Speed * Time.deltaTime);
    }
}
