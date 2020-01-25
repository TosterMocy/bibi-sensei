using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Transform _playerTransform;
    [SerializeField] private float offset;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = player.transform;
        offset = Mathf.Abs(_playerTransform.position.z - transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerTransform.position.x,_playerTransform.position.y, _playerTransform.position.z - offset);
    }
}
