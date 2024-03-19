
using System.Collections.Generic;
using UnityEngine;

public class ArrowDrection : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    public Camera _camera;
    public Canvas _canvas;

    public GameObject arrow;

    public Dictionary<GameObject, GameObject> enemiesDictonary = new Dictionary<GameObject, GameObject>();

    public void AddArrowDirection(GameObject obj)
    {
        GameObject arrowOvrEnemy = Instantiate(arrow, obj.transform.position, Quaternion.identity);
        enemiesDictonary.Add(obj, arrowOvrEnemy);
        arrowOvrEnemy.transform.SetParent(_canvas.transform, false);
    }

    public void RemoveArrowDirection(GameObject obj)
    {
        GameObject removeArrowFromDictonary;
        enemiesDictonary.Remove(obj, out removeArrowFromDictonary);
        Destroy(removeArrowFromDictonary);
    }

    private void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        foreach (var kvp in enemiesDictonary)
        {
            var positionEnemy = kvp.Key;
            var arrowEnemy = kvp.Value;
            Vector3 direction = positionEnemy.transform.position - _playerTransform.position;
            Ray ray = new Ray(_playerTransform.position, direction);

            float minDistance = Mathf.Infinity;
            int planeIndex = 0;
            for (int i = 0; i < 4; i++)
            {
                if (planes[i].Raycast(ray, out float distance))
                {
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        planeIndex = i;
                    }
                }
            }

            if (direction.magnitude < minDistance)
                arrowEnemy.GetComponent<ArrowForEnemy>().Hide();
            else
                arrowEnemy.GetComponent<ArrowForEnemy>().Show();

            minDistance = Mathf.Clamp(minDistance, 0f, direction.magnitude);
            Vector3 worldPoint = ray.GetPoint(minDistance);
            arrowEnemy.transform.position = _camera.WorldToScreenPoint(worldPoint);
            arrowEnemy.transform.rotation = GetRotation(planeIndex);
        }
    }

    private Quaternion GetRotation(int index)
    {
        if (index == 0)
            return Quaternion.Euler(0f, 0f, 90f);
        else if (index == 1)
            return Quaternion.Euler(0f, 0f, -90f);
        else if (index == 2)
            return Quaternion.Euler(0f, 0f, 180f);
        else if (index == 3)
            return Quaternion.Euler(0f, 0f, 0f);
        else
            return Quaternion.identity;
    }
}
