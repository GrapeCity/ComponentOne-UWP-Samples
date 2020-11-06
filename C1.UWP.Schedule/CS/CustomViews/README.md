## CustomViews
#### [Download as zip](https://downgit.github.io/#/home?url=https://github.com/GrapeCity/ComponentOne-UWP-Samples/tree/master/\C1.UWP.Schedule\CS\CustomViews)
____
#### Demonstrates using of adjusted MonthView styles in the C1Scheduler control.
____
themes/SchedulerStyles.xaml ResourceDictionary contains 2 scheduler styles:

* FiveWeekMonthStyle - the exact copy of default MonthView style with VisualTimeSpan set to 35 days;
* ThreeWeekStyle - based on FiveWeekMonthStyle and sets VisualTimeSpan to 21 days.


C1Scheduler.MonthStyle property is set to FiveWeekMonthStyle. It forces C1Scheduler to use FiveWeekMonthStyle instead of default MonthStyle.
It's impossible to use ThreeWeekStyle instead of one of default styles, as in this case navigation to previous/next dates won't honor actual number of displayed dates. 
So, whenever you need to use such custom style, you should either set C1Scheduler.Style property to it in xaml, or change style from code like this:

private void CustomClick(object sender, RoutedEventArgs e)
{
    sched1.ChangeStyle(Application.Current.Resources["ThreeWeekStyle"]);
}

