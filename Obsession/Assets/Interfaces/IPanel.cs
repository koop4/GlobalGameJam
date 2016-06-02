using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Interfaces
{
    public interface IPanel
    {
        List<IButton> Buttons { get;  }
        IEnemy Enemy { get; }

		//andrè o non andrà?
    }
}
