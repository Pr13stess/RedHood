using UnityEngine;
using UnityEngine.InputSystem;

public class TestDamage : MonoBehaviour
{
    [SerializeField] Health health;

    void Start()
    {
        Debug.Log("TestDamage AKTIF. Health terisi? " + (health != null));
        Debug.Log("Keyboard terdeteksi? " + (Keyboard.current != null));
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            Debug.Log("Tombol K ditekan");
            health.TakeDamage(10f);
        }
        if (Keyboard.current.hKey.wasPressedThisFrame)
        {
            Debug.Log("Tombol H ditekan");
            health.Heal(10f);
        }
    }
}