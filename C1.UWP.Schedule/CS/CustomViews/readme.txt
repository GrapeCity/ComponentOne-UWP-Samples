CustomViews
-----------------------------------------------------------------------------
Demonstrates using of adjusted MonthView styles in the C1Scheduler control.

<pre> 
themes/SchedulerStyles.xaml ResourceDictionary contains 2 scheduler styles:
- FiveWeekMonthStyle - the exact copy of default MonthView style with VisualTimeSpan set to 35 days;
- ThreeWeekStyle - based on FiveWeekMonthStyle and sets VisualTimeSpan to 21 days.
</pre>

C1Scheduler.MonthStyle property is set to FiveWeekMonthStyle. It forces C1Scheduler to use FiveWeekMonthStyle instead of default MonthStyle.
It's impossible to use ThreeWeekStyle instead of one of default styles, as in this case navigation to previous/next dates won't honor actual number of displayed dates. 
So, whenever you need to use such custom style, you should either set C1Scheduler.Style property to it in xaml, or change style from code like this:

<pre>
private void CustomClick(object sender, RoutedEventArgs e)
{
    sched1.ChangeStyle(Application.Current.Resources["ThreeWeekStyle"]);
}
</pre>