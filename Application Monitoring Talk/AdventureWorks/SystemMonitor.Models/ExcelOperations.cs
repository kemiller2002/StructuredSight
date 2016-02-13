#region Licensing

// This code is provided under the Attribution-NonCommercial-ShareAlike 4.0 International license.
// 
// https://creativecommons.org/licenses/by-nc-sa/4.0/
// 
// TCC Software Solutions 2015
// 

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClosedXML.Excel;
using TCC.SystemMonitor.Models.DataObjects;

#endregion

namespace TCC.SystemMonitor.Models
{
    public static class WorkSheetOperations
    {
        public static IXLWorksheet AddHeaders(this IXLWorksheet ws, IEnumerable<string> headers)
        {
            const int startingAsciiNumberForLetters = 65;

            headers.Aggregate(0, (agg, x) =>
            {
                var cell = ((char) (agg + startingAsciiNumberForLetters)) + "1";
                ws.Cell(cell).Value = x;

                return agg + 1;
            });

            return ws;
        }

        public static IXLWorksheet Populate<T>(this IXLWorksheet ws, IEnumerable<T> items,
            Func<Tuple<IXLWorksheet, int>, T, Tuple<IXLWorksheet, int>> populate)
        {
            return items.Aggregate(new Tuple<IXLWorksheet, int>(ws, 0), populate).Item1;
        }

        public static IXLWorksheet AddMiniProfilerData(IXLWorksheet ws, int row, MiniProfiler mp)
        {
            return ws;
        }

        public static IEnumerable<PropertyInfo> GetPropertiesForDisplay(this Type t)
        {
            return t.GetProperties()
                .Where(x => x.GetCustomAttributes(true).Any(y => y is HeaderAttribute))
                .OrderBy(x => ((HeaderAttribute) x.GetCustomAttribute(typeof (HeaderAttribute))).Position);
        }

        public static IEnumerable<string> GetHeaderInformation(this Type t)
        {
            return t.GetProperties()
                .Select(x => x.GetCustomAttributes(true).Select(y => (Attribute) y))
                .Select(x => x.FirstOrDefault(y => y is HeaderAttribute))
                .Where(x => x != null)
                .Select(x => (HeaderAttribute) x)
                .OrderBy(x => x.Position)
                .Select(x => x.PositionalString);
        }
    }


    public class ExcelOperations
    {
        public static IXLWorksheet CreateExcelDocument<T>(Func<IEnumerable<T>> getInformation, string worksheetName)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets
                .Add(worksheetName)
                .AddHeaders(typeof (T).GetHeaderInformation())
                .Populate(getInformation(), PopulateRow);

            return worksheet;
        }

        public static Tuple<IXLWorksheet, int> PopulateRow<T>(Tuple<IXLWorksheet, int> accum, T item)
        {
            const int asciiStartNumberForUpperCaseLetter = 65;

            var ixl = accum.Item1;
            var counter = accum.Item2;

            typeof (T)
                .GetPropertiesForDisplay()
                .Aggregate(0, (agg, y) =>
                {
                    var c = (char) (asciiStartNumberForUpperCaseLetter + agg);
                    var currentCell = c + counter.ToString(); //ex. A1;

                    ixl.Cell(currentCell).Value = y.GetValue(item);

                    return agg + 1;
                });
            return new Tuple<IXLWorksheet, int>(accum.Item1, counter + 1);
        }
    }
}