using SolidEdgePart;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace SldEdgeDemo.Extensions
{
    public static class SeFeatEx
    {
        public static ModelingModeConstants GetModelingModeType2(object feat) {
            if (feat == null)
                throw new ArgumentNullException(nameof(feat), "参数feat不能为null");

            if (feat is Bead bead)
                return bead.ModelingModeType;
            else if (feat is Bend bend)
                return bend.ModelingModeType;
            else if (feat is BendBulgeReliefFeature brf)
                return brf.ModelingModeType;
            else if (feat is Blank blank)
                return blank.ModelingModeType;
            else if (feat is Jog jog)
                return jog.ModelingModeType;
            else if (feat is KeyPointCurve keyPointCurve)
                return keyPointCurve.ModelingModeType;
            else if (feat is LabelWeld labelWeld)
                return labelWeld.ModelingModeType;
            else if (feat is Lip lip)
                return lip.ModelingModeType;
            else if (feat is LiveSection liveSection)
                return liveSection.ModelingModeType;
            else if (feat is LoftedCutout loftedCutout)
                return loftedCutout.ModelingModeType;
            else if (feat is LoftedFlange loftedFlange)
                return loftedFlange.ModelingModeType;
            else if (feat is LoftedProtrusion loftedProtrusion)
                return loftedProtrusion.ModelingModeType;
            else if (feat is LoftedSurface loftedSurface)
                return loftedSurface.ModelingModeType;
            else if (feat is Louver louver)
                return louver.ModelingModeType;
            else if (feat is MatchFlangeFace matchFlangeFace)
                return matchFlangeFace.ModelingModeType;
            else if (feat is MidSurface midSurface)
                return midSurface.ModelingModeType;
            else if (feat is MirrorCopy mirrorCopy)
                return mirrorCopy.ModelingModeType;
            else if (feat is MirrorCopyGeometry mirrorCopyGeometry)
                return mirrorCopyGeometry.ModelingModeType;
            else if (feat is MirrorPart mirrorPart)
                return mirrorPart.ModelingModeType;
            else if (feat is MountingBoss mountingBoss)
                return mountingBoss.ModelingModeType;
            else if (feat is NormalCutout normalCutout)
                return normalCutout.ModelingModeType;
            else if (feat is NormalToFaceCutout normalToFaceCutout)
                return normalToFaceCutout.ModelingModeType;
            else if (feat is NormalToFaceProtrusion normalToFaceProtrusion)
                return normalToFaceProtrusion.ModelingModeType;
            else if (feat is OffsetEdge offsetEdge)
                return offsetEdge.ModelingModeType;
            else if (feat is OffsetSurface offsetSurface)
                return offsetSurface.ModelingModeType;
            else if (feat is PartingSplit partingSplit)
                return partingSplit.ModelingModeType;
            else if (feat is PartingSurface partingSurface)
                return partingSurface.ModelingModeType;
            else if (feat is PartLabelWeld partLabelWeld)
                return partLabelWeld.ModelingModeType;
            else if (feat is Pattern pattern)
                return pattern.ModelingModeType;
            else if (feat is PatternCopyGeometry patternCopyGeometry)
                return patternCopyGeometry.ModelingModeType;
            else if (feat is PatternPart patternPart)
                return patternPart.ModelingModeType;
            else if (feat is ProjectCurve projectCurve)
                return projectCurve.ModelingModeType;
            else if (feat is Rebend rebend)
                return rebend.ModelingModeType;
            else if (feat is RecoveredBody recoveredBody)
                return recoveredBody.ModelingModeType;
            else if (feat is RedefineFace redefineFace)
                return redefineFace.ModelingModeType;
            else if (feat is RefPlane refPlane)
                return refPlane.ModelingModeType;
            else if (feat is ReplaceFace replaceFace)
                return replaceFace.ModelingModeType;
            else if (feat is ResizeBend resizeBend)
                return resizeBend.ModelingModeType;
            else if (feat is ResizeHole resizeHole)
                return resizeHole.ModelingModeType;
            else if (feat is ResizeRound resizeRound)
                return resizeRound.ModelingModeType;
            else if (feat is RevolvedCutout revolvedCutout)
                return revolvedCutout.ModelingModeType;
            else if (feat is RevolvedProtrusion revolvedProtrusion)
                return revolvedProtrusion.ModelingModeType;
            else if (feat is RevolvedSurface revolvedSurface)
                return revolvedSurface.ModelingModeType;
            else if (feat is Rib rib)
                return rib.ModelingModeType;
            else if (feat is RipEdge ripEdge)
                return ripEdge.ModelingModeType;
            else if (feat is Round round)
                return round.ModelingModeType;
            else if (feat is ScaleBodyFeature scaleBodyFeature)
                return scaleBodyFeature.ModelingModeType;
            else if (feat is Sketch sketch)
                return sketch.ModelingModeType;
            else if (feat is Sketch3D sketch3D)
                return sketch3D.ModelingModeType;
            else if (feat is Sketch3DFeature sketch3DFeature)
                return sketch3DFeature.ModelingModeType;
            else if (feat is Slot slot)
                return slot.ModelingModeType;
            else if (feat is SolidSweptCutout solidSweptCutout)
                return solidSweptCutout.ModelingModeType;
            else if (feat is SolidSweptProtrusion solidSweptProtrusion)
                return solidSweptProtrusion.ModelingModeType;
            else if (feat is Split split)
                return split.ModelingModeType;
            else if (feat is SplitCurve splitCurve)
                return splitCurve.ModelingModeType;
            else if (feat is SplitFace splitFace)
                return splitFace.ModelingModeType;
            else if (feat is StitchSurface stitchSurface)
                return stitchSurface.ModelingModeType;
            else if (feat is Subtract subtract)
                return subtract.ModelingModeType;
            else if (feat is SurfaceByBoundary surfaceByBoundary)
                return surfaceByBoundary.ModelingModeType;
            else if (feat is SweptCutout sweptCutout)
                return sweptCutout.ModelingModeType;
            else if (feat is SweptProtrusion sweptProtrusion)
                return sweptProtrusion.ModelingModeType;
            else if (feat is SweptSurface sweptSurface)
                return sweptSurface.ModelingModeType;
            else if (feat is Tab tab)
                return tab.ModelingModeType;
            else if (feat is Thicken thicken)
                return thicken.ModelingModeType;
            else if (feat is Thin thin)
                return thin.ModelingModeType;
            else if (feat is Thread thread)
                return thread.ModelingModeType;
            else if (feat is ThinWall thinWall)
                return thinWall.ModelingModeType;
            else if (feat is ToggleToDesign toggleToDesign)
                return toggleToDesign.ModelingModeType;
            else if (feat is TrimSurface trimSurface)
                return trimSurface.ModelingModeType;
            else if (feat is TubeFeature tubeFeature)
                return tubeFeature.ModelingModeType;
            else if (feat is Unbend unbend)
                return unbend.ModelingModeType;
            else if (feat is Union union)
                return union.ModelingModeType;
            else if (feat is UnitedBody unitedBody)
                return unitedBody.ModelingModeType;
            else if (feat is UserDefinedPattern userDefinedPattern)
                return userDefinedPattern.ModelingModeType;
            else if (feat is Vent vent)
                return vent.ModelingModeType;
            else if (feat is WebNetwork webNetwork)
                return webNetwork.ModelingModeType;
            else if (feat is WireFeature wireFeature)
                return wireFeature.ModelingModeType;
            else if (feat is WrapSketch wrapSketch)
                return wrapSketch.ModelingModeType;

            throw new ArgumentException($"{feat.GetType()} not solidEdge feature");
        }

        public static FeatureTypeConstants GetType2(object feat) {
            if (feat == null)
                throw new ArgumentNullException(nameof(feat), "参数feat不能为null");

            if (feat is Bead bead)
                return bead.Type;
            else if (feat is Bend bend)
                return bend.Type;
            else if (feat is BendBulgeReliefFeature brf)
                return brf.Type;
            else if (feat is Blank blank)
                return blank.Type;
            else if (feat is Jog jog)
                return jog.Type;
            else if (feat is KeyPointCurve keyPointCurve)
                return keyPointCurve.Type;
            else if (feat is LabelWeld labelWeld)
                return labelWeld.Type;
            else if (feat is Lip lip)
                return lip.Type;
            else if (feat is LiveSection liveSection)
                return liveSection.Type;
            else if (feat is LoftedCutout loftedCutout)
                return loftedCutout.Type;
            else if (feat is LoftedFlange loftedFlange)
                return loftedFlange.Type;
            else if (feat is LoftedProtrusion loftedProtrusion)
                return loftedProtrusion.Type;
            else if (feat is LoftedSurface loftedSurface)
                return loftedSurface.Type;
            else if (feat is Louver louver)
                return louver.Type;
            else if (feat is MatchFlangeFace matchFlangeFace)
                return matchFlangeFace.Type;
            else if (feat is MidSurface midSurface)
                return midSurface.Type;
            else if (feat is MirrorCopy mirrorCopy)
                return mirrorCopy.Type;
            else if (feat is MirrorCopyGeometry mirrorCopyGeometry)
                return mirrorCopyGeometry.Type;
            else if (feat is MirrorPart mirrorPart)
                return mirrorPart.Type;
            else if (feat is MountingBoss mountingBoss)
                return mountingBoss.Type;
            else if (feat is NormalCutout normalCutout)
                return normalCutout.Type;
            else if (feat is NormalToFaceCutout normalToFaceCutout)
                return normalToFaceCutout.Type;
            else if (feat is NormalToFaceProtrusion normalToFaceProtrusion)
                return normalToFaceProtrusion.Type;
            else if (feat is OffsetEdge offsetEdge)
                return offsetEdge.Type;
            else if (feat is OffsetSurface offsetSurface)
                return offsetSurface.Type;
            else if (feat is PartingSplit partingSplit)
                return partingSplit.Type;
            else if (feat is PartingSurface partingSurface)
                return partingSurface.Type;
            else if (feat is PartLabelWeld partLabelWeld)
                return partLabelWeld.Type;
            else if (feat is Pattern pattern)
                return pattern.Type;
            else if (feat is PatternCopyGeometry patternCopyGeometry)
                return patternCopyGeometry.Type;
            else if (feat is PatternPart patternPart)
                return patternPart.Type;
            else if (feat is ProjectCurve projectCurve)
                return projectCurve.Type;
            else if (feat is Rebend rebend)
                return rebend.Type;
            else if (feat is RecoveredBody recoveredBody)
                return recoveredBody.Type;
            else if (feat is RedefineFace redefineFace)
                return redefineFace.Type;
            else if (feat is RefPlane refPlane)
                throw new Exception($"{feat.GetType()}不支持该属性");
            else if (feat is ReplaceFace replaceFace)
                return replaceFace.Type;
            else if (feat is ResizeBend resizeBend)
                return resizeBend.Type;
            else if (feat is ResizeHole resizeHole)
                return resizeHole.Type;
            else if (feat is ResizeRound resizeRound)
                return resizeRound.Type;
            else if (feat is RevolvedCutout revolvedCutout)
                return revolvedCutout.Type;
            else if (feat is RevolvedProtrusion revolvedProtrusion)
                return revolvedProtrusion.Type;
            else if (feat is RevolvedSurface revolvedSurface)
                return revolvedSurface.Type;
            else if (feat is Rib rib)
                return rib.Type;
            else if (feat is RipEdge ripEdge)
                return ripEdge.Type;
            else if (feat is Round round)
                return round.Type;
            else if (feat is ScaleBodyFeature scaleBodyFeature)
                return scaleBodyFeature.Type;
            else if (feat is Sketch sketch)
                throw new Exception($"{feat.GetType()}不支持该属性");
            else if (feat is Sketch3D sketch3D)
                throw new Exception($"{feat.GetType()}不支持该属性");
            else if (feat is Sketch3DFeature sketch3DFeature)
                return sketch3DFeature.Type;
            else if (feat is Slot slot)
                return slot.Type;
            else if (feat is SolidSweptCutout solidSweptCutout)
                return solidSweptCutout.Type;
            else if (feat is SolidSweptProtrusion solidSweptProtrusion)
                return solidSweptProtrusion.Type;
            else if (feat is Split split)
                return split.Type;
            else if (feat is SplitCurve splitCurve)
                return splitCurve.Type;
            else if (feat is SplitFace splitFace)
                return splitFace.Type;
            else if (feat is StitchSurface stitchSurface)
                return stitchSurface.Type;
            else if (feat is Subtract subtract)
                return subtract.Type;
            else if (feat is SurfaceByBoundary surfaceByBoundary)
                return surfaceByBoundary.Type;
            else if (feat is SweptCutout sweptCutout)
                return sweptCutout.Type;
            else if (feat is SweptProtrusion sweptProtrusion)
                return sweptProtrusion.Type;
            else if (feat is SweptSurface sweptSurface)
                return sweptSurface.Type;
            else if (feat is Tab tab)
                return tab.Type;
            else if (feat is Thicken thicken)
                return thicken.Type;
            else if (feat is Thin thin)
                return thin.Type;
            else if (feat is Thread thread)
                return thread.Type;
            else if (feat is ThinWall thinWall)
                return thinWall.Type;
            else if (feat is ToggleToDesign toggleToDesign)
                //return toggleToDesign.Type;
                throw new Exception($"{feat.GetType()}不支持该属性");
            else if (feat is TrimSurface trimSurface)
                return trimSurface.Type;
            else if (feat is TubeFeature tubeFeature)
                return tubeFeature.Type;
            else if (feat is Unbend unbend)
                return unbend.Type;
            else if (feat is Union union)
                return union.Type;
            else if (feat is UnitedBody unitedBody)
                return unitedBody.Type;
            else if (feat is UserDefinedPattern userDefinedPattern)
                return userDefinedPattern.Type;
            else if (feat is Vent vent)
                return vent.Type;
            else if (feat is WebNetwork webNetwork)
                return webNetwork.Type;
            else if (feat is WireFeature wireFeature)
                return wireFeature.Type;
            else if (feat is WrapSketch wrapSketch)
                return wrapSketch.Type;

            throw new ArgumentException($"{feat.GetType()} not solidEdge feature");
        }

        // 缓存 (Type, PropertyName) -> getter
        private static readonly ConcurrentDictionary<Tuple<Type, string>, Func<object, object>> _getterCache
            = new ConcurrentDictionary<Tuple<Type, string>, Func<object, object>>();

        public static ModelingModeConstants GetModelingModeType(object feat) {
            if (feat == null)
                throw new ArgumentNullException(nameof(feat), "参数feat不能为null");

            var value = GetPropertyValue(feat, "ModelingModeType");
            if (value is ModelingModeConstants mm)
                return mm;

            throw new ArgumentException($"{feat.GetType()} not solidEdge feature");
        }

        public static FeatureTypeConstants GetType(object feat) {
            if (feat == null)
                throw new ArgumentNullException(nameof(feat), "参数feat不能为null");

            // 保留原实现中对某些类型的显式“不支持该属性”行为
            var t = feat.GetType();
            var name = t.Name;
            if (name == nameof(RefPlane) || name == nameof(Sketch) || name == nameof(Sketch3D) || name == nameof(ToggleToDesign))
                throw new Exception($"{t}不支持该属性");

            var value = GetPropertyValue(feat, "Type");
            if (value is FeatureTypeConstants ft)
                return ft;

            throw new ArgumentException($"{feat.GetType()} not solidEdge feature");
        }
        public static string GetName(object feat) {
            if (feat == null)
                throw new ArgumentNullException(nameof(feat), "参数feat不能为null");

            var value = GetPropertyValue(feat, "Name");
            if (value is string featName)
                return featName;

            throw new ArgumentException($"{feat.GetType()} not solidEdge feature");
        }

        private static object GetPropertyValue(object instance, string propertyName) {
            var type = instance.GetType();
            var key = Tuple.Create(type, propertyName);
            var getter = _getterCache.GetOrAdd(key, k => CreateGetter(k.Item1, k.Item2));
            try {
                return getter(instance);
            } catch (TargetInvocationException tie) when (tie.InnerException != null) {
                // 如果底层属性访问抛出，保留原异常信息
                throw tie.InnerException;
            }
        }

        private static Func<object, object> CreateGetter(Type type, string propertyName) {
            // 尝试找到公开实例属性
            var pi = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (pi == null || !pi.CanRead) {
                // 如果没有该属性，按原逻辑把它当成“非 SolidEdge feature”
                return _ => throw new ArgumentException($"{type} not solidEdge feature");
            }

            // 使用表达式树编译一个高效的 getter: (object o) => (object)((T)o).Property
            var param = Expression.Parameter(typeof(object), "o");
            var cast = Expression.Convert(param, type);
            var prop = Expression.Property(cast, pi);
            var convert = Expression.Convert(prop, typeof(object));
            var lambda = Expression.Lambda<Func<object, object>>(convert, param);
            return lambda.Compile();
        }
    }
}

