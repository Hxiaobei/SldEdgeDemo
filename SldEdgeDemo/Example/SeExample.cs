using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using SolidEdgeAssembly;
using SolidEdgeDraft;
using SolidEdgeFramework;
using SolidEdgeFrameworkSupport;
using SolidEdgeGeometry;
using SolidEdgePart;

using SeConst = SolidEdgeConstants;

namespace SldEdgeDemo {
    public static class SeExample {
        public static SolidEdgeDocument activeDoc;
        public static SolidEdgeFramework.Application SeApp;

        #region Head
        public static SolidEdgeDocument GetActiveDoc() {
            activeDoc = SeApp.GetActiveDoc();

            if(activeDoc == null) MessageBox.Show("请打开一个活动文档");

            return activeDoc;
        }
        #endregion

        public static void HighlightSet_FlatLoop(this SolidEdgeDocument activeDoc) {
            try {
                HighlightSet objHS;

                if(activeDoc.HighlightSets.Count == 0) objHS = activeDoc.HighlightSets.Add();
                else objHS = activeDoc.HighlightSets.Item(1);

                objHS.RemoveAll();
                objHS.Color = 250;

                var theDoc = activeDoc as PartDocument;
                FlatPatternModel objFPM = theDoc.FlatPatternModels.Item(1);

                if(objFPM == null) {
                    MessageBox.Show("No Flat Pattern");
                    return;
                }

                var Layer1LoopArray = Array.CreateInstance(typeof(object), 3);
                var Layer2LoopArray = Array.CreateInstance(typeof(object), 2);
                objFPM.GetClosedLoops(out int _, ref Layer1LoopArray, out int _, ref Layer2LoopArray);

                var loops = new List<object>();
                loops.AddRange((IEnumerable<object>)Layer1LoopArray);
                //loops.AddRange((IEnumerable<object>)Layer2LoopArray);

                var ReferenceKey = Array.CreateInstance(typeof(byte), 0);
                foreach(var item in loops) {
                    if(!(item is Edges AEdges)) continue;

                    for(int i = 1; i <= AEdges.Count; i++) {
                        if(AEdges.Item(i) is Edge edge) {
                            edge.GetReferenceKey(ref ReferenceKey, out var _);
                            theDoc.BindKeyToObject(ReferenceKey, out object seObj);
                            objHS.AddItem(seObj);

                        }
                    }
                }
                objHS.Draw();
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Highlights all edges of the flat pattern in the specified Solid Edge document using the given color.
        /// </summary>
        /// <remarks>If the document does not contain a flat pattern model, no highlighting is performed
        /// and a message is displayed. The method replaces any existing highlights in the document's highlight
        /// set.</remarks>
        /// <param name="activeDoc">The SolidEdgeDocument instance containing the flat pattern to highlight. Must not be null and should contain
        /// at least one flat pattern model.</param>
        /// <param name="color">The color to use for highlighting the edges. If set to the default value, Orchid is used.</param>
        public static void HighlightSet_Flat(this SolidEdgeDocument activeDoc, Color color) {
            HighlightSet objHS;

            if(activeDoc.HighlightSets.Count == 0) objHS = activeDoc.HighlightSets.Add();
            else objHS = activeDoc.HighlightSets.Item(1);

            objHS.RemoveAll();
            if(color == default) color = Color.Orchid;
            objHS.Color = (color.B) | (color.G << 8) | (color.R << 16);

            FlatPatternModel objFPM = (activeDoc as dynamic).FlatPatternModels.Item(1);

            if(objFPM == null) {
                MessageBox.Show("No Flat Pattern");
                return;
            }

            var flatBody = objFPM.Body as Body;

            objHS.AddItem(flatBody.Edges[FeatureTopologyQueryTypeConstants.igQueryAll]);
            objHS.Draw();
        }

        #region Code1

        public static void FaceMove() {
            Models seModels = activeDoc.Models();
            var objFaceMove = seModels.Item(1).FaceMoves.Item(1);

        }
        public static string GetLink() {
            var msg = "";
            try {
                InterpartLinks interPartLinks = activeDoc.InterpartLinks();
                Reference reference = (Reference)interPartLinks.AsItems<InterpartLink>().First();//InterpartLink

                if (reference != null) {
                    var referenObj = reference.Parent;
                    dynamic theObj = reference.Object;
                    msg += "\r\n theObjType " + (SeConst.GNTTypePropertyConstants)theObj.Type;
                }
            } catch(Exception) {

            }
            return msg;
        }
        public static string BodyData() {
            Models seModels = activeDoc.Models();
            Constructions seConstructions = activeDoc.Constructions();
            var listBody = new List<Shell>();

            var time = new Stopwatch();
            time.Start();

            for(int i = 1; i < seModels.Count + 1; i++) {
                Body body = (Body)seModels.Item(i).ConvertSe<Model>().Body;
                if(body == null) continue;
                Shells shells = (Shells)body.Shells;
                if(shells.Count != 1) continue;
                if(!body.IsSolid) continue;
                //if(!body.Valid) continue;

                listBody.Add((Shell)shells.Item(1));
            }

            for(int i = 1; i < seConstructions.Count + 1; i++) {
                //break;
                Body body = (Body)seConstructions.Item(i).Body;
                if(body == null) continue;
                Shells shells = (Shells)body.Shells;
                if(shells.Count != 1) continue;
                if(!body.IsSolid) continue;
                //if(!body.Valid) continue;

                listBody.Add((Shell)shells.Item(1));
            }

            //return;
            CoordinateSystems secoors = (activeDoc as dynamic).CoordinateSystems;
            //KeyPointCurves sekeyPtCurves = seConstructions.KeyPointCurves;
            Sketches3D sks3D = (activeDoc as dynamic).Sketches3D;
            Sketch3D sketch3D;
            if(sks3D.Count == 0) {
                sketch3D = sks3D.Add();
            } else {
                sketch3D = sks3D.Item(1);
            }
            var pts3D = sketch3D.Points3D;

            return "\r\n   Time:" + time.Elapsed.TotalSeconds;

        }
        public static string GetCommandBar() {
            var msg = "";
            var path = "F:\\AA 00\\files\\Image\\";
            var Environments = SeApp.Environments;
            var activeWindow = SeApp.ActiveWindow as SolidEdgeFramework.Window;
            var activeEnvironmentName = activeWindow.Environment;
            //var activeCommand = _SeApp.GetActiveCommand();

            var activeEnvironment = Environments.Item(activeEnvironmentName);
            var categories = activeEnvironment.CommandCategories;
            for(int i = 1; i < categories.Count + 1; i++) {
                var categorie = categories.Item(i);
                //textBox1.AppendText("\n\r" + categorie.Caption);
                for(int j = 1; j < categorie.Count + 1; j++) {
                    var commandInfo = categorie.Item(j);
                    commandInfo.SaveImage(path + commandInfo.Caption + ".ico");
                    //textBox1.AppendText("\n\r   >" + commandInfo.Description);
                    msg += "   [" + commandInfo.Caption + "\n";
                }
            }
            //var CustomizeDisplayName = activeEnvironment.CustomizeDisplayName;
            return msg;
        }

        #endregion

        #region Code2
        public static void RunStart() {
            try {
                // Get the type form the SolidEdge ProgID and Start SolidEdge
                var type = Type.GetTypeFromProgID("SolidEdge.Application");
                SolidEdgeFramework.Application seApp = null;
                try {
                    seApp = Marshal.GetActiveObject("SolidEdge.Application") as SolidEdgeFramework.Application;
                } catch(Exception) {
                    if(seApp == null) seApp = Activator.CreateInstance(type) as SolidEdgeFramework.Application;
                }

                //Turn off alerts. Weldment environment will display a warning
                seApp.DisplayAlerts = false;
                //seApp.Visible = false;

                var documents = seApp.Documents;
                PartDocument sePart = (PartDocument)(documents.Item(1) ?? documents.Add("SolidEdge.PartDocument", Missing.Value) as PartDocument);
                var activeSketch = sePart.ActiveSketch as Profile;
                activeSketch.AddDimnsions();
                //sePart.ExtrudedProfile();
                //Determining Document Type
                //Console.WriteLine($"This Document is Type: {sePart.Type}, Name: {sePart.Name}");
                //Console.ReadKey();

                seApp.DisplayAlerts = true;
                //Marshal.ReleaseComObject(seApp);
                //seApp.Quit();
                //seApp = null;
            } catch(Exception) {

            } finally {

            }
        }

        static void ExtrudedProfile(this SolidEdgePart.PartDocument sePart) {
            var profileSets = sePart.ProfileSets;
            if(profileSets.Count > 0) {
                //seApp.Visible = true;
                //return;
            }
            var profileSet = profileSets.Add();
            var profiles = profileSet.Profiles;
            var profile = profiles.Add(sePart.RefPlanes.Item(1));
            var lines2d = profile.Lines2d;
            var points2d = new double[] { 0, 0, 0.08, 0,
                                      0.08, 0, 0.08, 0.06,
                                      0.08, 0.06, 0.064, 0.06,
                                      0.064, 0.06, 0.064, 0.02,
                                      0.064, 0.02, 0.048, 0.02,
                                      0.048, 0.02, 0.048, 0.06,
                                      0.048, 0.06, 0.032, 0.06,
                                      0.032, 0.06, 0.032, 0.02,
                                      0.032, 0.02, 0.016, 0.02,
                                      0.016, 0.02, 0.016, 0.06,
                                      0.016, 0.06, 0, 0.06,
                                      0, 0.06, 0, 0
                                     };

            for(int i = 0; i < points2d.Length - 3; i += 4) {
                lines2d.AddBy2Points(points2d[i], points2d[i + 1], points2d[i + 2], points2d[i + 3]);
            }

            var relations2d = profile.Relations2d as Relations2d;
            //relations2d.AddKeypoint(lines2d.Item(1), (int)KeypointIndexConstants.igLineEnd, lines2d.Item(2), (int)KeypointIndexConstants.igLineStart, true);
            for(int i = 1; i < lines2d.Count + 1; i++) {
                if(i == lines2d.Count) {
                    relations2d.AddKeypoint(lines2d.Item(i), 1, lines2d.Item(1), 0, true);
                } else {
                    relations2d.AddKeypoint(lines2d.Item(i), 1, lines2d.Item(i + 1), 0, true);
                }
            }

            profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);
            var profileList = new List<SolidEdgePart.Profile> { profile };

            sePart.Models.AddFiniteExtrudedProtrusion(profileList.Count, profileList.ToArray(), SolidEdgePart.FeaturePropertyConstants.igRight, 0.02);

        }

        static void AddDimnsions(this SolidEdgePart.Profile profile) {
            var lines2d = profile.Lines2d;
            var relations2d = profile.Relations2d as Relations2d;
            var dimensions = profile.Dimensions as Dimensions;
            var points2d = new double[] { 0, 0, 0.1, 0,
                                      0.1, 0, 0.1, 0.1,
                                      0.1, 0.1, 0, 0.05,
                                      0, 0.05, 0, 0
                                     };
            for(int i = 0; i < points2d.Length - 3; i += 4) {
                lines2d.AddBy2Points(points2d[i], points2d[i + 1], points2d[i + 2], points2d[i + 3]);
            }
            for(int i = 1; i < lines2d.Count + 1; i++) {
                if(i == lines2d.Count) {
                    relations2d.AddKeypoint(lines2d.Item(i), 1, lines2d.Item(1), 0, true);
                } else {
                    relations2d.AddKeypoint(lines2d.Item(i), 1, lines2d.Item(i + 1), 0, true);
                }
            }

            var dimension = dimensions.AddLength(lines2d.Item(1));
            dimension.Constraint = true;
            dimension = dimensions.AddLength(lines2d.Item(3));
            dimension.Constraint = true;
            dimension = dimensions.AddDistanceBetweenObjects(lines2d.Item(2), 0.1, 0.1, 0, false, lines2d.Item(3), 0, 0.05, 0, false);
            dimension.Constraint = true;
        }

        #region Demo
        class RemovePs {
            public int Tag;
            public string Name;
            public bool IsModel;
        }

        #endregion

        #endregion

        public static void AddSketch(SolidEdgeDocument document) {
            PartDocument partDocument = document as PartDocument;

            RefPlanes refPlanes = partDocument.RefPlanes;
            ProfileSets sprofileSets = partDocument.ProfileSets;
            ProfileSet profileSet = sprofileSets.Add();
            Profiles profiles = profileSet.Profiles;
            Profile profile = profiles.Add(refPlanes.Item(1));
            Lines2d lines2d = profile.Lines2d;
            Line2d line2d = lines2d.AddBy2Points(0, 0, 0.1, 0.1);
            line2d.Move(0, 0, 0, 0.2);
        }

        /// <summary>
        /// 实体剖面草图
        /// </summary>
        /// <param name="partDoc"></param>
        public static void SectionSketches(PartDocument partDoc) {
            try {
                Models objModels = partDoc.Models;
                RefPlanes objPlanes = partDoc.RefPlanes;
                Model seModel = objModels.Item(1);

                Body[] inputbodies = { (Body)seModel.Body };

                Array objOutputSketches = Array.CreateInstance(typeof(object), 0);
                //只能在同步建模中添加
                partDoc.Sketches.CreateSectionSketches(inputbodies, objPlanes.Item(1), out objOutputSketches, out int SketchCount, out _,
                    0, SectionSketchesPlanesDirection.seSectionSketchesPlaneNormalSide,
                    0, -1, -1, -1, -1);
            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 设计体 添加Attribute
        /// </summary>
        /// <param name="aDoc"></param>
        public static void AddAttribute(SolidEdgeDocument SeDoc) {
            Models seModels = (SeDoc as dynamic).Models;
            //Constructions seConstr = (SeDoc as dynamic).Constructions;

            Model model = seModels.Item(1);
            //ConstructionModel consttsModel = seConstr.Item(1);

            AttributeSets attributeSets = (AttributeSets)model.AttributeSets;
            AttributeSet attributeSet = attributeSets.Add("attribute_set1");
            for(int i = 0; i < 12; i++) {
                var attribute = attributeSet.Add("Attribute" + i, SolidEdgeFramework.AttributeTypeConstants.seInteger);
                attribute.Value = i * 12;
            }
        }

        /// <summary>
        /// 选择草图合适窗口
        /// </summary>
        /// <param name="draft"></param>
        public static void Convert2DCoordinate(DraftDocument draft) {
            SelectSet selSet = draft.SelectSet;
            if(selSet.Count == 0) MessageBox.Show("没有选择对象");

            selSet.Item(1).ConvertSe<DrawingView>().Range(out double xMin, out double xMax, out double yMin, out double yMax);

            for(int i = 2; i < selSet.Count + 1; i++) {
                dynamic obj = selSet.Item(i);//2d对象
                obj.Range(out double x1, out double y1, out double x2, out double y2);
                if(xMin > x1) xMin = x1;
                if(yMin > y1) yMin = y1;
                if(xMax < x2) xMax = x2;
                if(yMax < y2) yMax = y2;
            }
            var oSheetWindow = draft.Application.ActiveWindow as SheetWindow;
            oSheetWindow.ModelToWindow(xMin, yMin, out var xWinMin, out var yWinMin);
            oSheetWindow.ModelToWindow(xMax, yMax, out var xWinMax, out var yWinMax);
            if(xWinMax == xWinMin) xWinMax += 2;
            if(yWinMax == yWinMin) xWinMax += 2;

            oSheetWindow.ZoomArea(xWinMin, yWinMin, xWinMax, yWinMax);
        }

        public static void SetDimPoint(DraftDocument draft) {
            var sheet = draft.ActiveSheet;

            var arcs2d = sheet.Arcs2d;
            var dimensions = (Dimensions)sheet.Dimensions;

            var arc2d = arcs2d.AddByCenterStartEnd(0.2, 0.2, 0.1, 0.1, 0.3, 0.3);

            var dimension = dimensions.AddCoordinateOrigin(arc2d, 0.1, 0.1, 0, true);

            dimension.SetKeyPoint(0, 0.3, 0.1, 0);
        }

        /// <summary>
        /// 设置视图投影方向
        /// </summary>
        /// <param name="draftDoc"></param>
        public static void DrViewOr(DraftDocument draftDoc) {
            SelectSet selectSet = draftDoc.Application.ActiveSelectSet;
            var item = selectSet.Item(1);
            var itemType = item.GetType();
            var objectType = itemType.InvokeMember("Type", System.Reflection.BindingFlags.GetProperty, null, item, null);
            var obType = (ObjectType)objectType;
            //Debug.Print(seleView.Name);
            //Debug.Print(obType.ToString());

            DrawingView seleView = (DrawingView)item;

            seleView.ViewOrientation(out double ViewVector_X, out double ViewVector_Y, out double ViewVector_Z,
                                    out double LocaXVector_X, out double LocaXVector_Y, out double LocaXVector_Z,
                                    out SolidEdgeDraft.ViewOrientationConstants Orientation);
            seleView.SetViewOrientation(0, 0, 1, 0, 0, -1);
        }

        public static void MoveFace(Face seleFace, Models seModels) {
            //移动面案例
            Shell shell = (Shell)seleFace.Shell;
            var faceCollection = (Faces)shell.Body.ConvertSe<Body>().CreateCollection(TopologyCollectionTypeConstants.seFaceCollection);
            faceCollection.Add(seleFace);
            FaceMoves faceMoves = seModels.Item(1).FaceMoves;
            Faces objFace = (Faces)seleFace.Body.ConvertSe<Body>().Faces[FeatureTopologyQueryTypeConstants.igQueryAll];

            var faceMoveType = SolidEdgePart.FaceMoveConstants.igFaceMoveAlongEdge;
            var faceMoveType2 = SolidEdgePart.FaceMoveConstants.igFaceMoveOffsetAlongVector;
            var blendCreation = SolidEdgePart.FaceMoveConstants.igFaceMoveRecreateBlends;
            var blendCreation2 = SolidEdgePart.FaceMoveConstants.igFaceMoveAlongVector;


            Vertex vertex1 = (Vertex)seleFace.Vertices.ConvertSe<Vertices>().Item(1);
            Edge objEdge1 = (activeDoc as dynamic).CoordinateSystems.Item(1).Axis(SolidEdgePart.CoordinateSystemFeatureConstants.seCoordSysYAxis);

            FaceMove faceMove = faceMoves.Add(objFace, faceMoveType, blendCreation, null, null, null
                , objEdge1, null, blendCreation2, vertex1,
                0.8d, null, 0, faceMoveType2);
        }

        static SolidEdgeFramework.ObjectType GetObjectType(dynamic obj) {
            var runtimeType = obj.GetType();
            return (SolidEdgeFramework.ObjectType)runtimeType.InvokeMember("Type", System.Reflection.BindingFlags.GetProperty, null, obj, null);
        }

        public static void CreateExtrudedSurface() {
            if(GetActiveDoc() == null) return;
            SeApp.DoIdle();
            var refPlane = (activeDoc as PartDocument).RefPlanes.Item(1);
            var skech = (activeDoc as PartDocument).Sketches.Add();
            var profiles = skech.Profiles;
            var profile = profiles.Add(refPlane);
            profile.Circles2d.AddByCenterRadius(0.04, 0.05, 0.02);
            profile.End(SolidEdgePart.ProfileValidationType.igProfileClosed);
            var extrudedSurfaces = (activeDoc as PartDocument).Constructions.ExtrudedSurfaces;


            Profile[] profile_s = new Profile[profiles.Count];

            for(int i = 1; i <= profiles.Count; i++) profile_s[i - 1] = profiles.Item(i);

            SolidEdgePart.KeyPointExtentConstants KeyPointFlags1 = SolidEdgePart.KeyPointExtentConstants.igTangentNormal;
            SolidEdgePart.KeyPointExtentConstants KeyPointFlags2 = SolidEdgePart.KeyPointExtentConstants.igTangentNormal;
            // Add a new ExtrudedSurface.
            var extrudedSurface = extrudedSurfaces.Add(
                NumberOfProfiles: profile_s.Length,
                ProfileArray: profile_s,
                ExtentType1: SolidEdgePart.FeaturePropertyConstants.igFinite,
                ExtentSide1: SolidEdgePart.FeaturePropertyConstants.igRight,
                FiniteDepth1: 0.0127,
                KeyPointOrTangentFace1: null,
                KeyPointFlags1: ref KeyPointFlags1,
                FromFaceOrRefPlane: null,
                FromFaceOffsetSide: SolidEdgePart.OffsetSideConstants.seOffsetNone,
                FromFaceOffsetDistance: 0,
                TreatmentType1: SolidEdgePart.TreatmentTypeConstants.seTreatmentCrown,
                TreatmentDraftSide1: SolidEdgePart.DraftSideConstants.seDraftInside,
                TreatmentDraftAngle1: 0.1,
                TreatmentCrownType1: SolidEdgePart.TreatmentCrownTypeConstants.seTreatmentCrownByOffset,
                TreatmentCrownSide1: SolidEdgePart.TreatmentCrownSideConstants.seTreatmentCrownSideInside,
                TreatmentCrownCurvatureSide1: SolidEdgePart.TreatmentCrownCurvatureSideConstants.seTreatmentCrownCurvatureInside,
                TreatmentCrownRadiusOrOffset1: 0.003,
                TreatmentCrownTakeOffAngle1: 0,
                ExtentType2: SolidEdgePart.FeaturePropertyConstants.igFinite,
                ExtentSide2: SolidEdgePart.FeaturePropertyConstants.igLeft,
                FiniteDepth2: 0.0127,
                KeyPointOrTangentFace2: null,
                KeyPointFlags2: ref KeyPointFlags2,
                ToFaceOrRefPlane: null,
                ToFaceOffsetSide: SolidEdgePart.OffsetSideConstants.seOffsetNone,
                ToFaceOffsetDistance: 0,
                TreatmentType2: SolidEdgePart.TreatmentTypeConstants.seTreatmentCrown,
                TreatmentDraftSide2: SolidEdgePart.DraftSideConstants.seDraftNone,
                TreatmentDraftAngle2: 0,
                TreatmentCrownType2: SolidEdgePart.TreatmentCrownTypeConstants.seTreatmentCrownByOffset,
                TreatmentCrownSide2: SolidEdgePart.TreatmentCrownSideConstants.seTreatmentCrownSideInside,
                TreatmentCrownCurvatureSide2: SolidEdgePart.TreatmentCrownCurvatureSideConstants.seTreatmentCrownCurvatureInside,
                TreatmentCrownRadiusOrOffset2: 0.003,
                TreatmentCrownTakeOffAngle2: 0,
                WantEndCaps: true
                );
        }

        // Add new dimple.
        //dimple = model.Dimples.Add(
        //    Profile: profile,
        //                Depth: depth,
        //                ProfileSide: SolidEdgePart.DimpleFeatureConstants.seDimpleDepthLeft,
        //                DepthSide: SolidEdgePart.DimpleFeatureConstants.seDimpleDepthRight);

        #region other

        public static void ParallelProcessDoc() {
            BlockingCollection<SheetMetalDocument> sheetMetalDocs = new BlockingCollection<SheetMetalDocument>();

            System.Threading.Thread newThread = new System.Threading.Thread(() => {

                var asmFile = System.IO.Path.GetFullPath(@"E:\asm.asm");
                var asmDoc = (AssemblyDocument)SeApp.Documents.Open(asmFile, 8);
                //_SeApp.SetBackgroundOptionsMask(31);
                //asmDoc.TraverseAssemblyWithAction((doc) =>
                //{
                //    var docFileExt = Path.GetExtension(doc.Name);
                //    if (doc.Type == DocumentTypeConstants.igSheetMetalDocument)
                //    {
                //        sheetMetalDocs.Add((SheetMetalDocument)doc);
                //    }
                //}, true);
                sheetMetalDocs.CompleteAdding();

            });

            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();

            Task.Run(() => {
                foreach(var doc in sheetMetalDocs.GetConsumingEnumerable()) {
                    Console.WriteLine(doc.FullName);
                    // Do stuff
                }
            }).Wait();
        }


        #endregion


        #region ###
        //IntersectionCurves 
        public static void OInterAdd(AssemblyDocument oAsmDoc, Occurrence oOcc1, Occurrence oOcc2, Faces obj2Faces) {
            try {
                //var oPart2 = (SolidEdgePart.PartDocument)oOcc2.OccurrenceDocument;
                //objFaces = oPart2.Models.Item(1).ExtrudedProtrusions.Item(1).Faces(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll);
                var oReferenceToOcc2 = oAsmDoc.CreateReference(oOcc2, obj2Faces);
                //as PartDocument
                var oInterpartConstruction = (oOcc1.OccurrenceDocument as PartDocument).Constructions.InterpartConstructions.Add(oReferenceToOcc2);
                //Update Path finder
                oAsmDoc.UpdatePathfinder(SolidEdgeAssembly.AssemblyPathfinderUpdateConstants.seRebuild);

            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void OInterAdd2(AssemblyDocument oAsmDoc, Occurrence oOcc1, Occurrence oOcc2, Faces obj2Faces) {
            try {
                //var oPart2 = (SolidEdgePart.PartDocument)oOcc2.OccurrenceDocument;
                //objFaces = oPart2.Models.Item(1).ExtrudedProtrusions.Item(1).Faces(SolidEdgeGeometry.FeatureTopologyQueryTypeConstants.igQueryAll);
                var oReferenceToOcc2 = oAsmDoc.CreateReference(oOcc2, obj2Faces);
                //as PartDocument
                var oInterpartConstruction = (oOcc1.OccurrenceDocument as PartDocument).Constructions.InterpartConstructions.Add2(oOcc1, oReferenceToOcc2);
                //Update Path finder
                oAsmDoc.UpdatePathfinder(SolidEdgeAssembly.AssemblyPathfinderUpdateConstants.seRebuild);

            } catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void GetPDoc(SolidEdgeDocument activeDoc) {
            var dyDoc = activeDoc as PartDocument;
            var matrix = Array.CreateInstance(typeof(double), 16);
            dyDoc.GetContainerDocumentAndMatrixOfIPADoc(out object parentDoc, ref matrix);

            if(parentDoc is AssemblyDocument asmDoc) {

            }
        }
        #endregion
    }
}
