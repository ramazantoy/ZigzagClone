using UnityEngine;

[System.Serializable]
public static class ClampHandler
{
    public static void ClampPosition(this Transform targetTransform, VectorClamp vectorClamp)
    {
        float x = Mathf.Clamp(targetTransform.position.x, vectorClamp.X.Min, vectorClamp.X.Max);
        float y = Mathf.Clamp(targetTransform.position.y, vectorClamp.Y.Min, vectorClamp.Y.Max);
        float z = Mathf.Clamp(targetTransform.position.z, vectorClamp.Z.Min, vectorClamp.Z.Max);

        Vector3 newPos = new Vector3(x, y, z);
        targetTransform.position = newPos;
    }

    public static void ClampLocalPosition(this Transform targetTransform, VectorClamp vectorClamp)
    {
        float x = Mathf.Clamp(targetTransform.localPosition.x, vectorClamp.X.Min, vectorClamp.X.Max);
        float y = Mathf.Clamp(targetTransform.localPosition.y, vectorClamp.Y.Min, vectorClamp.Y.Max);
        float z = Mathf.Clamp(targetTransform.localPosition.z, vectorClamp.Z.Min, vectorClamp.Z.Max);

        Vector3 newPos = new Vector3(x, y, z);
        targetTransform.localPosition = newPos;
    }

    public static void ClampLocalRotation(this Transform targetTransform, VectorClamp vectorClamp)
    {
        Quaternion originalRot = targetTransform.localRotation;

        float x = Mathf.Clamp(originalRot.eulerAngles.x, vectorClamp.X.Min, vectorClamp.X.Max);
        float y = Mathf.Clamp(originalRot.eulerAngles.y, vectorClamp.Y.Min, vectorClamp.Y.Max);
        float z = Mathf.Clamp(originalRot.eulerAngles.z, vectorClamp.Z.Min, vectorClamp.Z.Max);

        Quaternion clampedRot = Quaternion.Euler(x, y, z);

        // Use Quaternion.Slerp to smoothly interpolate between original and clamped rotations
        float t = .5f; // This should be a value between 0 and 1, representing the interpolation factor.
        targetTransform.localRotation = Quaternion.Slerp(originalRot, clampedRot, t);
    }

    public static void ClampLocalRotationZ(this Transform targetTransform, ClampVal clampValZ)
    {
        float z = Mathf.Clamp(targetTransform.localRotation.eulerAngles.x, clampValZ.Min, clampValZ.Max);
        Quaternion clampedRot = Quaternion.Euler(targetTransform.localRotation.eulerAngles.x,
            targetTransform.localRotation.eulerAngles.y, z);


        float t = 1f;
        targetTransform.localRotation = Quaternion.Slerp(targetTransform.rotation, clampedRot, t);
    }
}