using SolidEdgeFrameworkSupport;
using SolidEdgeFramework;
using SolidEdgePart;
using SolidEdgeAssembly;
using SolidEdgeDraft;
using SolidEdgeGeometry;

using seConst = SolidEdgeConstants;

using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;
using System.Diagnostics;

using SldEdgeEx;
using SldEdgeDemo;

namespace ColorPalette_Winform {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            LoadToolTip();
           SeExample.SeApp = SeUtils.Se;
            if(SeExample.SeApp == null) {
                MessageBox.Show("请先启动solid edge程序");
                Close();
            }

            //Add all of the geometry types to locate filter list.
            lstLocate.Items.AddRange(Enum.GetNames(typeof(seConst.seLocateFilterConstants)));
        }

        #region ColorSet

        static Color color;
        private void TrackBar_Scroll(object sender, EventArgs e) {
            color = Color.FromArgb(trackBarOpacity.Value, trackBarRed.Value, trackBarGreen.Value, trackBarBlue.Value);

            labelRed.Text = color.R.ToString();
            labelGreen.Text = color.G.ToString();
            labelBlue.Text = color.B.ToString();
            labelOpacity.Text = color.A.ToString();

            panelColor.BackColor = color;
        }
        private bool CheckColorCode(int numCode) {
            if(numCode >= 0 && numCode <= 255) return true;
            return false;
        }

        #endregion

        void LoadToolTip() {
            toolTip1.SetToolTip(but10, "零件");
            toolTip1.SetToolTip(but11, "装配");
            toolTip1.SetToolTip(but12, "图纸");
            toolTip1.SetToolTip(but13, "AllDocment");
            toolTip1.SetToolTip(but14, "Sketch");
            toolTip1.SetToolTip(but15, "GlobalParameter");
            toolTip1.SetToolTip(but16, "Sketch3D");
            toolTip1.SetToolTip(but17, "Relations2d");
            toolTip1.SetToolTip(but18, "FeatureGroups");
            toolTip1.SetToolTip(but19, "AssemblyGroups");
            toolTip1.SetToolTip(but20, "ImportStyles_Drft");
            toolTip1.SetToolTip(but21, "ImportStyles_3DView,<FaceStyles>");
        }

        #region Load{10-13}

        private void Part_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            if(SeExample.activeDoc.Type != SolidEdgeFramework.DocumentTypeConstants.igPartDocument
                &&SeExample.activeDoc.Type != SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument) {
                txbox_Msg.Text =SeExample.activeDoc.Type + " 环境不对";
                return;
            }
            oopc_tbox.Text = "GetFeatureData";
            switch(oopc_tbox.Text) {
                case "GetFeatureData":
                    GetFeatureData(SeExample.activeDoc);
                    break;
                case "GetSketchData":
                    break;
                case "GetSelectFaces":

                    break;
            }

        }
        private void Assembly_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            if(SeExample.activeDoc.Type != DocumentTypeConstants.igAssemblyDocument) {
                txbox_Msg.Text =SeExample.activeDoc.Type + " 环境不对";
                return;
            }
            var AssemDoc =SeExample.activeDoc as AssemblyDocument;

            var startTime = DateTime.UtcNow;

            var absTime = DateTime.UtcNow - startTime;
            txbox_Msg.AppendText("\r\n" + absTime.TotalMilliseconds);
        }
        private void Draft_Clict(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            if(SeExample.activeDoc.Type != SolidEdgeFramework.DocumentTypeConstants.igDraftDocument) {
                txbox_Msg.Text =SeExample.activeDoc.Type + " 环境不对";
                return;
            }

            var sketchs = (SeExample.activeDoc as dynamic).ActiveSketch;

            if(sketchs == null) return;


        }
        private void AllDocument(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            txbox_Msg.Text = "当前环境  ：" +SeExample.activeDoc.Type;
            switch(SeExample.activeDoc.Type) {
                case SolidEdgeFramework.DocumentTypeConstants.igAssemblyDocument:
                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igPartDocument:
                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igSheetMetalDocument:
                    break;
                case SolidEdgeFramework.DocumentTypeConstants.igDraftDocument:
                    break;
            }



        }

        #endregion

        #region MouseEnvt

        static FaceStyles fesyls = null;
        static FaceStyle fesyl = null;
        private void ButEnter_Click(object sender, EventArgs e) {
           SeExample.GetActiveDoc();

            if(fesyls == null &&SeExample.activeDoc.Type != SolidEdgeFramework.DocumentTypeConstants.igDraftDocument) {
                fesyls = (SeExample.activeDoc as dynamic).FaceStyles;
                if(fesyls == null) return;
            }

            seNewCmd =SeExample.SeApp.CreateCommand((int)seConst.seCmdFlag.seNoDeactivate);
            seNewCmd.Start();

            seMouse = seNewCmd.Mouse;
            seMouse.LocateMode = 2;
            seMouse.LocateFrontToBack = true;
            seMouse.WindowTypes = 1;
            seMouse.EnabledMove = true;

            foreach(var item in lstLocate.SelectedItems) {
                Enum.TryParse(item.ToString(), out seConst.seLocateFilterConstants result);
                seMouse.AddToLocateFilter((int)result);
            }

            seMouse.MouseDown += SeMouse_MouseDown;

        }
        private void Clear_Click(object sender, EventArgs e) {
            lstLocate.ClearSelected();
            try {
                if(seMouse == null) return;
                seMouse.MouseDown -= SeMouse_MouseDown;
                seMouse = null;
                seNewCmd.Done = true;
                seNewCmd = null;
                //Marshal.FinalReleaseComObject(seNewCmd);
            } catch(Exception ex) {
                txbox_Msg.AppendText($"{ex.Message}");
            }
        }

        Command seNewCmd;
        Mouse seMouse;
        private void SeMouse_MouseDown(short sButton, short sShift, double dX, double dY, double dZ, object pWindowDispatch, int lKeyPointType, object pGraphicDispatch) {
            if(pGraphicDispatch != null) {
                fesyl = fesyls.Add("", "");
                if(fesyl == null) return;
                fesyl.SetDiffuse((float)color.R / 255, (float)color.G / 255, (float)color.B / 255);
                fesyl.SetAmbient((float)color.R / 255, (float)color.G / 255, (float)color.B / 255);
                fesyl.Opacity = (float)color.A / 255;//透明度设置
                try {
                    GetSeObjectType(pGraphicDispatch);
                } catch(Exception ex) {
                    Invoke(new Action(() => txbox_Msg.AppendText($"{ex.Message}")));
                    //Invoke(new Action(() => txbox_Msg.AppendText($"{ex.StackTrace}")));
                }
            }
        }

        int GetSeObjectType(object pGraphicDispatch, int root = 0) {
            var seObjType = (pGraphicDispatch as dynamic).Type();
            switch((int)seObjType) {
                //igBody
                case 167551091:
                    Body sebody = pGraphicDispatch as Body;
                    sebody.Style = fesyl;
                    break;
                //Face 
                case 167551075:
                    Face seface = pGraphicDispatch as Face;
                    seface.Style = fesyl;
                    break;
                //edge
                case 167551093:
                    Edge edge = pGraphicDispatch as Edge;
                    GetGeometryData(edge);
                    break;
                //subOcc->part
                case -768828720:
                    Reference reference = pGraphicDispatch as Reference;
                    object referObj = reference.Object;
                    var setype = GetSeObjectType(referObj, root++);
                    if(root != 0) break;
                    var boundSubOcc = Array.CreateInstance(typeof(object), 0);
                    reference.GetOccurrencesInPath(out _, out _, out var NumBoundSub, ref boundSubOcc);
                    if(NumBoundSub == 0) break;
                    if(!(boundSubOcc.GetValue(0) is SubOccurrence subOcc)) break;
                    subOcc.FaceStyle = fesyl;

                    break;
                //Occ->part
                case -1879909117:
                    var occ = pGraphicDispatch as Occurrence;
                    if(root == 0) occ.FaceStyle = fesyl;
                    break;
                default:
                    Invoke(new Action(() => txbox_Msg.AppendText($"\r\n{seObjType}")));
                    break;
            }

            return (int)seObjType;
        }

        void GetGeometryData(Edge edge) {
            var geometry = edge.Geometry;
            if(geometry is Line line) {
                edge.GetParamExtents(out double min, out double max);
                edge.GetLengthAtParam(min, max, out double length);
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n line:{length * 1e3}")));
            } else if(geometry is Circle circle) {
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n Radius:{circle.Radius * 1e3}")));
            } else if(geometry is Ellipse ellipse) {
                edge.GetParamExtents(out double min, out double max);
                edge.GetLengthAtParam(min, max, out double length);
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n ellipse:{length}")));
            } else if(geometry is Cone cone) {
                edge.GetParamExtents(out double min, out double max);
                edge.GetLengthAtParam(min, max, out double length);
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n cone:{length}")));
            } else if(geometry is BSplineCurve b_Spline) {
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n B-Spline")));
            } else if(geometry is PLine pLine) {
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n pLine")));
            } else if(geometry is ParamBSplineCurve b_Spline2d) {
                Invoke(new Action(() => txbox_Msg.AppendText($"\r\n 2dB-Spline")));

            }

            if(geometry is Curve curve) Invoke(new Action(() => txbox_Msg.AppendText($"\r\n curve")));

        }

        #endregion

        #region Command
        private void but14_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            var sketchs = (SeExample.activeDoc as dynamic).ActiveSketch;
            if(sketchs == null) return;
        }
        private void But15_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            try {
                SolidEdgeDocument solidEdgeDocument = SeUtils.Se.GetActiveDoc();
                dynamic dyDocment = solidEdgeDocument;
                dyDocment.GetGlobalParameter(SheetMetalGlobalConstants.seSheetMetalGlobalFlatPatternSimplifyBSplines, out object value);
                dyDocment.GetGlobalParameter(SheetMetalGlobalConstants.seSheetMetalGlobalMaterialThickness, out value);

                //dyDocment.SetGlobalParameter(SmGloCons.seSheetMetalGlobalMaterialThickness, 2.5e-3);
            } catch(Exception) {

                return;
            }
        }
        private void But16_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;

        }
        private void But17_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;

        }
        private void But18_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;
            FeatureGroups featGroups = (SeExample.activeDoc as dynamic).Models.Item(1).FeatureGroups;
            foreach(FeatureGroup featGroup in featGroups) {
                Debug.Print(featGroup.Name);
            }

            List<object> listObj = new List<object>();

            EdgebarFeatures edbFeatures = (SeExample.activeDoc as dynamic).DesignEdgebarFeatures;
            foreach(dynamic objFeat in edbFeatures) {
                try {
                    if(objFeat.ModelingModeType == 1) { continue; }
                } catch(Exception) {
                    continue;
                }

                if(objFeat.Type != (int)ObjectType.igRefPlane) {
                    listObj.Add(objFeat);
                }
            }

            //生成新的特征组 要求特征不在其他组内
            object[] objFeats = { listObj[0], listObj[1] };
            FeatureGroup objFG = featGroups.AddFeatureGroupsBySet(2, objFeats);
        }
        private void But19_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;

        }
        private void but20_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;


        }
        private void but21_Click(object sender, EventArgs e) {
            if(SeExample.GetActiveDoc() == null) return;

        }

        #endregion

        #region Feature
        void GetFeatureData(SolidEdgeDocument activeDoc) {
            EdgebarFeatures edgebarFeatures = activeDoc.EdgebarFeatures();
            for(int i = edgebarFeatures.Count; i > 0; i--) {
                dynamic Feat = edgebarFeatures.Item(i);
                //if (Feat.ModelingModeType == 2 && (Feat.Type != 732824896)) selectSet.Add(Feat);
                txbox_Msg.AppendText($"\r\n{Feat.Name}  {Feat.Type}  {Feat.ModelingModeType}");
            }
        }

        #endregion

        void Measure() {
            /*InquireElement//提供有关元素的信息
            MeasureAngle
            MeasureAngleEx//测量 3 个元素之间的角度
            MeasureDistance//测量两个元素之间的距离
            MinimumDistance
            NormalDistance//测量线或平面之间的法线距离*/
        }
    }
}