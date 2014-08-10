using CubeWorldV.ParticleEngine.Emitters;
using CubeWorldV.ParticleEngine.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ParticleEngine
{
    static class ParticleManager
    {
        private static List<ParticleEmitter> Emitters = new List<ParticleEmitter>();

        internal static void AddEmitter(ParticleEmitter emitter)
        {
            Emitters.Add(emitter);
        }

        internal static void Update(float dt)
        {
            for (int i = 0; i < Emitters.Count; i++)
            {
                Emitters[i].Update(dt);
            }
        }

        internal static List<Particle> GetParticles()
        {
            List<Particle> particles = new List<Particle>();

            for (int i = 0; i < Emitters.Count; i++)
            {
                foreach (Particle p in Emitters[i].Particles)
                {
                    particles.Add(p);
                }
            }

            return particles;
        }
    }
}
