using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] Image fill;
    [SerializeField] float fillSpeed = 10f;

    float targetFill = 1f;

    void OnEnable() => health.OnHealthChanged += HandleChange;
    void OnDisable() => health.OnHealthChanged -= HandleChange;

    void HandleChange(float current, float max)
    {
        targetFill = current / max;
    }

    void Update()
    {
        fill.fillAmount = Mathf.Lerp(fill.fillAmount, targetFill, Time.deltaTime * fillSpeed);
    }
}