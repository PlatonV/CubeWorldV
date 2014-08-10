using CubeWorldV.ParticleEngine.Particles;
using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubeWorldV.ParticleEngine.Emitters
{
    class GlobalEmitter : ParticleEmitter
    {
        private Random r = new Random();

        public GlobalEmitter(int maxx, int maxy, int count)
            : base()
        {
            for (int i = 0; i < count; i++)
            {
                Particles.Add(new DustParticle()
                {
                    Position = new Math.Vector2(r.Next(0, maxx), r.Next(0, maxy)),
                    Velocity = new Math.Vector2((float)(r.Next(-10, 10)) / 100, (float)(r.Next(-10, 10)) / 100)
                });
            }
        }

        public override void Update(float dt)
        {
            for (int i = 0; i < Particles.Count; i++)
            {
                var part = Particles[i] as DustParticle;

                part.Position = part.Position + part.Velocity;
            }
        }
    }
}
