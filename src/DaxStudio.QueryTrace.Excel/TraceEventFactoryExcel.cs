﻿extern alias ExcelAmo;

using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows.Documents;
using xlAmo = ExcelAmo.Microsoft.AnalysisServices;
//using xlAmo = ExcelAmo.Microsoft.AnalysisServices;
namespace DaxStudio.QueryTrace
{
    public  static partial class TraceEventFactoryExcel
    {

        public static List<xlAmo.TraceColumn> RequiredColumns = new List<xlAmo.TraceColumn>(){
            xlAmo.TraceColumn.EventClass,
            xlAmo.TraceColumn.EventSubclass,
            xlAmo.TraceColumn.TextData,
            xlAmo.TraceColumn.CurrentTime,
            xlAmo.TraceColumn.Spid,
            xlAmo.TraceColumn.SessionID,
            //xlAmo.TraceColumn.ActivityID,
            //xlAmo.TraceColumn.RequestID,
            xlAmo.  TraceColumn.DatabaseName,
            xlAmo.TraceColumn.StartTime,
            xlAmo.TraceColumn.NTUserName,
            xlAmo.TraceColumn.ApplicationName,
            xlAmo.TraceColumn.ObjectPath,
            xlAmo.TraceColumn.ObjectName,
            xlAmo.TraceColumn.ObjectReference,
//            trc.Columns.Add(TraceColumn.IntegerData);
            xlAmo.TraceColumn.RequestParameters,
            xlAmo.TraceColumn.RequestProperties,
            xlAmo.TraceColumn.Duration,
            xlAmo.TraceColumn.CpuTime,
            xlAmo.TraceColumn.EndTime,
            xlAmo.TraceColumn.Error,

        };

        //public static xlAmo.TraceEvent CreateTrace(xlAmo.TraceEventClass eventClass)
        //{
        //    xlAmo.TraceEvent trc = new xlAmo.TraceEvent(eventClass);
        //    trc.Columns.Add(xlAmo.TraceColumn.EventClass);

        //    if (eventClass != xlAmo.TraceEventClass.DirectQueryEnd && eventClass != xlAmo.TraceEventClass.Error)
        //    {
        //        // DirectQuery doesn't have subclasses
        //        trc.Columns.Add(xlAmo.TraceColumn.EventSubclass);
        //    }

        //    trc.Columns.Add(xlAmo.TraceColumn.TextData);
        //    trc.Columns.Add(xlAmo.TraceColumn.CurrentTime);
        //    if (eventClass == xlAmo.TraceEventClass.QueryEnd)
        //    {
        //        trc.Columns.Add(xlAmo.TraceColumn.DatabaseName);
        //        trc.Columns.Add(xlAmo.TraceColumn.EndTime);
        //        trc.Columns.Add(xlAmo.TraceColumn.NTUserName);
        //    }
        //    if (eventClass != xlAmo.TraceEventClass.VertiPaqSEQueryCacheMatch)
        //    {
        //        trc.Columns.Add(xlAmo.TraceColumn.StartTime);
        //    }
        //    trc.Columns.Add(xlAmo.TraceColumn.Spid);
        //    trc.Columns.Add(xlAmo.TraceColumn.SessionID);
        //    // In Excel we do not add ActivityID
        //    // trc.Columns.Add(xlAmo.TraceColumn.ActivityID);
        //    switch (eventClass)
        //    {
        //        case xlAmo.TraceEventClass.CommandEnd:
        //        case xlAmo.TraceEventClass.CalculateNonEmptyEnd:
        //        case xlAmo.TraceEventClass.DirectQueryEnd:
        //        case xlAmo.TraceEventClass.DiscoverEnd:
        //        case xlAmo.TraceEventClass.ExecuteMdxScriptEnd:
        //        case xlAmo.TraceEventClass.FileSaveEnd:
        //        case xlAmo.TraceEventClass.ProgressReportEnd:
        //        case xlAmo.TraceEventClass.QueryCubeEnd:
        //        case xlAmo.TraceEventClass.QueryEnd:
        //        case xlAmo.TraceEventClass.QuerySubcube:
        //        case xlAmo.TraceEventClass.QuerySubcubeVerbose:
        //        case xlAmo.TraceEventClass.VertiPaqSEQueryEnd:
        //            trc.Columns.Add(xlAmo.TraceColumn.Duration);
        //            trc.Columns.Add(xlAmo.TraceColumn.CpuTime);
        //            break;
        //        case xlAmo.TraceEventClass.Error:
        //            trc.Columns.Add(xlAmo.TraceColumn.Error);
        //            break;

        //    }
        //    return trc;
        //}

        public static xlAmo.TraceEvent CreateTrace(xlAmo.TraceEventClass eventClass, List<int> columns )
        {
            xlAmo.TraceEvent trc = new xlAmo.TraceEvent(eventClass);
            var columnsToRecord = columns.Where(c => RequiredColumns.Contains((xlAmo.TraceColumn)c));
            foreach (var col in columns)
            {
                trc.Columns.Add((xlAmo.TraceColumn) col);
            }
            return trc;
        }
    }
}
