using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]float timeOffset;
    [SerializeField] Vector2 posOfset;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;

    private void Update()
    {
        // Текущее положение камеры
        Vector3 startPos = transform.position;

        //Текущее положение игрока
        Vector3 endPos = player.transform.position;
        endPos.x += posOfset.x;
        endPos.y += posOfset.y;
        endPos.z = -10;

        //Плавное следование камеры
        transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        transform.position = new Vector3
            (
               Mathf.Clamp(transform.position.x, rightLimit, leftLimit),
               Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
               transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        //Нарисовать рамку камеры
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }
}
