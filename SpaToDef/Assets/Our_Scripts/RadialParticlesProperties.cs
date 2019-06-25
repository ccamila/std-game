using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialParticlesProperties : MonoBehaviour
{
    private ParticleSystem ps;
    // Start is called before the first frame update
    

    // Update is called once per frame
    public void setRange(float range)
    {
        ps = gameObject.GetComponent<ParticleSystem>();
        var sz = ps.sizeOverLifetime;
        
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.1f);
        curve.AddKey(1f, range);

        sz.size = new ParticleSystem.MinMaxCurve(1f, curve);
    }
}
