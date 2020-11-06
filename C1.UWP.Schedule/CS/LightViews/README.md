## LightViews
#### [Download as zip](https://downgit.github.io/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/C1.UWP.Schedule/CS/LightViews)
____
#### Demonstrates using of adjusted styles in the C1Scheduler control.
____
themes/SchedulerStyles.xaml ResourceDictionary contains a copy of default scheduler styles, where PART_FlipView ItemsControl is excluded from the DayView control template.
That removes ability to swipe DayView horizontally, but makes visual tree lighther and faster to load.


themes/DeviceFamily-Mobile/SchedulerStyles.xaml ResourceDictionary includes a copy of default Scheduler styles used on mobile devices. 
The PART_FlipView ItemsControl is excluded from the DayView control template.


C1Scheduler's OneDayStyle, WeekStyle, WorkingWeekStyle and MonthStyle properties are set to styles defined in SchedulerStyles.xaml ResourceDictionaries. 
Edit these styles according to your needs if you need further customization.
