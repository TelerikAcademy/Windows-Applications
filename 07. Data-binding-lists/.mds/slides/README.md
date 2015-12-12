<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Data-binding List Controls
##  In Windows Universal Applications

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
- The ViewModel
  - DataContext of the View
- Binding List Controls
  - Binding enumerable objects to List controls
- Using Data Templates

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
# The ViewModel
##  The way to abstract the UI from the BL

<!-- attr: { showInPresentation:true, style:'' } -->
# The ViewModel
- The ViewModel is a Model-of-the-View
  - Exposes public properties for View to bind
- ViewModel objects are the objects that do most of the work
  - Except UI
- The ViewModels needs to:
  - Perform data storage operations
  - Contain business logic

<!-- attr: { showInPresentation:true, style:'' } -->
# The ViewModel
- In most cases a ViewModel is a POCO object
  - Nothing special about it
  - Contains little or no XAML/WPF/SL dependencies and references
- Yet the ViewModel cannot be absolutely decoupled from the XAML platform
  - In some cases it needs to inherit from `INotifyPropertyChanged `

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # The ViewModel -->
##  [Demo]()

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Binding List Controls
##  DisplayMemberPath and SelectedValuePath

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Binding List Controls
- List controls like `ListBox` and `ComboBox` display multiple items at a time
  - Can be bound to a collection in the `ViewModel`/`DataContext`
  - Can keep track of the current item
  - When binding the `DisplayMemberPath` specifies the property to be displayed
    - The `SelectedValuePath` specifies the property to be used as selected value (some ID)

<!-- attr: { showInPresentation:true, style:'' } -->
# DisplayMemberPath
- If we want to show every object of the `PhonesStore `class and display one of its properties
  - The `ListBox` class provides the `DisplayMemberPath` property

```cs
<ListBox 
  ItemsSource="{Binding Phones}"
  DisplayMemberPath="Model"
  IsSynchronizedWithCurrentItem = "True"
/>
```

<!-- attr: { showInPresentation:true, style:'' } -->
# SelectedValuePath
- The `ItemsControl` class provides a path to describe the selected value of a piece of data
- Data which is often used when the selection changes or an item is double-clicked

```cs
<ListBox Name="ListBoxPeople" ItemsSource="{Binding}"
  DisplayMemberPath="Name" SelectedValuePath="Age" />
```

```cs
private void ListBoxPeople_SelectionChanged(
  object sender, SelectionChangedEventArgs e)
{
   int index = ListBoxPerson.SelectedIndex;
   if (index < 0) { return; }
   Person item = (Person) ListBoxPerson.SelectedItem;
   int value = (int) ListBoxPerson.SelectedValue; …
}
```

<!-- attr: { class:'slide-section demo', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # DisplayMemberPath and SelectedValuePath -->
##  [Demo]()

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Using Data Templates

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { showInPresentation:true, style:'' } -->
# Using Data Templates
- `Data templates `allow displaying more than one property from a custom class
- A data template is a tree of elements to expand in a particular context
- For example, for each `Phone `object, you might like to be able to concatenate the `Vendor`, `Model `and` Year `together
- This is a logical template that looks like this
  - `Year: Vendor Model`

<!-- attr: { showInPresentation:true, style:'' } -->
# Using Data Templates (2)
- To define this template for items in the `ListBox`, we create a `DataTemplate` element

```cs
<ListBox ItemsSource="{Binding}">
  <ListBox.ItemTemplate>
    <DataTemplate>
      <TextBlock>
        <TextBlock Text="{Binding Year}" />:
        <TextBlock Text="{Binding Vendor}" />
        <TextBlock Text="{Binding Model}" />
      </TextBlock>
    </DataTemplate>
  </ListBox.ItemTemplate>
</ListBox>
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Using Data Templates (2)
- The `ListBox` control has an `ItemTemplate` property
  - Accepts an instance of the `DataTemplate` class
- The `ListBox` shows all the items in the collection

<img class="slide-image" src="imgs/pic.png" style="width:80%; top:10%; left:10%" />

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Using Data Templates -->
##  [Demo]()

<!-- attr: { showInPresentation:true, style:'' } -->
# Data-binding List Controls
- http://academy.telerik.com

<!-- attr: { showInPresentation:true, style:'' } -->
# Exercises
- Write a program to manage a simple system with information about towns and countries. Each country is described by name, language, national flag and list of towns. Each town is described by name, population and country. You should create navigation over the towns and countries. Enable editing the information about them. Don't use `list controls` but only `text boxes `and simple binding
- Rewrite the previous exercise using `list controls`.

