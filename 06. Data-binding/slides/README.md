<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true } -->

# Data-binding
##  In Universal Windows Applications

<!-- attr: {showInPresentation: true} -->
# Table of Contents

- Why We Need Data-binding?
- Simple Binding
  - Binding a Control Property to Object Property
- Data Contexts
- Binding Class and its Properties
- Binding Control to Another Control
- Value Conversion
- Using Relative Sources
- Using Update Source Triggers

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # What is Data-binding?
##  And why we need it? -->

<!-- attr: {showInPresentation: true} -->
# What is Data-binding?

- The purpose of most applications is to:
  - **Display data** to users
  - Let them **edit that data**
- Developers' job is:
  - **Bring the data** from a variety of sources
  - **Expose the data** in object, hierarchical, or relational format
- With the XAML Data-binding engine, you get **more features** with **less code**

<!-- attr: {showInPresentation: true, style: 'font-size: 0.95em' } -->
<!-- # What is Data-binding? -->

- Data-binding is pulling information out of an object into another object or property
  - Data-binding means **automatically change** the value of a property when the value of **another property is changed**
- Many Windows applications are all about data
- Data-binding is a top concern in a user interface technologies like Windows Phone and Windows Store
- UWP and XAML provide very powerful Data-binding mechanisms

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Simple Binding
##  Binding UI component to a backing object

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Simple Binding

- Binding in XAML is **the act of registering two properties** with the **Data-binding engine**
  - Letting the engine keep them **synchronized**
- The synchronization and conversion are duties of the Data-binding engine

<!-- attr: {showInPresentation: true, hasScriptWrapper: true, style: 'font-size:0.9em'} -->
# Simple Binding
- Binding a property to a data source property:
- The **shorthand** binding syntax:

```xml
<TextBox Text="{Binding Path=SomeName}" />
```

- Binding between the `Text` property of the `TextBox` and an object called `SomeName`
  - `SomeName` is a property of some object to be named later

```xml
<TextBox ...>
  <TextBox.Text>
    <Binding Path="SomeName" />
  </TextBox.Text>
</TextBox>
```

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
# Data Contexts
##  The backing objects

<!-- attr: {showInPresentation: true} -->
# Data Contexts

- In XAML every `FrameworkElement` and every `FrameworkContentElement` has a `DataContext` property
  - `DataContext` is an object used as **data source** during the binding, addressed by binding `Path`
- If you don’t specify a `Source` property
  - The XAML binding engine goes up the element tree in searching of a `DataContext`

<!-- attr: {showInPresentation: true, hasScriptWrapper: true} -->
<!-- # Data Contexts -->
- Two controls with the same logical parent can bind to the same data source
- Providing a `DataContext` value for both of the text box controls

```xml
<!-- DataContextWindow.xaml -->
<Grid Name="gridMain">
  <TextBlock>Name: </TextBlock>
  <TextBox Text="{Binding Path=Name}" />
  <TextBlock>Age:</TextBlock>
  <TextBox Text="{Binding Path=Age}" />
  <Button Name="ButtonBirthday" Content="Birthday!" />
</Grid>
```

<!-- attr: {showInPresentation: true} -->
<!-- # Data Contexts -->
- Setting an object as a value of the grid’s `DataContext` property in the `MainPage` constructor:

```cs
public partial class MainPage : Page
{
  public MainPage()
  {
    this.InitializeComponent();
    this.gridMain.DataContext = new Person("John", 19);
  }
}
```

<!-- attr: { class:'slide-section demo', showInPresentation:true} -->
<!-- # Data Contexts -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Binding to UI Components Together
##  Binding a property of a property of a component to other component -->

<!-- attr: {hasScriptWrapper: true} -->
# Binding to Other Controls

- XAML provides binding of one element’s property to another element’s property
- The button’s foreground brush will always follow foreground brush’s color of the age `TextBox`

```xml
<TextBox Name="ageTextBox" Foreground="Red"/>
<Button Foreground="{Binding ForeGround,
                             ElementName= ageTextBox}"
        Content="Birthday" />
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Binding to Other Controls -->
##  [Demo]()


<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # The Binding Class
##  And its properties -->

<!-- attr: {hasScriptWrapper: true} -->
# The Binding Class

- A more full-featured binding example
- This features are represent in `Binding` class
  - `Converter` - convert values back and forth from the data source
  - `ConverterParameter` - parameter passed to the `IValueConverter` methods during the conversion

```xml
<TextBox Foreground="{Binding Path=Age, Mode=OneWay,
                     Source={StaticResource Tom},
                     Converter={StaticResource ageConverter}}" />
```

<!-- attr: {showInPresentation: true} -->
<!-- # The Binding Class -->
- More `Binding` class properties
  - `ElementName` - used when the source of the data is a UI element as well as the target
  - `Mode` - has values `TwoWay`, `OneWay`, `OneTime` or `Default`
  - `Path` - path to the data in the data source object
  - `Source` - a reference to the data source

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
<!-- # The Binding Class -->
- The binding target can be any XAML element
  - Only allowed to bind to the element’s dependency properties
- The `TextBox` control is the `binding target`
- Object that provides the data is the `binding source`

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true } -->
<!-- # Value Conversion
##  How to bind `Foreground` to an integer? -->

<!-- attr: {hasScriptWrapper: true} -->
# Value Conversion

- In the previous example we might decide that anyone **over age 25 is hot**
  - Should be marked in the UI as red
- Binding to a non-Text property
- Bound the age text box’s `Text` property to the `Person` object’s `Age` property

```xml
<TextBox Text="{Binding Path=Age}"
         Foreground="{Binding Path=Age, …}" … />
```

<!-- attr: {showInPresentation: true} -->
<!-- # Value Conversion -->
- How to bind the `Foreground` property of the text box to `Age` property on the `Person` object?
  - The `Age` is of type `Int32` and `Foreground` is of type `Brush`
  - Mapping from `Int32` to `Brush` needs to be applied to the data-binding from `Age` to `Foreground`
  - That’s the job of a `ValueConverter`

<!-- attr: {showInPresentation: true} -->
<!-- # Value Conversion -->
- A value converter is an implementation of the `IValueConverter` interface
  - `Convert()` - converting from the source data to the target UI data
  - `ConvertBack()` - convert back from the UI data to the source data

<!-- attr: {showInPresentation: true} -->
<!-- # Value Conversion -->
- Converter `Int32` -> `Brush`

```cs
public class AgeToForegroundConverter : IValueConverter
{
  public object Convert(object value, Type targetType, …)
  {
    if (targetType != typeof(Brush))
    {
      return null;
    }

    int age = int.Parse(value.ToString());
    var color = (age > 25)
        ? Colors.Red
        : Colors.Black;
    return new SolidColorBrush(color);
  }
}
```

<!-- attr: {showInPresentation: true, hasScriptWrapper: true} -->
<!-- # Value Conversion -->
- Creating an instance of the converter class in the XAML and using it:

```xml
<Page …
    xmlns:local="clr-namespace:ValueConverters"
    xmlns:helpers="clr-namespace:ValueConverters.Helpers">
  <Page.Resources>
    <local:Person x:Key="Tom" … />
    <helpers:AgeToForegroundConverter x:Key="ageConverter"/>
  </Page.Resources>
  <Grid DataContext="{StaticResource Tom}"> …
    <TextBox Text="{Binding Path=Age}"
             Foreground="{Binding Age, Converter= {StaticResource ageConverter}}" />
    <Button Foreground="{Binding Foreground, ElementName= ageTextBox}"
            Content="Birthday" />
  </Grid>
</Page>
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Value Conversion -->
##  [Demo]()


<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Binding Path Syntax
##  What else can we do with data-binding? -->

# Binding Path Syntax

- When you use `Path= Something` in a `Binding` statement, the `Something` can be in a number of formats
  - `Path=Property` - bind to the property of the current object (`Path=Age`)
  - `Path=(OwnerType.AttachedProperty)` - bind to an attached dependency property (`Path=(Validation.HasError)`)
  - `Path=Property.SubProperty` - bind to a subproperty (`Path=Name.Length`)

<!-- attr: {showInPresentation: true} -->
<!-- # Binding Path Syntax
- Other formats -->
  - `Path=Property[n]` - bind to an indexer (`Path=Names[0]`)
  - Path=Property/Property - master-detail binding (`Path=Customers/Orders`)
  - `Path=(OwnerType.AttachedProperty)[n].SubProperty` - bind to a mixture of properties, subproperties, and indexers
    - `Path=(Validation.Errors)[0].ErrorContent)`

<!-- section start -->

<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true } -->
<!-- # Update Source Triggers
##  When to update the binding? -->

<!-- attr: {hasScriptWrapper: true} -->
# Update Source Triggers

- Binding can happen immediately when the control state changes
- Using the `UpdateSourceTrigger` property on the `Binding` object

```xml
<TextBox Text="{Binding Age,
                UpdateSourceTrigger= PropertyChanged}" />
```

<!-- attr: {showInPresentation: true} -->
<!-- # Update Source Triggers -->
- `UpdateSourceTrigger` values
  - `Default` - updates "naturally" based on the target control
  - `PropertyChanged` - updates the source immediately
  - `Explicit` - when `BindingExpression. UpdateSource()` is explicitly called

<!-- attr: {class: 'slide-section', showInPresentation: true} -->
# Data-binding
## Questions?
http://academy.telerik.com
