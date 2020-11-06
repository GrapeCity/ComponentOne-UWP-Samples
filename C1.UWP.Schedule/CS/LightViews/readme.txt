LightViews
-----------------------------------------------------------------------------
Demonstrates using of adjusted styles in the C1Scheduler control.

<pre> 
themes/SchedulerStyles.xaml ResourceDictionary contains a copy of default scheduler styles, where PART_FlipView ItemsControl is excluded from the DayView control template.
That removes ability to swipe DayView horizontally, but makes visual tree lighther and faster to load.
</pre>

<pre> 
themes/DeviceFamily-Mobile/SchedulerStyles.xaml ResourceDictionary includes a copy of default Scheduler styles used on mobile devices. 
The PART_FlipView ItemsControl is excluded from the DayView control template.
</pre>

C1Scheduler's OneDayStyle, WeekStyle, WorkingWeekStyle and MonthStyle properties are set to styles defined in SchedulerStyles.xaml ResourceDictionaries. 
Edit these styles according to your needs if you need further customization.