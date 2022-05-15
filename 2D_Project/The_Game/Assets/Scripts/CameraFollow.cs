using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    [SerializeField]private float _timeOffset;
    [SerializeField]private Vector2 _posOfset;
    [SerializeField]private float _leftLimit;
    [SerializeField]private float _rightLimit;
    [SerializeField]private float _bottomLimit;
    [SerializeField]private float _topLimit;

    private void Update()
    {
        // Текущее положение камеры
        Vector3 startPos = transform.position;

        //Текущее положение игрока
        Vector3 endPos = _player.transform.position;
        endPos.x += _posOfset.x;
        endPos.y += _posOfset.y;
        endPos.z = -10;

        //Плавное следование камеры
        transform.position = Vector3.Lerp(startPos, endPos, _timeOffset * Time.deltaTime);

        transform.position = new Vector3
            (
               Mathf.Clamp(transform.position.x, _rightLimit, _leftLimit),
               Mathf.Clamp(transform.position.y, _bottomLimit, _topLimit),
               transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        //Нарисовать рамку камеры
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(_leftLimit, _topLimit), new Vector2(_rightLimit, _topLimit));
        Gizmos.DrawLine(new Vector2(_rightLimit, _topLimit), new Vector2(_rightLimit, _bottomLimit));
        Gizmos.DrawLine(new Vector2(_rightLimit, _bottomLimit), new Vector2(_leftLimit, _bottomLimit));
        Gizmos.DrawLine(new Vector2(_leftLimit, _bottomLimit), new Vector2(_leftLimit, _topLimit));

    }
}
