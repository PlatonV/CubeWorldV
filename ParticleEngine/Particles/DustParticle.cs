using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ParticleEngine.Particles
{
    class DustParticle : Particle
    {
        public Vector2 Velocity { get; set; }

        public DustParticle()
            : base(ParticleType.Point)
        {

        }
    }
}
