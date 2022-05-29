using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    internal abstract class Event
    {
        #region Methods

        public abstract void Apply();

        #endregion
    }
}
