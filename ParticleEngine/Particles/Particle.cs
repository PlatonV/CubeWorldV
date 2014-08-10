using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CubeWorldV.ParticleEngine.Particles
{
    class Particle
    {
        public ParticleType Type { get; protected set; }

        public Vector2 Position { get; set; }

        public Particle(ParticleType type)
        {
            Type = type;
        }
    }
}
