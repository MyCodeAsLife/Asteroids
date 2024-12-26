using Asteroids.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{
    public class TransformableViewFactory<RType>
    {
        protected virtual TransformableView GetTemplate(Bullet bullet)
        {
        }
    }
}
