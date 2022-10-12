using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Transform itemTransform;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private float delay;

    private float _speed;
    private float _distance;
    private Vector3 _startPoint;

    public void Init(float speed, float distance)
    {
        _speed = speed;
        _distance = distance;
        _startPoint = itemTransform.position;
    }

    private void Update()
    {
        var distance = Vector3.Distance(_startPoint, itemTransform.position);

        if (_distance < distance)
        {
            StartCoroutine(ReturnToPool(delay));
            return;
        }

        itemTransform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        distanceText.text = (Mathf.Round(distance)).ToString(CultureInfo.InvariantCulture);
    }

    private IEnumerator ReturnToPool(float delayBeforeReturn)
    {
        yield return new WaitForSeconds(delayBeforeReturn);
        gameObject.SetActive(false);
    }
}