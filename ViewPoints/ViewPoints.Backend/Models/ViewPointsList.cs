using System;
using System.Collections.Generic;
using System.Text;

namespace ViewPoints.Backend.Models
{
    /// <summary>
    /// Třída pro serializaci do XML, je potřeba mít nějaký root prvek
    /// </summary>
    public class ViewPointsList
    {
        public List<ViewPoint> ViewPoints { get; set; }
    }
}
