using System;
using System.Collections.Generic;

public class ResistanceSheetProvider
{
    private Dictionary<ResistanceType, float> _resistances;
    public Dictionary<ResistanceType, float> Resistances => _resistances;

    public ResistanceSheetProvider(ResistanceSheet sheet)
    {
        _resistances = new Dictionary<ResistanceType, float>();
        foreach (var r in sheet.ResistanceList)
        {
            _resistances.Add(r.Type, r.BaseValue);
        }
    }
    public ResistanceSheetProvider()
    {
        _resistances = new Dictionary<ResistanceType, float>();
    }

    public float GetResistanceValue(ResistanceType type)
    {
        float res = 0;
        _resistances.TryGetValue(type, out res);
        return res;
    }
}
