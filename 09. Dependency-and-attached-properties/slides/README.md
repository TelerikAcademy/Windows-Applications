<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Dependency Properties and Attached Properties
##  Attached and Dependency Properties

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents
- Property Elements
- Attached Properties
- Dependency Properties
- Attached Behavior

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Property Elements

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Property Elements
- Not all properties have just a string value
  - Some must be set to an instance of an object
- XAML provide syntax for setting complex property values, called `property elements`
  - Take the form `TypeName.PropertyName `contained inside an `TypeName` element

```cs
<Ellipse>
  <Ellipse.RenderTransform>
    <RotateTransform Angle="45" CenterY="60" />
  </Ellipse.RenderTransform>
</Ellipse>
```
<div class="fragment balloon" style="width:250px; top:60%; left:10%">A property element</div>

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Property Elements -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Content Properties

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Content Properties
- One of the element's properties is default
  - Known as `content property`
  - Typically contains the child elements
- Content properties are used without prefix:

```cs
<Border>
  <TextBox Width="300"/>
</Border>
<!-- Explicit equivalent -->
<Border>
  <Border.Child>
    <TextBox Width="300"/>
  </Border.Child>
</Border>
```
<div class="fragment balloon" style="width:250px; top:60%; left:10%">A content property</div>
<div class="fragment balloon" style="width:250px; top:60%; left:10%">A property element</div>

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Dependency Object

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Object
- The `DependencyObject`
  - Represents an object that participates in the dependency property system
  - Enables `WPF` / `SL` `property` `system` services
- The property system's functions:
  - Compute the values of properties
  - Provide system notification about values that have changed
- `DependencyObject` as a base class enables objects to use Dependency Properties

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Object (2)
- `DependencyObject` has the following members:
  - `Get`, `Set`, and `Clear` methods for values of any dependency properties
  - Metadata, coerce value support, property changed notification
  - Override callbacks for dependency properties or attached properties
- `DependencyObject` class facilitates the per-owner property metadata for a dependency property

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Dependency Properties
##  Dependencies

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Properties
- Silverlight, WPF and WinRT provide a set of services that can be used to extend the functionality of a CLR property
  - These services are typically referred to as the Silverlight / WPF/WinRT property system
- Dependency Property is a property that is backed by the SL/WPF property system

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Properties (2)
- Dependency properties are typically exposed as CLR properties
  - At a basic level, you could interact with these properties directly 
  - May never find out they are dependency properties
- Better to know if a property is Dependency or CLR
  - Can use the advantages of the dependency properties

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Properties (3)
- The purpose of dependency properties is to provide a way to compute the value of a property based on the value of other inputs
  - Can be implemented to provide callbacks to propagate changes to other properties
  - Provide two-way data binding with UI controls

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Dependency Properties -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Attached Properties
##  How to set properties from another place

<!-- attr: { showInPresentation:true, style:'' } -->
# Attached Properties
- An attached property is intended to be used as a type of global property that is settable on any object
- In WPF and Silverlight attached properties are defined as dependency properties 
  - They don't have the wrapper property
- Examples of Attached Properties
  - Grid.Row, Grid.Column, Grid.RowSpan
  - Canvas.Top, Canvas.Left, Canvas.Bottom

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Attached Properties -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Creating and Registering Dependency Properties

<!-- attr: { showInPresentation:true, style:'' } -->
# Custom Dependency Properties
- DependencyProperties must be registered in the Property System
  - Done by the static method `DependencyProperty.Register()`
  - The Register() takes few parameters
    - Name of the property - `string`
    - The object type of the property - `Type`
    - The type that the property belongs to - mostly UserControl

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Custom Dependency Properties
- Dependency property can be registered using the following template
  - or using code snippet `propdp`
- public static readonly 
-   DependencyProperty ScrollValueProperty =
-     DependencyProperty.Register(
-        "ScrollValue", 
-        typeof(double), 
-        typeof(UserControl),
-        null);
<div class="fragment balloon" style="width:250px; top:60%; left:10%">Dependency Property's instance is always readonly</div>
<div class="fragment balloon" style="width:250px; top:60%; left:10%">The name of the Dependency Property</div>
<div class="fragment balloon" style="width:250px; top:60%; left:10%">Registration to the Property System</div>

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Property Registration
- Two Register Methods:
  - `Register(String, Type, Type)`
    - Registers a dependency property with the specified property name, property type, and owner type
  - `Register(String, Type, Type, PropertyMetadata)`
    - Add Property metadata
    - Default value or Callback for Property changes

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Property Wrapper
- After the registration of the `Dependency Property` it needs wrapper
  - Used to make it look like plain old CLR Property
- `DependencyObject` has two methods used for the wrapping of dependency properties
  - `SetValue(DependenyProperty, value)`
  - `GetValue(DependenyProperty)`
- public double ScrollValue
- {
-    get { return (double)GetValue(ScrollValueProperty); }
-    set { SetValue(ScrollValueProperty , value); }
- }

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Creating and Registering Dependency Properties -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Creating and Registering Attached Properties
##  How to make attached properties?

<!-- attr: { showInPresentation:true, style:'' } -->
# Custom Attached Properties
- The registration of attached properties is a little different than DependencyProperties
  - Has a code snippet `propa`
- public static Thickness GetMargin(DependencyObject obj)
- {
-    return (Thickness)obj.GetValue(MarginProperty);
- }
- public static void SetMargin(DependencyObject obj, Thickness val)
- {
-    obj.SetValue(MarginProperty, val);
- }
- public static readonly DependencyProperty MarginProperty =
-         DependencyProperty.RegisterAttached("Margin",
-           typeof(Thickness), typeof(ContentMargin), 
-            new FrameworkPropertyMetadata(default(Thickness), 
-               new PropertyChangedCallback(OnPropertyChanged)));

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Custom Dependency and Attached Properties -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Attached Behavior
##  The real usage of Attached Properties

<!-- attr: { showInPresentation:true, style:'' } -->
# Attached Behavior
- Attached behavior is behavior that does not exist on the control by default
  - i.e. binding a command to a `TextBlock `
    - `TextBlock `does not have a property `Command`
- Attached Behavior is done using Attached Properties
  - Create an Attach Property that accepts Command

<!-- attr: { showInPresentation:true, style:'' } -->
# Attached Behavir: Sample
- Creating a way to bind a command to the MouseLeftButtonDown event
- public static ICommand GetClick(DependencyObject obj) {…}
- public static void SetClick(DependencyObject obj,
-                             Icommand value) {…}
- public static readonly DependencyProperty ClickProperty =
-             DependencyProperty.RegisterAttached("Click",
-                 typeof(ICommand),
-                 typeof(CommandsBehavior),
-                 new PropertyMetadata(ExecuteClickCommand));
- <TextBlock commandBehavior:CommandsBehavior.Click="{Binding Click}"
-             Text="Click" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Attached Behavior -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Dependency Properties and Attached Properties
- http://academy.telerik.com 

