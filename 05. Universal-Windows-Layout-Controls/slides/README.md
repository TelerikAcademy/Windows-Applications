<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Windows UniversalLayout Controls

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
- What is Container?
  - Containers in XAML
  - StackPanel
  - Canvas
  - Grid

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# What is a Container?
- Containers are things that contain other things
  - Like `divs` and `sections` in HTML
  - They hold other controls / elements
  - Used to build the layout of the application
- Every container is given a space to consume
  - All his children are in this space

<!-- attr: { showInPresentation:true, style:'' } -->
# Containers in XAML
- In XAML containers are called `Panels`
- Three common types of panels
  - Panels with absolute coordinates
  - Panels with stacking order
  - Panels with proportional or with rows/columns
- Absolute coordinates Panels
  - `Canvas`
  - Controls inside the canvas are arranged based on the `Canvas` position and size

<!-- attr: { showInPresentation:true, style:'' } -->
# Containers in XAML (2)
- Stacking Panels
  - `StackPanel`
  - Elements are arranged in a stacking order
    - i.e. first come goes in the beginning
- Proportional Panels
  - `Grid`, `VariableSizedWrapGrid` and `WrapGrid`
  - Arrange the elements in a table-like layout

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# The Canvas Container

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# The Canvas Container
- The `Canvas` is a `layout` `container`
  - An element that holds other elements
  - Elements inside are positioned using fixed coordinates
  - Places elements behind or in front of others (depending on the z-order)
  - Supports size and clipping

<!-- attr: { showInPresentation:true, style:'' } -->
# The Canvas Container (2)
- To position elements inside a `Canvas` use `attached properties`
- Example:
  - Places a `Rectangle `at specific location in a `Canvas`

```cs
<Canvas>
-   <Rectangle `Canvas.Left="30" Canvas.Top="30"`
      Fill="Red" Width="100" Height="100"/>
  …
</Canvas>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# The Canvas Container (3)
- Placing elements behind or in front of others depends on the `z-order`
- The default z-order 
  - Defines which elements are "`on top of`" the other elements
  - Determined by the order in which the children are added to the `Canvas`
- Customize the z-order of any child element using `Canvas.ZIndex` attached property

<!-- attr: { showInPresentation:true, style:'' } -->
# The Canvas Container – Example

```cs
<Canvas Background="White" Height="680">
  <Rectangle Canvas.Left="0" Canvas.Top="0" Fill="Red"
    Width="100" Height="100" Canvas.ZIndex="3`"` />
-   <Rectangle Canvas.Left="20" Canvas.Top="20"
    Fill="Orange" Width="100" Height="100"
    Canvas.ZIndex="2" />
-   <Canvas Canvas.Left="300" Canvas.Top="300"
    Canvas.ZIndex="1">
    <Rectangle Width="120" Height="330" RadiusX="20"
      RadiusY="20" Fill="Black"/>
-     <Ellipse Canvas.Left="10" Canvas.Top="10"
      Width="100" Height="100" Fill="Red"/>
  </Canvas>
</Canvas>
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Customize the Z-order and Multiple Canvas Elements -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# StackPanel

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# StackPanel
- The `StackPanel` arranges the elements in one row/column 
  - Depends on the orientation property
  - If the size of each element is not explicitly set all elements have the same width/height
  - Can set flow orientation
    - Vertical or Horizontal

```cs
<StackPanel>
 <TextBlock Text="Text" Background="Yellow"/>
 <TextBlock Text="Text" Background="Blue"/>
</StackPanel>
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # StackPanel -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Grid Panels
##  Grid and UniformGrid

<!-- attr: { showInPresentation:true, style:'' } -->
# Grid
- The most powerful layout container in XAML
  - Everything can be done with `Grid`
    - Sometimes way harder than using `StackPanel`
- Arranges the elements in a table-like layout
  - Predefined number of rows and columns
  - Each element has explicitly set grid row/column
  - Using the attached properties `Grid.Row `and `Grid.Column`
- If no columns/rows are defined, works the like canvas

<!-- attr: { showInPresentation:true, style:'' } -->
# Grid (2)
- Number of Rows is defined by a content property called "`RowDefinitions`"
  - Each row can be set a height
- The same with "`ColumnDefinitions`"

```cs
<Grid.RowDefinitions>
  <RowDefinition Height="50"/>
  <RowDefinition/>
  <RowDefinition/>
</Grid.RowDefinitions>
<Grid.ColumnDefinitions>
  <ColumnDefinition/>
  <ColumnDefinition Width="50"/>
</Grid.ColumnDefinitions>
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Grid (3)
- Each of the elements in a Grid should have a `Grid.Row `and/or `Grid.Column `property set

```cs
<Grid>
…
  <Button Grid.Row="0" Grid.Column="0" Content="{0, 0}"/>
  <Button Grid.Row="0" Grid.Column="1" Content="{0, 1}"/>
  <Button Grid.Row="1" Grid.Column="0" Content="{1, 0}"/>
  <Button Grid.Row="1" Grid.Column="1" Content="{1, 1}"/>
  <Button Grid.Row="2" Grid.Column="0" Content="{2, 0}"/>
  <Button Grid.Row="2" Grid.Column="1" Content="{2, 1}"/>
</Grid>
```

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Grid -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Viewbox

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Viewbox
- `Viewbox `is a container control that scales its content to a specified size
  - Stretches to 
  - Has single child element
  - Can manipulate `Stretch` and `StretchDirection`
- <StackPanel Margin="5" Orientation="Horizontal">
-    <Viewbox MaxWidth="100" MaxHeight="100" Name="vb1">
-       <Image Source="flower.jpg"/>
-    </Viewbox>
-    <Viewbox MaxWidth="200" MaxHeight="200" Name="vb2">
-       <Image Source="flower.jpg"/>
-    </Viewbox>
- </StackPanel>

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# Border Container

<!-- attr: { showInPresentation:true, style:'' } -->
# Border Container
- The `Border` is a special kind of container
  - It can hold only one child element
  - The child element becomes surrounded by a border
- The Border properties for border style
  - `BorderBrush`
  - `BorderThickness`
  - `CornerRadius`

<!-- attr: { showInPresentation:true, style:'' } -->
# XAML Overview
- http://academy.telerik.com 

