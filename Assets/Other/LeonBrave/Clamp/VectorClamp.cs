using UnityEngine;

[System.Serializable]
public class VectorClamp
{
    public ClampVal X;
    public ClampVal Y;
    public ClampVal Z;

    public VectorClamp()
    {
        X = new ClampVal();
        Y = new ClampVal();
        Z = new ClampVal();
    }
}