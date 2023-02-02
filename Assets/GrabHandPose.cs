using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabHandPose : MonoBehaviour
{

    public HandData rightHandPose;
    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startingFingerRotations;
    private Quaternion[] finalFingerRotations;
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(SetupPose);
        rightHandPose.gameObject.SetActive(false);
    }

    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if(arg.interactorObject is XRDirectInteractor)
        {
            Debug.Log(arg.interactorObject);
            // Set the hand pose to the grab pose
            HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>(); // Get the hand data from the interactor
            
            handData.animator.enabled = false; // Disable the animator

            SetHandDataValues(handData, rightHandPose);
            SetHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations);
        }
    }

    public void SetHandDataValues(HandData h1, HandData h2)
    {
        startingHandPosition = h1.root.localPosition;
        finalHandPosition = h2.root.localPosition;

        startingHandRotation = h1.root.localRotation;
        finalHandRotation = h2.root.localRotation;

        startingFingerRotations = new Quaternion[h1.bones.Length];
        finalFingerRotations = new Quaternion[h1.bones.Length];

        for (int i = 0; i < h1.bones.Length; i++)
        {
            startingFingerRotations[i] = h1.bones[i].localRotation;
            finalFingerRotations[i] = h2.bones[i].localRotation;
        }
    }

    public void SetHandData(HandData h, Vector3 pos, Quaternion rot, Quaternion[] bonesRotation)
    {
        h.root.localPosition = pos;
        h.root.localRotation = rot;

        for (int i = 0; i < bonesRotation.Length; i++)
        {
            h.bones[i].localRotation = bonesRotation[i];
        }
    }
}
