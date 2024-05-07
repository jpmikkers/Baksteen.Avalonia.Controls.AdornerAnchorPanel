
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Layout;
using Avalonia.Utilities;

namespace Baksteen.Avalonia.Controls;

/// <summary>
/// A panel that displays child controls at arbitrary locations defined by fractional anchors.
/// </summary>
public class AdornerAnchorPanel : Panel
{
    /// <summary>
    /// Defines the RootAnchorH attached property.
    /// </summary>
    public static readonly AttachedProperty<double> RootAnchorHProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("RootAnchorH", 0.0);

    /// <summary>
    /// Defines the RootAnchorV attached property.
    /// </summary>
    public static readonly AttachedProperty<double> RootAnchorVProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("RootAnchorV", 0.0);

    /// <summary>
    /// Defines the ChildAnchorH attached property.
    /// </summary>
    public static readonly AttachedProperty<double> ChildAnchorHProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("ChildAnchorH", 0.0);

    /// <summary>
    /// Defines the ChildAnchorV attached property.
    /// </summary>
    public static readonly AttachedProperty<double> ChildAnchorVProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("ChildAnchorV", 0.0);

    /// <summary>
    /// Defines the OffsetH attached property.
    /// </summary>
    public static readonly AttachedProperty<double> OffsetHProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("OffsetH", 0.0);

    /// <summary>
    /// Defines the OffsetV attached property.
    /// </summary>
    public static readonly AttachedProperty<double> OffsetVProperty =
        AvaloniaProperty.RegisterAttached<AdornerAnchorPanel, Control, double>("OffsetV", 0.0);

    /// <summary>
    /// Initializes static members of the <see cref="AdornerAnchorPanel"/> class.
    /// </summary>
    static AdornerAnchorPanel()
    {
        ClipToBoundsProperty.OverrideDefaultValue<AdornerAnchorPanel>(false);
        AffectsParentArrange<AdornerAnchorPanel>(
            RootAnchorHProperty, 
            RootAnchorVProperty, 
            ChildAnchorHProperty, 
            ChildAnchorVProperty,
            OffsetHProperty,
            OffsetVProperty);
    }

    /// <summary>
    /// Gets the value of the RootAnchorH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The control's horizontal root anchor.</returns>
    public static double GetRootAnchorH(AvaloniaObject element)
    {
        return element.GetValue(RootAnchorHProperty);
    }

    /// <summary>
    /// Sets the value of the RootAnchorH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The horizontal root anchor.</param>
    public static void SetRootAnchorH(AvaloniaObject element, double value)
    {
        element.SetValue(RootAnchorHProperty, value);
    }

    /// <summary>
    /// Gets the value of the RootAnchorV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The control's vertical root anchor.</returns>
    public static double GetRootAnchorV(AvaloniaObject element)
    {
        return element.GetValue(RootAnchorVProperty);
    }

    /// <summary>
    /// Sets the value of the RootAnchorV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The vertical root anchor.</param>
    public static void SetRootAnchorV(AvaloniaObject element, double value)
    {
        element.SetValue(RootAnchorVProperty, value);
    }

    /// <summary>
    /// Gets the value of the ChildAnchorH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The control's horizontal anchor.</returns>
    public static double GetChildAnchorH(AvaloniaObject element)
    {
        return element.GetValue(ChildAnchorHProperty);
    }

    /// <summary>
    /// Sets the value of the ChildAnchorH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The horizontal anchor.</param>
    public static void SetChildAnchorH(AvaloniaObject element, double value)
    {
        element.SetValue(ChildAnchorHProperty, value);
    }

    /// <summary>
    /// Gets the value of the ChildAnchorV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The control's vertical anchor.</returns>
    public static double GetChildAnchorV(AvaloniaObject element)
    {
        return element.GetValue(ChildAnchorVProperty);
    }

    /// <summary>
    /// Sets the value of the ChildAnchorV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The vertical anchor.</param>
    public static void SetChildAnchorV(AvaloniaObject element, double value)
    {
        element.SetValue(ChildAnchorVProperty, value);
    }

    /// <summary>
    /// Gets the value of the OffsetH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The horizontal pixel offset between the anchors.</returns>
    public static double GetOffsetH(AvaloniaObject element)
    {
        return element.GetValue(OffsetHProperty);
    }

    /// <summary>
    /// Sets the value of the OffsetH attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The horizontal pixel offset between the anchors.</param>
    public static void SetOffsetH(AvaloniaObject element, double value)
    {
        element.SetValue(OffsetHProperty, value);
    }

    /// <summary>
    /// Gets the value of the OffsetV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <returns>The vertical pixel offset between the anchors.</returns>
    public static double GetOffsetV(AvaloniaObject element)
    {
        return element.GetValue(OffsetVProperty);
    }

    /// <summary>
    /// Sets the value of the OffsetV attached property for a control.
    /// </summary>
    /// <param name="element">The control.</param>
    /// <param name="value">The vertical pixel offset between the anchors.</param>
    public static void SetOffsetV(AvaloniaObject element, double value)
    {
        element.SetValue(OffsetVProperty, value);
    }

    /// <summary>
    /// Measures the control.
    /// </summary>
    /// <param name="availableSize">The available size.</param>
    /// <returns>The desired size of the control.</returns>
    protected override Size MeasureOverride(Size orgAvailableSize)
    {
        var availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);

        foreach(var child in Children)
        {
            child.Measure(availableSize);
        }

        return new Size(
            double.IsPositiveInfinity(orgAvailableSize.Width) ? 0.0 : orgAvailableSize.Width,
            double.IsPositiveInfinity(orgAvailableSize.Height) ? 0.0 : orgAvailableSize.Height);
    }

    private double Interpolate(double from, double to, double progress) => from + (to - from) * progress;

    /// <summary>
    /// Arranges the control's children.
    /// </summary>
    /// <param name="finalSize">The size allocated to the control.</param>
    /// <returns>The space taken.</returns>
    protected override Size ArrangeOverride(Size finalSize)
    {
        foreach(Control child in Children)
        {
            var rootAnchorX = Interpolate(0, finalSize.Width, GetRootAnchorH(child));
            var rootAnchorY = Interpolate(0, finalSize.Height, GetRootAnchorV(child));
            var childAnchorX = Interpolate(0, child.DesiredSize.Width, GetChildAnchorH(child));
            var childAnchorY = Interpolate(0, child.DesiredSize.Height, GetChildAnchorV(child));

            child.Arrange(new Rect(new Point(rootAnchorX - childAnchorX + GetOffsetH(child), rootAnchorY - childAnchorY + GetOffsetV(child)), child.DesiredSize));
        }

        return finalSize;
    }
}
