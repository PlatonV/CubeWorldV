using CubeWorldV.ParticleEngine.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ParticleEngine.Emitters
{
    abstract class ParticleEmitter
    {
        public List<Particle> Particles = new List<Particle>();

        public ParticleEmitter()
        {
            ParticleManager.AddEmitter(this);
        }

        public abstract void Update(float dt);
    }
}
