using System;
using System.Collections.Generic;
using System.Text;

namespace ViewPoints.DependencyServices
{
    public interface IToast
    {
        void ShowToast(string text, Length length);
    }

    public enum Length
    {
        Short,
        Long
    }
}
