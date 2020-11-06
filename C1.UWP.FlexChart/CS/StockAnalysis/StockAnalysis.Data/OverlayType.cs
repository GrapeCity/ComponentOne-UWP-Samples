using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Data
{
    public enum OverlayType
    {
        None,
        BollingerBands,
        Envelopes,
        FibonacciRetracements,
        FibonacciArcs,
        FibonacciFans,
        FibonacciTimeZones,
        IchimokuCloud,

        PivotPoint,
    }
}
