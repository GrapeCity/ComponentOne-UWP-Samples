## GridTreeView
#### [Download as zip](https://downgit.github.io/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/\C1.UWP.FlexGrid\CS\GridTreeView)
____
#### Shows how you can use the C1FlexGrid to implement a bound hierarchical C1TreeView.
____
The ChildItemsPath property allows you to use the FlexGrid as a bound C1TreeView 
control.

To use it, the data source must contain items that have properties which are 
collections of the same type as the main items.
	
The sample defines a Person class with a Children property that contains 
a list of Person objects (which themselves may have children). 

It then defines a person with a whole family tree under it, and binds this person
to a FlexGrid and to a C1TreeView control.

This is done with the following XAML:

```
        <flexgrid:C1FlexGrid x:Name="_flex" Grid.Column="1" Grid.Row="2" 
            AutoGenerateColumns="False" 
            ChildItemsPath="Children" >
            <flexgrid:C1FlexGrid.Columns>
                <flexgrid:Column x:Uid="/GridTreeViewSamplesLib/Resources/Name" Binding="{Binding Name, Mode=TwoWay}" Width="*" />
                <flexgrid:Column x:Uid="/GridTreeViewSamplesLib/Resources/Children" Binding="{Binding Children.Count}" />
            </flexgrid:C1FlexGrid.Columns>
        </flexgrid:C1FlexGrid>
```
The grid automatically displays each Person that has children as a group row, and each 
person that doesn't have children as a regular row.

The sample also populates a FlexGrid and a C1TreeView to the same data source, to show
how you could do it if you didn't want to use data binding.

Notice that unlike the C1TreeView, the FlexGrid allows you to show multiple columns for each
object, to edit values, and it offers methods such as CollapseGroupsToLevel that allow you 
to control the tree in ways that are not possible using a C1TreeView control.

