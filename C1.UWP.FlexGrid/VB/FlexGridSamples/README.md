## FlexGrid Samples
#### [Download as zip](https://grapecity.github.io/DownGit/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/C1.UWP.FlexGrid/VB/FlexGridSamples)
____
#### Shows the main features in the C1FlexGrid control.
____

* Financial:
C1FlexGrid is a DataGrid control with a lightweight, flexible object model. C1FlexGrid offers many unique features such as unbound mode, sorting, filtering, flexible cell merging, and multi-cell row and column headers.


* CollectionView:
FlexGrid supports C1CollectionView to provide live sorting, filtering and grouping, the features absent in the native CollectionViewSource/ICollectionView implementation. Tap a column header once or twice to sort that column.


* Media Library:
This demo show cases CellFactory interface used for customizing cells. We use custom cells to display images next to the artists, albums, songs, collapse/expand icons, and ratings. We can easily create custom cells by inheriting the ICellFactory interface and providing the FrameworkElement objects used to represent the cells.


* Editing:
The C1FlexGrid control supports Excel-style editing. Just type values into cells and use the enter or arrow keys to move to the next one. Or press F2 and enter full-edit mode, where arrow keys navigate within the editor. Auto-complete and value-mapped columns are also built-in: simply create a ColumnValueConverter and assign it to the columns ValueConverter property and you're done. Transactioned edits are supported too. The Customer class used here implements IEditableObject, so you can undo changes by pressing the Escape key before you move to a new row. (Note: the gray columns are read-only). Note this feature is only supported by mouse and keyboard.


* Unbound:
In addition to working with IEnumerable data sources, the C1FlexGrid also supports an unbound mode, where cell values are stored in the grid itself and are accessed using familiar indexing notation. This demo also shows how you can set up merged multi-cell row and column headers.


* CustomColumns:
The sample shows how you can combine custom columns with regular bound columns. All custom columns are implemented in XAML using the Column.CellTemplate property.


* CellMerging:
Merge adjacent cells by mouse/touch.


* Printing:
Directly output your FlexGrid UI to any printer. The C1FlexGrid control provides a GetPageImages method that beaks up the grid into a list of Visual Elements representing each page in a document which allows for printing.


* YouTube:
Diplays a list of YouTube videos which load on demand when the end of the list is reached.


* Drag-drop Rows and Columns:
The sample shows drag-drop rows and columns when FlexGrid is in unbound mode.Press and hold a row header/column header until it becomes selected. Then drag the row header/column header to the desired location.
