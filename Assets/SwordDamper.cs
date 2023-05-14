using UnityEngine;



public class SwordDamper : MonoBehaviour
{
    public SecondOrderDynamics secondOrderDynamics;

    public float f;
    public float z;
    public float r;

    public Transform damperTransform;

    public Vector3 x0; //Initial position

    private void Start()
    {
        secondOrderDynamics = new SecondOrderDynamics(f, z, r, damperTransform.position);
    }
    private void Update()
    {

        transform.position = secondOrderDynamics.Update(Time.deltaTime, damperTransform.position);
    }
    private void OnValidate()
    {
        secondOrderDynamics = new SecondOrderDynamics(f, z, r, damperTransform.position);
    }

}
public class SecondOrderDynamics
{
    private Vector3 xp; // previous input

    private Vector3 y;//Position state variable
    private Vector3 yd;//Velocity state variable

    private float k1, k2, k3; // dynamics constants
    public SecondOrderDynamics(float f, float z, float r, Vector3 x0)
    {
        // compute constants
        k1 = z / (Mathf.PI * f);
        k2 = 1 / ((2 * Mathf.PI * f) * (2 * Mathf.PI * f));
        k3 = r * z / (2 * Mathf.PI * f);
        // initialize variables
        xp = x0;
        y = x0;
        yd = Vector3.zero;
    }

    public Vector3 Update(float T, Vector3 x, Vector3? xd = null)
    {
        if (xd == null)
        {
            // estimate velocity
            xd = (x - xp) / T;
            xp = x;
        }

        float k2_stable = Mathf.Max(k2, T * T / 2 + T * k1 / 2, T * k1); // clamp k2 to guarantee stability without jitter 
        y = y + T * yd;       // integrate position by velocity
        yd = yd + T * (x + k3 * xd.Value - y - k1 * yd) / k2_stable; // integrate velocity by acceleration 
        return y;
    }


}