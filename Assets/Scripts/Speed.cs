using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speed = 2.0f;
    void Update()
    {
        speed += Time.deltaTime;
    }

    public void Reset()
    {
        speed = 2;
    }
}
