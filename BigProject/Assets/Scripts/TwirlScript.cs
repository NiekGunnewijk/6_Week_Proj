using UnityEngine;

public class TwirlScript : MonoBehaviour
{
    [SerializeField] float turningSpeed = 0.1f;
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,turningSpeed,0));
    }
}
