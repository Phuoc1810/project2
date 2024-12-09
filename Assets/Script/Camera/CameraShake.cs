using System.Collections;
using UnityEngine;
using Cinemachine; // Đảm bảo có sử dụng namespace này

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private Vector3 originalPosition;
    public float shakeDuration = 0.5f; // Thời gian rung lắc
    public float shakeMagnitude = 0.2f; // Cường độ rung lắc

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>(); // Lấy reference đến CinemachineVirtualCamera
        if (virtualCamera == null)
        {
            Debug.LogError("CameraShake không tìm thấy CinemachineVirtualCamera!");
        }
    }

    // Hàm bắt đầu rung lắc camera
    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsed = 0f;

        // Lấy Virtual Camera's Noise component để điều chỉnh
        CinemachineBasicMultiChannelPerlin perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        if (perlin != null)
        {
            perlin.m_AmplitudeGain = shakeMagnitude; // Đặt cường độ rung lắc
            perlin.m_FrequencyGain = shakeMagnitude; // Đặt tần số rung lắc
        }

        while (elapsed < shakeDuration)
        {
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset lại cường độ và tần số sau khi hoàn thành rung lắc
        if (perlin != null)
        {
            perlin.m_AmplitudeGain = 0f; // Reset rung lắc
            perlin.m_FrequencyGain = 0f;
        }
    }
}
