

[System.Serializable]
public class ClampVal
{
    public float Max;
    public float Min;

   public ClampVal()
   {
       Max = 99999f;
       Min = -99999f;
   }

   public float RandomValue
   {
       get
       {
           return UnityEngine.Random.Range(Min, Max);
       }
   }
}
