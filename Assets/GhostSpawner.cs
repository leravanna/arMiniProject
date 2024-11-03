using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private XRRayInteractor _interactor;
    [SerializeField] private XRScreenSpaceController _controller;
    [SerializeField] private GameObject _gameObject;

    void Update()
    {
        if (_interactor.TryGetCurrentARRaycastHit(out ARRaycastHit hit))
        {
            if (hit.trackable is not ARPlane)
            {
                return;
            }
            if (_controller.tapStartPositionAction.action.WasPressedThisFrame())
            {
                Instantiate(_gameObject, hit.pose.position, hit.pose.rotation);
            }
        }
    }
}
