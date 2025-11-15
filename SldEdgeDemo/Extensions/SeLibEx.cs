using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SolidEdgeFramework;
using SolidEdgeAssembly;
using SolidEdgePart;
using SolidEdgeDraft;

namespace SldEdgeDemo {
    public static class SeLibEx {
        public static T[] ConvertSeArray<T>(this object seObject) where T : class {
            if(seObject is null) return Array.Empty<T>();
            if(seObject is T[] array) return array;
            else if(seObject is object[] objArray) return Array.ConvertAll(objArray, item => (T)item);
            throw new InvalidCastException($"not => {seObject?.GetType().Name ?? "null"}");
        }
        public static T ConvertSe<T>(this object seObject) where T : class {
            if(seObject is T obj) return obj;
            throw new InvalidCastException($"not => {seObject?.GetType().Name ?? "null"}");
        }

        #region seApp
        public static SolidEdgeDocument GetActiveDoc(this Application seApp) => (SolidEdgeDocument)seApp.ActiveDocument;

        #endregion
        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector,
            Func<SheetMetalDocument, T> sheetSelector) {

            if(seDoc is PartDocument part)
                return partSelector(part);
            else if(seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);

            throw new Exception("This Document Not Part Or SheetMetal");
        }
        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector, 
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector) {

            if(seDoc is PartDocument part)
                return partSelector(part);
            else if(seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if(seDoc is AssemblyDocument asm)
                return asmSelector(asm);

            throw new Exception("This Document Not Part Or SheetMetal");
        } 
        
        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector, 
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector,
            Func<WeldmentDocument, T> weldSelector) {

            if(seDoc is PartDocument part)
                return partSelector(part);
            else if(seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if(seDoc is AssemblyDocument asm)
                return asmSelector(asm);  
            else if(seDoc is WeldmentDocument weld)
                return weldSelector(weld);

            throw new Exception("This Document Not Part Or SheetMetal");
        } 
        
        private static T MatchDoc<T>(SolidEdgeDocument seDoc,
            Func<PartDocument, T> partSelector, 
            Func<SheetMetalDocument, T> sheetSelector,
            Func<AssemblyDocument, T> asmSelector,
            Func<DraftDocument, T> draftSelector,
            Func<WeldmentDocument, T> weldSelector) {

            if(seDoc is PartDocument part)
                return partSelector(part);
            else if(seDoc is SheetMetalDocument sheet)
                return sheetSelector(sheet);
            else if(seDoc is AssemblyDocument asm)
                return asmSelector(asm);  
            else if(seDoc is DraftDocument draft)
                return draftSelector(draft);  
            else if(seDoc is WeldmentDocument weld)
                return weldSelector(weld);

            throw new Exception("This Document Not Part Or SheetMetal");
        }


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
