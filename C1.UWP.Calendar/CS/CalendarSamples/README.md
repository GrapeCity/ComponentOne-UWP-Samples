## C1Calendar_Demo
#### [Download as zip](https://grapecity.github.io/DownGit/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/C1.UWP.Calendar/CS/CalendarSamples)
____
#### Shows the key features of the C1Calendar control.
____
Points of interest:

1) Navigation and selection:

* navigate C1Calendar by drag, flicks, with mouse wheel or using navigation buttons;
* tap or mouse click to select single day;
* tap or hold and then slide finger to select multiple days.

2) Customizing C1Calendar appearance:

* use Clear Style properties to alter common brushes;
* use custom DataTemplateSelector implementations to alter individual day and day of week appearance based on date,
      day of week or other DaySlot and DayOfWeekSlot properties. In your C1DataTemplateSelector implementation you can 
	  place arbitrary content into DaySlot.Tag property and display it in the custom DataTemplate.

3) Performance tip:

* when you do multiple changes to the C1Calendar.SelectedDates or C1Calendar.BoldedDates collections, always enclose such changes
      into collection.BeginUpdate() and collection.EndUpdate() method calls. 

4) Binding to custom data:

* C1Calendar.DataSource, StartTimePath and EndTimePath allows to bind calendar to the collection of custom business objects;
* if data binding is set, the C1Calendar control collects data objects for individual days.
      Then, it updates the BoldedDates list and puts collection of objects for the each bolded day
      to the corresponding DaySlot.DataSource property. Applications can use data in the DaySlot.DataSource property as a binding source in the custom DataTemplates.
