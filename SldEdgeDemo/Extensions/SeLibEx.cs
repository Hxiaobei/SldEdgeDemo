using SolidEdgeAssembly;
using SolidEdgeDraft;
using SolidEdgeFramework;
using SolidEdgePart;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SldEdgeDemo
{
    public static class SeLibEx
    {
        public static T[] ConvertSeArray<T>(this object seObject) where T : class
        {
            if (seObject is null) return Array.Empty<T>();
            if (seObject is T[] array) return array;
            else if (seObject is object[] objArray) return Array.ConvertAll(objArray, item => (T)item);
            throw new InvalidCastException($"not => {seObject?.GetType().Name ?? "null"}");
        }
        public static T ConvertSe<T>(this object seObject) where T : class
        {
            if (seObject is T obj) return obj;
            throw new InvalidCastException($"not => {seObject?.GetType().Name ?? "null"}");
        }

        public static IEnumerable<T> AsItems<T>(this IEnumerable comCollection) where T : class
        {
            foreach (var item in comCollection)
                if (item is T typedItem)
                    yield return typedItem;
        }

        public static IEnumerable<T> AsItems<T>(this object seObj)
        {

            if (!(seObj is IEnumerable comCollection)) throw new ArgumentException("seObj is not IEnumerable");

            foreach (var item in comCollection)
                if (item is T typedItem)
                    yield return typedItem;
        }

        #region seApp
        public static SolidEdgeDocument GetActiveDoc(this Application seApp) => (SolidEdgeDocument)seApp.ActiveDocument;

        #endregion

        private static void MatchDoc(SolidEdgeDocument seDoc,
         Action<PartDocument> partAction,
         Action<SheetMetalDocument> sheetAction)
        {

            if (seDoc is PartDocument part)
                partAction(part);
            else if (seDoc is SheetMetalDocument sheet)
                sheetAction(sheet);
            else
                throw new Exception("This Document Not Part Or SheetMetal");
        }

        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector,
            Func<SheetMetalDocument, T> sheetSelector)
        {

            if (seDoc is PartDocument part)
                return partSelector(part);
            else if (seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);

            throw new Exception("This Document Not Part Or SheetMetal");
        }
        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector,
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector)
        {

            if (seDoc is PartDocument part)
                return partSelector(part);
            else if (seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if (seDoc is AssemblyDocument asm)
                return asmSelector(asm);

            throw new Exception("This Document Not Part Or SheetMetal");
        }

        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector,
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector,
            Func<WeldmentDocument, T> weldSelector)
        {

            if (seDoc is PartDocument part)
                return partSelector(part);
            else if (seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if (seDoc is AssemblyDocument asm)
                return asmSelector(asm);
            else if (seDoc is WeldmentDocument weld)
                return weldSelector(weld);

            throw new Exception("This Document Not Part Or SheetMetal");
        }

        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector,
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector,
            Func<DraftDocument, T> draftSelector,
            Func<WeldmentDocument, T> weldSelector)
        {

            if (seDoc is PartDocument part)
                return partSelector(part);
            else if (seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if (seDoc is AssemblyDocument asm)
                return asmSelector(asm);
            else if (seDoc is DraftDocument draft)
                return draftSelector(draft);
            else if (seDoc is WeldmentDocument weld)
                return weldSelector(weld);

            throw new Exception("This Document Not Part Or SheetMetal");
        }

        /// <summary>
        /// Suspends or resumes live rules processing for the specified Solid Edge document.
        /// </summary>
        /// <remarks>Live rules control automatic geometric relationships and constraints during editing.
        /// Suspending live rules may improve performance when making bulk changes, but may affect constraint
        /// enforcement until resumed.</remarks>
        /// <param name="doc">The SolidEdgeDocument instance for which live rules processing will be modified. Cannot be null.</param>
        /// <param name="suspend">A value indicating whether to suspend live rules processing. Specify <see langword="true"/> to suspend live
        /// rules; <see langword="false"/> to resume.</param>
        public static void SuspendLiveRules(this SolidEdgeDocument doc, bool suspend)
            => MatchDoc(doc, p => p.SuspendLiveRules(suspend), s => s.SuspendLiveRules(suspend));

        /// <summary>
        /// Retrieves the bend table associated with the specified Solid Edge document.
        /// </summary>
        /// <param name="doc">The SolidEdgeDocument instance from which to obtain the bend table. Cannot be null.</param>
        /// <returns>A BendTable object representing the bend data for the document. Returns null if the document does not
        /// contain a bend table.</returns>
        public static BendTable BendTable(this SolidEdgeDocument doc) => MatchDoc(doc, p => p.BendTable, s => s.BendTable);
        public static EdgebarFeatures EdgebarFeatures(this SolidEdgeDocument doc) => MatchDoc(doc, p => p.DesignEdgebarFeatures, s => s.DesignEdgebarFeatures);
        public static Models Models(this SolidEdgeDocument doc) => MatchDoc(doc, p => p.Models, s => s.Models);
        public static Constructions Constructions(this SolidEdgeDocument doc) => MatchDoc(doc, d => d.Constructions, d => d.Constructions);
        public static EdgebarFeatures DesignFeatures(this SolidEdgeDocument doc) => MatchDoc(doc, d => d.DesignEdgebarFeatures, d => d.DesignEdgebarFeatures);
        public static FlatPatternModels FlatPatternModels(this SolidEdgeDocument doc) => MatchDoc(doc, d => d.FlatPatternModels, d => d.FlatPatternModels);
        public static ModelingModeConstants ModelingMode(this SolidEdgeDocument doc) => MatchDoc(doc, d => d.ModelingMode, d => d.ModelingMode);
        public static void ModelingMode(this SolidEdgeDocument doc, ModelingModeConstants modeling)
            => MatchDoc(doc, d => d.ModelingMode = modeling, d => d.ModelingMode = modeling);
        public static Variables Variables(this SolidEdgeDocument doc)
            => (Variables)MatchDoc(doc, d => d.Variables, d => d.Variables, d => d.Variables, d => d.Variables, d => d.Variables);
        public static InterpartLinks InterpartLinks(this SolidEdgeDocument doc)
            => (InterpartLinks)MatchDoc(doc, d => d.InterpartLinks, d => d.InterpartLinks, d => d.InterpartLinks, d => d.InterpartLinks);


    }
}
