using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset; // смещение камеры относительно игрока

    private float lastX; // последняя позиция камеры по X

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player не назначен!");
            return;
        }

        lastX = transform.position.x;
    }

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = transform.position;

        // Вертикальное слежение
        targetPos.y = player.position.y + offset.y;

        // Горизонтальное слежение только вправо
        if (player.position.x + offset.x > lastX)
        {
            targetPos.x = player.position.x + offset.x;
            lastX = targetPos.x; // обновляем максимальную позицию
        }

        targetPos.z = -10f; // камера 2D

        // Плавное движение камеры
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
